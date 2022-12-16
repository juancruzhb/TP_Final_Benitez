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
            Usuario aux = new Usuario();
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para enviar acceder al menú");
                Response.Redirect("Error.aspx");
            }
            aux = (Usuario)Session["usuario"];  

            List<Ticket> tickets = new List<Ticket>();
            TicketNegocio negocio = new TicketNegocio();
            tickets = negocio.listar(aux.IdUsuario);

            dvTickets.DataSource = tickets;
            dvTickets.DataBind();

        }


        protected void btnVer_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("TicketDetalles.aspx?Id=" + id, false);

            TicketRespuestaNegocio negocio = new TicketRespuestaNegocio();
            negocio.LeerRespuesta(id, 1);
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Usuario aux = new Usuario();
            List<Ticket> tickets = new List<Ticket>();
            List<Ticket> filtrados = new List<Ticket>();
            TicketNegocio negocio = new TicketNegocio();
            tickets = negocio.listar(aux.IdUsuario);
            string filtro = txtBuscar.Text;

            if (filtro != "")
            {
                filtrados = tickets.FindAll(x => x.TicketID.ToString() == filtro || x.Asunto.ToLower().Contains(filtro.ToLower()));
            }
            else
            {
                filtrados = tickets;
            }


            dvTickets.DataSource = null;
            dvTickets.DataSource = filtrados;
            dvTickets.DataBind();
        }

        protected void dvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TicketRespuestaNegocio n = new TicketRespuestaNegocio();
            if(!n.VerificaLectura(Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "TicketId")), false))
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;

            }

        }
        }
 
}