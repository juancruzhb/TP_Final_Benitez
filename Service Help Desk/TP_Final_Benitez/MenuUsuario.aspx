<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuUsuario.aspx.cs" Inherits="TP_Final_Benitez.MenuUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <nav class="navbar navbar-expand-lg bg-light">
                    <div class="container-fluid">
                        <a class="navbar-brand" href="#">Sistema de Tickets</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page" href="NuevoTicket.aspx">Nuevo Ticket</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Modificar mi perfil</a>
                                </li>
                            </ul>
                            <form class="d-flex" role="search">
                                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" Width="30%" TextMode="Search" placeholder="Buscar Ticket"></asp:TextBox>
                                <asp:Button CssClass="btn btn-outline-success" Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
                                <asp:Button CssClass="btn btn-outline-danger" Text="Logut" runat="server" ID="btnlogout" OnClick="btnlogout_Click" />

                            </form>
                        </div>
                    </div>
                </nav>
            </header>
            <asp:GridView AutoGenerateColumns="false" CssClass="table" runat="server" ID="dvTickets" OnRowDataBound="dvTickets_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Ticket Numero" DataField="TicketId" />
                    <asp:BoundField HeaderText="Fecha Creacion" DataField="FechaCreacion" />
                    <asp:BoundField HeaderText="Asunto" DataField="Asunto" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="oCategoria.Nombre" />
                    <asp:BoundField HeaderText="Prioridad" DataField="oPrioridad.Nombre" />
                    <asp:TemplateField>
                        <itemtemplate>
                            <asp:LinkButton Text="Ver" ID="btnVer" CssClass="btn btn-primary" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' runat="server" OnCommand="btnVer_Command"/>
                        </itemtemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
