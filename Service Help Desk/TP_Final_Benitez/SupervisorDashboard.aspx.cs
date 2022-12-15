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
    public partial class SupervisorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Agente aux = new Agente();
            if (Session["agente"] == null)
            {               
                Session.Add("error", "Debes estar logueado para enviar acceder al menú");
                Response.Redirect("Error.aspx");
            }else if(Session["agente"] != null)
            {
                aux = (Agente)Session["agente"];
                if(aux.Tipo.IdTipo == 3)
                {
                    Session.Add("error", "No tienes los permisos para ingresar a este sector");
                    Response.Redirect("Error.aspx");
                }
            }

        }
        private void cargarTickets(int estado)
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

        protected void btnSinAsignar_Click(object sender, EventArgs e)
        {

            gvTickets.Columns[9].Visible = true;
            gvTickets.Columns[8].Visible = false;


            List<Ticket> aux = new List<Ticket>();
            List<Ticket> tickets = new List<Ticket>();
            TicketNegocio tNegocio = new TicketNegocio();

            aux = tNegocio.listar();

            foreach (var ticket in aux)
            {
                if (ticket.Estado.IdEstado == 1 && ticket.IdAgenteAsignado == 0)
                    tickets.Add(ticket);
            }

            gvTickets.DataSource = tickets;
            gvTickets.DataBind();


        }


        protected void gvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Agente> agentes = new List<Agente>();
                AgenteNegocio negocio = new AgenteNegocio();
                agentes = negocio.listar();

                DropDownList ddlAgentes = (e.Row.FindControl("ddlAgentes") as DropDownList);
                ddlAgentes.DataSource = agentes;
                ddlAgentes.DataTextField = "Apellido";
                ddlAgentes.DataValueField = "IdAgente";
                ddlAgentes.DataBind();
                ddlAgentes.Items.Insert(0, new ListItem("Sin Asignar"));

            }

            
        }

        protected void btnAbiertos_Click(object sender, EventArgs e)
        {
            gvTickets.Columns[9].Visible = false;
            cargarTickets(1);
        }

        protected void ddlAgentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList ddlAgentes = (DropDownList)gvr.FindControl("ddlAgentes");
            int idAgente =int.Parse(ddlAgentes.SelectedItem.Value);
            int idTicket = int.Parse(gvr.Cells[0].Text);

            negocio.AsignarAgente(idTicket, idAgente);

        }

        protected void btnResueltos_Click(object sender, EventArgs e)
        {
            cargarTickets(3);
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            cargarTickets(4);
        }

        protected void btnCerrados_Click(object sender, EventArgs e)
        {

            cargarTickets(2);
        }
    }
}