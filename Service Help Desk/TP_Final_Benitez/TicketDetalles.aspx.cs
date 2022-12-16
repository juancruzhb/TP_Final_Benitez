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

            if(seleccionado.Estado.Nombre == "Cerrado" || seleccionado.Estado.Nombre == "Resuelto")
            {
                btnResponderTicket2.Visible = false;
            }
            else
            {
                btnResponderTicket2.Visible = true;

            }

            if(seleccionado.Estado.Nombre == "Abierto")
            {
                btnReabrir.Visible = false;
            }


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
            btnEnviarRespuestaTicket.Visible = estado;
            btnCancelarRespuestaTicket.Visible = estado;
            txtRespuestaTicket.Visible = estado;

            if(Session["agente"] == null)
            {
                btnEnviarRespuestaTicketResuelto.Visible = false;
                btnEnviarRespuestaTicketPendiente.Visible = false;
                btnEnviarRespuestaTicketCerrado.Visible = false;
            }
            else
            {
                btnEnviarRespuestaTicket.Visible = estado;
                btnEnviarRespuestaTicketResuelto.Visible = estado;
                btnEnviarRespuestaTicketPendiente.Visible = estado;
                btnEnviarRespuestaTicketCerrado.Visible = estado;
            }
        }

        protected void btnEnviarRespuestaTicket_Click(object sender, EventArgs e)
        {
            enviarRespuesta();
        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

            if(Session["agente"]!= null)
            {
                Agente aux = new Agente();
                aux = (Agente)Session["agente"];

                if(aux.Tipo.IdTipo == 2)
                    Response.Redirect("SupervisorDashboard.aspx");
                else
                    Response.Redirect("AgenteDashboard.aspx");

            }else if (Session["usuario"] != null)
            {
                Response.Redirect("MenuUsuario.aspx");

            }
        }

        protected void btnEnviarRespuestaTicketResuelto_Click(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            negocio.CambiarEstado(seleccionado.TicketID, 3);

            EmailService emailService = new EmailService();
            string asunto = "Ticket #" + seleccionado.TicketID.ToString() +" Ha sido resuelto";
            string EmailDestino = seleccionado.Contacto;
            string cuerpo = "Los tecnicos informan que su ticket ha sido resuelto con el siguiente comentario: " + txtRespuestaTicket.Text;

            emailService.armarCorreo(EmailDestino, asunto, cuerpo);
            try
            {
                emailService.EnviarEmail();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            enviarRespuesta();

        }

        protected void btnEnviarRespuestaTicketPendiente_Click(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            negocio.CambiarEstado(seleccionado.TicketID, 4);
            enviarRespuesta();
        }

        protected void btnEnviarRespuestaTicketCerrado_Click(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            negocio.CambiarEstado(seleccionado.TicketID, 2);
            enviarRespuesta();
        }

        private void enviarRespuesta()
        {
            TicketRespuesta respuesta = new TicketRespuesta();
            TicketRespuestaNegocio negocio = new TicketRespuestaNegocio();


            respuesta.Fecha = DateTime.Now;
            respuesta.TicketId = seleccionado.TicketID;
            respuesta.Respuesta = txtRespuestaTicket.Text;
            respuesta.EsAgente = false;
            respuesta.Leido = false;



            if (Session["agente"] != null)
            {
                Agente aux = new Agente();
                aux = (Agente)Session["agente"];
                respuesta.Emisor = aux.IdAgente; ;
                respuesta.EsAgente = true;



            }
            else if (Session["usuario"] != null)
            {
                Usuario aux = new Usuario();
                aux = (Usuario)Session["usuario"];

            }

            lblSuccesRespuesta.Visible = true;
            negocio.InsertarNueva(respuesta);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnReabrir_Click(object sender, EventArgs e)
        {
            TicketNegocio negocio = new TicketNegocio();
            negocio.CambiarEstado(seleccionado.TicketID, 1);
            btnReabrir.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

    }
}