<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo_logovanje.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    <title>Sportski Centar </title>
    <style>
        .btn btn-default {
        }
    </style>
</head>
<body>
    <div class="container-fluid bg-dark text-light divHeader">
        <div class="row">
            <div class="col-md-6-h1 col-sm-8 col-12">
                <h1> <img src="" class="img-fluid" alt="" width=200> Sportski centar</h1>


            </div>
        </div>


        <div class="row bg-dark d-flex align-items-start">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link text-light" href="index.html">POCETNA</a>
                </li>
            </ul>

        </div>
    </div>
   

    <div class="container">
        <div class="row">

           

                <div class="col-6 text-left text-dark  ">

                    <div> <h1>Login</h1> </div>

                    <div class="jumbotron p-3 mb-2 bg-light text-dark">

                        <form id=form1 runat="server">
                            <div class="form-group">

                                <label for="usr">e-mail:</label>
                               <%-- <input type="text" class="form-control" id="usr" name="korisnik" />--%>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                            <label for="pwd">Password:</label>
                                <%--<input type="password" class="form-control" id="pwd" name="lozinka" />--%>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-sm-offset-2 col-sm-10">
                                <%--<input type="submit" value="submit" class="btn btn-primary" />--%>
                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

                            </div>
                        </form>

                    </div>

            </div>




        </div>
        <div class="row">
            <div class="col-6 text-left text-dark  ">
                <p> Ako niste clan onda se prvo prijavitee</p>
                <a href="Registracija.html"> Odvedi me na stranu za Sign-up</a>

            </div>
        </div>
    </div>
</body>
</html>
