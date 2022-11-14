using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class TicketNegocio
    {
        public int InsertarNuevo(Ticket ticket)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_InsertarTicket");
                datos.setearParametros("@Asunto", ticket.Asunto);
                datos.setearParametros("@Mensaje", ticket.Mensaje);
                datos.setearParametros("@IdCategoria", ticket.oCategoria.IdCategoria);
                datos.setearParametros("@IdPrioridad", ticket.oPrioridad.IdPrioridad);
                datos.setearParametros("@FechaCreacion", ticket.FechaCreacion);
                datos.setearParametros("@IdEstado", 1);
                datos.setearParametros("@IdUsuario", ticket.User.IdUsuario);
                datos.setearParametros("@Celular", ticket.Contacto);

                return datos.ejecutarScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }

        }

        public List<Ticket> listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Ticket> tickets = new List<Ticket>();
            List<Categoria> categorias = new List<Categoria>();
            List<Prioridad> prioridades = new List<Prioridad>();
            List<Estado> estados = new List<Estado>();
            EstadoNegocio eNegocio = new EstadoNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();
            PrioridadNegocio pNegocio = new PrioridadNegocio();

            categorias = cNegocio.listar();
            prioridades = pNegocio.listar();
            estados = eNegocio.listar();

            try
            {
                if(id == 0)
                {
                    datos.setearQuery("select Id, Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular from Tickets");

                }
                else
                {
                    datos.setearQuery("select Id, Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular from Tickets where Idusuario = @Id");
                    datos.setearParametros("@Id", id);
                }
                datos.ejecutarReader();

                while (datos.Reader.Read())
                {
                    tickets.Add(new Ticket
                    {
                        TicketID = (int)datos.Reader["Id"],
                        Asunto = datos.Reader["Asunto"].ToString(),
                        Mensaje = datos.Reader["Mensaje"].ToString(),
                        FechaCreacion = (DateTime)datos.Reader["FechaCreacion"],
                        Contacto = datos.Reader["Celular"].ToString(),
                        oCategoria = categorias.Find(x => x.IdCategoria.Equals((int)datos.Reader["IdCategoria"])),
                        oPrioridad = prioridades.Find(x => x.IdPrioridad.Equals((int)datos.Reader["IdPrioridad"])),
                         Estado= estados.Find(x => x.IdEstado.Equals((int)datos.Reader["IdEstado"]))

                    });
                }
                return tickets;

                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

    }

     
}
