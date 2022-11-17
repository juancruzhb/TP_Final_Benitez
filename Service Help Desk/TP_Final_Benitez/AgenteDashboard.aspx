<%@ Page Title="" Language="C#" MasterPageFile="~/AgenteMaster.Master" AutoEventWireup="true" CodeBehind="AgenteDashboard.aspx.cs" Inherits="TP_Final_Benitez.AgenteDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title nuevos">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Abiertos" class="btn btn-primary btn-lg" runat="server" ID="btnAbiertos" OnClick="btnAbiertos_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Resueltos" class="btn btn-success btn-lg" runat="server" ID="btnResueltos" OnClick="btnResueltos_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Pendientes" class="btn btn-warning btn-lg" runat="server" ID="btnPendientes" OnClick ="btnPendientes_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Cerrados" class="btn btn-secondary btn-lg" runat="server" ID="btnCerrados" OnClick="btnCerrados_Click"/>
            </div>
        </div>
    </div>
    <div class="tablaGrid">
        <asp:GridView AutoGenerateColumns="false" CssClass="table tablaTickets" ID="gvTickets" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Ticket Numero" DataField="TicketId" />
                    <asp:BoundField HeaderText="Fecha Creacion" DataField="FechaCreacion" />
                    <asp:BoundField HeaderText="Asunto" DataField="Asunto" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="oCategoria.Nombre" />
                    <asp:BoundField HeaderText="Prioridad" DataField="oPrioridad.Nombre" />
                    <asp:BoundField HeaderText="Remitente" DataField="NombreApellido" />
                    <asp:TemplateField>
                        <itemtemplate>
                            <asp:LinkButton Text="Ver" ID="btnVer" CssClass="btn btn-primary" runat="server" />
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Indicador de respuesta" />

                </Columns>
            </asp:GridView>
    </div>
</asp:Content>
