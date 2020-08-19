using Cinema.Web.Models.Customer;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        [Route("/ChairOn/Create")]
        public JsonResult Create(Customer model,out int CusId)
        {
            CustomerResult result = ApiHelper<CustomerResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/Customer/Create",
                                                    model
                                                );
            CusId = result.CusId;
            return Json(new { result });
        }
    }
}
