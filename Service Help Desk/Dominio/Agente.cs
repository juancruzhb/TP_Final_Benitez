using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agente
    {
        public int IdAgente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Tipo Tipo { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public string NombreApellido
        {

            get { return Nombre + " " + Apellido; }
        }

        public string MostrarEstado
        {
            get
            {
                if (Estado)
                {
                    return "Activo";
                }
                else
                {
                    return "Desactivado";
                }
            }
        }

    }
}
