using StroyModern.provider;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class ProductControl : UserControl
    {
        private ProductProvider provider = new ProductProvider();
        private OrderProvider orderProvider = new OrderProvider();
        public Product Product { get; set; }
        private ProductForm parentForm;

        public ProductControl(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = (ProductForm) parentForm;
        }

        private void ProductControl_Load(object sender, System.EventArgs e)
        {
            string imagePath = "";
            if (string.IsNullOrEmpty(Product.Image))
            {
                imagePath = Application.StartupPath + "\\Resources\\picture.jpg";
            }
            else
            {
                imagePath = Application.StartupPath + Product.Image;
            }

            productImage.Image = new Bitmap(imagePath);
            articleLbl.Text = Product.Article;
            titleLbl.Text = Product.Title;  
            priceLbl.Text += Product.Cost.ToString();

            articleLbl.Click += (s, args) => DrawBarcode(articleLbl.Text);

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem addToOrderItem = new ToolStripMenuItem("Добавить к заказу");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить товар");
            ToolStripMenuItem editItem = new ToolStripMenuItem("Редактировать товар");

            if (parentForm.UserRole.Equals("Администратор"))
            {
                editItem.Click += EditItem_Click;
                deleteItem.Click += DeleteItem_Click;
                contextMenu.Items.Add(editItem);
                contextMenu.Items.Add(deleteItem);
            } else
            {
                addToOrderItem.Click += AddToOrderItem_Click;
                contextMenu.Items.Add(addToOrderItem);
            }
            ContextMenuStrip = contextMenu;

        }

        private void AddToOrderItem_Click(object sender, EventArgs e)
        {
            if (parentForm.OrderId == 0)
            {
                int orderId = orderProvider.CreateOrder(Product.Id);
                parentForm.OrderId = orderId;
            } else
            {
                var count = orderProvider.GetCount(Product.Id, parentForm.OrderId);
                if (count != null)
                {
                    orderProvider.UpdateProductCount(Product.Id, parentForm.OrderId, (int)count + 1);
                } else
                {
                    orderProvider.AddProduct(Product.Id, parentForm.OrderId);
                }
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            provider.DeleteProduct(Product.Id);
            parentForm.RefreshProducts();
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            UpdateProductForm updateForm = new UpdateProductForm(parentForm);
            updateForm.Product = Product;
            updateForm.ShowDialog();
        }

        private void DrawBarcode(string code, int resolution = 20) // resolution - пикселей на миллиметр
        {
            int numberCount = 13; // количество цифр
            float height = 25.93f * resolution; // высота штрих кода
            float lineHeight = 22.85f * resolution; // высота штриха
            float leftOffset = 3.63f * resolution; // свободная зона слева
            float rightOffset = 2.31f * resolution; // свободная зона справа
                                                    //штрихи, которые образуют правый и левый ограничивающие знаки,
                                                    //а также центральный ограничивающий знак должны быть удлинены вниз на 1,65мм
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 2.75f * resolution; // высота цифр
            float lineToFontOffset = 0.165f * resolution; // минимальный размер от верхнего края цифр до нижнего края штрихов
            float lineWidthDelta = 0.15f * resolution; // ширина 0.15*{цифра}
            float lineWidthFull = 1.35f * resolution; // ширина белой полоски при 0 или 0.15*9
            float lineOffset = 0.2f * resolution; // между штрихами должно быть расстояние в 0.2мм

            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset); // ширина штрих-кода

            Bitmap bitmap = new Bitmap((int)width, (int)height); // создание картинки нужных размеров
            Graphics g = Graphics.FromImage(bitmap); // создание графики

            System.Drawing.Font font = new System.Drawing.Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel); // создание шрифта

            StringFormat fontFormat = new StringFormat(); // Центрирование текста
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;

            float x = leftOffset; // позиция рисования по x
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString()); // число из кода
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight); // рисуем штрих
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight); // рамки для буквы
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat); // рисуем букву
                x += lineWidthFull + lineOffset; // смещаем позицию рисования по x


                if (i == 0 || i == numberCount / 2 || i == numberCount - 1) // если это начало, середина или конец кода рисуем разделители
                {
                    for (int j = 0; j < 2; j++) // рисуем 2 линии разделителя
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight); // рисуем длинный штрих
                        x += lineWidthDelta + lineOffset; // смещаем позицию рисования по x
                    }
                }
            }
            MessageForm messageForm = new MessageForm();
            messageForm.barcode = bitmap;
            messageForm.Code = code;
            messageForm.ShowDialog();
        }
    }
}
