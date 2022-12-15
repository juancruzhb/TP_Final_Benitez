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
    public partial class TicketDetalles : System.Web.UI.Page
    {
        public Ticket seleccionado = new Ticket();
        public List<TicketRespuesta> respuestas = new List<TicketRespuesta>();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["Id"] != null)
            {
                TicketNegocio negocio = new TicketNegocio();
                seleccionado = negocio.TicketPorId(int.Parse(Request.QueryString["Id"]));

                TicketRespuestaNegocio TPNegocio = new TicketRespuestaNegocio();
                respuestas = TPNegocio.listar(seleccionado.TicketID);
            }

            rpRespuestas.DataSource = respuestas;
            rpRespuestas.DataBind();
            

        }

        protected void btnResponderTicket2_Click(object sender, EventArgs e)
        {
            MostrarOcultarRespuestas(true);
        }

        protected void btnCancelarRespuestaTicket_Click(object sender, EventArgs e)
        {
            MostrarOcultarRespuestas(false);
        }

        protected void MostrarOcultarRespuestas(bool estado)
        {
            btnCancelarRespuestaTicket.Visible = estado;
            txtRespuestaTicket.Visible = estado;
            btnEnviarRespuestaTicket.Visible = estado;
        }

        protected void btnEnviarRespuestaTicket_Click(object sender, EventArgs e)
        {

            TicketRespuesta respuesta = new TicketRespuesta();
            TicketRespuestaNegocio negocio = new TicketRespuestaNegocio();
            RespuestasLeidas nuevaRespuesta = new RespuestasLeidas();

            respuesta.Fecha = DateTime.Now;
            respuesta.TicketId = seleccionado.TicketID;
            respuesta.Respuesta = txtRespuestaTicket.Text;
            nuevaRespuesta.IdTicket = respuesta.TicketId;
            nuevaRespuesta.Leido = false;


            if(Session["agente"]!= null)
            {
                Agente aux = new Agente();
                aux = (Agente)Session["agente"];
                respuesta.Emisor = aux.IdAgente; ;
                respuesta.Tipo = 1;
                nuevaRespuesta.EsAgente = true;
               

            }else if (Session["usuario"] != null)
            {
                Usuario aux = new Usuario();
                aux = (Usuario)Session["usuario"];
                respuesta.Emisor = aux.IdUsuario;
                respuesta.Tipo = 0;
            }

            lblSuccesRespuesta.Visible = true;
            negocio.InsertarNueva(respuesta);
            Response.Redirect(Request.RawUrl);


        }
    }
}