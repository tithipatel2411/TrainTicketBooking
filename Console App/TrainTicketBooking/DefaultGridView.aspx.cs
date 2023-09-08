using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainBooking.DataAccess;

namespace TrainTicketBooking
{
    public partial class DefaultGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //using coonection string here
            //SqlConnection sqlConnection = ConnectionString.GetConnection();
            ////SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from UserDetail", sqlConnection);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();

            // use connection string in dataacces file
            UserDetailDataAccess userDetailDataAccess = new UserDetailDataAccess();
            
            Repeater1.DataSource = userDetailDataAccess.GetData();
            Repeater1.DataBind();





        }

    }
}