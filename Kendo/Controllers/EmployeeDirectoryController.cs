using Kendo.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Kendo.Models;
using Kendo.Services;
using Kendo.Data;
using Microsoft.AspNetCore.Mvc;




namespace Kendo.Controllers
{
    public class EmployeeDirectoryController : Controller
    {
        private readonly EmployeeDirectoryService _service;

        public EmployeeDirectoryController(EmployeeDirectoryService service)
        {
            _service = service;
        }

        public JsonResult All([DataSourceRequest] DataSourceRequest request)
        {
            var result = _service.GetAll().ToTreeDataSourceResult(
                request,
                e => e.EmployeeId,
                e => e.ReportsTo,
                e => e
            );
            return Json(result);
        }
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(employee);
            }
            return Json(new[] { employee }.ToTreeDataSourceResult(request));
        }

        public JsonResult Update([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                _service.Update(employee);
            }
            return Json(new[] { employee }.ToTreeDataSourceResult(request));
        }

        public JsonResult Destroy([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(employee);
            }
            return Json(new[] { employee }.ToTreeDataSourceResult(request));
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
