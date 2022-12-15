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
    public partial class LoginAgente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");

            Agente agente = new Agente();
            Agente aux = new Agente();
            AgenteNegocio negocio = new AgenteNegocio();
            try
            {
                agente.Email = txtEmail.Text;
                agente.Password = txtPass.Text;

                if (negocio.Loguear(agente))
                {
                    aux = negocio.ObtenerAgente(agente);
                    Session.Add("agente", aux);
                    if(aux.Tipo.IdTipo == 3 && aux.Estado)
                    {
                        Response.Redirect("AgenteDashboard.aspx", false);
                    }else if(aux.Tipo.IdTipo == 2 && aux.Estado)
                    {
                        Response.Redirect("SupervisorDashboard.aspx", false);
                    }else if(aux.Tipo.IdTipo == 1 && aux.Estado)
                    {
                        Response.Redirect("AdminDashboard.aspx", false);
                    }else if (aux.Estado == false)
                    {
                        Session.Add("error", "El agente se encuentra desactivado, comuniquese con el administrador");
                        Response.Redirect("Error.aspx", false);
                    }


                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx", false);

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}