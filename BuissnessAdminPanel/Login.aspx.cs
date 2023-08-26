using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace BuissnessAdminPanel
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["CON"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("adminlogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Username", txtusername.Text);
            cmd.Parameters.AddWithValue("Password", txtpassword.Text);
            conn.Open ();
            int usercount=(Int32) cmd.ExecuteScalar();
            if (usercount==1)
            {
                Response.Redirect("ContactDetailTable.aspx");
            }
            else
            {
                lblmsg.Text = "Invalid Username And Password";
            }

        }
    }
}