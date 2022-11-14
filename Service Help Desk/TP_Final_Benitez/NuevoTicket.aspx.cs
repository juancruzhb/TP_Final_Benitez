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
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                listaCategorias = categoriaNegocio.listar();
                ddlCategorias.DataSource = listaCategorias;
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "IdCategoria";
                ddlCategorias.DataBind();
                ddlCategorias.Items.Insert(0, new ListItem("--Categoria--", "0"));

                PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                listaPrioridades = prioridadNegocio.listar();
                ddlPrioridades.DataSource = listaPrioridades;
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
    }
}