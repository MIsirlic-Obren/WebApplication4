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
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string korisnik = Request.Form["user"];
            string lozinka = Request.Form["lozinka"];
            string ime = Request.Form["ime"];
            string prezime = Request.Form["prezime"];
            string email = Request.Form["email"];


            string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
            SqlConnection conn = new SqlConnection(CS);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM KORISNIK WHERE username = " + "'" + korisnik + "'" + " OR mejl = " + "'" + email + "'", conn);


            DataTable tabela = new DataTable();
            adapt.Fill(tabela);


            if (tabela.Rows.Count == 0)
            {

                SqlCommand komanda = new SqlCommand("INSERT INTO KORISNIK(username,lozinka,ovlascenje,mejl,ime,prezime) VALUES(" + "'" + korisnik + "','" + lozinka + "', 2, " + "'" + email + "', '" + ime + "', " + "'" + prezime + "'" +  ")", conn);
                conn.Open();
                komanda.ExecuteNonQuery();
                conn.Close();

                //Response.Write("unos uspesan");

                SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * FROM KORISNIK WHERE username = " + "'" + korisnik + "'" + " OR mejl = " + "'" + email + "'", conn);
                DataTable tabela2 = new DataTable();
                adapt1.Fill(tabela2);

                Session["tip_korisnika"] = tabela2.Rows[0][6].ToString();
                Session["ID"] = tabela2.Rows[0][0].ToString();
                Session["USERNAME"] = tabela2.Rows[0][1].ToString();

                Response.Redirect("Home.html");



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
                   // Response.Write("<a href=" + "'index.html'" + ">klikni</a>");
                    ////Response.Redirect("index.html");
                }


            }






        }
    
    }
}