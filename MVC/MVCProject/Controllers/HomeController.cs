using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Employee> employeesList = new List<Employee>();
            employeesList.Add(new Employee { EmpId = 1 , Name = "Zenil" , designation = "CEO"}) ;

            //ViewBag.employeesList = employeesList;

            ViewData["EmployeeList"] = employeesList;

            ViewBag.ViewBag = "Patel";
            ViewBag.ViewBag = "Patel";
            ViewData["Viewdata"] = "Tithi";
            TempData["Tempdata"] = "Zenil";
            TempData["Tempdasta"] = "Zenil";

            return View();
            //return View(employeesList);
        }

        public ActionResult SecondPage()
        {     
            ViewBag.t = TempData["Tempdata"];
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.t = TempData["Tempdata"];
            //throw new Exception();
            return View();
        }

        [HandleError(View = "CustomError")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            throw new Exception();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login Messsage   ";

            return View();
        }

        public ActionResult NotFound()
        {
            //ViewBag.Message = "Login Messsage   ";

            return View();
        }
    }
}