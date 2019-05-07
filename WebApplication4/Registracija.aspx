<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="WebApplication4.Registracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>

        .izgled{

            display:flex;
            justify-content:center;
            align-items:center;
            width:60px;
            height:35px;
            background-color:antiquewhite;
            color:black;
            margin-top:15px;
            cursor:pointer;


        }

        body{

            display:flex;
            justify-content:center;
            align-items:center;
            flex-direction:column;


        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="glavni">
        </div>
    </form>


    <script>

        document.getElementById("nazad").addEventListener("click", function () {


            history.back();


        })

    </script>
</body>
</html>
