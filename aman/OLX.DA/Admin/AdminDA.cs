﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLX.Models.Admin;

namespace OLX.DA.Admin
{
    public class AdminDA
    {
        private SqlConnection con;

        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }


        public IEnumerable<ProductSubCategoryModeljoin> GetProductDetailsLists()
        {
            connection();
            List<ProductSubCategoryModeljoin> lstProject = new List<ProductSubCategoryModeljoin>();
            // string query = "select * from tbl_ProductDetails ";
            SqlDataAdapter da = new SqlDataAdapter("spGetAllProductSubCategory", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {

                lstProject.Add(

                    new ProductSubCategoryModeljoin
                    {
                        productSubCategoryId = Convert.ToInt32(rdr["productSubCategoryId"]),
                        productCategoryName = Convert.ToString(rdr["productCategoryName"]),
                        productSubCategoryName = rdr["productSubCategoryName"].ToString(),
                        createdOn = Convert.ToDateTime(rdr["createdOn"]),
                        updatedOn = Convert.ToDateTime(rdr["updatedOn"]),
                    }
                );
            }
            return lstProject;
        }


        //public void AddProductDetails(ProductSubCategoryModeljoin productDetails)
        //{
        //    connection();

        //    // Check if the product subcategory already exists
        //    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_ProductSubCategory WHERE productCategoryId = @productCategoryId AND productSubCategoryName = @productSubCategoryName", con);
        //    checkCmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        //    checkCmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
        //    con.Open();

        //    int existingCount = (int)checkCmd.ExecuteScalar();
        //    con.Close();

        //    if (existingCount > 0)
        //    {
        //        throw new Exception("Product Subcategory Name Already Exists.");
        //    }

        //    // Add the product subcategory
        //    SqlCommand cmd = new SqlCommand("AddNewProductDetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        //    cmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}



        //public string GetProductNameById(int productCategoryId)
        //{
        //    string productName = null;
        //    connection();
        //    using (con)
        //    {
        //        con.Open();

        //        string query = "SELECT productCategoryName FROM tbl_ProductCategory WHERE productCategoryId = @productCategoryId";
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.Parameters.AddWithValue("@productCategoryId", productCategoryId);
        //            productName = (string)cmd.ExecuteScalar();
        //        }
        //    }

        //    return productName;
        //}
        ////public void AddProductDetails(ProductSubCategoryModeljoin productDetails)
        ////{
        ////    connection();

        ////    // Check if the product subcategory already exists
        ////    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_ProductSubCategory WHERE productCategoryId = @productCategoryId AND productSubCategoryName = @productSubCategoryName", con);
        ////    checkCmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        ////    checkCmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
        ////    con.Open();

        ////    int existingCount = (int)checkCmd.ExecuteScalar();
        ////    con.Close();

        ////    if (existingCount > 0)
        ////    {
        ////        throw new Exception("Product Subcategory Name Already Exists.");
        ////    }

        ////    // Add the product subcategory
        ////    SqlCommand cmd = new SqlCommand("AddNewProductDetails", con);
        ////    cmd.CommandType = CommandType.StoredProcedure;

        ////    cmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        ////    cmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);

        ////    con.Open();
        ////    cmd.ExecuteNonQuery();
        ////    con.Close();
        ////}


        //public bool AddProductDetails(ProductSubCategoryModeljoin productDetails)
        //{
        //    connection();

        //    // Check if the product subcategory already exists
        //    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_ProductSubCategory WHERE productCategoryId = @productCategoryId AND productSubCategoryName = @productSubCategoryName", con);
        //    checkCmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        //    checkCmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
        //    con.Open();

        //    int existingCount = (int)checkCmd.ExecuteScalar();
        //    con.Close();

        //    if (existingCount > 0)
        //    {
        //        return false; // Product Subcategory Name Already Exists
        //    }

        //    // Add the product subcategory
        //    SqlCommand cmd = new SqlCommand("AddNewProductDetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
        //    cmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    return true; // Product Subcategory added successfully
        //}


        public string GetProductNameById(int productCategoryId)
        {
            string productName = null;
            connection();
            using (con)
            {
                con.Open();

                string query = "SELECT productCategoryName FROM tbl_ProductCategory WHERE productCategoryId = @productCategoryId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productCategoryId", productCategoryId);
                    productName = (string)cmd.ExecuteScalar();
                }
            }

