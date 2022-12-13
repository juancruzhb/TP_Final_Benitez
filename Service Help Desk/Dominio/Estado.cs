using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public bool Activo { get; set; }
        public string MostrarEstado
        {
            get
            {
                if (Activo)
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
