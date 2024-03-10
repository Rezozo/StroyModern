using System.Collections.Generic;

namespace StroyModern.model
{
    public class Orders
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public List<ProductOrder> Products { get; set; }
        public decimal TotalSum { get; set; }   

        public Orders() { }

        public Orders(int id, string fullName, string address, List<ProductOrder> products)
        {
            Id = id;
            FullName = fullName;
            Address = address;
            Products = products;
        }
    }
}
