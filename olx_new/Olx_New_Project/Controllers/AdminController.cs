using Olx_New_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olx_New_Project.Controllers
{
    public class AdminController : Controller
    {

        ProductSubCatModelRepo productCatRepository = null;
        public AdminController()
        {
            productCatRepository = new ProductSubCatModelRepo();
        }

        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable<ProductSubCategoryModel> productDetails = productCatRepository.GetProductDetailsLists();
            //if (productDetails.Count == 0)
            //{
            //    TempData["InfoMessage"] = "Currently Data Not Available in the Database ";
            //}
            return View(productDetails);
            // return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(ProductSubCategoryModel productDetails)
        {
            try
            {
                // TODO: Add insert logic here  
                productCatRepository.AddProductDetails(productDetails);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int productSubCategoryId)
        {
            ProductSubCategoryModel productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View(productDetails);
            // return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductSubCategoryModel productDetails)
        {
            try
            {
                // TODO: Add update logic here  
                productCatRepository.UpdateProductDetails(productDetails);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int productSubCategoryId)
        {
            ProductSubCategoryModel productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View(productDetails);
            // return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductSubCategoryModel productDetails)
        {
            try
            {
                // TODO: Add delete logic here  
                productCatRepository.DeleteProductDetails(productDetails.@productSubCategoryId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
