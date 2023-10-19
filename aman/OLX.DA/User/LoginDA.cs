﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLX.Models;

namespace OLX.DA.User
{
    public class LoginDA
    {
        private SqlConnection con;

        
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }
        public bool authLogin(UsersModel model, out string validationmsg,out int id)
        {
            connection();
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            string q = "select count(*) from Users where userEmail=@userEmail";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@userEmail", model.userEmail);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count == 0)
            {
                validationmsg = "UserEmail doesn't Exist";

            }
            if (count == 1)
            {

                string useridQuery = "SELECT TOP 1 userid FROM Users WHERE userEmail = @userEmail";
                SqlCommand useridCmd = new SqlCommand(useridQuery, con);
                useridCmd.Parameters.AddWithValue("@userEmail", model.userEmail);
                con.Open();
                id = (int)useridCmd.ExecuteScalar();
                con.Close();

                string query = "select count(*) from Users where userEmail=@userEmail and Password=@Password";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userEmail", model.userEmail);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                con.Open();
                count = (int)cmd.ExecuteScalar();
                con.Close();

                validationmsg = count == 1 ? "Login Successful" : "Invalid credentials";

                if (count == 1)
                {
                    bool isadmin = IsAdmin(model.userEmail);
                    if (isadmin)
                    {
                        return true;
                    }
                }
                return count > 0;
            }
            else
            {
                validationmsg = "UserEmail doesn't Exist";
                id = 0; 
                return false;
            }

            //if (rows == 0)
            //{  


            //}
            ////return false;
            //validationmsg = "Invalid Credentials ";
            //return rows>0 ;
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dataTable = new DataTable();

        }
        public bool IsAdmin(string userEmail)
        {connection();
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            string query = "select role from users where userEmail=@userEmail and Role='Admin'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userEmail", userEmail);
            con.Open();
            string role = (string)cmd.ExecuteScalar();
            con.Close();
            return role == "Admin";
        }

     
        public int GetOtp(int userId, out string message)
        {
            
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            connection();
            string query = "SELECT lu.LoginOtp FROM Users u JOIN LoginUser lu ON u.userId = lu.userIdByLoginUser WHERE lu.LoginUserId = @id and lu.ExpirationLoginTime>GETDATE()";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", userId);
            con.Open();
            int count = (int)(cmd.ExecuteScalar() ?? 0); // Use null coalescing to handle null results
            con.Close();
            if (count == 0)
            {
                message = "Time Expired";
                return 0;
            }
            else
            {
                message = string.Empty;

                return count;
            }
          

        }
        public int getuserid(int loginid)
        {
            connection();
            string query = "select u.userId from LoginUser lu \r\n  join Users u \r\n  on lu.userIdByLoginUser=u.userId\r\n where lu.LoginUserId=@loginuserid";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@loginuserid", loginid);
            con.Open();
            int i = (int)cmd.ExecuteScalar();
            con.Close();

            if (i > 0)
            {
                return i;
            }
            else
                return 0;
        }

        public int getidfromOtp(int userotp, out string msg)
        {

            connection();
            // SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            string query = "SELECT LoginUserId FROM LoginUser where LoginOtp=@otp";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@otp", userotp);
            con.Open();
            object c = cmd.ExecuteScalar();
            con.Close();
            if (c == null)
            {
                msg = "Otp not matched";
                return 0;

            }

            msg = null;
            //else { msg = "user found"; return (int)c; }
            return (int)c;
        }
        public bool MobileNumberExists(string MobileNo)
        {
            connection();
           // using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            
                con.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE MobileNo = @mobile";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@mobile", MobileNo);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            
        }
        public bool InsertOtp(int userid, int otp, DateTime expiretime)
        {
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            connection();
            con.Open();
            string q = "insert into LoginUser(userIdByLoginUser,LoginOtp,ExpirationLoginTime)values(@id,@otp,@expiretime)";
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@id", userid);
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@expiretime", expiretime);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }

        }
        public int GetUserIdByMobileNumber(string mobileNumber)
        {

            // using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            connection();
            con.Open();

            string query = "SELECT userId FROM Users WHERE MobileNo = @mobile";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@mobile", mobileNumber);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result;
            }
            else
            {
                return 0;
            }


        }
    }
}
