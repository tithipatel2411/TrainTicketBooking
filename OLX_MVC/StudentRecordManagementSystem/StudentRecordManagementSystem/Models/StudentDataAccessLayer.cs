using StudentRecordManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace StudentRecordManagementSystem.Models
{
    public class StudentDataAccessLayer
    {
        //string connectionString = ConnectionString.CName;

        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }

        public List<Student> GetAllStudent()
        {
            connection();
            List<Student> lstStudent = new List<Student>();
            
                SqlCommand cmd = new SqlCommand("spGetAllSubcategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Product_id = Convert.ToInt32( rdr["Product_id"]);
                    student.SubcategoryName = rdr["SubcategoryName"].ToString();
                    student.CategoryDescription = rdr["CategoryDescription"].ToString();
                    student.price = Convert.ToInt32(rdr["price"]);
                    //student.price = rdr["price"].ToString();
                    student.Location = rdr["Location"].ToString();

                    lstStudent.Add(student);
                }
                con.Close();
            
            return lstStudent;
        }
        public void AddStudent(Student student)
        {
            connection();

            SqlCommand cmd = new SqlCommand("spAddSubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Product_id", student.Product_id);
            cmd.Parameters.AddWithValue("@SubcategoryName", student.SubcategoryName);
            cmd.Parameters.AddWithValue("@CategoryDescription", student.CategoryDescription);
            cmd.Parameters.AddWithValue("@price", student.price);
            cmd.Parameters.AddWithValue("@Location", student.Location);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void UpdateStudent(Student student)
        {
            connection();

            SqlCommand cmd = new SqlCommand("spUpdateSubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Product_id", student.Product_id);
            cmd.Parameters.AddWithValue("@SubcategoryName", student.SubcategoryName);
            cmd.Parameters.AddWithValue("@CategoryDescription", student.CategoryDescription);
            cmd.Parameters.AddWithValue("@price", student.price);
            cmd.Parameters.AddWithValue("@Location", student.Location);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public Student GetStudentData(int? id)
        {
            Student student = new Student();
            connection();

            string sqlQuery = "SELECT * FROM Subcategory WHERE Id= " + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                student.Id = Convert.ToInt32(rdr["Id"]);
                student.Product_id = Convert.ToInt32(rdr["Product_id"]);
                student.SubcategoryName = rdr["SubcategoryName"].ToString();
                student.CategoryDescription = rdr["CategoryDescription"].ToString();
                student.price = Convert.ToInt32(rdr["price"]);
                student.Location = rdr["Location"].ToString();
            }

            return student;
        }

        public void DeleteStudent(int? id)
        {
            connection();

            SqlCommand cmd = new SqlCommand("spDeleteSubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}