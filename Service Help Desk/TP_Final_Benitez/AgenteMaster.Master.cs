using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Final_Benitez
{
    public partial class AgenteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["agente"] != null)
            {
                Agente agente = (Agente)Session["agente"];
                if(agente.Tipo.IdTipo == 2)
                {
                    btnSupervisorDashboard.Enabled = true;

                }
            }
            else
            {
                btnSupervisorDashboard.Enabled = false;

            }

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void btnSupervisorDashboard_Click(object sender, EventArgs e)
        {
            Agente agente = (Agente)Session["agente"];

            if(agente.Tipo.IdTipo == 2)
            {
                Response.Redirect("SupervisorDashboard.aspx");
            }
            else
            {
                btnSupervisorDashboard.Enabled = false;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgenteDashboard.aspx?q=" + txtSearch.Text, false);
        }
    }
}