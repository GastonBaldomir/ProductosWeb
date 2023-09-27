using ConexionDb;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductosWeb
{
    public partial class Formulario : System.Web.UI.Page
    {
        public bool confirmaEliminacion = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            txbId.Enabled = false;
            try
            {
               
                if (!IsPostBack)
                {
                    ProductosNegocio productosNegocio = new ProductosNegocio();
                    List<Productos> lista = productosNegocio.listar();

                    HashSet<string> marcasUnicas = new HashSet<string>();


                    List<Productos> listaMarcasUnicas = new List<Productos>();
                    foreach (Productos producto in lista)
                    {
                        if (!marcasUnicas.Contains(producto.Marca.ToString()))
                        {
                            marcasUnicas.Add(producto.Marca.ToString());
                            listaMarcasUnicas.Add(producto);
                        }
                    }
                    List<Productos> listaCatUnicas = new List<Productos>();
                    foreach (Productos producto in lista)
                    {
                        if (!marcasUnicas.Contains(producto.Categoria.ToString()))
                        {
                            marcasUnicas.Add(producto.Categoria.ToString());
                            listaCatUnicas.Add(producto);
                        }
                    }

                    dropDawnMarca.DataSource = listaMarcasUnicas;
                    dropDawnMarca.DataValueField = "Id";
                    dropDawnMarca.DataTextField = "Marca";
                    dropDawnMarca.DataBind();

                    dropDawnCategoria.DataSource = listaCatUnicas;
                    dropDawnCategoria.DataValueField = "Id";
                    dropDawnCategoria.DataTextField = "Categoria";
                    dropDawnCategoria.DataBind();
                }
            //modificar

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductosNegocio negocio = new ProductosNegocio();
                    List<Productos> lista = negocio.listar(id);
                    Productos seleccionado = lista[0];

                    //precargar datos

                    txbId.Text = id;
                    txbNombre.Text = seleccionado.Nombre;
                    txbCodArt.Text = seleccionado.CodArt;
                    txbDescripcion.Text = seleccionado.Descripcion;
                    txbPrecio.Text = seleccionado.Precio.ToString();
                    if (seleccionado.Imagen != null)
                        txtUrlImg.Text = "";
                    else
                        txtUrlImg.Text = seleccionado.Imagen;
                    txtUrlImg_TextChanged1(sender, e);

                    dropDawnCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    dropDawnMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false)
;            }

        }

        protected void txtUrlImg_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Productos productoNuevo = new Productos();
                ProductosNegocio productosNegocio = new ProductosNegocio();

                productoNuevo.Nombre = txbNombre.Text;

                productoNuevo.CodArt = txbCodArt.Text.ToString();
                productoNuevo.Descripcion = txbDescripcion.Text;
                productoNuevo.Precio = decimal.Parse(txbPrecio.Text);
                productoNuevo.Imagen = txtUrlImg.Text;
                if ((txtUrlImg.Text == "")|| (txtUrlImg.Text == null))
                {
                    string imgVacia = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s";
                    productoNuevo.Imagen = imgVacia;
                }

                productoNuevo.Categoria = new Categoria();
                productoNuevo.Categoria.Id = int.Parse(dropDawnCategoria.SelectedValue);

                productoNuevo.Marca = new Marca();
                productoNuevo.Marca.Id = int.Parse(dropDawnMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    productoNuevo.Id = int.Parse(txbId.Text);
                    productosNegocio.modificar(productoNuevo);
                }
                else
                    productosNegocio.agregar(productoNuevo);


                Response.Redirect("ListaProductos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx" , false);
            }
        }

        protected void txtUrlImg_TextChanged1(object sender, EventArgs e)
        {
            urlImg.ImageUrl = txtUrlImg.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                confirmaEliminacion = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void btnconfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkboxConfirmaEliminar.Checked)
                {
                    ProductosNegocio negocio = new ProductosNegocio();
                    negocio.eliminar(int.Parse(txbId.Text));
                    Response.Redirect("ListaProductos.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            Response.Redirect("ListaProductos.aspx");
        }
    }
}