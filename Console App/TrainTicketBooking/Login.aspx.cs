using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainBooking.DataAccess;

namespace TrainTicketBooking
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string UserName = TextBox1.Text;
            string Password = TextBox2.Text;

            UserDetailDataAccess userDetailDataAccess = new UserDetailDataAccess();

            bool exists = userDetailDataAccess.AuthenticateUser(UserName, Password, out string validationmessage);
            if (exists)
            {
                Session["UserName"] = UserName;
                Response.Redirect("DefaultGridView.aspx");
            }
            else
            {
                Label1.Text = validationmessage;
            }
        }
    }
}