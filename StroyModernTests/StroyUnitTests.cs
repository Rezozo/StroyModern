using Microsoft.VisualStudio.TestTools.UnitTesting;
using StroyModern;
using StroyModern.model;
using StroyModern.provider;
using System.Collections.Generic;

namespace StroyModernTests 
{
    [TestClass]
    public class StroyUnitTests
    {
        private UserProvider userProvider;
        private OrderProvider orderProvider;
        private ProductProvider productProvider;

        [TestInitialize]
        public void Init()
        {
            userProvider = new UserProvider();
            orderProvider = new OrderProvider();
            productProvider = new ProductProvider();
        }

        [TestMethod]
        public void TC_isValidUser_1()
        {
            string expectedRole = "Администратор";
            string actualRole = userProvider.isValidUser("admin", "1234");

            Assert.AreEqual(expectedRole, actualRole);

            string expectedRole2 = "Менеджер";
            string actualRole2 = userProvider.isValidUser("manager", "1234");
            Assert.AreEqual(expectedRole2, actualRole2);
        }

        [TestMethod]
        public void TC_deleteUser_1()
        {
            userProvider.DeleteUser(100);
            string expectedRole = "";
            string actualRole = userProvider.isValidUser("user", "1234");
            Assert.AreEqual(expectedRole, actualRole);
        }

        [TestMethod]
        public void TC_updateOrder_1()
        {
            string fullName = "Яков Аким Абдулаевич";
            string address = "ул. Заморская, д.25, кв.43";
            orderProvider.UpdateOrder(fullName, address, 2);

            Orders order = orderProvider.GetAllOrderInfo(2);
            Assert.IsNotNull(order);
            Assert.AreEqual(fullName, order.FullName);
            Assert.AreEqual(address, order.Address);
        }

        [TestMethod]
        public void TC_createProduct_1()
        {
            Product product = new Product();
            product.Title = "Цемент";
            product.Cost = 500;
            product.Article = "1298473285746";
            product.Image = "\\Resources\\цемент.jpg";
            product.Quantity = 200;
            product.ProductShopNumber = 123;
            product.Type = "Строительные материалы";

            int id = productProvider.InsertProduct(product);

            Product findedProduct = productProvider.GetById(id);
            Assert.IsNotNull(findedProduct);
            Assert.AreEqual(product.Title, findedProduct.Title);
            Assert.AreEqual(product.Cost, findedProduct.Cost);
            Assert.AreEqual(product.Article, findedProduct.Article);
            Assert.AreEqual(product.Quantity, findedProduct.Quantity);
            Assert.AreEqual(product.ProductShopNumber, findedProduct.ProductShopNumber);
            Assert.AreEqual(product.Type, findedProduct.Type);
        }

        [TestMethod]
        public void TC_getAllTypes_1()
        {
            List<string> types = productProvider.GetAllTypes();
            Assert.IsNotNull(types);
            Assert.AreNotEqual(0, types.Count);
        }
    }
}
