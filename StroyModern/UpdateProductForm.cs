using StroyModern.provider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class UpdateProductForm : Form
    {
        private ProductProvider productProvider;
        public Product Product { get; set; }
        private string savedImageTitle = Application.StartupPath + "\\Resources\\picture.jpg";
        private ProductForm productForm;

        public UpdateProductForm(Form parentForm)
        {
            InitializeComponent();
            productForm = (ProductForm)parentForm;
            productProvider = new ProductProvider();
            List<string> typeList = productProvider.GetAllTypes();
            string[] typeArray = new string[typeList.Count];
            typeList.CopyTo(typeArray, 0);
            typeBox.Items.AddRange(typeArray);
        }

        private void UpdateProductForm_Load(object sender, EventArgs e)
        {
            if (Product != null)
            {
                try
                {
                    productImage.Image = new Bitmap(Application.StartupPath + Product.Image);
                } catch { }
                titleTxt.Text = Product.Title;
                priceTxt.Text = Product.Cost.ToString();
                articleTxt.Text = Product.Article;
                quantityTxt.Text = Product.Quantity.ToString();
                productShopTxt.Text = Product.ProductShopNumber.ToString();
                typeBox.Text = Product.Type.ToString();
            }
        }

        private void productImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    savedImageTitle = fileName;

                    if (Product != null)
                    {
                        Product.Image = "\\Resources\\" + fileName.Split('\\').Last();
                    }

                    productImage.Image = new Bitmap(fileName);
                }
            } catch
            {
                MessageBox.Show("Укажите файл из папки Resources");
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string title = titleTxt.Text;
                string price = priceTxt.Text;
                string article = articleTxt.Text;
                string quantity = quantityTxt.Text;
                string productShop = productShopTxt.Text;
                string type = typeBox.Text;
                if (!ValidateProduct(title, price, article, quantity, productShop, type))
                {
                    return;
                }

                Product newProduct = new Product();
                newProduct.Title = title;
                newProduct.Cost = decimal.Parse(price);
                newProduct.Article = article;
                newProduct.Quantity = int.Parse(quantity);
                newProduct.ProductShopNumber = int.Parse(productShop);
                newProduct.Type = type;
                savedImageTitle = "\\Resources\\" + savedImageTitle.Split('\\').Last();

                if (Product == null)
                {
                    newProduct.Image = savedImageTitle;
                    productProvider.InsertProduct(newProduct);
                }
                else
                {
                    newProduct.Id = Product.Id;
                    newProduct.Image = Product.Image;
                    productProvider.UpdateProduct(newProduct);
                }

                MessageBox.Show("Данные успешно сохранены");
                productForm.RefreshProducts();
                Hide();
            } catch
            {
                MessageBox.Show("Проверьте данные перед сохранением, что-то пошло не так");
            }
        }

        private bool ValidateProduct(string title, string price, string article, string quantity, string productShop, string type)
        {
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Укажите название продукта");
                return false;
            }

            if (!string.IsNullOrEmpty(price))
            {
                try
                {
                    decimal.Parse(price);
                } catch
                {
                    MessageBox.Show("Стоимость должна состоять только из цифр");
                    return false;
                }
            } else
            {
                MessageBox.Show("Укажите стоимость продукта");
                return false;
            }

            if (!string.IsNullOrEmpty(article))
            {
                if (article.Count(char.IsDigit) != 13)
                {
                    MessageBox.Show("Артикул должен состоять только из цифр");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Укажите артикул продукта");
                return false;
            }

            if (!string.IsNullOrEmpty(quantity))
            {
                try
                {
                    int.Parse(quantity);
                }
                catch
                {
                    MessageBox.Show("Количество должено состоять только из цифр");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Укажите количество продукта");
                return false;
            }

            if (!string.IsNullOrEmpty(productShop))
            {
                try
                {
                    int.Parse(productShop);
                }
                catch
                {
                    MessageBox.Show("Номер цеха должен состоять только из цифр");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Укажите номер производственного цеха продукта");
                return false;
            }

            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Укажите тип продукта");
                return false;
            }

            return true;
        }
    }
}
