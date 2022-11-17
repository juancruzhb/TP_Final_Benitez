<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="TP_Final_Benitez.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title nuevos">Agentes</h5>
                <asp:Button Text="Crear" class="btn btn-primary btn-lg" runat="server" ID="btnCrearAgente" />
                <asp:Button Text="Listado" class="btn btn-primary btn-lg" runat="server" ID="btnListadoAgentes" OnClick="btnListadoAgentes_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Categorias</h5>
                <asp:Button Text="Crear" class="btn btn-success btn-lg" runat="server" />
                <asp:Button Text="Listado" class="btn btn-success btn-lg" runat="server" ID="bntListadoCategorias" OnClick="bntListadoCategorias_Click" />
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Estados</h5>
                <asp:Button Text="Crear" class="btn btn-warning btn-lg" runat="server" />
                <asp:Button Text="Listado" class="btn btn-warning btn-lg" runat="server" Id="btnListadoEstados" OnClick="btnListadoEstados_Click"/>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Prioridades</h5>
                <asp:Button Text="Crear" class="btn btn-danger btn-lg" runat="server" />
                <asp:Button Text="Listado" class="btn btn-danger btn-lg" runat="server" Id="btnListadoPrioridades" OnClick="btnListadoPrioridades_Click"/>
            </div>

        </div>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="true" ID="gvAgentes">
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="true" ID="gvCategorias">
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="true" ID="gvEstados">
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="true" ID="gvPrioridades">
        </asp:GridView>
    </div>
</asp:Content>
