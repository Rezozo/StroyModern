using StroyModern.provider;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class ProductForm : Form
    {
        private ProductProvider productProvider;
        private List<Product> productList;
        private List<string> typeList;
        private const int itemsPerPage = 5;
        private int currentPage = 1;
        private int offset;
        private int limit;
        private int totalPages;
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
            productList = new List<Product>();
            searchTxt.Text = "Введите для поиска";
            searchTxt.ForeColor = Color.Gray;
            searchTxt.Multiline = false;
            searchTxt.AutoSize = false;
            searchTxt.Height = 35;


        }

    }
}
