using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace OLXProject.Models
{
    public class ProductCatRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }

        //public List<PoductCatModel> GetAllStudent()
        //{
        //    connection();
        //    List<PoductCatModel> lstStudent = new List<PoductCatModel>();

        //    SqlCommand cmd = new SqlCommand("spGetAllProductDetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        ProductDetailsModel poductCat = new ProductDetailsModel();
        //        poductCat.productDetailsId = Convert.ToInt32(rdr["productDetailsId"]);
        //        poductCat.productSubCategoryId = Convert.ToInt32(rdr["productSubCategoryId"]);
        //        poductCat.productTitle = rdr["productTitle"].ToString();
        //        poductCat.productDescription = rdr["productDescription"].ToString();
        //        poductCat.productPrice = Convert.ToInt32(rdr["productPrice"]);
        //        //poductCat.price = rdr["price"].ToString();
        //        poductCat.productImageId = Convert.ToInt32(rdr["productImageId"]);
        //        poductCat.cityId = Convert.ToInt32(rdr["cityId"]);
        //        poductCat.userId = Convert.ToInt32(rdr["userId"].ToString());
        //        //poductCat.userId = rdr["userId"].ToString();
        //        //poductCat.productImageId = rdr["productImageId"].ToString();

        //        lstStudent.Add(poductCat);
        //    }
        //    con.Close();

        //    return lstStudent;
        //}

        //public List<PoductCatModel> GetAllProject()
        //{
        //    connection();
        //    List<PoductCatModel> lstProject = new List<PoductCatModel>();


        //    SqlCommand com = new SqlCommand("GetProjects", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    da.Fill(dt);
        //    con.Close();
        //    //Bind EmpModel generic list using dataRow     
        //    foreach (DataRow rdr in dt.Rows)
        //    {

        //        lstProject.Add(

        //            new ProductDetailsModel
        //            {
        //                //ProjectId = Convert.ToInt64(dr["ProjectId"]),
        //                //AttachmentName = Convert.ToString(dr["AttachmentName"]),
        //                //ProjectName = Convert.ToString(dr["ProjectName"]),
        //                //ProjectDate = Convert.ToDateTime(dr["ProjectDate"]),
        //                //ProjectNumber = Convert.ToInt32(dr["ProjectNumber"])
        //                productDetailsId = Convert.ToInt32(rdr["productDetailsId"]),
        //                productSubCategoryId = Convert.ToInt32(rdr["productSubCategoryId"]),
        //                productTitle = rdr["productTitle"].ToString(),
        //                productDescription = rdr["productDescription"].ToString(),
        //                productPrice = Convert.ToInt32(rdr["productPrice"]),
        //                //poductCat.price = rdr["price"].ToString();
        //                productImageId = Convert.ToInt32(rdr["productImageId"]),
        //                cityId = Convert.ToInt32(rdr["cityId"]),
        //                userId = Convert.ToInt32(rdr["userId"])

        //            }

        //        );
        //    }

        //    return lstProject;
        //}



        public List<ProductDetailsModel> GetProductDetailsLists()
        {
            connection();
            List<ProductDetailsModel> lstProject = new List<ProductDetailsModel>();
           // string query = "select * from tbl_ProductDetails ";
            SqlDataAdapter da = new SqlDataAdapter("spGetAllProductDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {

                lstProject.Add(

                new ProductDetailsModel
                {
                    productDetailsId = Convert.ToInt32(rdr["productDetailsId"]),
                    productSubCategoryId = Convert.ToInt32(rdr["productSubCategoryId"]),
                    productTitle = rdr["productTitle"].ToString(),
                    productDescription = rdr["productDescription"].ToString(),
                    productPrice = Convert.ToInt32(rdr["productPrice"]),
                    //poductCat.price = rdr["price"].ToString();
                    productImageId = Convert.ToInt32(rdr["productImageId"]),
                    cityId = Convert.ToInt32(rdr["cityId"]),
                    userId = Convert.ToInt32(rdr["userId"])

                }


                );
            }
            return lstProject;
        }

        // join two table
        public List<ProductDetailsModel1> GetProductDetailsLists1()
        {
            connection();
            List<ProductDetailsModel1> lstProject = new List<ProductDetailsModel1>();
            // string query = "select * from tbl_ProductDetails ";
            SqlDataAdapter da = new SqlDataAdapter("spGetAllProductDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {

                lstProject.Add(

                new ProductDetailsModel1
                {
                    productDetailsId = Convert.ToInt32(rdr["productDetailsId"]),
                    productSubCategoryName = Convert.ToString(rdr["productSubCategoryName"]),
                    productTitle = rdr["productTitle"].ToString(),
                    productDescription = rdr["productDescription"].ToString(),
                    productPrice = Convert.ToInt32(rdr["productPrice"]),
                    //poductCat.price = rdr["price"].ToString();
                    productImageId = Convert.ToInt32(rdr["productImageId"]),
                    cityId = Convert.ToInt32(rdr["cityId"]),
                    userId = Convert.ToInt32(rdr["userId"])

                }


                );
            }
            return lstProject;
        }

        public void AddProductDetails(ProductDetailsModel productDetails)
        {
            connection();

            SqlCommand cmd = new SqlCommand("AddNewProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@productSubCategoryId", productDetails.productSubCategoryId);
            cmd.Parameters.AddWithValue("@productTitle", productDetails.productTitle);
            cmd.Parameters.AddWithValue("@productDescription", productDetails.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", productDetails.productPrice);
            cmd.Parameters.AddWithValue("@productImageId", productDetails.productImageId);
            cmd.Parameters.AddWithValue("@cityId", productDetails.cityId);
            cmd.Parameters.AddWithValue("@userId", productDetails.userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //public ProductDetailsModel GetProductDetails(int? id)
        //{
        //    ProductDetailsModel productDetails = new ProductDetailsModel();
        //    connection();

        //    string sqlQuery = "SELECT * FROM tbl_ProductDetails WHERE productDetailsId= " + id;
        //    SqlCommand cmd = new SqlCommand(sqlQuery, con);
        //    con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        productDetails.productDetailsId = Convert.ToInt32(rdr["productDetailsId"]);
        //        productDetails.productSubCategoryId = Convert.ToInt32(rdr["productSubCategoryId"]);
        //        productDetails.productTitle = rdr["productTitle"].ToString();
        //        productDetails.productDescription = rdr["productDescription"].ToString();
        //        productDetails.productPrice = Convert.ToInt32(rdr["productPrice"]);
        //        //poductCat.price = rdr["price"].ToString();
        //        productDetails.productImageId = Convert.ToInt32(rdr["productImageId"]);
        //        productDetails.cityId = Convert.ToInt32(rdr["cityId"]);

        //        productDetails.userId = Convert.ToInt32(rdr["userId"]);
        //    }

        //    return productDetails;
        //}

        //public void UpdateProductDetails(ProductDetailsModel productDetails)
        //{
        //    connection();

        //    SqlCommand cmd = new SqlCommand("spUpdateProductDetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@productSubCategoryId", productDetails.productSubCategoryId);
        //    cmd.Parameters.AddWithValue("@productTitle", productDetails.productTitle);
        //    cmd.Parameters.AddWithValue("@productDescription", productDetails.productDescription);
        //    cmd.Parameters.AddWithValue("@productPrice", productDetails.productPrice);
        //    cmd.Parameters.AddWithValue("@productImageId", productDetails.productImageId);
        //    cmd.Parameters.AddWithValue("@cityId", productDetails.cityId);
        //    cmd.Parameters.AddWithValue("@userId", productDetails.userId);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}

        public void UpdateProductDetails(ProductDetailsModel productDetails)
        {
            connection();

            SqlCommand cmd = new SqlCommand("spUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@productDetailsId", productDetails.productDetailsId);
            cmd.Parameters.AddWithValue("@productSubCategoryId", productDetails.productSubCategoryId);
            cmd.Parameters.AddWithValue("@productTitle", productDetails.productTitle);
            cmd.Parameters.AddWithValue("@productDescription", productDetails.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", productDetails.productPrice);
            cmd.Parameters.AddWithValue("@productImageId", productDetails.productImageId);
            cmd.Parameters.AddWithValue("@cityId", productDetails.cityId);
            //cmd.Parameters.AddWithValue("@@productStatus", productDetails.productStatus);
            cmd.Parameters.AddWithValue("@userId", productDetails.userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public ProductDetailsModel GetProductDetails(int? productDetailsId)
        {
            connection();
            ProductDetailsModel ul = new ProductDetailsModel();
            string sqlQuery = "SELECT * FROM tbl_ProductDetails WHERE productDetailsId= " + productDetailsId;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ul.productDetailsId = Convert.ToInt32(dr["productDetailsId"]);
                ul.productSubCategoryId = Convert.ToInt32(dr["productSubCategoryId"]);
                ul.productTitle = Convert.ToString(dr["productTitle"]);
                ul.productDescription = Convert.ToString(dr["productDescription"]);
                ul.productPrice = Convert.ToInt32(dr["productPrice"]);
                ul.productImageId = Convert.ToInt32(dr["productImageId"]);
                ul.cityId = Convert.ToInt32(dr["cityId"]);

                //ul.productStatus = Convert.ToInt32(dr["productStatus"]);
                ul.userId = Convert.ToInt32(dr["userId"]);
            }
            return ul;
        }

        public void DeleteProductDetails(int? productDetailsId)
        {
            connection();

            SqlCommand cmd = new SqlCommand("SpDeleteProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productDetailsId", productDetailsId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}