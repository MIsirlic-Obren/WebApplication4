<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zakazivanje.aspx.cs" Inherits="WebApplication4.Zakazivanje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    <title>Sportski Centar </title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>


        <style>

        .dugme{

            background-color:red;
            color:blue;


        }
        #termini{

            width:100%;
            display:flex;
            margin:auto;
            flex-direction:column;
            justify-content:center;
            align-items:center;

        }

        .stavka{

           width:60%;
           display:flex;
           justify-content:center;
           align-items:center;


        }

        .detalj{

            width:25%;
            display:flex;
           justify-content:center;
           align-items:center;
        }


        /*.Prostor
        {

            width:100%;
            height:500px;
                     
        }*/

    </style>



</head>



<body>
        <div class="container-fluid   bg-primary text-light">
        <div class="row justify-content-between ">
            <div class="col-md-6-h1 col-sm-8 col-12">
                <h1> <img src="YE6LLW3.jpg" class="img-fluid" alt="" width='200'/> CENTAR SPORTA-ZAKAZIVANJE</h1>
            </div>
           <div class="col-md-2">
            <span class="navbar-text ">
                <a href="Logout.aspx" class="text-light btn btn-primary"><span class="glyphicon glyphicon-user"> </span> Log out</a>
            </span>
        </div>
        </div>
    </div>

     <div class="row bg-dark">
        <div class="col-md-12">


            <nav class="navbar navbar-expand-lg navbar-light bg-light">

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav mr-auto">
                         <li class="nav-item active">
                            <a class="nav-link text-dark" href="Home.html">HOME</a>
                        </li>
                       <%-- <li class="nav-item active">
                            <a class="nav-link text-dark" href="O nama.html">O NAMA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" href="Kontakt i  lokacija.html">KONTAKT I LOKACIJA</a>
                        </li>--%>
                      <%--  <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-dark " href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                NASA PONUDA
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">

                                <a class="dropdown-item" href="Baloni_za_fudbal.html">BALONI ZA FUDBAL</a>
                                <a class="dropdown-item" href="Teretane.html">TERETANE</a>
                                <a class="dropdown-item" href="Bazen.html">BAZENI</a>
                                <a class="dropdown-item" href="TereniZaKosarku.html">TERENI ZA KOSARKU</a>
                            </div>
                        </li>--%>
                    </ul>
                </div>
            </nav>
            </div>
         </div>


    <form id="form1" runat="server">
        <div>

  <div>
                <label>IZABERI SPORT</label>    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>   
            <label>IZABERI DATUM</label>   <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

           <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>


              <label>IZABERI SLOBODAN TERMIN</label> 
              <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                       <div id="moj" runat="server"></div>

            <%--    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>--%>


           
            <asp:Button ID="Button1" runat="server" Text="ZAKAZI TERMIN!" OnClick="Button1_Click" />

             <asp:Button ID="Button2" runat="server" Text="PRIKAZI ZAKAZANE TERMINE" OnClick="Button2_Click" />


             </div>



        </div>
    </form>

    
<%--    <div class="Prostor"></div>--%>
     <div id="termini" runat="server">
         


      </div>


          <script>

              function poziv(element) {

                 

                  var id = element.getAttribute("id");
                  $.ajax({
                      url: "Zakazivanje.aspx/ObrisiTermin",
                      method: "POST",
                      contentType: "application/json; charset=utf-8",  //OBAVEZAN DEO AJAXA KADA SE RADI SA WEB METODOM DA METODA ZNA KOJU VRDTU PODATKA PRIMA
                      data: JSON.stringify({ id: id }), // F-JA KOJA PRETVARA JAVASCRIPT OBJEKAT U TEKST {PARAMETAR, VREDNOST} RAZLIKUJE DA LI MU PROSLEDJUJEMO STRING ILI BROJ
                      success: function (result) {

                          alert("radi");

                          document.getElementById("Button2").click();
                          document.getElementById("DropDownList1").selectedIndex = 0;


                      },
                      error: function () {

                          alert("ne radi");


                      }

                  })


              }





        </script>

    
    <footer class="container-fluid text-center fixed-bottom bg-dark text-light">
        <p style="margin-bottom:0px">    &copy Obren Misirlíć</p>
    </footer>
</body>
</html>
