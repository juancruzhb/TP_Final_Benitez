<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="TicketDetalle.aspx.cs" Inherits="TP_Final_Benitez.TicketDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="border: 2px solid grey">
        <div class="uno">
            <h3><%:seleccionado.Asunto%></h3>
            <div class="dos">
                <div class="tres">
                    <div class="cuatro">
                        <div class="cinco">
                            <span>Numero de caso</span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.TicketID%></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dos">
                <div class="tres">
                    <div class="cuatro">
                        <div class="cinco">
                            <span>Fecha de creacion</span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.FechaCreacion%></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dos">
                <div class="tres">
                    <div class="cuatro">
                        <div class="cinco">
                            <span>Categoria</span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.oCategoria.Nombre%></span>
                        </div>
                    </div>
                </div>
            </div>
                        <div class="dos">
                <div class="tres">
                    <div class="cuatro">
                        <div class="cinco">
                            <span>Prioridad</span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.oPrioridad.Nombre%></span>
                        </div>
                    </div>
                </div>
            </div>
                        <div class="dos">
                <div class="tres">
                    <div class="cuatro">
                        <div class="cinco">
                            <span>Estado</span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.Estado.Nombre%></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <div class="mensaje">
                <span class="spanMensaje"><%:seleccionado.Mensaje %></span>
            </div>
    </div>
    <div><h3>Comentarios realizados</h3></div>
</asp:Content>
