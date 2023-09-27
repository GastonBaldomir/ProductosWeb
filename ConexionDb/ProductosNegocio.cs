using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web;
using System.Reflection;

namespace ConexionDb
{
    public class ProductosNegocio
    {

        public List<Productos> listar(string id = "")
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Id,Nombre, Codigo, ImagenUrl, Precio,A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, M.Id as IdMarca, C.Id as IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and A.IdCategoria= C.Id ";
                if (id != "")
                {
                    consulta += "and A.Id = " + id;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos aux = new Productos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodArt = (String)datos.Lector["Codigo"];
                    aux.Nombre = (String)datos.Lector["Nombre"];
                    aux.Descripcion = (String)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = (String)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (String)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (String)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (String)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                //conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Productos productoNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Nombre, Codigo,Precio, Descripcion,IdMarca,IdCategoria, ImagenUrl)values(@Nombre,@Codigo,@Precio,@Descripcion,@IdMarca,@IdCategoria, @Imagen) ");
                datos.setearParametros("@Nombre", productoNuevo.Nombre);
                datos.setearParametros("Codigo", productoNuevo.CodArt);
                datos.setearParametros("@Precio", productoNuevo.Precio);
                datos.setearParametros("@Descripcion", productoNuevo.Descripcion);
                datos.setearParametros("@IdMarca", productoNuevo.Marca.Id);
                datos.setearParametros("IdCategoria", productoNuevo.Categoria.Id);
                datos.setearParametros("@Imagen", productoNuevo.Imagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public void modificar(Productos seleccionado)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Nombre = @Nombre, Descripcion = @Descripcion,Codigo= @CodArt,ImagenUrl= @img, Precio=@Precio,IdMarca=@IdMarca,IdCategoria=@IdCategoria where Id=@Id ");
                datos.setearParametros("@Nombre", seleccionado.Nombre);
                datos.setearParametros("@Descripcion", seleccionado.Descripcion);
                datos.setearParametros("@CodArt", seleccionado.CodArt);
                datos.setearParametros("@img", seleccionado.Imagen);
                datos.setearParametros("@Precio", seleccionado.Precio);
                datos.setearParametros("@IdMarca", seleccionado.Marca.Id);

                datos.setearParametros("@IdCategoria", seleccionado.Categoria.Id);

                datos.setearParametros("@Id", seleccionado.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { datos.cerrarConexion(); }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS Where Id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void filtrarProductos(GridView dgvProductos, string campo, string criterio, string valor)
        {

            ProductosNegocio negocioFiltro = new ProductosNegocio();
            List<Productos> listaProductosF = negocioFiltro.listar();
            List<Productos> listaFiltrar;

            if (campo == "Precio")
            {
                int valorPrecio = int.Parse(valor);
                if (criterio == "Mayor a:")
                {
                    listaFiltrar = listaProductosF.FindAll(x => x.Precio > int.Parse(valor));
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = listaFiltrar;
                    dgvProductos.DataBind();
                }
                else if (criterio == "Menor a:")
                {
                    listaFiltrar = listaProductosF.FindAll(x => x.Precio < int.Parse(valor));
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = listaFiltrar;
                    dgvProductos.DataBind();
                }
                else
                {

                    listaFiltrar = listaProductosF.FindAll(x => x.Precio == int.Parse(valor));
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = listaFiltrar;
                    dgvProductos.DataBind();
                }

            }

            else if (campo == "Nombre")
            {
                if (criterio == "Comienza con: ")
                {
                    listaFiltrar = listaProductosF.Where(x => x.Nombre.ToUpper().StartsWith(valor.ToUpper())).ToList();
                }
                else if (criterio == "Termina con: ")
                {
                    listaFiltrar = listaProductosF.Where(x => x.Nombre.ToUpper().EndsWith(valor.ToUpper())).ToList();
                }
                else
                {
                    criterio = "Contiene: ";
                    listaFiltrar = listaProductosF.Where(x => x.Nombre.ToUpper().Contains(valor.ToUpper())).ToList();
                }
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaFiltrar;
                dgvProductos.DataBind();
            }
            else if (campo == "Categoria")
            {
                if (criterio == "Comienza con: ")
                {
                    listaFiltrar = listaProductosF.Where(x => x.Categoria.Descripcion.ToUpper().StartsWith(valor.ToUpper())).ToList();
                }
                else if (criterio == "Termina con: ")
                {
                    listaFiltrar = listaProductosF.Where(x => x.Categoria.Descripcion.ToUpper().EndsWith(valor.ToUpper())).ToList();
                }
                else
                {
                    criterio = "Contiene: ";
                    listaFiltrar = listaProductosF.Where(x => x.Categoria.Descripcion.ToUpper().Contains(valor.ToUpper())).ToList();
                }
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaFiltrar;
                dgvProductos.DataBind();
            }

        }

        public List<Productos> listarFiltroDB(string campo, string criterio, string valor)
        {
            try
            {
                List<Productos> listaFil = new List<Productos>();
                AccesoDatos datos = new AccesoDatos();

                string consulta = "select A.Id,Nombre, Codigo, ImagenUrl, Precio,A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, M.Id as IdMarca, C.Id as IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and A.IdCategoria= C.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a:":
                            consulta += "Precio > " + (int.Parse(valor));
                            break;
                        case "Menor a:":
                            consulta += "Precio < " + (int.Parse(valor));
                            break;
                        default:
                            consulta += "Precio = " + (int.Parse(valor));
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con: ":
                            consulta += "C.Descripcion like '" + valor + "%'";
                            break;
                        case "Termina con: ":
                            consulta += "C.Descripcion like '%" + valor + "' ";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + valor + "%'";
                            break;
                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con: ":
                            consulta += "Nombre like '" + valor + "%'";
                            break;
                        case "Termina con: ":
                            consulta += "Nombre like '%" + valor + "' ";
                            break;
                        default:
                            consulta += "Nombre like '%" + valor + "%'";
                            break;
                    }
                    
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Productos aux = new Productos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodArt = (String)datos.Lector["Codigo"];
                    aux.Nombre = (String)datos.Lector["Nombre"];
                    aux.Descripcion = (String)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = (String)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (String)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (String)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (String)datos.Lector["Categoria"];

                    listaFil.Add(aux);
                }

                return listaFil;
            }
            catch (Exception ex)
            {
               
                throw ex;
               
            }

        }
        
    }
    }
