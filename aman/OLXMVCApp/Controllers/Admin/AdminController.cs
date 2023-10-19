﻿using OLX.DA.Admin;
using OLX.Models.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLXMVCApp.Controllers.Admin
{
    public class AdminController : Controller
    {
        ProductListDA dataAccess = new ProductListDA();
        UserList_Data_Access uda = new UserList_Data_Access();
        AdminDA productCatRepository = new AdminDA();
        productDA pd = new productDA();

        public ActionResult SubCategoryList()
        {
            IEnumerable<ProductSubCategoryModeljoin> productDetails = productCatRepository.GetProductDetailsLists();


            return View("SubCategoryList", "Admin_Layout", productDetails);
        }

        //public ActionResult SubCategoryListCreate()
        //{
        //    return View("SubCategoryListCreate", "Admin_Layout");
        //}

        //[HttpPost]
        //public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        //{
        //    try
        //    {
        //        TempData["AlertMessage"] = "Product Subcategory Added successfully......";
        //        productCatRepository.AddProductDetails(productDetails);

        //        return RedirectToAction(nameof(SubCategoryList));
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();
        //    }
        //}


        //[HttpPost]
        //public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        //{
        //    try
        //    {
        //        // Attempt to add the product subcategory
        //        productCatRepository.AddProductDetails(productDetails);

        //        TempData["AlertMessage"] = "Product Subcategory Added successfully......";

        //        return RedirectToAction(nameof(SubCategoryList));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View("SubCategoryListCreate", "Admin_Layout", productDetails);
        //    }
        //}

        //private SqlConnection con;

        //// To handle connection related activities    
        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //    con = new SqlConnection(constr);
        //}

        //public ActionResult SubCategoryListCreate()
        //{
        //    // Fetch product IDs and names from the database
        //    List<ProductSubCategoryModeljoin> products = new List<ProductSubCategoryModeljoin>();
        //    connection();
        //    using (con)
        //    {
        //        con.Open();

        //        string query = "SELECT productCategoryId, productCategoryName FROM tbl_ProductCategory";
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                products.Add(new ProductSubCategoryModeljoin
        //                {
        //                    productCategoryId = reader.GetInt32(0),
        //                    productCategoryName = reader.GetString(1)
        //                });
        //            }
        //        }
        //    }

        //    // Pass the list of product IDs to the view
        //    ViewBag.ProductCategoryIds = new SelectList(products, "productCategoryId", "productCategoryName");

        //    return View();
        //}

        ////[HttpPost]
        ////public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        ////{
        ////    try
        ////    {
        ////        // Fetch the product name based on the selected product ID
        ////        productDetails.productCategoryName = productCatRepository.GetProductNameById(productDetails.productCategoryId);

        ////        // Attempt to add the product subcategory
        ////        productCatRepository.AddProductDetails(productDetails);

        ////        TempData["AlertMessage"] = "Product Subcategory Added successfully...";

        ////        return RedirectToAction("SubCategoryList");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ModelState.AddModelError("", ex.Message);
        ////        return View(productDetails);
        ////    }
        ////}


        //[HttpPost]
        //public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        //{
        //    try
        //    {
        //        // Fetch the product name based on the selected product ID
        //        productDetails.productCategoryName = productCatRepository.GetProductNameById(productDetails.productCategoryId);

        //        bool isProductAdded = productCatRepository.AddProductDetails(productDetails);

        //        if (isProductAdded)
        //        {
        //            TempData["AlertMessage"] = "Product Subcategory Added successfully...";
        //            return RedirectToAction("SubCategoryList");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("productCategoryName", "Product Category Name Already Exists.");
        //            return View(productDetails);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View(productDetails);
        //    }
        //}





        //// [HttpPost]
        ////public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        ////{
        ////    try
        ////    {
        ////        // Check if the product subcategory already exists
        ////        bool exists = CheckIfProductSubCategoryExists(productDetails.productCategoryId, productDetails.productSubCategoryName);

        ////        if (exists)
        ////        {
        ////            TempData["AlertMessage"] = "Product Subcategory already exists.";
        ////            return View(productDetails);
        ////        }

        ////        // Fetch the product name based on the selected product ID
        ////        productDetails.productCategoryName = GetProductNameById(productDetails.productCategoryId);

        ////        // Attempt to add the product subcategory
        ////        AddProductDetails(productDetails);

        ////        TempData["AlertMessage"] = "Product Subcategory Added successfully...";

        ////        return RedirectToAction("SubCategoryList");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ModelState.AddModelError("", ex.Message);
        ////        return View(productDetails);
        ////    }
        ////}
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>

        private SqlConnection con;

        // To handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public ActionResult SubCategoryListCreate()
        {
            // Fetch product IDs and names from the database
            List<ProductSubCategoryModeljoin> products = new List<ProductSubCategoryModeljoin>();
            connection();
            using (con)
            {
                con.Open();

                string query = "SELECT productCategoryId, productCategoryName FROM tbl_ProductCategory";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductSubCategoryModeljoin
                        {
                            productCategoryId = reader.GetInt32(0),
                            productCategoryName = reader.GetString(1)
                        });
                    }
                }
            }

            // Pass the list of product IDs to the view
            ViewBag.ProductCategoryIds = new SelectList(products, "productCategoryId", "productCategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                // Fetch the product name based on the selected product ID
                productDetails.productCategoryName = productCatRepository.GetProductNameById(productDetails.productCategoryId);

                // Attempt to add the product subcategory
                productCatRepository.AddProductDetails(productDetails);

                TempData["AlertMessage"] = "Product Subcategory Added successfully...";

                return RedirectToAction("SubCategoryList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(productDetails);
            }
        }



        public ActionResult SubCategoryListEdit(int productSubCategoryId)
        {
            ProductSubCategoryModeljoin productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View("SubCategoryListEdit", "Admin_Layout", productDetails);
        }

        //[HttpPost]
        //public ActionResult SubCategoryListEdit(ProductSubCategoryModeljoin productDetails)
        //{
        // try
        // {
        // TempData["AlertMessage"] = "Product Subcategory Edited successfully......";
        // productCatRepository.UpdateProductDetails(productDetails);
        // return RedirectToAction(nameof(SubCategoryList));
        // }
        // catch
        // {
        // return View();
        // }
        //}


        //[HttpPost]
        //public ActionResult SubCategoryListEdit(ProductSubCategoryModeljoin productDetails)
        //{
        //    try
        //    {
        //        // Attempt to update the product subcategory
        //        productCatRepository.UpdateProductDetails(productDetails);

        //        TempData["AlertMessage"] = "Product Subcategory Edited successfully......";

        //        return RedirectToAction(nameof(SubCategoryList));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View("SubCategoryListEdit", "Admin_Layout", productDetails);
        //    }
        //}
        //[HttpPost]
        //public ActionResult SubCategoryListEdit(ProductSubCategoryModeljoin productDetails)
        //{
        //    try
        //    {
        //        TempData["AlertMessage"] = "Product Subcategory Edited successfully......";
        //        productCatRepository.UpdateProductDetails(productDetails);
        //        return RedirectToAction(nameof(SubCategoryList));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        [HttpPost]
        public ActionResult SubCategoryListEdit(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                // Attempt to update the product subcategory
                productCatRepository.UpdateProductDetails(productDetails);

                TempData["AlertMessage"] = "Product Subcategory Edited successfully......";

                return RedirectToAction(nameof(SubCategoryList));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("SubCategoryListEdit", "Admin_Layout", productDetails);
            }
        }


        public ActionResult SubCategoryListDelete(int productSubCategoryId)
        {
            ProductSubCategoryModeljoin productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View("SubCategoryListDelete", "Admin_Layout", productDetails);
        }

        [HttpPost]
        public ActionResult SubCategoryListDelete(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                TempData["AlertMessage"] = "Product Subcategory Deleted successfully......";
                productCatRepository.DeleteProductDetails(productDetails.productSubCategoryId);
                return RedirectToAction(nameof(SubCategoryList));
            }
            catch
            {
                return View();
            }
        }




        public ActionResult UserIndex()
        {
            IEnumerable<UserList> ul = uda.GetAllUser();
            return View("UserIndex", "Admin_Layout", ul);
        }

        public ActionResult UserDetails(int? id)
        {
            UserList product = uda.GetUserData(id);
            return View("UserDetails", "Admin_Layout", product);
        }

        public ActionResult UserEdit(int id)
        {

            UserList user = uda.GetUserData(id);
            TempData["AlertMessage"] = "User Edited successfully......";
            return View("UserEdit", "Admin_Layout", user);
        }

        [HttpPost]
        public ActionResult UserEdit(UserList ul)
        {
            try
            {
                uda.Updateuser(ul);

                return RedirectToAction(nameof(UserIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UserDelete(int? id)
        {
            UserList userList = uda.GetUserData(id);
            return View("UserDelete", "Admin_Layout", userList);
        }

        [HttpPost]
        public ActionResult UserDelete(int id)
        {
            try
            {
                uda.DeleteUser(id);
                TempData["AlertMessage"] = "user deleted successfully......";
                return RedirectToAction(nameof(UserIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            return View("Dashboard", "Admin_Layout");
        }


        public ActionResult ProductList(string SearchItem, int? i)
        {
            IEnumerable<ProductListModel> products = dataAccess.GetAllProductList();
            return View("ProductList", "Admin_Layout", products);
        }

        public ActionResult ProductListDetails(int advertiseId)
        {
            ProductListModel product = dataAccess.GetProductList(advertiseId);
            return View("ProductListDetails", "Admin_Layout", product);
        }
        public ActionResult ProductlistEdit(int advertiseId)
        {
            ProductListModel product = dataAccess.GetProductList(advertiseId);
            return View("ProductlistEdit", "Admin_Layout", product);
        }

        [HttpPost]
        public ActionResult ProductlistEdit(ProductListModel product)
        {
            try
            {
                TempData["AlertMessage"] = "Product-List Edited successfully......";
                dataAccess.UpdateProductList(product);
                return RedirectToAction(nameof(ProductList));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProductListDelete(int advertiseId)
        {
            TempData["AlertMessage"] = "Product-List Data Deleted successfully......";
            ProductListModel product = dataAccess.GetProductList(advertiseId);
            return View("ProductListDelete", "Admin_Layout", product);
        }

        [HttpPost]
        public ActionResult ProductListDelete(ProductListModel product)
        {
            try
            {
                dataAccess.DeleteProductList(product.advertiseId);
                return RedirectToAction(nameof(ProductList));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Advertise()
        {
            AdvertiseDA d1 = new AdvertiseDA();
            AdvertiseModel viewModel = new AdvertiseModel();

            viewModel.Products = d1.GetProductsFromDatabase();
            viewModel.SubCategories = d1.GetProductsFromDatabase1();

            foreach (var subCategory in viewModel.SubCategories)
            {
                subCategory.ImageBytes = subCategory.imageData;
            }


            return View("Advertise", "Admin_Layout", viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int advertiseId, int advertiseImageId)
        {
            AdvertiseDA d = new AdvertiseDA();
            d.Deleteproduct(advertiseId, advertiseImageId);

            return RedirectToAction("Advertise");
        }

        public ActionResult productDisplay()
        {
            IEnumerable<product> productDetails = pd.productDisplay();
            return View("productDisplay", "Admin_Layout", productDetails);
        }

        public ActionResult productDisplayAdd()
        {
            return View("productDisplayAdd", "Admin_Layout");
        }

        [HttpPost]
        public ActionResult productDisplayAdd(product product)
        {
            try
            {
                pd.productDisplayAdd(product);

                return RedirectToAction(nameof(productDisplay));
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        public ActionResult productDisplayDetail(int productCategoryId)
        {
            product product = pd.productDisplayDetail(productCategoryId);
            return View("productDisplayDetail", "Admin_Layout", product);
        }

        public ActionResult productDisplayDelete(int productCategoryId)
        {
            TempData["AlertMessage"] = "Product-List Data Deleted successfully......";
            product product = pd.productDisplayDetail(productCategoryId);
            return View("productDisplayDelete", "Admin_Layout", product);
        }

        [HttpPost]
        public ActionResult productDisplayDelete(product product)
        {
            try
            {
                pd.productDisplayDelete(product.productCategoryId);
                return RedirectToAction(nameof(productDisplay));
            }
            catch
            {
                return View();
            }
        }

    }

}
