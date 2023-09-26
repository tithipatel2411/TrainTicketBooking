using OLXProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLXProject.Controllers
{
    public class AdminController : Controller
    {
        ProductCatRepository productCatRepository = null;
        public AdminController()
        {
            productCatRepository = new ProductCatRepository();
        }
        // GET: Admin
        //public ActionResult Index()
        //{
        //    //StudentDataAccessLayer std = new StudentDataAccessLayer();
        //    List<ProductDetailsModel> productDetails = productCatRepository.GetProductDetailsLists();
        //    return View(productDetails);
        //    //return View();
        //}  

        public ActionResult Index()
        {
            //StudentDataAccessLayer std = new StudentDataAccessLayer();
            List<ProductDetailsModel1> productDetails = productCatRepository.GetProductDetailsLists1();
            return View(productDetails);
            //return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(ProductDetailsModel productDetails)
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
        public ActionResult Edit(int productDetailsId)
        {
            ProductDetailsModel productDetails = productCatRepository.GetProductDetails(productDetailsId);
            return View(productDetails);
            // return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductDetailsModel productDetails)
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
        public ActionResult Delete(int productDetailsId)
        {
            ProductDetailsModel productDetails= productCatRepository.GetProductDetails(productDetailsId);
            return View(productDetails);
            // return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductDetailsModel productDetails)
        {
            try
            {
                // TODO: Add delete logic here  
                productCatRepository.DeleteProductDetails(productDetails.productDetailsId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int productDetailsId)
        {
            ProductDetailsModel productDetails= productCatRepository.GetProductDetails(productDetailsId);
            return View(productDetails);
        }
    }
}
