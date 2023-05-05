using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigMovies
{
    public partial class _Default : System.Web.UI.Page
    {
        public string analysis;

        protected void SearchDatabase(string searchCriteria)
        {
            Alg.Visible= true;
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT * FROM Movies WHERE Movie LIKE @searchCriteria";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();



            GridView1.DataSource = reader;
            GridView1.DataBind();

            int rowCount = GridView1.Rows.Count;

            if (rowCount == 0)
            {
                Alg.Visible = false;
            }
            else
            {
                Alg.Visible = true;
            }

            conn.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCriteria = txtSearch.Text;

            SearchDatabase(searchCriteria);
            
        }

        protected void alg_Click(object sender, EventArgs e)
        {
            string searchCriteria = txtSearch.Text;

            Analyse(searchCriteria);
        }

        protected void Analyse(string searchCriteria)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT [Critic Score] FROM Movies WHERE Movie LIKE @searchCriteria";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            conn.Open();

            object result = cmd.ExecuteScalar();
            int value = (int)result;
            conn.Close();

            string connnStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connn = new SqlConnection(connnStr);
            string sqll = "SELECT [Audience Score] FROM Movies WHERE Movie LIKE @searchCriteria";
            SqlCommand cmmd = new SqlCommand(sqll, connn);
            cmmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            connn.Open();

            object result2 = cmmd.ExecuteScalar();
            int value2 = (int)result2;
            connn.Close();

            int value3 = Math.Abs(value2 - value);

            var n = new Algorithm();


            if (value >= 90)
            {
                analysis = n.Alg1(value3);
            }
            else if (value >= 75)
            {
                analysis = n.Alg2(value3);
            }
            else if (value >= 60)
            {
                analysis = n.Alg3(value3);
            }
            else if (value >= 50)
            {
                analysis = n.Alg4(value3);
            }
            else
            {
                analysis = n.Alg5(value3);
            }

        }


    }

}