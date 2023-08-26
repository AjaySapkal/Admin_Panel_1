using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace BuissnessAdminPanel
{
    public partial class ContactDetailTable : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CON"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            displayRecords();

        }
        protected void Button1_Click(Object sender, EventArgs e)
        {
            
           string id =(((sender as LinkButton).NamingContainer.FindControl("label1") as Label).Text);
            SqlCommand cmd = new SqlCommand("deleterecordsfromtblcontact", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            displayRecords();

        }
        void displayRecords()
        {
            SqlCommand cmd = new SqlCommand("displaycontactdetail", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptContactDetails.DataSource = dt;
            rptContactDetails.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("searchrecord", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Email",txtsearchemail.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptContactDetails.DataSource = dt;
            rptContactDetails.DataBind();

        }
    }
}