<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="TP_Final_Benitez.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title nuevos">Agentes</h5>
                <asp:Button Text="Crear" class="btn btn-primary btn-lg" data-bs-toggle="modal" data-bs-target="#staticBackdrop" runat="server" ID="btnCrearAgente" OnClientClick="return false;" />
                <asp:Button Text="Listado" class="btn btn-primary btn-lg" runat="server" ID="btnListadoAgentes" OnClick="btnListadoAgentes_Click" />
                <div>
                    <!-- Modal -->
                    <div class="modal fade " id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Nuevo Agente</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div>
                                        <asp:Label Text="Apellido: " runat="server" />
                                        <asp:TextBox runat="server" ID="txtApellido" />
                                    </div>
                                    <div>
                                        <asp:Label Text="Nombre: " runat="server" />
                                        <asp:TextBox runat="server" ID="txtNombre" />
                                    </div>
                                    <div>
                                        <asp:Label Text="Email: " runat="server" />
                                        <asp:TextBox ID="txtEmail" runat="server" />
                                    </div>
                                    <div>
                                        <asp:Label Text="Perfil: " runat="server" />
                                        <asp:DropDownList ID="ddlPerfil" runat="server"></asp:DropDownList>
                                    </div>
                                    <div>
                                        <asp:Label Text="Contraseña: " runat="server" />
                                        <asp:TextBox runat="server" ID="txtContraseña" />
                                    </div>
                                    <div>
                                        <asp:Label Text="Confirmar Contraseña: " runat="server" />
                                        <asp:TextBox runat="server" ID="txtConfirmaContraseña" />
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button Text="Aceptar" ID="btnAceptarNuevoAgente" runat="server" CssClass="btn btn-primary" OnClick="btnAceptarNuevoAgente_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title nuevos">Categorias</h5>
                <asp:Button Text="Crear" class="btn btn-success btn-lg" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" runat="server" ID="Button1" OnClientClick="return false;" />
                <asp:Button Text="Listado" class="btn btn-success btn-lg" runat="server" ID="bntListadoCategorias" OnClick="bntListadoCategorias_Click" />
                <div>
                    <div class="modal fade " id="staticBackdrop2" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5" id="staticBackdropLabe2">Nueva Categoria</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div>
                                        <asp:Label Text="Nombre: " runat="server" />
                                        <asp:TextBox runat="server" ID="txtNuevaCategoria" />
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button Text="Aceptar" ID="btnAceptarNuevaCategoria" runat="server" CssClass="btn btn-primary" OnClick="btnAceptarNuevaCategoria_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Estados</h5>
                <asp:Button Text="Crear" class="btn btn-warning btn-lg" runat="server" data-bs-toggle="modal" data-bs-target="#staticBackdrop3" OnClientClick="return false;" />
                <asp:Button Text="Listado" class="btn btn-warning btn-lg" runat="server" ID="btnListadoEstados" OnClick="btnListadoEstados_Click" />
            </div>
            <div class="modal fade " id="staticBackdrop3" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="staticBackdropLabel3">Nuevo Estado</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div>
                                <asp:Label Text="Nombre: " runat="server" />
                                <asp:TextBox runat="server" ID="txtNuevoEstado" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <asp:Button Text="Aceptar" ID="btnAceptarNuevoEstado" runat="server" CssClass="btn btn-primary" OnClick="btnAceptarNuevoEstado_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card uno" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Prioridades</h5>
                <asp:Button Text="Crear" class="btn btn-danger btn-lg" runat="server" data-bs-toggle="modal" data-bs-target="#staticBackdrop4" OnClientClick="return false;" />
                <asp:Button Text="Listado" class="btn btn-danger btn-lg" runat="server" ID="btnListadoPrioridades" OnClick="btnListadoPrioridades_Click" />
            </div>
            <div class="modal fade " id="staticBackdrop4" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="staticBackdropLabel4">Nueva Prioridad</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div>
                                <asp:Label Text="Nombre: " runat="server" />
                                <asp:TextBox runat="server" ID="txtNuevaPrioridad" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <asp:Button Text="Aceptar" ID="btnAceptarNuevaPrioridad" runat="server" CssClass="btn btn-primary" OnClick="btnAceptarNuevaPrioridad_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="false" ID="gvAgentes">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdAgente" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo.Nombre" />
                <asp:BoundField HeaderText="Estado" DataField="MostrarEstado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Activar" ID="btnActivarAgente" CssClass="btn btn-success" CommandName="IdAgente" CommandArgument='<%#Eval("IdAgente") %>' runat="server" OnCommand="btnActivarAgente_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Desactivar" ID="btnDesactivarAgente" CssClass="btn btn-danger" CommandName="IdAgente" CommandArgument='<%#Eval("IdAgente") %>' runat="server" OnCommand="btnDesactivarAgente_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="false" ID="gvCategorias">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdCategoria" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Estado" DataField="MostrarEstado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Activar" ID="btnActivarCategoria" CssClass="btn btn-success" CommandName="IdCategoria" CommandArgument='<%#Eval("IdCategoria") %>' runat="server" OnCommand="btnActivarCategoria_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Desactivar" ID="btnDesactivarCategoria" CssClass="btn btn-danger" CommandName="IdCategoria" CommandArgument='<%#Eval("IdCategoria") %>' runat="server" OnCommand="btnDesactivarCategoria_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="false" ID="gvEstados">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdEstado" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Estado" DataField="MostrarEstado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Activar" ID="btnActivarEstado" CssClass="btn btn-success" CommandName="IdEstado" CommandArgument='<%#Eval("IdEstado") %>' runat="server" OnCommand="btnActivarEstado_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Desactivar" ID="btnDesactivarEstado" CssClass="btn btn-danger" CommandName="IdEstado" CommandArgument='<%#Eval("IdEstado") %>' runat="server" OnCommand="btnDesactivarEstado_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="tablaGrid">
        <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="false" ID="gvPrioridades">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdPrioridad" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Estado" DataField="MostrarEstado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Activar" ID="btnActivarPrioridad" CssClass="btn btn-success" CommandName="IdPrioridad" CommandArgument='<%#Eval("IdPrioridad") %>' runat="server" OnCommand="btnActivarPrioridad_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Desactivar" ID="btnDesactivarPrioridad" CssClass="btn btn-danger" CommandName="IdPrioridad" CommandArgument='<%#Eval("IdPrioridad") %>' runat="server" OnCommand="btnDesactivarPrioridad_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
