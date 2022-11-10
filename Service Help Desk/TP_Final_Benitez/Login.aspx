<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Final_Benitez.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link href="Styles/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Sistema de ticket</h1>
            <nav>
                <div>
                    Bienvenido
                </div>
                <b>
                    <a href="#">Iniciar Sesion</a>
                </b>
                <b>
                    <a href="#">Registrarse</a>
                </b>
            </nav>
        </header>
        <div class="container">
            <div>
                <h2>Iniciar sesión en el portal de asistencia</h2>
                <p>Introduce los datos que utilizaste para registrarte con nosotros:</p>
                <div>
                    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                    <div>
                        <asp:Button Text="Login" CssClass="btn btn-primary" runat="server" />
                    </div>
                </div>
            </div>
            <div>
                <h2>Registrese</h2>
                <div>
                    <a href="#" class="btn btn-primary">Registrese con nosotros</a>
                </div>
                <div>
                    <p>Cuando se registre, tendrá acceso completo a nuestro portal de autoservicio y podrá utilizar su cuenta para crear tickets de soporte y realizar un seguimiento de su estado.</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
