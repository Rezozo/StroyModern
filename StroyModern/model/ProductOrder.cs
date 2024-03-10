using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroyModern.model
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public ProductOrder() { }

        public ProductOrder(int id, string title, int count, decimal price, decimal totalPrice)
        {
            Id = id;
            Title = title;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }   
    }
}
