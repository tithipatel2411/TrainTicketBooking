using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DataAccess
{
    public class BookingDataAccess
    {
        public void InsertBooking()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "Insert into Booking values(4,4,4,1,150,getdate(),'No')";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
