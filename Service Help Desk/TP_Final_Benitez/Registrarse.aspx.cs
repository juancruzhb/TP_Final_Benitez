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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                user.Apellido = txtApellido.Text;
                user.Nombre = txtNombre.Text;
                user.Email = txtCorreo.Text;
                user.Password = txtPass.Text;
               int id = negocio.insertarNuevo(user);
                

            }
            catch (Exception ex)
            {

                Session.Add("error",ex.ToString());
            }

        }
    }
}