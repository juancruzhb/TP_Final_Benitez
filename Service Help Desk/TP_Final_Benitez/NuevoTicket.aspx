<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoTicket.aspx.cs" Inherits="TP_Final_Benitez.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- CSS only -->
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
</head>
<body>
    <h3>Ingreso de ticket</h3>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="mb-3">
                    <asp:Label ID="lbAsunto" CssClass="form-label" runat="server" Text="Asunto"></asp:Label>
                    <asp:TextBox ID="txtAsunto" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblTipo" CssClass="form-label" runat="server" Text="Tipo de Problema"></asp:Label>
                    <div>
                        <asp:DropDownList ID="ddlCategorias" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Label ID="lblPrioridad" CssClass="form-label" runat="server" Text="Prioridad"></asp:Label>
                    <div>
                        <asp:DropDownList ID="ddlPrioridades" runat="server"> </asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDescripcion" CssClass="form-label" Text="Descripcion" runat="server" />
                    <asp:TextBox TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" Rows="3" runat="server" />
                </div>
                <div class="mb-3">  
                    <asp:FileUpload ID="fpArchivo" runat="server" />
                </div>
                <asp:Button Text="Enviar" CssClass="btn btn-primary" runat="server" />
                <asp:Button Text="Cancelar" CssClass="btn btn-primary" runat="server" />

            </div>
        </div>
    </form>
</body>
</html>
