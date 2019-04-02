﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>

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
    </style>

    <title>Sportski Centar </title>



</head>
<body>
    <div class="container-fluid bg-dark text-light divHeader">
        <div class="row">
            <div class="col-md-6-h1 col-sm-8 col-12">
                <h1> <img src="YE6LLW3.jpg" class="img-fluid" alt="" width='200'> CENTAR SPORTA</h1>
            </div>
        </div>
    </div>

    <div class="row bg-dark">
        <div class="col-md-12">
            <nav class="navbar navbar-expand-lg navbar-dark text-light">

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-light " href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                NASA PONUDA
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">

                                <a class="dropdown-item" href="Baloni_za_fudbal.html">BALONI ZA FUDBAL</a>
                                <a class="dropdown-item" href="Teretane.html">TERETANE</a>
                                <a class="dropdown-item" href="Bazen.html">BAZENI</a>
                                <a class="dropdown-item" href="TereniZaKosarku.html">TERENI ZA KOSARKU</a>
                            </div>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="O nama.html">O NAMA</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="Kontakt i  lokacija.html">KONTAKT I LOKACIJA</a>
                        </li>
                    </ul>
                </div>

            </nav>
        </div>
    </div>
 

    <div class="container">
        <div class="row">

            <div class="col-12 text-left text-dark  ">
                <div> <h1>DOBRODOSLI</h1> </div>
                <div class="jumbotron p-3 mb-2 bg-light text-dark">
                    <p>
                        Dobrodosli na nasu stranicu gde cemo vas upoznati sa nasim radom,
                        rezultatima i uspesima. Hvala sto ste posetili nas sajt, nadamo se da smo zadobili vase poverenje
                        i da cete uzivati u nasem radu.
                    </p>

                </div>
            </div>
        </div>
    </div>


        <div class="container-fluid bg-grey">
            <div class="row">
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-globe logo"></span>
                </div>
                <div class="col-sm-4">
                    <h2>STA MOZETE DA OCEKUJETE OD NAS</h2>
                    <br>
                    <h4><strong>NASA MISIJA:</strong> Je vase zdravlje </h4>
                    <h4><strong>NASA VIZIJA:</strong> Zdraviji svet</h4>
                </div>
            </div>
        </div>
        <br>
        <br>

        <div class="container-fluid text-center">
            <h2>USLUGE</h2>
            <h4>Sta mi nudimo</h4>
            <br>
            <div class="row">
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-off"></span>
                    <h4>SNAGU</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-heart"></span>
                    <h4>POSVECENOST</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-lock"></span>
                    <h4>ZAVRSEN POSAO</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
            </div>
            <br><br>
            <div class="row">
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-leaf"></span>
                    <h4>ZDRAVLJE</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
                <div class="col-sm-4">
                    <span class= "glyphicon glyphicon-certificate"></span>
                    <h4>OBUCENE TRENERE</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
                <div class="col-sm-4">
                    <span class="glyphicon glyphicon-wrench"></span>
                    <h4>NAPORAN RAD I MNOGO ZNOJA</h4>
                    <p>Lorem ipsum dolor sit amet..</p>
                </div>
            </div>
        </div>


        <footer class="container-fluid text-center fixed-bottom bg-dark text-light">
            <p>  www.steroid@gmail.com</p>
        </footer>

</body>
</html>