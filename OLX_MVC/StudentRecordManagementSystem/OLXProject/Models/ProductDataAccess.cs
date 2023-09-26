using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OLXProject.Models
{
    public class ProductDataAccess
    {

        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }

        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            connection();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblStudent", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }




    }
}