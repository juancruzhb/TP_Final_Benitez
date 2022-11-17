﻿using System;
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
            Response.Redirect("TicketDetalle.aspx?Id=" + id, false);
        }
    }
}