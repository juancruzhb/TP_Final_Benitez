using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Benitez
{
    public partial class SupervisorMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorDashboard.aspx?q=" + txtSearch.Text, false);

        }
    }
}