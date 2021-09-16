using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InventoryWebApp.Helpper;
using InventoryWebApp.Models;

namespace InventoryWebApp.Controllers
{
    public class ProductController : Controller
    {
        private const string URLAPI = "Product";
        private HttpClient client = null;

        public ProductController()
        {
            client = ConnectionToAPIHelpper.GetInstance.ClientInstance;
        }
        // GET: Product
        public ActionResult Index()
        {
            try
            {

                HttpResponseMessage message = client.GetAsync(URLAPI).Result;

                IEnumerable<Product> datos = message.Content.ReadAsAsync<IEnumerable<Product>>().Result;

                return View(datos);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet, ActionName("InsertUpdate")]
        public ActionResult InsertUpdate(int id = 0)
        {
            if (id > 0)
            {
                var dato = client.GetAsync(string.Concat(URLAPI, "/", id.ToString())).Result;
                var result = dato.Content.ReadAsAsync<Product>().Result;
                return View(result);
            }
            return View(new Product());
        }

        [HttpPost, ActionName("InsertUpdate")]
        public ActionResult InsertUpdate(Product _product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_product);
                }

                HttpResponseMessage message = null;

                if (_product.InstanceId > 0)
                {
                    message = client.PutAsJsonAsync(string.Concat(URLAPI, "/", _product.InstanceId.ToString()), _product).Result;

                }
                else
                {
                    message = client.PostAsJsonAsync(URLAPI, _product).Result;

                }

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                throw new Exception(message.IsSuccessStatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage message = client.DeleteAsync(string.Concat(URLAPI, "/", id.ToString())).Result;

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}