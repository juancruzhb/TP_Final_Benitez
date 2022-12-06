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
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Responder</button>

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Nueva Respuesta</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <div class="mb-3">
                                        <label for="message-text" class="col-form-label">Mensaje:</label>
                                        <asp:TextBox CssClass="form-control" TextMode="MultiLine"  runat="server" ID="txtRespuestaNueva"/>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                <asp:Button Text="Enviar22" CssClass = "btn btn-primary" runat="server" Id="btnEnviarRespuesta" OnClick="btnEnviarRespuesta_Click" UseSubmitBehavior="false"  CausesValidation="false"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="mensaje">
            <span class="spanMensaje"><%:seleccionado.Mensaje %></span>
        </div>
    </div>

    <div>
        <h3>Comentarios realizados</h3>
    </div>
</asp:Content>
