<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TP_Final_Benitez.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link href="Styles/login.css" rel="stylesheet" />
    <title>Registrarse</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row registro">
            <div >
                <h2 class="text-center">Registrate con nosotros</h2>
                <asp:Label ID="lblRequerido" ForeColor="Red" Text="" runat="server" />
                <div>
                    <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"/>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Apellido" CssClass="form-label" runat="server" />
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtApellido"/>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Celular" CssClass="form-label" runat="server" />
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtCelular"/>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Correo Electronico" CssClass="form-label" runat="server" />
                    <asp:TextBox CssClass="form-control" ID="txtCorreo" placeholder="sucorreo@correo.com" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label Text="Contraseña" CssClass="form-label" runat="server" />
                    <asp:TextBox TextMode="Password" CssClass="form-control" ID="txtPass" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label Text="Repita su contraseña" CssClass="form-label"    runat="server" />
                    <asp:TextBox CssClass="form-control" TextMode ="Password" runat="server" Id="txtConfirmaPass"/>
                </div>
                <div class="text-center">
                    <asp:Button Text="Confirmar" runat="server" CssClass="btn btn-primary" ID="btnConfirmarRegistro"  OnClick="btnConfirmarRegistro_Click" />
                    <a href="Login.aspx" class="btn btn-danger">Cancelar</a>
                </div>
                <div>
                    <asp:Label ID="lblRedirigiendo" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
