<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketDetalles.aspx.cs" Inherits="TP_Final_Benitez.TicketDetalles" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <link href="Styles/TDetalles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container" style="border: 2px solid grey; ">
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
            <asp:Repeater runat="server" ID="rpRespuestas">
                <ItemTemplate>
                    <div class="container" style="border: 2px solid grey; margin-bottom:25px;">
                        <div class="uno">
                            <h3><%:seleccionado.Asunto%></h3>
                            <div class="dos">
                                <div class="tres">
                                    <div class="cuatro">
                                        <div class="cinco">
                                            <span>Numero de caso</span>
                                        </div>
                                        <div class="cinco">
                                            <span><%#Eval("TicketId")%></span>
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
                                            <span><%#Eval("Fecha")%></span>
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
                                            <span>ponercategoria</span>
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
                                            <span>Poner Prioridad</span>
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
                                            <span>Poner Agente</span>
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
                                            <span>Poner Estado</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mensaje">
                            <span class="spanMensaje"><%#Eval("Respuesta")%></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="container">
                <asp:TextBox TextMode="MultiLine" CssClass="form form-control" runat="server" Visible="false" ID="txtRespuestaTicket" CausesValidation="false" />
                <asp:Button Text="Enviar" CssClass="btn btn-primary" runat="server" Visible="false" ID="btnEnviarRespuestaTicket" UseSubmitBehavior="false" OnClick="btnEnviarRespuestaTicket_Click" />
                <asp:Button Text="Cancelar" CssClass="btn btn-success" runat="server" Visible="false" ID="btnCancelarRespuestaTicket" OnClick="btnCancelarRespuestaTicket_Click" UseSubmitBehavior="false" />
                <asp:Label Text="Se ha enviado la respuesta correctamente" ID="lblSuccesRespuesta" CssClass="alert-success" Visible="false" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
