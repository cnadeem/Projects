using System.Web.Mvc;

namespace WebProduct.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string access_token = WebApiCaller.GetUserToken(username, password);

            if (!string.IsNullOrEmpty(access_token))
            {
                System.Web.HttpContext.Current.Session["access_token"] = access_token;
                return RedirectToAction("ViewProduct", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public ActionResult ViewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListProduct()
        {
            if (System.Web.HttpContext.Current.Session["access_token"] != null)
            {
                string token = (string)System.Web.HttpContext.Current.Session["access_token"];
                Product[] products = WebApiCaller.GetProducts(token);
                return View(products);
            }
            else
            {
                return View("ViewProduct");
            }
        }
    }
}