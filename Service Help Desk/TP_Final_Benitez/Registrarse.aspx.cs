using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final_Benitez
{
    public partial class Registrarse : System.Web.UI.Page
    {
        List<Usuario> usuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio n = new UsuarioNegocio();
            List<String> emails = new List<string>();
            usuarios = n.listar();

            foreach (var item in usuarios)
            {
                emails.Add(item.Email);

            }

            if (emails.Contains(txtCorreo.Text))
            {
                lblRequerido.Text = "LA CUENTA YA SE ENCUENTRA REGISTRADA";
            }
            else
            {


                int id = 0;
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
                        id = negocio.InsertarNuevo(user);

                    }
                    catch (Exception ex)
                    {

                        Session.Add("error",ex.ToString());
                    }
                }

                EmailService emailService = new EmailService();
                emailService.armarCorreo(txtCorreo.Text, "Gracias por Registrarse", "prueba");
                try
                {
                    emailService.EnviarEmail();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                if (id > 0)
                {
                    Response.AppendHeader("Refresh", "5;url=Login.aspx");
                    lblRedirigiendo.Text = "Registro Exitoso, Sera redirigido al login";
                }

            }

        }
    }
}