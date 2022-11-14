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
            if (txtApellido.Text == null || txtApellido.Text == "" || txtNombre.Text == null || txtNombre.Text == "" || txtCorreo.Text == null || txtCorreo.Text == "" || txtPass.Text == null || txtPass.Text == "" || txtConfirmaPass.Text == null || txtConfirmaPass.Text == "")

            {
                lblRequerido.Text = "TODOS LOS CAMPOS SON REQUIRIDOS";

            }else if(txtPass.Text != txtConfirmaPass.Text)
            {
                lblRequerido.Text = "LAS CONTRASEÑAS NO COINCIDEN";
            }
            else
            {
                lblRequerido.Text = "";
                try
                {
                    Usuario user = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    user.Apellido = txtApellido.Text;
                    user.Nombre = txtNombre.Text;
                    user.Email = txtCorreo.Text;
                    user.Password = txtPass.Text;
                   int id = negocio.InsertarNuevo(user);

                }
                catch (Exception ex)
                {

                    Session.Add("error",ex.ToString());
                }
            }

        }
    }
}