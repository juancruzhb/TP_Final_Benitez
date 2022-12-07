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
                            <span>Asignado a: </span>
                        </div>
                        <div class="cinco">
                            <span><%:seleccionado.AgenteAsignado.NombreApellido%></span>
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
            <div>
                <asp:Button Text="Responder" CssClass="btn btn-primary" ID="btnResponderTicket2" runat="server" OnClick="btnResponderTicket2_Click" UseSubmitBehavior="false" />
            </div>
        </div>
        <div class="mensaje">
            <span class="spanMensaje"><%:seleccionado.Mensaje %></span>
        </div>
    </div>

    <div>
        <h3>Comentarios realizados</h3>
    </div>
    <div class="container">
        <asp:TextBox  TextMode="MultiLine" runat="server" Visible ="false" ID="txtRespuestaTicket" CausesValidation="false" />
        <asp:Button Text="Enviar" CssClass="btn btn-primary" runat="server" Visible="false" ID="btnEnviarRespuestaTicket" UseSubmitBehavior = "false" OnClick="btnEnviarRespuestaTicket_Click" />
        
        <asp:Button Text="Cancelar" CssClass="btn btn-success" runat="server" Visible ="false" Id="btnCancelarRespuestaTicket" OnClick="btnCancelarRespuestaTicket_Click" UseSubmitBehavior="false"/>
    </div>
</asp:Content>
