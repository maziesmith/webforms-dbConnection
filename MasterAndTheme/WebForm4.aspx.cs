using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MasterAndTheme
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = Northwind");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            Label1.Text = "No error message";
        }

        public void ShowMyData()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }

            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sqlsel = "Select top 10 * from products";
            ShowMyData();
        }
    }
}