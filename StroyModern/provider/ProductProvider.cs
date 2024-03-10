using Npgsql;
using System.Collections.Generic;
using System;

namespace StroyModern.provider
{
    public class ProductProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=mdb;User Id=postgres;Password=0987");

        public void DeleteProduct(int id)
        {
            connection.Open();
            var command = new NpgsqlCommand($"DELETE FROM tovar WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Product> GetAllProducts()
        {
            connection.Open();

            string commandBase = "SELECT p.id, p.articul, p.name_t, p.prise, p.production_shop_number, p.quantity, tp.title as type, p.photo FROM tovar p " +
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

        public Product GetById(int productId)
        {
            connection.Open();
            string commandBase = "SELECT p.id, p.articul, p.name_t, p.prise, p.production_shop_number, p.quantity, tp.title as type, p.photo FROM tovar p " +
                "INNER JOIN type_of_product tp ON tp.id = p.type_id WHERE p.id = " + productId;

            var command = new NpgsqlCommand(commandBase, connection);

            var reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
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
            }
            reader.Close();
            connection.Close();
            return product;
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

        public int GetTypeId(string type)
        {
            connection.Open();
            var command = new NpgsqlCommand($"SELECT id FROM type_of_product WHERE title = '{type}'", connection);
            int id = (int)command.ExecuteScalar();
            connection.Close();
            return id;
        }

        public int InsertProduct(Product product)
        {
            int type = GetTypeId(product.Type);
            connection.Open();
            var command = new NpgsqlCommand($"INSERT INTO tovar VALUES (DEFAULT, '{product.Title}', '{product.Cost}', '{product.Article}', '{product.Image}', {product.Quantity}, " +
                $"{product.ProductShopNumber}, {type}) RETURNING id", connection);
            int id = (int)command.ExecuteScalar();
            connection.Close();
            return id;
        }

        public void UpdateProduct(Product product)
        {
            int type = GetTypeId(product.Type);
            connection.Open();
            var command = new NpgsqlCommand($"UPDATE tovar SET name_t = '{product.Title}', prise = '{product.Cost}', articul = '{product.Article}', photo = '{product.Image}', " +
                $"quantity = {product.Quantity}, production_shop_number = {product.ProductShopNumber}, type_id = {type} WHERE id = {product.Id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