            return productName;
        }



        public void AddProductDetails(ProductSubCategoryModeljoin productDetails)
        {
            connection();

            // Check if the product subcategory already exists
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_ProductSubCategory WHERE productCategoryId = @productCategoryId AND productSubCategoryName = @productSubCategoryName", con);
            checkCmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
            checkCmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
            con.Open();

            int existingCount = (int)checkCmd.ExecuteScalar();
            con.Close();

            if (existingCount > 0)
            {
                throw new Exception("Product Subcategory Name Already Exists.");
            }

            // Add the product subcategory
            SqlCommand cmd = new SqlCommand("AddNewProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
            cmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void UpdateProductDetails(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                connection();

                // Check if the updated product subcategory name already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_ProductSubCategory WHERE productSubCategoryId != @productSubCategoryId AND productCategoryId = @productCategoryId AND productSubCategoryName = @productSubCategoryName", con);
                checkCmd.Parameters.AddWithValue("@productSubCategoryId", productDetails.productSubCategoryId);
                checkCmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
                checkCmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
                con.Open();

                int existingCount = (int)checkCmd.ExecuteScalar();

                if (existingCount > 0)
                {
                    throw new Exception("Product Subcategory Name Already Exists.");
                }

                // Proceed with the update
                string sqlUpdate = "UPDATE tbl_ProductSubCategory SET productCategoryId = @productCategoryId, productSubCategoryName = @productSubCategoryName , updatedOn=getdate() WHERE productSubCategoryId = @productSubCategoryId";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@productSubCategoryId", productDetails.productSubCategoryId);
                cmd.Parameters.AddWithValue("@productCategoryId", productDetails.productCategoryId);
                cmd.Parameters.AddWithValue("@productSubCategoryName", productDetails.productSubCategoryName);
                cmd.Parameters.AddWithValue("@updatedOn", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;  // Re-throw the exception to be caught in the controller
            }
            finally
            {
                con.Close();
            }
        }






        public ProductSubCategoryModeljoin GetProductDetails(int? productSubCategoryId)
        {
            connection();
            ProductSubCategoryModeljoin ul = new ProductSubCategoryModeljoin();
            string sqlQuery = "SELECT * FROM tbl_ProductSubCategory WHERE productSubCategoryId= " + productSubCategoryId;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ul.productSubCategoryId = Convert.ToInt32(dr["productSubCategoryId"]);
                ul.productCategoryId = Convert.ToInt32(dr["productCategoryId"]);
                ul.productSubCategoryName = Convert.ToString(dr["productSubCategoryName"]);
                ul.createdOn = Convert.ToDateTime(dr["createdOn"]);
                ul.updatedOn = Convert.ToDateTime(dr["updatedOn"]);
            }
            return ul;
        }

        public void DeleteProductDetails(int? productSubCategoryId)
        {
            connection();

            SqlCommand cmd = new SqlCommand("SpDeleteProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productSubCategoryId", productSubCategoryId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //public IEnumerable<ProductSubCategoryModeljoin> DropdownList()
        //{
        //    connection();
        //    List<ProductSubCategoryModeljoin> lstProject = new List<ProductSubCategoryModeljoin>();
        //    // string query = "select * from tbl_ProductDetails ";
        //    SqlDataAdapter da = new SqlDataAdapter("DropdownList", con);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    da.Fill(dt);
        //    con.Close();
        //    foreach (DataRow rdr in dt.Rows)
        //    {

        //        lstProject.Add(

        //            new ProductSubCategoryModeljoin
        //            {
        //                productCategoryId = Convert.ToInt32(rdr["productCategoryId"]),
        //                productCategoryName = Convert.ToString(rdr["productCategoryName"]),
        //                //productSubCategoryName = rdr["productSubCategoryName"].ToString(),
        //                //createdOn = Convert.ToDateTime(rdr["createdOn"]),
        //                //updatedOn = Convert.ToDateTime(rdr["updatedOn"]),
        //            }
        //        );
        //    }
        //    return lstProject;
        //}
    }
}
