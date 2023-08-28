using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DataAccess
{
    public class UserMappingDataAccess
    {
        public void InsertUserMapping()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            string Query = "Insert into UserMapping values(4,4,4,5)";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            int rowaffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
