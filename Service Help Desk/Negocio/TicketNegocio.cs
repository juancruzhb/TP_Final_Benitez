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
                datos.setearParametros("@IdAgente", DBNull.Value);

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
            List<Agente> agentes = new List<Agente>();
            List<Usuario> usuarios = new List<Usuario>();
            EstadoNegocio eNegocio = new EstadoNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();
            PrioridadNegocio pNegocio = new PrioridadNegocio();
            AgenteNegocio aNegocio = new AgenteNegocio();
            UsuarioNegocio uNegocio = new UsuarioNegocio();

            categorias = cNegocio.listar();
            prioridades = pNegocio.listar();
            estados = eNegocio.listar();
            agentes = aNegocio.listar();
            usuarios = uNegocio.listar();

            int idaux = 0;


            try
            {
                if (id == 0)
                {
                    datos.setearQuery("select Id, Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular, IdAgente from Tickets");

                }
                else
                {
                    datos.setearQuery("select Id, Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular, IdAgente from Tickets where Idusuario = @Id");
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
                        Estado = estados.Find(x => x.IdEstado.Equals((int)datos.Reader["IdEstado"])),
                        User = usuarios.Find(x => x.IdUsuario.Equals((int)datos.Reader["IdUsuario"])),
                        IdAgenteAsignado = datos.Reader["IdAgente"] != (object)DBNull.Value ? (int)datos.Reader["IdAgente"] : 0
                        //AgenteAsignad o = datos.Reader["IdAgente"] != null ? agentes.Find(x => x.IdAgente.Equals((int)datos.Reader["IdAgente"])): agenteAux

                        //AgenteAsignado = agenteAux

                    }) ;

                }
                return tickets;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public Ticket TicketPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Categoria> categorias = new List<Categoria>();
            List<Prioridad> prioridades = new List<Prioridad>();
            List<Agente> agentes = new List<Agente>();
            List<Estado> estados = new List<Estado>();
            EstadoNegocio eNegocio = new EstadoNegocio();
            AgenteNegocio aNegocio = new AgenteNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();
            PrioridadNegocio pNegocio = new PrioridadNegocio();
            Agente aux = new Agente();
            aux.Nombre = "Sin asignar";

            categorias = cNegocio.listar();
            prioridades = pNegocio.listar();
            estados = eNegocio.listar();
            agentes = aNegocio.listar();

            try
            {
                Ticket ticket = new Ticket();

                datos.setearQuery("Select Id, Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular, IdAgente FROM Tickets WHERE Id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarReader();

                while (datos.Reader.Read())
                {

                    ticket.TicketID = (int)datos.Reader["Id"];
                    ticket.Asunto = datos.Reader["Asunto"].ToString();
                    ticket.Mensaje = datos.Reader["Mensaje"].ToString();
                    ticket.FechaCreacion = (DateTime)datos.Reader["FechaCreacion"];
                    ticket.Contacto = datos.Reader["Celular"].ToString();
                    ticket.oCategoria = categorias.Find(x => x.IdCategoria.Equals((int)datos.Reader["IdCategoria"]));
                    ticket.oPrioridad = prioridades.Find(x => x.IdPrioridad.Equals((int)datos.Reader["IdPrioridad"]));
                    ticket.Estado = estados.Find(x => x.IdEstado.Equals((int)datos.Reader["IdEstado"]));
                    ticket.AgenteAsignado = datos.Reader["IdAgente"] != (object)DBNull.Value ? agentes.Find(x => x.IdAgente.Equals((int)datos.Reader["IdAgente"])):aux;
                }
                return ticket;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void AsignarAgente(int idTicket,int idAgente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update tickets set IdAgente = @IdAgente where Id = @IdTicket");
                datos.setearParametros("@IdAgente", idAgente);
                datos.setearParametros("@IdTicket", idTicket);

                datos.ejecutarQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CambiarEstado(int idTicket, int idEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update tickets set IdEstado = @IdEstado where Id = @IdTicket");
                datos.setearParametros("@IdEstado", idEstado);
                datos.setearParametros("@IdTicket", idTicket);

                datos.ejecutarQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }


}
