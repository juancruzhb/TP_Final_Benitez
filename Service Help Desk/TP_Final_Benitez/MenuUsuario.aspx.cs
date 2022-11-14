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
    public partial class MenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para enviar acceder al menú");
                Response.Redirect("Error.aspx");
            }

            List<Ticket> tickets = new List<Ticket>();
            TicketNegocio negocio = new TicketNegocio();
            tickets = negocio.listar();

            dvTickets.DataSource = tickets;
            dvTickets.DataBind();

        }
    }
}