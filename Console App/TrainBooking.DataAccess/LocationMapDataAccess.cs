﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DataAccess
{
    public class LocationMapDataAccess
    {
        public void InsertLocationMap()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "Insert into LocationMap values(5,'Delhi')";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
