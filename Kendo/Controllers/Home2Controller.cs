using Kendo.Data;
using Kendo.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kendo.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly AppDbContext _context;

        public Home2Controller(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Grid_Read([DataSourceRequest] DataSourceRequest request)
        {
            var products = _context.Products.ToList();
            return Json(products.ToDataSourceResult(request));
        }

        public JsonResult Grid_Destroy([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productToDelete = _context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                if (productToDelete != null)
                {
                    _context.Products.Remove(productToDelete);
                    _context.SaveChanges();
                }
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult Grid_Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult Grid_Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = _context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                if (productToUpdate != null)
                {
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.UnitPrice = product.UnitPrice;
                    productToUpdate.UnitsInStock = product.UnitsInStock;
                    productToUpdate.Discontinued = product.Discontinued;

                    _context.SaveChanges();
                }
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }




    }
}
