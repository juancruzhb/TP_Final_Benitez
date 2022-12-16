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
            if (Request.QueryString["q"] != null)
            {
                string busqueda = Request.QueryString["q"];
                cargarTickets(0, busqueda);

            }
        }
        private void cargarTickets(int estado, string search = null)
        {
            List<Ticket> aux = new List<Ticket>();
            List<Ticket> tickets = new List<Ticket>();
            TicketNegocio tNegocio = new TicketNegocio();

            aux = tNegocio.listar();

            if (search != null && estado == 0)
            {
                gvTickets.Columns[10].Visible = false;
                tickets = aux.FindAll(x => x.TicketID.ToString() == search || x.Asunto.ToLower().Contains(search.ToLower()));
            }
            else
            {
                foreach (var ticket in aux)
                {
                    if (ticket.Estado.IdEstado == estado)
                        tickets.Add(ticket);
                }
            }


            gvTickets.DataSource = tickets;
            gvTickets.DataBind();
        }

        private void cargarTicketsSinAsignar()
        {
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

        protected void btnSinAsignar_Click(object sender, EventArgs e)
        {

            gvTickets.Columns[10].Visible = true;
            gvTickets.Columns[9].Visible = false;
            gvTickets.Columns[7].Visible = false;


            cargarTicketsSinAsignar();

        }


        protected void gvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Agente> agentes = new List<Agente>();
                AgenteNegocio negocio = new AgenteNegocio();
                agentes = negocio.listar();

                DropDownList ddlAgentes = (e.Row.FindControl("ddlAgentes") as DropDownList);
                ddlAgentes.Visible = true;
                ddlAgentes.DataSource = agentes;
                ddlAgentes.DataTextField = "NombreApellido";
                ddlAgentes.DataValueField = "IdAgente";
                ddlAgentes.DataBind();
                ddlAgentes.Items.Insert(0, new ListItem(""));

            }

        }

        protected void btnAbiertos_Click(object sender, EventArgs e)
        {
            gvTickets.Columns[9].Visible = false;
            gvTickets.Columns[10].Visible = true;
            gvTickets.Columns[7].Visible = true;

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
            cargarTicketsSinAsignar();

        }

        protected void btnResueltos_Click(object sender, EventArgs e)
        {
            gvTickets.Columns[10].Visible = false;
            gvTickets.Columns[9].Visible = true;
            gvTickets.Columns[7].Visible = true;
            gvTickets.Columns[11].Visible = false;
            gvTickets.Columns[12].Visible = true;
            gvTickets.Columns[13].Visible = true;

            cargarTickets(3);
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            gvTickets.Columns[9].Visible = false;
            gvTickets.Columns[10].Visible = true;
            gvTickets.Columns[7].Visible = true;
            gvTickets.Columns[11].Visible = true;
            gvTickets.Columns[13].Visible = true;
            gvTickets.Columns[12].Visible = false;

            cargarTickets(4);
        }

        protected void btnCerrados_Click(object sender, EventArgs e)
        {
            gvTickets.Columns[10].Visible = false;
            gvTickets.Columns[9].Visible = true;
            gvTickets.Columns[11].Visible = true;
            gvTickets.Columns[7].Visible = true;
            gvTickets.Columns[12].Visible = true;
            gvTickets.Columns[13].Visible = false;


            cargarTickets(2);
  
        }



        protected void btnReabrir_Command(object sender, CommandEventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();


            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());

            negocio.CambiarEstado(idTicket, 1);

            cargarTickets(1);
            Response.Redirect(Request.RawUrl);
        }



        protected void btnResuelto_Command(object sender, CommandEventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();


            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());

            negocio.CambiarEstado(idTicket, 3);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnPendiente_Command(object sender, CommandEventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();


            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());

            negocio.CambiarEstado(idTicket, 4);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCerrado_Command(object sender, CommandEventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();


            int idTicket = Convert.ToInt32(e.CommandArgument.ToString());

            negocio.CambiarEstado(idTicket, 2);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnVer_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("TicketDetalles.aspx?Id=" + id, false);
        }
    }
}