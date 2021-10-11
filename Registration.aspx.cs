using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtCPassword.Text)
            {
                string query = @"INSERT INTO [dbo].[tblUser]
                                             ([UserName]
                                            ,[EmailID]
                                            ,[Password]
                                          ,[CreatedDatetime])
                                        VALUES
                                        (@UserName, @EmailID,@Password,GETDATE())";
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 600;
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                conn.Open();
                int i = (int)cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                Response.Write("Password and confirm password didn't match");
            }
        }
    }
}