using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DataAccess
{
    public class ConnectionString
    {
        public static SqlConnection GetConnection()
        {
            return GetConnection("Connection");
        }

        public static SqlConnection GetConnection(string name)
        {
            string conn = ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();
            SqlConnection cn;
            cn = new SqlConnection(conn);
            cn.Open(); // It's not a good idea to open early, you should open right before it is needed

            return cn;
        }
    }
}
