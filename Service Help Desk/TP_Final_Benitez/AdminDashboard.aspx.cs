using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final_Benitez
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Tipo> perfiles = new List<Tipo>();
            TipoNegocio tNegocio = new TipoNegocio();
            perfiles = tNegocio.listar();

            Agente aux = new Agente();
            if (Session["agente"] == null)
            {
                Session.Add("error", "Debes estar logueado para enviar acceder al menú");
                Response.Redirect("Error.aspx");
            }
            else if (Session["agente"] != null)
            {
                aux = (Agente)Session["agente"];
                if (aux.Tipo.IdTipo != 1)
                {
                    Session.Add("error", "No tienes los permisos para ingresar a este sector");
                    Response.Redirect("Error.aspx");
                }
            }

            if (!Page.IsPostBack)
            {
                ddlPerfil.DataSource = perfiles;
                ddlPerfil.DataTextField = "Nombre";
                ddlPerfil.DataValueField = "IdTipo";
                ddlPerfil.DataBind();
            }

        }

        protected void btnListadoAgentes_Click(object sender, EventArgs e)
        {
            gvAgentes.Visible = true;
            gvCategorias.Visible = false;
            gvEstados.Visible = false;
            gvPrioridades.Visible = false;
 
            List<Agente> agentes = new List<Agente>();
            AgenteNegocio negocio = new AgenteNegocio();

            agentes = negocio.listar();
            gvAgentes.DataSource = agentes;
            gvAgentes.DataBind();
        }

        protected void bntListadoCategorias_Click(object sender, EventArgs e)
        {
            gvCategorias.Visible = true;
            gvAgentes.Visible = false;
            gvEstados.Visible = false;
            gvPrioridades.Visible = false;
            List<Categoria> categorias = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();
            categorias = negocio.listar();
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
        }

        protected void btnListadoEstados_Click(object sender, EventArgs e)
        {
            gvEstados.Visible = true;
            gvAgentes.Visible = false;
            gvCategorias.Visible = false;
            gvPrioridades.Visible = false;

            List<Estado> estados = new List<Estado>();
            EstadoNegocio negocio = new EstadoNegocio();
            estados = negocio.listar();
            gvEstados.DataSource = estados;
            gvEstados.DataBind();

        }

        protected void btnListadoPrioridades_Click(object sender, EventArgs e)
        {
            gvPrioridades.Visible = true;
            gvAgentes.Visible = false;
            gvCategorias.Visible = false;
            gvEstados.Visible = false;

            List<Prioridad> prioridades = new List<Prioridad>();
            PrioridadNegocio negocio = new PrioridadNegocio();
            prioridades = negocio.listar();
            gvPrioridades.DataSource = prioridades;
            gvPrioridades.DataBind();

        }

        protected void btnAceptarNuevoAgente_Click(object sender, EventArgs e)
        {
            List<Tipo> tipos = new List<Tipo>();
            TipoNegocio tNegocio = new TipoNegocio();
            tipos = tNegocio.listar();
            AgenteNegocio negocio = new AgenteNegocio();
            Agente agente = new Agente();

            agente.Apellido = txtApellido.Text;
            agente.Nombre = txtNombre.Text;
            agente.Email = txtEmail.Text;
            agente.Tipo = tipos.Find(x => x.IdTipo.Equals(int.Parse(ddlPerfil.SelectedValue)));
            //TODO: verificar contraseña
            agente.Password = txtContraseña.Text;

            negocio.InsertarNuevo(agente);
            //TODO: Desactivar agentes y que no puedan ingresar si esta desactivado
        }

        protected void btnActivarAgente_Command(object sender, CommandEventArgs e)
        {
            AgenteNegocio negocio = new AgenteNegocio();
            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarAgente(idTicket, true);

            List<Agente> agentes = new List<Agente>();

            agentes = negocio.listar();
            gvAgentes.DataSource = agentes;
            gvAgentes.DataBind();

        }

        protected void btnDesactivarAgente_Command(object sender, CommandEventArgs e)
        {
            AgenteNegocio negocio = new AgenteNegocio();
            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarAgente(idTicket, false);

            List<Agente> agentes = new List<Agente>();
            agentes = negocio.listar();
            gvAgentes.DataSource = agentes;
            gvAgentes.DataBind();
        }

        protected void btnActivarCategoria_Command(object sender, CommandEventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            int idCategoria = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarCategoria(idCategoria, true);

            cargarCategorias();
        }

        protected void btnDesactivarCategoria_Command(object sender, CommandEventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            int idCategoria = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarCategoria(idCategoria, false);

            cargarCategorias();
        }

        protected void btnActivarEstado_Command(object sender, CommandEventArgs e)
        {
            EstadoNegocio negocio = new EstadoNegocio();
            int idEstado = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarEstado(idEstado, true);

            cargarEstados();
        }

        protected void btnDesactivarEstado_Command(object sender, CommandEventArgs e)
        {
            EstadoNegocio negocio = new EstadoNegocio();
            int idEstado = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarEstado(idEstado, false);

            cargarEstados();
        }

        protected void btnActivarPrioridad_Command(object sender, CommandEventArgs e)
        {
            PrioridadNegocio negocio = new PrioridadNegocio();
            int idPrioridad = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarPrioridad(idPrioridad, true);

            cargarPrioridad();
            
        }

        protected void btnDesactivarPrioridad_Command(object sender, CommandEventArgs e)
        {
            PrioridadNegocio negocio = new PrioridadNegocio();
            int idPrioridad = Convert.ToInt32(e.CommandArgument.ToString());
            negocio.ActivarDesactivarPrioridad(idPrioridad, false);

            cargarPrioridad();
        }

        protected void btnAceptarNuevaCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            categoria.Nombre = txtNuevaCategoria.Text;
            categoria.Activo = true;

            if (negocio.InsertarCategoria(categoria))
            {
                cargarCategorias();
            }

        }

        protected void btnAceptarNuevoEstado_Click(object sender, EventArgs e)
        {
            EstadoNegocio negocio = new EstadoNegocio();
            Estado estado = new Estado();
            estado.Nombre = txtNuevoEstado.Text;
            estado.Activo = true;

            if (negocio.InsertarEstado(estado))
                cargarEstados();

        }

        protected void btnAceptarNuevaPrioridad_Click(object sender, EventArgs e)
        {
            PrioridadNegocio negocio = new PrioridadNegocio();
            Prioridad prioridad = new Prioridad();
            prioridad.Nombre = txtNuevaPrioridad.Text;
            prioridad.Activo = true;

            if (negocio.InsertarPrioridad(prioridad))
                cargarPrioridad();


        }

        private void cargarPrioridad()
        {
            List<Prioridad> prioridades = new List<Prioridad>();
            PrioridadNegocio negocio = new PrioridadNegocio();
            prioridades = negocio.listar();
            gvPrioridades.DataSource = prioridades;
            gvPrioridades.DataBind();
        }

        private void cargarEstados()
        {
            List<Estado> estados = new List<Estado>();
            EstadoNegocio negocio = new EstadoNegocio();
            estados = negocio.listar();
            gvEstados.DataSource = estados;
            gvEstados.DataBind();
        }

        private void cargarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();
            categorias = negocio.listar();
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
        }

    }
}