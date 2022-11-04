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
    }
}