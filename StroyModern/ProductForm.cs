using StroyModern.provider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class ProductForm : Form
    {
        private ProductProvider productProvider;
        public List<Product> productList = new List<Product>();
        private List<string> typeList = new List<string>();
        private const int itemsPerPage = 5;
        private int currentPage = 1;
        private int offset;
        private int limit;
        private int totalPages;
        public int OrderId { get; set; } = 0;
        public string LoginLabel
        {
            get { return loginLbl.Text; }
            set { loginLbl.Text = value; }
        }

        public string UserRole { get; set; } = "";

        public ProductForm()
        {
            InitializeComponent();
            productProvider = new ProductProvider();
            productList = productProvider.GetAllProducts();
            typeList = productProvider.GetAllTypes();
            searchTxt.Text = "Введите для поиска";
            searchTxt.ForeColor = Color.Gray;
            searchTxt.Multiline = false;
            searchTxt.AutoSize = false;
            searchTxt.Height = 35;

            string[] typeArray = new string[typeList.Count];
            typeList.CopyTo(typeArray, 0);
            filterBox.Items.Add("Все типы");
            filterBox.Items.AddRange(typeArray);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            ToolStrip toolStrip = new ToolStrip();

            if (UserRole == "Администратор")
            {
                ToolStripLabel adminLabel = new ToolStripLabel("Админка");
                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                ToolStripButton userListButton = new ToolStripButton("Перейти к списку пользователей");
                ToolStripButton addProductButton = new ToolStripButton("Добавить товар");
                ToolStripButton orderList = new ToolStripButton("Перейти к списку заказов");
                ToolStripButton sendEmail = new ToolStripButton("Сделать рассылку");

                userListButton.Click += (s, args) =>
                {
                    UserListForm userListForm = new UserListForm();
                    userListForm.ShowDialog();
                };
                addProductButton.Click += (s, args) =>
                {
                    UpdateProductForm updateProductForm = new UpdateProductForm(this);
                    updateProductForm.ShowDialog();
                };
                orderList.Click += (s, args) =>
                {
                    AllOrdersForm allOrdersForm = new AllOrdersForm();
                    allOrdersForm.ShowDialog();
                };
                sendEmail.Click += (s, args) =>
                {
                    MailMessage message = new MailMessage("aleks.ivka@yandex.ru", "aleks.ivka@yandex.ru");

                    message.Subject = "Акция на нашем магазине!";
                    message.Body = "Уважаемый клиент! Только 24 февраля вся продукция со скидкой – 20%, при указании кодового слова «Дэмоэкзамен 2024».";

                    SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
                    smtpClient.Credentials = new NetworkCredential("aleks.ivka@yandex.ru", "123"); 
                    smtpClient.EnableSsl = true;

                    try
                    {
                        smtpClient.Send(message);
                        MessageBox.Show("Письмо успешно отправлено.");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при отправке письма. Попробуйте позже снова");
                    }
                };

                toolStrip.Items.Add(adminLabel);
                toolStrip.Items.Add(toolStripSeparator);
                toolStrip.Items.Add(userListButton);
                toolStrip.Items.Add(addProductButton);
                toolStrip.Items.Add(orderList);
                toolStrip.Items.Add(sendEmail);
            }
            else
            {
                ToolStripLabel managerLabel = new ToolStripLabel("Создание заказа");
                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                ToolStripButton createOrder = new ToolStripButton("Сформировать заказ");

                createOrder.Click += (s, args) =>
                {
                    CreateOrderForm orderForm = new CreateOrderForm(this);
                    orderForm.OrderId = OrderId;
                    orderForm.ShowDialog();
                };

                toolStrip.Items.Add(managerLabel);
                toolStrip.Items.Add(toolStripSeparator);
                toolStrip.Items.Add(createOrder);
            }
            Controls.Add(toolStrip);

            DisplayPage(currentPage, null, null, null);
        }

        public void RefreshProducts()
        {
            productList = productProvider.GetAllProducts();
            DisplayPage(1, null, null, null);
        }

        private void DisplayPage(int page, string text, string sorter, string filter)
        {
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelPagination.Controls.Clear();

            offset = (page - 1) * itemsPerPage;
            limit = itemsPerPage;

            var filteredProducts = productList;

            if (!string.IsNullOrEmpty(text) && text != "Введите для поиска")
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Title.Contains(text))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(sorter) && sorter != "Сортировка")
            {
                switch (sorter)
                {
                    case "По наименованию (по возрастанию)":
                        filteredProducts = filteredProducts.OrderBy(p => p.Title).ToList();
                        break;
                    case "По наименованию (по убыванию)":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Title).ToList();
                        break;
                    case "По номеру производственного цеха (по возрастанию)":
                        filteredProducts = filteredProducts.OrderBy(p => p.ProductShopNumber).ToList();
                        break;
                    case "По номеру производственного цеха (по убыванию)":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.ProductShopNumber).ToList();
                        break;
                    case "По стоимости (по возрастанию)":
                        filteredProducts = filteredProducts.OrderBy(p => p.Cost).ToList();
                        break;
                    case "По стоимости (по убыванию)":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Cost).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter) && filter != "Фильтрация" && filter != "Все типы")
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Type.Equals(filter))
                    .ToList();
            }

            int resultCount = filteredProducts.Count;
            filteredProducts = filteredProducts.Skip(offset).Take(limit).ToList();

            DisplayProduct(filteredProducts);
            DisplayPagination(resultCount);
        }

        private void DisplayProduct(List<Product> product)
        {
            ProductControl[] productControls = new ProductControl[product.Count];

            for (int i = 0; i < product.Count; i++)
            {
                ProductControl productControl = new ProductControl(this);
                productControl.Product = product[i];
                productControls[i] = productControl;
            }

            flowLayoutPanelProducts.Controls.AddRange(productControls);
        }

        private void DisplayPagination(int count)
        {
            totalPages = (int)Math.Ceiling((double)count / itemsPerPage);

            flowLayoutPanelPagination.RightToLeft = RightToLeft.Yes;

            AddPageButton("<", currentPage + 1);

            for (int i = totalPages; i != 0; i--)
            {
                Label pageButton = new Label
                {
                    Text = i.ToString(),
                    Width = 20,
                    Height = 20,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                if (i == currentPage)
                {
                    pageButton.Font = new System.Drawing.Font(pageButton.Font, FontStyle.Bold | FontStyle.Underline);
                }

                pageButton.Click += (sender, e) =>
                {
                    currentPage = int.Parse(((Label)sender).Text);
                    DisplayPage(currentPage, searchTxt.Text, sortBox.Text, filterBox.Text);
                };

                flowLayoutPanelPagination.Controls.Add(pageButton);
            }

            AddPageButton(">", currentPage - 1);
        }

        private void AddPageButton(string buttonText, int targetPage)
        {
            Label pageButton = new Label
            {
                Text = buttonText,
                Width = 15,
                Height = 15,
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            pageButton.Click += (sender, e) =>
            {
                if (targetPage > 0 && targetPage <= totalPages)
                {
                    currentPage = targetPage;
                    DisplayPage(currentPage, searchTxt.Text, sortBox.Text, filterBox.Text);
                }
            };

            flowLayoutPanelPagination.Controls.Add(pageButton);
        }

        private void searchTxt_Enter(object sender, EventArgs e)
        {
            if (searchTxt.Text.Equals("Введите для поиска"))
            {
                searchTxt.Clear();
                searchTxt.ForeColor = Color.Black;
            }
        }

        private void searchTxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTxt.Text))
            {
                searchTxt.Text = "Введите для поиска";
                searchTxt.ForeColor = Color.Gray;
            }
        }

        private void searchTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            currentPage = 1;
            DisplayPage(currentPage, searchTxt.Text, sortBox.Text, filterBox.Text);
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            DisplayPage(currentPage, searchTxt.Text, sortBox.Text, filterBox.Text);
        }

        private void filterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            DisplayPage(currentPage, searchTxt.Text, sortBox.Text, filterBox.Text);
        }
    }
}
