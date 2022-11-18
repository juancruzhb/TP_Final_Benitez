<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP_Final_Benitez.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hubo un error</h1>
            <asp:Label Text="text" ID="lblError" runat="server" />
            <a href="login.aspx">Volver al Login</a>
        </div>
    </form>
</body>
</html>
