<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TP_Final_Benitez.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link href="Styles/Dashboard.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="ticket-sumario">
                <ul class="ticket-summario-board">
                    <li class="score-cards"><a class="a-cards" href="#">Sin Resolver</a></li>
                    <li class="score-cards"><a class="a-cards" href="#">Abiertos</a></li>
                    <li class="score-cards"><a class="a-cards" href="#">En espera</a></li>
                    <li class="score-cards"><a class="a-cards" href="#">No asignados</a></li>

                </ul>
            </div>
        </div>
    </form>
</body>
</html>
