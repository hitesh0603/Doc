using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalDemo_MVC.Models;


namespace FinalDemo_MVC.Controllers
{
    public class BaseController : Controller
    {
      
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

    }

}
