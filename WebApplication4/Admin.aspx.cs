using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication4
{
	public partial class Admin : System.Web.UI.Page
	{

        Dictionary<string, string> recnik = new Dictionary<string, string>();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["tip_korisnika"].ToString() != "1")
            {
                Response.Redirect("Home.html");
            }

            else
            {
                if (!IsPostBack)
                {
                    string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
                    SqlConnection conn = new SqlConnection(CS);
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM LOKACIJA", conn);
                    DataTable da = new DataTable();
                    adapt.Fill(da);

                    DropDownList1.DataSource = da;
                    DropDownList1.DataTextField = "Naziv";
                    DropDownList1.DataValueField = "ID";
                    DropDownList1.DataBind();

                    DropDownList1.Items.Insert(0, new ListItem("", ""));

                    for(int i = 0; i < da.Rows.Count; i++)
                    {

                        recnik.Add(da.Rows[i]["ID"].ToString(), da.Rows[i]["Cena"].ToString());


                    }

                    Session["recnik"] = recnik;

                }

                

         
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //uraditi verziju sa selektom iz baze na izbor iz dropdown-a!!!!

            cena.InnerHtml = "";

            if (DropDownList1.SelectedValue != "")
            {

                
                Dictionary<string, string> novi = (Dictionary<string, string>)Session["recnik"];

                string cena1 = novi[DropDownList1.SelectedValue];
                cena.InnerHtml = "Trenutna cena je " + cena1;



            }

      


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            napomena.InnerHtml = "";
            string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");

            string sport = DropDownList1.SelectedValue;
            string novacena = novaCena.Value;
            if (novacena != "" && sport != "")
            {
                SqlConnection conn = new SqlConnection(CS);
                SqlCommand komanda = new SqlCommand("UPDATE LOKACIJA SET Cena= " + novacena + " WHERE id =" + sport, conn);
                conn.Open();
                komanda.ExecuteNonQuery();
                conn.Close();

                cena.InnerHtml = "Uspesno ste izmenili cenu. Nova cena je: " + novacena;
            }
            else
            {
                napomena.InnerHtml = "morati odabrati kategoriju i uneti vrednost";
            }
           
        }

    }
}