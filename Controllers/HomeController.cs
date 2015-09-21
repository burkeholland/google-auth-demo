using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Everlive.Sdk.Core;

namespace google_auth_demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SignIn(string token)
        {
            var app = new EverliveApp("5tnum1NuePyeHNwk");

            try {
                app.WorkWith().Authentication().LoginWithGoogle(token).ExecuteSync();
                return "SUCCESS!";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return $"Operation Failed: {ex.Message}"; 
            }
        }
    }
}