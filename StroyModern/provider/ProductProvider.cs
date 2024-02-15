using Npgsql;
using System.Collections.Generic;
using System;

namespace StroyModern.provider
{
    public class ProductProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=mdb;User Id=postgres;Password=0987");


        public List<Product> GetAllProducts()
        {
            connection.Open();

            string commandBase = "SELECT p.id, p.article, p.title, p.description, p.production_shop_number, p.cost, tp.title as type, p.image FROM products p " +
                "INNER JOIN type_of_product tp ON tp.id = p.type_id";

            var command = new NpgsqlCommand(commandBase, connection);

            var reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product();
                product.Id = (int)reader["id"];
                product.Title = (string)reader["name_t"];
                product.Cost = (decimal)reader["prise"];
                product.Article = (string)reader["articul"];
                product.ProductShopNumber = (int)reader["production_shop_number"];
                product.Type = (string)reader["type"];
                if (reader["photo"] != DBNull.Value)
                {
                    product.Image = (string)reader["photo"];
                }
                if (reader["quantity"] != DBNull.Value)
                {
                    product.Quantity = (int)reader["quantity"];
                }
                products.Add(product);
            }
            reader.Close();
            connection.Close();
            return products;
        }

        public List<string> GetAllTypes()
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT t.title FROM type_of_product t", connection);
            var reader = command.ExecuteReader();

            List<string> types = new List<string>();

            while (reader.Read())
            {
                types.Add((string)reader["title"]);
            }

            reader.Close();
            connection.Close();

            return types;
        }
    }
}
