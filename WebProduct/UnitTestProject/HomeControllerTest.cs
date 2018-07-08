using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebProduct.Controllers;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Reflection;

namespace UnitTestProject
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestLoginGetPostive()
        {
            string UserName = "cnadeem6@gmail.com";
            string Password = "P@ssw0rd";
            var controller = new HomeController();
            HttpContext.Current = FakeHttpContext();
            HttpContext.Current.Session["access_token"] = string.Empty;
            var result = (RedirectToRouteResult)controller.Login(UserName, Password);
            Assert.AreEqual("ViewProduct", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void TestLoginGetNegative()
        {
            string UserName = "cnadeem6@gmail.com";
            string Password = "";
            var controller = new HomeController();
            HttpContext.Current = FakeHttpContext();
            HttpContext.Current.Session["access_token"] = string.Empty;
            var result = (RedirectToRouteResult)controller.Login(UserName, Password);
            Assert.AreEqual("Login", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        
        public static HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://stackoverflow/", "");
            var stringWriter = new StringWriter();
            var httpResponse = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponse);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                    new HttpStaticObjectsCollection(), 10, true,
                                                    HttpCookieMode.AutoDetect,
                                                    SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                        null, CallingConventions.Standard,
                                        new[] { typeof(HttpSessionStateContainer) },
                                        null)
                                .Invoke(new object[] { sessionContainer });

            return httpContext;
        }

    }


}
