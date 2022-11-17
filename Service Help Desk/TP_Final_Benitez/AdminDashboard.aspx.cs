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

        }
    }
}