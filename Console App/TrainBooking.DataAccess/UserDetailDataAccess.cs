using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DataAccess
{
    public class UserDetailDataAccess
    {
        public void InsertUserDetail()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "Insert into UserDetail values(1,'Tithi','Female',22,10000)";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // using sp
        public void InsertUserDetail1()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "InsertUserDetail";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = 4;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = "Aman";
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = "Male";
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = 20;
            sqlCommand.Parameters.Add("@Wallet", SqlDbType.Int).Value = 1000;
            sqlCommand.Parameters.Add("@OPType", SqlDbType.VarChar).Value = "I";

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void getFirstUserdtail()
        {
            //SqlConnection sqlConnetion = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            //string RetriveQuery = "select top 1 UserName from UserDetail";
            //SqlCommand sqlCommand = new SqlCommand(RetriveQuery, sqlConnetion);
            //sqlConnetion.Open();
            //string UserName = Convert.ToString(sqlCommand.ExecuteScalar());
            //sqlConnetion.Close();
            //Console.WriteLine(UserName);
            //Console.ReadKey();


            //---- All Data Print (Using Reader )
            //SqlConnection sqlconnetion = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            //string retrivequery = "select * from userdetail";
            //SqlCommand sqlcommand = new SqlCommand(retrivequery, sqlconnetion);
            //sqlconnetion.Open();
            //SqlDataReader rdr = sqlcommand.ExecuteReader();
            ////sqlconnetion.close();
            //if (rdr.HasRows) // no data// null// not give any error
            //{
            //    while (rdr.Read())
            //    {
            //        Console.WriteLine($"{rdr["userid"]} { rdr["username"]} {rdr["gender"]}  {rdr["wallet"]}");
            //    }
            //    Console.ReadKey();

            //}



        }
        public void UpdateUSerDetail()
        {
            SqlConnection sqlConnetion = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "update UserDetail set UserName='abc' where UserId=10";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnetion);
            sqlConnetion.Open();
            Convert.ToString(sqlCommand.ExecuteNonQuery());
            sqlConnetion.Close();
        }

        // using sp -- pending
        public void UpdateTrainDetail()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string updateQuery = "InsertTrain";

            SqlCommand cmd = new SqlCommand(updateQuery, sqlConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@TrainId", SqlDbType.Int).Value = 125;
            cmd.Parameters.Add("@TrainNo", SqlDbType.Int).Value = 10;
            cmd.Parameters.Add("@TrainName", SqlDbType.VarChar).Value = "Added";
            cmd.Parameters.Add("@SourceId", SqlDbType.Int).Value = 1002;
            cmd.Parameters.Add("@DestinationId", SqlDbType.Int).Value = 102;
            cmd.Parameters.Add("@NoOfSeat", SqlDbType.Int).Value = 102;
            cmd.Parameters.Add("@OPType", SqlDbType.VarChar).Value = "U";

            sqlConnection.Open();
            int rowaffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void DeleteTrainDetail()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string updateQuery = "InsertTrain";

            SqlCommand cmd = new SqlCommand(updateQuery, sqlConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@TrainId", SqlDbType.Int).Value = 124;
            cmd.Parameters.Add("@TrainNo", SqlDbType.Int).Value = 10;
            cmd.Parameters.Add("@TrainName", SqlDbType.VarChar).Value = "Added";
            cmd.Parameters.Add("@SourceId", SqlDbType.Int).Value = 1002;
            cmd.Parameters.Add("@DestinationId", SqlDbType.Int).Value = 102;
            cmd.Parameters.Add("@NoOfSeat", SqlDbType.Int).Value = 102;
            cmd.Parameters.Add("@OPType", SqlDbType.VarChar).Value = "D";

            sqlConnection.Open();
            int rowaffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}
