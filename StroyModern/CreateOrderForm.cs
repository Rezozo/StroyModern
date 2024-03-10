using StroyModern.model;
using StroyModern.provider;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class CreateOrderForm : Form
    {
        private OrderProvider orderProvider = new OrderProvider();
        public int OrderId { get; set; } 
        private Form parentForm;

        public CreateOrderForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            UpdateOrderProduct();
        }

        private void UpdateOrderProduct()
        {
            Orders orders = orderProvider.GetAllOrderInfo(OrderId);
            if (firstNameTxt.Text.Length == 0)
            {
                if (!string.IsNullOrEmpty(orders.FullName))
                {
                    string[] fullName = orders.FullName.Split(' ');
                    firstNameTxt.Text = fullName[0];
                    lastNameTxt.Text = fullName[1];
                    middleNameTxt.Text = fullName[2];
                    addressTxt.Text = orders.Address;
                }
            }

            if (orders.Status == "Сформирован")
            {
                createOrderBtn.Text = "Сохранить изменения";
            }

            orderView.Rows.Clear();
            foreach (ProductOrder productOrder in orders.Products)
            {
                orderView.Rows.Add(productOrder.Id, productOrder.Title, productOrder.Count, productOrder.Price + "руб.", productOrder.TotalPrice + "руб.");
            }
        }

        private void orderView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = orderView.Rows[e.RowIndex];
                DataGridViewCellCollection cells = row.Cells;

                string count = cells["Count"].Value.ToString();
                if (count.Count(d => char.IsDigit(d)) != count.Length)
                {
                    MessageBox.Show("Неправильно указано количество товара!");
                    return;
                }

                if (int.Parse(count) == 0)
                {
                    DialogResult result = MessageBox.Show("Удалить товар?", "Удаление", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        orderProvider.DeleteProductFromOrder((int)cells["Id"].Value, OrderId);
                    }
                }
                else
                {
                    orderProvider.UpdateProductCount((int)cells["Id"].Value, OrderId, int.Parse(count));
                }

                UpdateOrderProduct();
            } catch
            {
                MessageBox.Show("Такого продукта не существует");
            }
        }

        private void createOrderBtn_Click(object sender, EventArgs e)
        {
            if (orderView.Rows.Count == 0 || string.IsNullOrEmpty(lastNameTxt.Text) || string.IsNullOrEmpty(firstNameTxt.Text) || string.IsNullOrEmpty(addressTxt.Text))
            {
                MessageBox.Show("Заполните все данные корректно");
                return;
            }

            orderProvider.UpdateOrder(firstNameTxt.Text.Trim() + " " + lastNameTxt.Text.Trim() + " " + middleNameTxt.Text.Trim(), addressTxt.Text.Trim(), OrderId);
            try
            {
                ProductForm product = (ProductForm)parentForm;
            } catch { }

            DialogResult result = MessageBox.Show("Выгрузить чек в pdf?", "Выгрузка", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                PrintTicket();
            }

            Hide();
        }

        private void PrintTicket()
        {
            Orders orders = orderProvider.GetAllOrderInfo(OrderId);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Чек №" + orders.Id;
            saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";

            string path;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            } else
            {
                return;
            }

            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += (s, e) =>
            {
                Graphics graphics = e.Graphics;
                Font font = new Font("Times New Roman", 12);
                Font titleFont = new Font("Times New Roman", 16);
                float fontHeight = font.GetHeight();

                float startX = 10;
                float startY = 10;
                float offset = 40;

                graphics.DrawString("Компания ООО", titleFont, Brushes.Black, e.PageBounds.Width - graphics.MeasureString("Компания ООО", font).Width - 100, startY);
                startY += offset;
                graphics.DrawString("\"СтройМодерн\"", titleFont, Brushes.Black, e.PageBounds.Width - graphics.MeasureString("\"СтройМодерн\"", font).Width - 100, startY);
                startY += offset;
                graphics.DrawString("Чек №" + orders.Id, titleFont, Brushes.Black, (e.PageBounds.Width - graphics.MeasureString("\"СтройМодерн\"", font).Width) / 2, startY);
                startY += offset;

                Pen pen = new Pen(Color.Black, 1);
                float currentY = startY;
                graphics.DrawLine(pen, startX, currentY, e.PageBounds.Width - startX, currentY);
                for (int i = 1; i < orderView.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        graphics.DrawLine(pen, startX, startY, startX, currentY + offset);
                        graphics.DrawString(orderView.Columns[i].HeaderText, font, Brushes.Black, startX, currentY);
                    } else
                    {
                        graphics.DrawLine(pen, startX + (i - 1) * 200, startY, startX + (i - 1) * 200, currentY + offset);
                        graphics.DrawString(orderView.Columns[i].HeaderText, font, Brushes.Black, startX + (i - 1) * 200, currentY);
                    }
                }

                graphics.DrawLine(pen, startX, currentY + offset, e.PageBounds.Width - startX, currentY + offset);
                currentY += offset;

                for (int i = 0; i < orderView.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = orderView.Rows[i];
                    for (int j = 1; j < orderView.Columns.Count; j++)
                    {
                        if (j == 1)
                        {
                            graphics.DrawLine(pen, startX, currentY, startX, currentY + offset);
                            graphics.DrawString(row.Cells[j].Value.ToString(), font, Brushes.Black, startX, currentY);
                        }
                        else
                        {
                            graphics.DrawLine(pen, startX + (j - 1) * 200, currentY, startX + (j - 1) * 200, currentY + offset);
                            graphics.DrawString(row.Cells[j].Value.ToString(), font, Brushes.Black, startX + (j - 1) * 200, currentY);
                        }
                    }

                    graphics.DrawLine(pen, startX, currentY, e.PageBounds.Width - startX, currentY);
                    currentY += offset;
                }

                graphics.DrawLine(pen, startX, currentY, e.PageBounds.Width - startX, currentY);
            };

            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = path;
            printDocument.Print();
        }
    }
}
