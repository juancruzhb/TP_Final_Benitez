 <%@ Page Title="" Language="C#" MasterPageFile="~/AgenteMaster.Master" AutoEventWireup="true" CodeBehind="LoginAgente.aspx.cs" Inherits="TP_Final_Benitez.LoginAgente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex-child1" style="width:30%; margin:auto">
                <h2>Iniciar sesión en el portal de asistencia</h2>
                <p>Introduce los datos que utilizaste para registrarte con nosotros:</p>
                <div>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox TextMode ="Password" ID="txtPass" runat="server"></asp:TextBox>
                    <div>
                        <asp:Button Text="Login" CssClass="btn btn-primary" runat="server"  ID="btnLogin" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
</asp:Content>
