using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["tip_korisnika"] = "";
            Session["ID"] = "";
            Session["USERNAME"] = "";
            Response.Redirect("index.html");
            //Response.Redirect("Home.html");


        }
    }
}