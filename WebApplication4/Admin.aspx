<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>

<!doctype html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>

    <style>
        /*.dropdown-menu {
            display: "none" display:"block";
        }*/

        .nevidljiv{
            display:none;
        }
    </style>

    <title>Sportski Centar </title>



</head>
<body>
    <div class="container-fluid" style="background-color: #e3f2fd">
        <div class="row">
            <div class="col-md-6-h1 col-sm-8 col-12">
                <h1> <img src="YE6LLW3.jpg" class="img-fluid" alt="" width='200'> CENTAR SPORTA</h1>
            </div>
        </div>
    </div>

    <div class="container-fluid bg-grey text-center ">
        <div class="row">

            <div class="col-md-12  navbar navbar-expand-lg navbar navbar-light " style="background-color: #e3f2fd" >
                <div class= "col-md-10 text-left"> <h1>WELCOME TO ADMIN PAGE</h1> </div>

             <div class="col-md-2">
               <span class="navbar-text">
                 <a href="Logout.aspx" class="text-light btn btn-primary"><span class="glyphicon glyphicon-user"> </span> Log out</a>
                </span>
            </div>

            </div>

        </div>
    </div>

    <div class="container">
        <div class="row">

        

    <form id="form1" runat="server">


        <asp:Label ID="Label2" runat="server" Text="Label">IZABERI KATEGORIJU</asp:Label>


        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        

             <span class="navbar-text">
                            <input type="button" value="Prikaži panel za izmenu" onclick="return false" id="dugme" /></span><div class="col-sm-offset-2 col-sm-10">
                            &nbsp;</div>


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

          <div id="cena" runat="server"></div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>



        <div class="nevidljiv" id="sakriven"> 
            <asp:Label ID="Label1" runat="server" Text="Label"> Unesi novu cenu</asp:Label>

          <input type="number" id="novaCena"  runat="server"/>

          <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />

        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                  <div id="napomena" runat="server">
        </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


      


    </form>

            </div>
        </div>

   



<%--        <footer class="container-fluid text-center bg-dark text-light futer">
        <p style="margin-bottom:0px">  &copy Obren Misirlíć</p>
    </footer>--%>

    <script>    
        document.getElementById("dugme").addEventListener("click", function () {

            //alert("radi");

            if (document.getElementById("sakriven").classList.contains("nevidljiv")) {

                document.getElementById("sakriven").classList.remove("nevidljiv");
                this.value = "zatvori panel za izmenu";

            }
            else
            {

                document.getElementById("sakriven").classList.add("nevidljiv");
                this.value = "otvori panel za izmenu";
            }



        })

    </script>


</body>
</html>