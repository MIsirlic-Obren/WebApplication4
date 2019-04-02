using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string novoime = Request.QueryString["name"];
            //string novoprezime = Request.QueryString["lastname"];

            //string novoprezime1 = Request.QueryString["lastname"];


            string korisnik = Request.Form["korisnik"];
            string lozinka = Request.Form["lozinka"];
            string ime = Request.Form["ime"];
            string prezime = Request.Form["prezime"];
            string email = Request.Form["mejl"];


            string CS = ("Data Source=DESKTOP-EU3VD12;Initial Catalog=korisnici;Integrated Security=True;MultipleActiveResultSets=True");
            SqlConnection conn = new SqlConnection(CS);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT USERNAME, EMAIL FROM PODACI WHERE username = " + "'" + korisnik + "'" + " OR email = " + "'" + email + "'", conn);


            DataTable tabela = new DataTable();
            adapt.Fill(tabela);


            if (tabela.Rows.Count == 0)
            {

                SqlCommand komanda = new SqlCommand("INSERT INTO PODACI(username,lozinka,ovlascenja,email) VALUES(" + "'" + korisnik + "','" + lozinka + "', 2, " + "'" + email + "'" + ")", conn);
                conn.Open();
                komanda.ExecuteNonQuery();
                conn.Close();
                Response.Write("unos uspesan");


            }

            else
            {

                bool provera = true;
                for (int i = 0; i < tabela.Rows.Count; i++)
                {

                    if (tabela.Rows[i][1].ToString() == email)
                    {
                        provera = false;
                        // Response.Redirect('index.html?odgovor:negativan')


                        break;


                    }



                }

                if (provera)
                {

                    Response.Write("postoji korisnik sa tim username-om");
                    Response.Write("<a href=" + "'index.html'" + ">klikni</a>");
                    ////Response.Redirect("index.html");
                }


            }






        }
    }
}