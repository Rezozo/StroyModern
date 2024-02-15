namespace StroyModern
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string Article { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int ProductShopNumber { get; set; }
        public string Type { get; set; }

        public Product() { }
        public Product(int id, string title, decimal cost, string article, string image, int quantity, int productShopNumber, string type)
        {
            Id = id;
            Title = title;
            Cost = cost;
            Article = article;
            Image = image;
            Quantity = quantity;
            ProductShopNumber = productShopNumber;
            Type = type;
        }
    }
}
