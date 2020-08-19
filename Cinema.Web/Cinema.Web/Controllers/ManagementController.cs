using Cinema.Web.Models.Room;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class ManagementController : Controller
    {
           public IActionResult Index()
        {
            return View();
        }
    }
}
