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
    public partial class TicketDetalle : System.Web.UI.Page
    {
       public Ticket seleccionado = new Ticket();
        private string mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                mensaje = txtRespuestaNueva.Text;
            }
            if(Request.QueryString["Id"] != null)
            {
                TicketNegocio negocio = new TicketNegocio();
                seleccionado = negocio.TicketPorId(int.Parse(Request.QueryString["Id"]));
            }

        }

        protected void btnEnviarRespuesta_Click(object sender, EventArgs e)
        {

            TicketRespuesta respuesta = new TicketRespuesta();
            TicketRespuestaNegocio negocio = new TicketRespuestaNegocio();

            respuesta.Agente =(Agente) Session["agente"];
            respuesta.Fecha = DateTime.Now;
            respuesta.TicketId = seleccionado.TicketID;
            respuesta.Respuesta = txtRespuestaNueva.Text;

            negocio.InsertarNueva(respuesta);
            
        }
    }
}