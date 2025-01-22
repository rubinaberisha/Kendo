using Kendo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository customerRepository = new CustomerRepository();
       public JsonResult GetAllCustomer()
        {
            var res = customerRepository.GetAllCustomer();
            var data = new
            {
                Items = res,
                TotalCount = res.Count
            };

            return new JsonResult(data);
        }
    }
}
