<%@ Page Title="" Language="C#" MasterPageFile="~/SupervisorMaster.Master" AutoEventWireup="true" CodeBehind="SupervisorDashboard.aspx.cs" Inherits="TP_Final_Benitez.SupervisorDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <asp:Button Text="Tickets Abiertos" Width="100%" class="btn btn-primary btn-lg" runat="server" ID="btnAbiertos" OnClick="btnAbiertos_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <asp:Button Text="Tickets Resueltos" Width="100%" class="btn btn-success btn-lg" runat="server" ID="btnResueltos" OnClick="btnResueltos_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <asp:Button Text="Tickets Pendientes" Width="100%" class="btn btn-warning btn-lg" runat="server" ID="btnPendientes" OnClick="btnPendientes_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <asp:Button Text="Tickets Cerrados" Width="100%" class="btn btn-danger btn-lg" runat="server" ID="btnCerrados" OnClick="btnCerrados_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <asp:Button Text="Tickets Sin Asignar" Width="100%" class="btn btn-secondary btn-lg" runat="server" ID="btnSinAsignar" OnClick="btnSinAsignar_Click" />
            </div>
        </div>
    </div>
    <div class="tablaGrid">
        <asp:GridView AutoGenerateColumns="false" CssClass="table tablaTickets" ID="gvTickets" runat="server" OnRowDataBound="gvTickets_RowDataBound">

            <Columns>
                <asp:BoundField HeaderText="Ticket Numero" DataField="TicketId" />
                <asp:BoundField HeaderText="Fecha Creacion" DataField="FechaCreacion" />
                <asp:BoundField HeaderText="Asunto" DataField="Asunto" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Nombre" />
                <asp:BoundField HeaderText="Categoria" DataField="oCategoria.Nombre" />
                <asp:BoundField HeaderText="Prioridad" DataField="oPrioridad.Nombre" />
                <asp:BoundField HeaderText="Remitente" DataField="NombreApellido" />
                <asp:BoundField HeaderText="Agente Asignado" DataField="AgenteAsignado.NombreApellido" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Ver" ID="btnVer" CssClass="btn btn-primary btn-sm" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' OnCommand="btnVer_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <asp:LinkButton Text="Reabrir" ID="btnReabrir" CssClass="btn btn-danger btn-sm" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' OnCommand="btnReabrir_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Asignar Agente">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlAgentes" AutoPostBack="true" OnSelectedIndexChanged="ddlAgentes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marcar Como">
                    <ItemTemplate>
                        <asp:LinkButton Text="Resuelto" ID="btnResuelto" CssClass="btn btn-success btn-sm" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' OnCommand="btnResuelto_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marcar Como">
                    <ItemTemplate>
                        <asp:LinkButton Text="Pendiente" ID="btnPendiente" CssClass="btn btn-warning btn-sm" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' OnCommand="btnPendiente_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marcar Como">
                    <ItemTemplate>
                        <asp:LinkButton Text="Cerrado" ID="btnCerrado" CssClass="btn btn-danger btn-sm" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' OnCommand="btnCerrado_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
