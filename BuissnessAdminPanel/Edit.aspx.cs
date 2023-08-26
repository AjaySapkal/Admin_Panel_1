using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BuissnessAdminPanel
{
    public partial class Edit : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CON"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                string id = Request.QueryString["Id"];
                Session["contactid"] = id;
                SqlCommand cmd = new SqlCommand("editrecords", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                conn.Open();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string name = ds.Tables[0].Rows[0]["Name"].ToString();
                    string email = ds.Tables[0].Rows[0]["Email"].ToString();
                    string phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    string comment = ds.Tables[0].Rows[0]["Comments"].ToString();

                    txtname.Text = name;
                    txtemail.Text = email;
                    txtphone.Text = phone;
                    txtmsg.Text = comment;
                }
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string idd = Session["contactid"].ToString();
            SqlCommand cmd = new SqlCommand("updaterecord", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", idd);
            cmd.Parameters.AddWithValue("Name", txtname.Text);
            cmd.Parameters.AddWithValue("Email",txtemail.Text);
            cmd.Parameters.AddWithValue("Phone", txtphone.Text);
            cmd.Parameters.AddWithValue("Comments", txtmsg.Text);
            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k!=0)
            {
                Response.Redirect("ContactDetailTable.aspx");
            }
            else
            {
                lblerr.Text = "Somthing went wrong please try after sometime";
                conn.Close();
            }

        }
    }


}