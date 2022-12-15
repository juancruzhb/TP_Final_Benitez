using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace TP_Final_Benitez
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Categoria> listaCategorias { get; set; }
        public List<Prioridad> listaPrioridades { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para ingresar");
                Response.Redirect("Error.aspx");
            }

            if (!Page.IsPostBack)
            {
                List<Categoria> listaFiltradaCat = new List<Categoria>();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                listaCategorias = categoriaNegocio.listar();

                listaFiltradaCat = filtrarListaCategoria(listaCategorias);
                ddlCategorias.DataSource = listaFiltradaCat;
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "IdCategoria";
                ddlCategorias.DataBind();
                ddlCategorias.Items.Insert(0, new ListItem("--Categoria--", "0"));

                List<Prioridad> listaFiltradaPrio = new List<Prioridad>();
                PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                listaPrioridades = prioridadNegocio.listar();
                listaFiltradaPrio = filtrarListaPrioridades(listaPrioridades);

                ddlPrioridades.DataSource = listaFiltradaPrio;
                ddlPrioridades.DataTextField = "Nombre";
                ddlPrioridades.DataValueField = "IdPrioridad";
                ddlPrioridades.DataBind();
                ddlPrioridades.Items.Insert(0, new ListItem("--Prioridad--", "0"));


            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuUsuario.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            PrioridadNegocio pNegocio = new PrioridadNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();
            TicketNegocio tNegocio = new TicketNegocio();
            listaCategorias = cNegocio.listar();
            listaPrioridades = pNegocio.listar();
            try
            {
                TicketNegocio negocio = new TicketNegocio();
                Ticket nuevo = new Ticket();

                nuevo.Asunto = txtAsunto.Text;
                nuevo.FechaCreacion = DateTime.Now;
                nuevo.Activo = true;
                nuevo.Mensaje = txtMensaje.Text;
                nuevo.Contacto = txtContacto.Text;
                nuevo.User = (Usuario)Session["usuario"];
                nuevo.oPrioridad = listaPrioridades.Find(x => x.IdPrioridad.Equals(int.Parse(ddlPrioridades.SelectedValue)));
                nuevo.oCategoria = listaCategorias.Find(x => x.IdCategoria.Equals(int.Parse(ddlCategorias.SelectedValue)));

                if (tNegocio.InsertarNuevo(nuevo) >0)
                {
                    Response.Redirect("TicketSuccess.aspx", false);
                }
                
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<Categoria> filtrarListaCategoria(List<Categoria> categorias)
        {
            List<Categoria> filtrada = new List<Categoria>();

            foreach (var cat in categorias)
            {
                if (cat.Activo)
                    filtrada.Add(cat);
            }

            return filtrada;
        }

        private List<Prioridad> filtrarListaPrioridades(List<Prioridad> prioridades)
        {
            List<Prioridad> filtrada = new List<Prioridad>();

            foreach (var cat in prioridades)
            {
                if (cat.Activo)
                    filtrada.Add(cat);
            }

            return filtrada;
        }

        private List<Estado> filtrarListaEstados(List<Estado> estados)
        {
            List<Estado> filtrada = new List<Estado>();

            foreach (var cat in estados)
            {
                if (cat.Activo)
                    filtrada.Add(cat);
            }

            return filtrada;
        }
    }
}