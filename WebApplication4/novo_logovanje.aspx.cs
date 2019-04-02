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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tip_korisnika"].ToString() == "Admin")
            {


                Response.Redirect("Admin.aspx");


            }

            else if (Session["tip_korisnika"].ToString() == "User")
                {


                    Response.Redirect("Home.html");


                }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //string kori = Request.Form["korisnik"];
            //string pass = Request.Form["lozinka"];


            string kori = TextBox1.Text;
            string pass = TextBox2.Text;

            string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=KORISNICI;Integrated Security=True;MultipleActiveResultSets=True");
            SqlConnection conn = new SqlConnection(CS);

            SqlDataAdapter ADAPT = new SqlDataAdapter("SELECT PODACI.ID, USERNAME, LOZINKA, OVLASCENJA.NAZIV, EMAIL FROM PODACI INNER JOIN OVLASCENJA ON OVLASCENJA.ID = PODACI.OVLASCENJA WHERE USERNAME = " + "'" + kori + "'" + " OR EMAIL = " + "'" + kori + "'", conn);
            DataTable tabela = new DataTable();
            ADAPT.Fill(tabela);

            if (tabela.Rows.Count == 0)
            {
                Response.Write("pogresan username ili email");

            }

            else
            {

                if (tabela.Rows[0]["LOZINKA"].ToString() == pass) // koloni mozes da pristupis ili preko broja kolone ili preko imena kolone, on pamti ime kolone iz SQL-a u ovoj tabeli u C#      dakle table.Rows[0][2] ili table.Rows[0]["LOZINKA"]  daju istu stvar tj lozinku u ovom slucaju
                {

                    Response.Write("korisnik postoji");

                    //provera za admina, usera
                    Session["tip_korisnika"] = tabela.Rows[0][3].ToString();

                    if (tabela.Rows[0][3].ToString() == "Admin")
                    {
                        //Session["korisnik"] = kori;
                        
                        Response.Redirect("Admin.aspx"); //ako se admin ulogovao posalji ga na admin stranu
                        

                    }


                    else
                    {
                        //Session["korisnik"] = kori;
                        Response.Redirect("Home.html"); // ako se user ulogovao posalji ga na user stranu
                        
                    }


                }


                else
                {

                    Response.Write("pogresan password");

                }


            }


        }
    }
}