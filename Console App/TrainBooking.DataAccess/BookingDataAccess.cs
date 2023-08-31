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
            string Query = "Insert into Booking values(1,1,1,1,150,getdate(),'1',1)";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
