using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebProduct;
namespace UnitTestProject
{
    [TestClass]
   public class WebApiCallerTest
    {
        [TestMethod]
        public void TestGetProducts()
        {
            string UserName = "cnadeem6@gmail.com";
            string Password = "P@ssw0rd";
            string result = WebApiCaller.GetUserToken(UserName, Password);
            Product[] products = WebApiCaller.GetProducts(result);
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void TestAuthenticatePositive()
        {
            string UserName = "cnadeem6@gmail.com";
            string Password = "P@ssw0rd";
            string result = WebApiCaller.GetUserToken(UserName,Password);
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestAuthenticateNegative()
        {
            string UserName = "cnadeem6@gmail.com";
            string Password = "P@ssw0rd1";
            string result = WebApiCaller.GetUserToken(UserName, Password);
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
    }
}
