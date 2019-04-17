using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace WebApplication4
{
    public partial class Zakazivanje : System.Web.UI.Page
    {

        public static DropDownList C1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"].ToString() == "")
            {

                Response.Redirect("novo_logovanje.aspx?value=zakazivanje");


            }

            else

            {

                if (!IsPostBack) // ako nije prvo(pocetno) loadovanje stranice onda izvrsavaj kod koji se nalazi u ovom if bloku!!!!!!!!
                {

                    C1 = DropDownList1;

                    DateTime novi = new DateTime();
                    novi = DateTime.Now;
                    Dictionary<string, string> datumi = new Dictionary<string, string>();
                    
                    


                    for (int i = 0; i < 15; i++)
                    {

                        string datumText = novi.Day.ToString().PadLeft(2, '0') + "." + novi.Month.ToString().PadLeft(2, '0') + "." + novi.Year.ToString().PadLeft(2, '0') + ".";
                        string datumValue = novi.Year.ToString().PadLeft(2, '0') + novi.Month.ToString().PadLeft(2, '0') + novi.Day.ToString().PadLeft(2, '0');

                        datumi.Add(datumText, datumValue);
                        novi = DateTime.Now.AddDays(i + 1);

                    }

                    DropDownList1.DataSource = datumi;
                    DropDownList1.DataTextField = "KEY";
                    DropDownList1.DataValueField = "VALUE";
                    DropDownList1.DataBind();

                    DropDownList1.Items.Insert(0, new ListItem("", "")); //rucno insertovanje itema u dropdown


                    string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
                    SqlConnection conn = new SqlConnection(CS);

                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM LOKACIJA", conn);
                    DataTable lokacije = new DataTable();
                    adapt.Fill(lokacije);


              

                    DropDownList2.DataSource = lokacije;
                    DropDownList2.DataTextField = "Naziv";
                    DropDownList2.DataValueField = "ID";
                    DropDownList2.DataBind();

                }



            }

           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {

                string datum = DropDownList1.SelectedValue;
                string vreme = DropDownList3.SelectedValue;
                string lokacija = DropDownList2.SelectedValue;

                string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
                SqlConnection conn = new SqlConnection(CS);

                SqlCommand komanda = new SqlCommand("INSERT INTO PODACI(DATUM,VREME,LOKACIJA,KORISNIK) VALUES(" + "'" + datum + "', " + "'" + vreme + "', " + lokacija + ", " + Session["ID"].ToString() + ")", conn); // Session["ID"]
                conn.Open();
                komanda.ExecuteNonQuery();
                conn.Close();
                moj.InnerHtml = Session["USERNAME"].ToString() + " je uspesno zakazao termin";

                Metoda();
                osveziTabelu();

            }

            else
            {


                moj.InnerHtml = "morate unesti datum i vreme zakazivanja!";
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Metoda(); //izabacuje slobodne termine

        }


        public void Metoda()
        {

            if (DropDownList1.SelectedValue != "")
            {

                DropDownList3.Items.Clear(); // ocisti sve iz liste sa terminima ako slucajno ima nesto

                string datum = DropDownList1.SelectedValue; // datumi
                string lokacija = DropDownList2.SelectedValue; //sport

                string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
                SqlConnection conn = new SqlConnection(CS);

                SqlDataAdapter adapt = new SqlDataAdapter("SELECT DATUM,VREME,LOKACIJA FROM PODACI WHERE DATUM = '" + datum + "'" + " AND LOKACIJA = " + lokacija, conn); // daj mi zakazane termin za izabrani dan i izabrani sport!
                DataTable termini = new DataTable();
                adapt.Fill(termini);  //tabela zauzetih termina!!!
                //   

                if (termini.Rows.Count == 0)// svi termini za izabrani datum su slobodni!!!
                {
                    TimeSpan vreme = new TimeSpan(9, 0, 0);
                    Dictionary<string, string> satnica = new Dictionary<string, string>();
                    satnica.Clear();

                    for (int j = 0; j < 13; j++)
                    {

                        string val = vreme.Hours + ":" + vreme.Minutes;
                        string text = vreme.Hours.ToString().PadLeft(2, '0');
                        satnica.Add(text, val);
                        TimeSpan razlika = new TimeSpan(1, 0, 0);
                        vreme = vreme.Add(razlika);

                    }

                    DropDownList3.DataSource = satnica;
                    DropDownList3.DataTextField = "KEY";
                    DropDownList3.DataValueField = "VALUE";
                    DropDownList3.DataBind();

                  //  osveziTabelu();


                }

                else
                {

                    TimeSpan vreme = new TimeSpan(9, 0, 0);
                    Dictionary<string, string> satnica = new Dictionary<string, string>();
                    satnica.Clear();
                    bool provera = true;

                    //  TimeSpan prov = (TimeSpan)termini.Rows[0][1];

                    for (int j = 0; j < 13; j++)
                    {

                        for (int k = 0; k < termini.Rows.Count; k++)
                        {

                            if ((TimeSpan)termini.Rows[k][1] == vreme)
                            {

                                provera = false; // kada nadje vrednost u tabeli zauzetih termins
                                break;


                            }

                            else
                            {


                                provera = true; // kada je termin slobodan
                            }

                        }
                        //  9:00

                        if (provera == true)
                        {

                            string val = vreme.Hours + ":" + vreme.Minutes;
                            string text = vreme.Hours.ToString().PadLeft(2, '0');
                            satnica.Add(text, val);
                            //TimeSpan razlika = new TimeSpan(1, 0, 0);
                            //vreme = vreme.Add(razlika);

                        }

                        TimeSpan razlika = new TimeSpan(1, 0, 0);
                        vreme = vreme.Add(razlika);


                    }

                  //filtriranje termina i popunjavanje dropdown-a sa slobodnim terminima
                    DropDownList3.DataSource = satnica;
                    DropDownList3.DataTextField = "KEY";
                    DropDownList3.DataValueField = "VALUE";
                    DropDownList3.DataBind();

                //    osveziTabelu();


                }

            }

            else
            {

                DropDownList3.Items.Clear();

            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            // svi termini za id trenutno ulogovanog!

            //termini.InnerHtml = "";

            //DateTime danasnji = DateTime.Now;
            //string sqlDatum = danasnji.Year.ToString() + danasnji.Month.ToString().PadLeft(2, '0') + danasnji.Day.ToString().PadLeft(2, '0');


            //string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
            //SqlConnection conn = new SqlConnection(CS);

            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT PODACI.ID,Datum, Vreme,Lokacija.NAZIV,Korisnik,Lokacija.Cena FROM PODACI INNER JOIN LOKACIJA ON LOKACIJA.ID = PODACI.LOKACIJA WHERE Korisnik = " + Session["ID"].ToString() + " AND Datum >= '" + sqlDatum + "'", conn);
            //DataTable lista = new DataTable();
            //adapter.Fill(lista);

            ////DataTableReader citac = lista.CreateDataReader();
            ////while (citac.HasRows)
            ////{

            ////    termini.InnerHtml += "<div>" + citac[1].ToString() + "   " + citac[2].ToString() + "    " + citac[3].ToString();



            ////}
            //int suma = 0;

            //for(int i = 0; i < lista.Rows.Count; i++)
            //{
            //    suma += (int)lista.Rows[i][5];

            //    DateTime trenutni = Convert.ToDateTime(lista.Rows[i][1]);
            //    string datum = trenutni.Day.ToString().PadLeft(2, '0') + "." + trenutni.Month.ToString().PadLeft(2, '0') + "." + trenutni.Year.ToString();
            //    // termini.InnerHtml += "<div>" + lista.Rows[i][1].ToString() + "   " + lista.Rows[i][2].ToString() + "    " + lista.Rows[i][3].ToString();
            //    termini.InnerHtml += "<div>" + datum + "   " + lista.Rows[i][2].ToString() + "    " + lista.Rows[i][3].ToString() + "  Cena je  " + lista.Rows[i][5].ToString() + "<button id= '" + lista.Rows[i][0].ToString() + "'" + " class='dugme'" + " onclick='" + "poziv(this)" + "'" + ">Obrisi</button></div>";
            //   // termini.InnerHtml += "<div class>" + datum + "   " + lista.Rows[i][2].ToString() + "    " + lista.Rows[i][3].ToString() + "  Cena je  " + lista.Rows[i][5].ToString() + "<button id= '" + lista.Rows[i][0].ToString() + "'" + " class='dugme'" + " onclick='" + "poziv(this)" + "'" + ">Obrisi</button></div>";


            //}

            //termini.InnerHtml += "<div>Vasa ukupna suma je " + suma + "</div>";


            //  termini.InnerHtml += "<div>" + citac[1].ToString() + "   " + citac[2].ToString() + "    " + citac[3].ToString();
            osveziTabelu();
            Metoda();

        }

        public void osveziTabelu()
        {

            termini.InnerHtml = "";

            DateTime danasnji = DateTime.Now;
            string sqlDatum = danasnji.Year.ToString() + danasnji.Month.ToString().PadLeft(2, '0') + danasnji.Day.ToString().PadLeft(2, '0');


            string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
            SqlConnection conn = new SqlConnection(CS);

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT PODACI.ID,Datum, Vreme,Lokacija.NAZIV,Korisnik, Lokacija.Cena FROM PODACI INNER JOIN LOKACIJA ON LOKACIJA.ID = PODACI.LOKACIJA WHERE Korisnik = " + Session["ID"].ToString() + " AND Datum >= '" + sqlDatum + "'", conn);
            DataTable lista = new DataTable();
            adapter.Fill(lista);

            //DataTableReader citac = lista.CreateDataReader();
            //while (citac.HasRows)
            //{

            //    termini.InnerHtml += "<div>" + citac[1].ToString() + "   " + citac[2].ToString() + "    " + citac[3].ToString();



            //}

            int suma = 0;

            for (int i = 0; i < lista.Rows.Count; i++)
            {

                //if (i == 0)
                //{

                //    termini.InnerHtml += "<div>

                suma += (int)lista.Rows[i][5];
                //}

                DateTime trenutni = Convert.ToDateTime(lista.Rows[i][1]);
                string datum = trenutni.Day.ToString().PadLeft(2, '0') + "." + trenutni.Month.ToString().PadLeft(2, '0') + "." + trenutni.Year.ToString();
                // termini.InnerHtml += "<div>" + lista.Rows[i][1].ToString() + "   " + lista.Rows[i][2].ToString() + "    " + lista.Rows[i][3].ToString() + "<button id= '" + lista.Rows[i][0].ToString() + "'" + " onclick='" + "poziv(this)" + "'" + ">Obrisi</button></div>";
                // termini.InnerHtml += "<div>" + datum + "   " + lista.Rows[i][2].ToString() + "    " + lista.Rows[i][3].ToString() + "<button id= '" + lista.Rows[i][0].ToString() + "'" + " class='dugme'" + " onclick='" + "poziv(this)" + "'" + ">Obrisi</button></div>";
                termini.InnerHtml += "<div class='stavka'>" + "<div class='detalj'>" + datum + "</div>" + "<div class='detalj'>" + lista.Rows[i][2].ToString() + "</div>" + "<div class='detalj'>" + lista.Rows[i][3].ToString() + "</div>" + "<div class='detalj'>" + "Cena je " + lista.Rows[i][5].ToString() + " dinara" + "</div>" + "<div class='detalj'>" + "<button id= '" + lista.Rows[i][0].ToString() + "'" + " class='dugme'" + " onclick='" + "poziv(this)" + "'" + ">Obrisi</button>" + "</div>" + "</div>";

            }

            termini.InnerHtml += "<div>Vasa ukupna suma je " + suma + "</div>";


            //  termini.InnerHtml += "<div>" + citac[1].ToString() + "   " + citac[2].ToString() + "    " + citac[3].ToString();

        }

        [WebMethod]
        public static void ObrisiTermin(string id)
        {

            //string provera = id;
            //string provera1 = id;


            string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
            SqlConnection conn = new SqlConnection(CS);
            SqlCommand brisi = new SqlCommand("DELETE FROM PODACI WHERE ID = " + id, conn);
            conn.Open();
            brisi.ExecuteNonQuery();
            conn.Close();

        }
    }
}