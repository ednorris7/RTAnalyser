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


            if (value >= 90)
            {
                Alg1(value3);
            }
            else if (value >= 75)
            {
                Alg2(value3);
            }
            else if (value >= 60)
            {
                Alg3(value3);
            }
            else if (value >= 50)
            {
                Alg4(value3);
            }
            else
            {
                Alg5(value3);
            }

        }

        protected void Alg1(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Certified Banger";
            }
            else if (value3 <= 10)
            {
                analysis = "Very good movie";
            }
            else if (value3 <= 20)
            {
                analysis = "Pretty good movie";
            }
            else if (value3 <= 30)
            {
                analysis = "Leaning towards artsy";
            }
            else if (value3 > 30)
            {
                analysis = "This movie is either extremely artsy or it's been review bombed";
            }
        }

        protected void Alg2(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Really good movie";
            }
            else if (value3 <= 10)
            {
                analysis = "An unbelievably mid movie or cult classic";
            }
            else if (value3 <= 20)
            {
                analysis = "It's a coin toss. This movie is either the greatest film of all time or the biggest snooze fest your ever likely to experience";
            }
            else if (value3 <= 30)
            {
                analysis = "TRUST ME THIS MOVIE IS AMAZING";
            }
            else if (value3 > 30)
            {
                analysis = "This movie is highly likely to be terrible don't watch";
            }
        }

        protected void Alg3(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Average movie";
            }
            else if (value3 <= 10)
            {
                analysis = "Some pleasure will be had watching this";
            }
            else if (value3 <= 20)
            {
                analysis = "Masterpiece right here, watch it now";
            }
            else if (value3 <= 30)
            {
                analysis = "Masterpiece or Terrible. It should be evident which one after looking at the trailer";
            }
            else if (value3 > 30)
            {
                analysis = "If you like fast and furious this shit gonna be fire";
            }
        }

        protected void Alg4(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Bad movie, don't watch";
            }
            else if (value3 <= 10)
            {
                analysis = "This movie is definitley not good in any possible way";
            }
            else if (value3 <= 20)
            {
                analysis = "This movie will be a 10/10 trust me";
            }
            else if (value3 <= 30)
            {
                analysis = "A dumb movie that could be alot of fun";
            }
            else if (value3 > 30)
            {
                analysis = "If the audience score is higher this movie is for sure alot of dumb fun";
            }
        }

        protected void Alg5(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Terrible movie";
            }
            else if (value3 <= 10)
            {
                analysis = "Awful movie";
            }
            else if (value3 <= 20)
            {
                analysis = "Most Likely an abhorrent viewing experience";
            }
            else if (value3 <= 30)
            {
                analysis = "Terrible or average, don't watch either way";
            }
            else if (value3 > 30)
            {
                analysis = "Dumb box office movie that critics hate and audience love, if you like those kinda movies then go right ahead";
            }
        }
    }

}