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
    public partial class Zakazivanje : System.Web.UI.Page
    {
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

                    DropDownList1.Items.Insert(0, new ListItem("", ""));


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


            }

            else
            {


                moj.InnerHtml = "morate unesti datum i vreme zakazivanja!";
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Metoda();

        }


        public void Metoda()
        {

            if (DropDownList1.SelectedValue != "")
            {

                DropDownList3.Items.Clear(); // ocisti sve iz liste sa terminima ako slucajno ima nesto

                string datum = DropDownList1.SelectedValue;
                string lokacija = DropDownList2.SelectedValue;

                string CS = ("Data Source=LAPTOP-6RQ2FFD7\\SQLEXPRESS;Initial Catalog=FITNESS;Integrated Security=True;MultipleActiveResultSets=True");
                SqlConnection conn = new SqlConnection(CS);

                SqlDataAdapter adapt = new SqlDataAdapter("SELECT DATUM,VREME,LOKACIJA FROM PODACI WHERE DATUM = '" + datum + "'" + " AND LOKACIJA = " + lokacija, conn); // daj mi zakazane termin za izabrani dan i izabrani sport!
                DataTable termini = new DataTable();
                adapt.Fill(termini);
                //   

                if (termini.Rows.Count == 0)
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

                                provera = false;
                                break;


                            }

                            else
                            {


                                provera = true;
                            }

                        }


                        if (provera)
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

                    DropDownList3.DataSource = satnica;
                    DropDownList3.DataTextField = "KEY";
                    DropDownList3.DataValueField = "VALUE";
                    DropDownList3.DataBind();


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
    }
}