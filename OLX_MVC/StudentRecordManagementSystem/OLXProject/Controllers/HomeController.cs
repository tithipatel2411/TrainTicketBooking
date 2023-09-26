using OLXProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLXProject.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    //return View();
        //    using (ProductDataAccess pda = new ProductDataAccess())
        //    {
        //        List<UserDetail> userDetails = (from data in tr.UserDetails
        //                                        select data).ToList();
        //        return View(userDetails);
        //    }
        //}

        public ActionResult Index()
        {
            //ProductDataAccess model = new ProductDataAccess();
            //DataTable dt = model.GetAllStudents();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}