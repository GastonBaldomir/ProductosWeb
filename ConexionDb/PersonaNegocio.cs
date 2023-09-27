using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDb
{
    public class PersonaNegocio
    {
        public bool Loguear(Persona user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email,pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email AND pass = @pass");

                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Pass);
                

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Admin = (bool)(datos.Lector["admin"]);
                    if(!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.ImgPerfil = (string)(datos.Lector["urlImagenPerfil"]);
                    if (!(datos.Lector["apellido"] is DBNull))
                         user.Apellido = (string)(datos.Lector["apellido"]);
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)(datos.Lector["nombre"]);
                        //user.Email = (string)(datos.Lector["email"]);
                        return true;
                }
                //while (datos.Lector.Read())
                //{
                //    user.Id = (int)datos.Lector["Id"];
                //    user.Admin = (bool)(datos.Lector["Admin"]);
                //    if (!(datos.Lector["nombre"] is DBNull))
                //        user.Nombre = (string)(datos.Lector["nombre"]);

                //    if (!(datos.Lector["imagenPerfil"] is DBNull))
                //        user.ImgPerfil = (string)(datos.Lector["imagenPerfil"]);
                //    if (!(datos.Lector["apellido"] is DBNull))
                //        user.Apellido = (string)(datos.Lector["apellido"]);
                //    return true;
                //}
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public int InsertarRegistro(Persona registro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into USERS (email, pass, admin) output inserted.Id values (@email, @pass ,0)");
                datos.setearParametros("@email", registro.Email);
                datos.setearParametros("@pass", registro.Pass);

                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public void actualizar (Persona user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {    
                datos.setearConsulta("update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagen, email = @email Where Id= @id");
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido );
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@imagen", user.ImgPerfil != null ? user.ImgPerfil : "");
                datos.setearParametros("@id", user.Id);
               
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
