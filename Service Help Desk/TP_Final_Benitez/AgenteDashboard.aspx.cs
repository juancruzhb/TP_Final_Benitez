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
    public partial class AgenteDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Agente aux = new Agente();
            if (Session["agente"] == null)
            {
                Session.Add("error", "Debes estar logueado para enviar acceder al menú");
                Response.Redirect("Error.aspx");
            }

        }

        private void cargarTickets(int estado, int IdAgente)
        {
            List<Ticket> aux = new List<Ticket>();
            List<Ticket> tickets = new List<Ticket>();
            TicketNegocio tNegocio = new TicketNegocio();

            aux = tNegocio.listar();

            foreach (var ticket in aux)
            {
                if (ticket.Estado.IdEstado == estado)
                    tickets.Add(ticket);
            }

            gvTickets.DataSource = tickets;
            gvTickets.DataBind();
        }

        protected void btnAbiertos_Click(object sender, EventArgs e)
        {
            cargarTickets(1, 100);

        }

        protected void btnResueltos_Click(object sender, EventArgs e)
        {
            cargarTickets(3, 100);

        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            cargarTickets(4, 100);

        }

        protected void btnCerrados_Click(object sender, EventArgs e)
        {
            cargarTickets(2, 100);

        }

        protected void btnVer_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("TicketDetalle.aspx?Id=" + id, false);
        }
    }
}