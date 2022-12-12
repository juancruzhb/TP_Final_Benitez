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
                if(ticket.IdAgenteAsignado != 0)
                {
                    if (ticket.Estado.IdEstado == estado && ticket.IdAgenteAsignado == IdAgente)
                    {
                         tickets.Add(ticket);
                    }

                }
            }

            gvTickets.DataSource = tickets;
            gvTickets.DataBind();
        }

        protected void btnAbiertos_Click(object sender, EventArgs e)
        {
            Agente agente = new Agente();
            agente = (Agente)Session["agente"];
            cargarTickets(1, agente.IdAgente);

        }

        protected void btnResueltos_Click(object sender, EventArgs e)
        {
            Agente agente = new Agente();
            agente = (Agente)Session["agente"];

            cargarTickets(3, agente.IdAgente);

        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            Agente agente = new Agente();
            agente = (Agente)Session["agente"];

            cargarTickets(4, agente.IdAgente);

        }

        protected void btnCerrados_Click(object sender, EventArgs e)
        {
            Agente agente = new Agente();
            agente = (Agente)Session["agente"];
            cargarTickets(2, agente.IdAgente);

        }

        protected void btnVer_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("TicketDetalles.aspx?Id=" + id, false);
        }

        protected void ddlCambiarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList ddlEstados = (DropDownList)gvr.FindControl("ddlEstados");
            int idEstado = int.Parse(ddlEstados.SelectedItem.Value);
            int idTicket = int.Parse(gvr.Cells[0].Text);

            negocio.CambiarEstado(idTicket, idEstado);

        }

        protected void gvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Estado> estados = new List<Estado>();
                EstadoNegocio negocio = new EstadoNegocio();
                estados = negocio.listar();

                DropDownList ddlEstados = (e.Row.FindControl("ddlEstados") as DropDownList);
                ddlEstados.DataSource = estados;
                ddlEstados.DataTextField = "Nombre";
                ddlEstados.DataValueField = "IdEstado";
                ddlEstados.DataBind();
                ddlEstados.Items.Insert(0, new ListItem("Cambiar Estado"));

            }
        }
    }
}