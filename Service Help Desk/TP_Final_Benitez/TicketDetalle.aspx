<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="TicketDetalle.aspx.cs" Inherits="TP_Final_Benitez.TicketDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="border:2px solid grey">
        <div class="mb-3 row">
            <h4><%:seleccionado.Asunto%></h4>
            <div class="col-sm-10">
                <input type="text" readonly class="form-control-plaintext" id="staticEmail" value="email@example.com">
            </div>
        </div>
    </div>
</asp:Content>
