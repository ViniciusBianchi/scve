using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCVE.Persistencia;

namespace SCVE.Controllers
{
    public class LoginController : Controller
    {
        DataContext contexto = new DataContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}
