using Npgsql;
using StroyModern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroyModern.provider
{
    public class OrderProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=mdb;User Id=postgres;Password=0987");
        public List<Orders> GetAllOrders()
        {
            List<Orders> allOrders = new List<Orders>();
            connection.Open();
            var command = new NpgsqlCommand($"SELECT * FROM orders", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Orders orders = new Orders();  
                orders.Id = (int)reader["id"];
                if (reader["full_name"] != DBNull.Value)
                {
                    orders.FullName = (string)reader["full_name"];
                }
                if (reader["address"] != DBNull.Value)
                {
                    orders.Address = (string)reader["address"];
                }
                if ((int)reader["status_id"] == 1)
                {
                    orders.Status = "Новый";
                }
                else
                {
                    orders.Status = "Сформирован";
                }
                allOrders.Add(orders);
            }
            reader.Close();
            connection.Close();



            return allOrders;
        }

        public Orders GetAllOrderInfo(int orderId)
        {
            var orders = new Orders();

            connection.Open();
            var command = new NpgsqlCommand($"SELECT * FROM orders WHERE id = {orderId}", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Id = orderId;
                if (reader["full_name"] != DBNull.Value)
                {
                    orders.FullName = (string)reader["full_name"];
                }
                if (reader["address"] != DBNull.Value)
                {
                    orders.Address = (string)reader["address"];
                }
                if ((int)reader["status_id"] == 1)
                {
                    orders.Status = "Новый";
                } else
                {
                    orders.Status = "Сформирован";
                }
            }
            reader.Close();
            connection.Close();

            connection.Open();
            var command2 = new NpgsqlCommand($"SELECT t.id, t.name_t, tor.count, t.prise, tor.count * t.prise AS total_price " +
                $"FROM tovar_orders tor " +
                $"INNER JOIN tovar t ON t.id = tor.tovar_id " +
                $"WHERE tor.order_id = {orderId}", connection);

            var reader2 = command2.ExecuteReader();
            List<ProductOrder> productOrders = new List<ProductOrder>();
            while (reader2.Read())
            {
                ProductOrder product = new ProductOrder();
                product.Id = (int)reader2[0];
                product.Title = (string)reader2[1];
                product.Count = (int)reader2[2];
                product.Price = (decimal)reader2[3];
                product.TotalPrice = (decimal)reader2[4];
                productOrders.Add(product);
            }
            orders.Products = productOrders;
            reader2.Close();
            connection.Close();
            return orders;
        }

        public int CreateOrder(int productId)
        {
            connection.Open();
            var command = new NpgsqlCommand("INSERT INTO orders VALUES (DEFAULT, null, null, 1) RETURNING id", connection);
            int orderId = (int)command.ExecuteScalar();
            connection.Close();
            AddProduct(productId, orderId);
            return orderId;
        }

        public void UpdateOrder(string fullName, string address, int orderId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"UPDATE orders SET full_name = '{fullName}', address = '{address}', status_id = 2 WHERE id = {orderId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddProduct(int productId, int orderId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"INSERT INTO tovar_orders VALUES ({orderId}, {productId}, 1)", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateProductCount (int productId, int orderId, int count)
        {
            connection.Open();
            var command = new NpgsqlCommand($"UPDATE tovar_orders SET count = {count} WHERE order_id = {orderId} and tovar_id = {productId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public object GetCount(int productId, int orderId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"select count from tovar_orders WHERE order_id = {orderId} AND tovar_id = {productId}", connection);
            object count = command.ExecuteScalar();
            connection.Close();
            return count;
        }

        public void DeleteProductFromOrder(int productId, int orderId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"DELETE FROM tovar_orders WHERE order_id = {orderId} AND tovar_id = {productId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteOrder(int orderId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"DELETE FROM orders WHERE id = {orderId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
