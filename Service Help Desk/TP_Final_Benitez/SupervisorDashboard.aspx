<%@ Page Title="" Language="C#" MasterPageFile="~/SupervisorMaster.Master" AutoEventWireup="true" CodeBehind="SupervisorDashboard.aspx.cs" Inherits="TP_Final_Benitez.SupervisorDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title nuevos">Aca van las cantidades</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Abiertos" class="btn btn-primary btn-lg" runat="server" ID="btnAbiertos" OnClick="btnAbiertos_Click"/>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Aca van las cantidades</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Resueltos" class="btn btn-success btn-lg" runat="server" ID="btnResueltos"/>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Aca van las cantidades</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Pendientes" class="btn btn-warning btn-lg" runat="server" ID="btnPendientes"  />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Aca van las cantidades</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Cerrados" class="btn btn-danger btn-lg" runat="server" ID="btnCerrados"  />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <asp:Button Text="Tickets Sin Asignar" class="btn btn-secondary btn-lg" runat="server" ID="btnSinAsignar" OnClick="btnSinAsignar_Click"  />
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Ver" ID="btnVer" CssClass="btn btn-primary" runat="server" CommandName="IdTicket" CommandArgument='<%#Eval("TicketId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Indicador de Respuesta">
                    <ItemTemplate>
                        <asp:LinkButton Text="X" ID="btnSinRespuesta" CssClass="btn btn-danger" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agente Asignado" Visible="false"  >
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlAgentes" AutoPostBack="true" OnSelectedIndexChanged="ddlAgentes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
