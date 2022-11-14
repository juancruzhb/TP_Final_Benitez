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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Usuario aux = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPass.Text;

                if (negocio.Loguear(usuario))
                {
                    aux = negocio.ObtenerUsuario(usuario);
                    Session.Add("usuario", aux);
                    Response.Redirect("MenuUsuario.aspx",false);

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