using Microsoft.AspNetCore.Mvc;
using Tirth_Gold.Models;
using System.Runtime.Intrinsics.Arm;
using Tirth_Gold.Data;

namespace Tirth_Gold.Controllers
{
    public class AdminController : Controller
    {
        private dbcontext s2;
        public AdminController(dbcontext dbcontext)
        {
            s2 = dbcontext;
        }

        public IActionResult Index()
        {
            IEnumerable<LoginModel> abc = s2.Registers;
            return View(abc);
        }
    }
}
