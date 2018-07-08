using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (ProductDBEntities entities = new ProductDBEntities())
            {
                var message = Request.CreateResponse(HttpStatusCode.OK, entities.Products.ToList());
                return message;
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (ProductDBEntities entities = new ProductDBEntities())
            {
                var entity = entities.Products.FirstOrDefault(x => x.ID == id);
                if (entity != null)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK, entity);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        String.Format("Product with ID = {0} not found", id));
                }
            }
        }
    }
}
