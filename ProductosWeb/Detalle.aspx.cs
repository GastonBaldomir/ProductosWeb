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
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Productos> Favoritos
        {
            get
            {
                if (Session["Favoritos"] == null)
                {
                    Session["Favoritos"] = new List<Productos>(); //recibi ayuda en esta parte Maxi, creo que se podia hacer mas facil pero me trabé
                                                                  // use chatgpt te eh fallado jaja pero entendi el codigo y como funciona
                }                                   
                return (List<Productos>)Session["Favoritos"];
            }
            set
            {
                Session["Favoritos"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductosNegocio negocio = new ProductosNegocio();
                    List<Productos> lista = negocio.listar(id);
                    Productos seleccionado = lista[0];

                    txbNombreDetalle.Text= seleccionado.Nombre;
                    txbPrecioDetalle.Text = seleccionado.Precio.ToString();
                    txbDescrDetalle.Text = seleccionado.Descripcion;
                    txtUrlImgDetalle.Text = seleccionado.Imagen;
                    txtUrlImgDetalle_TextChanged(sender, e);
                    txtUrlImgDetalle.Enabled = false;   
                   
                }    
                
            }
			catch (Exception ex)
			{
				Session.Add("error",ex.ToString());
                Response.Redirect("Error.aspx", false);       
       		}
        }

        protected void txtUrlImgDetalle_TextChanged(object sender, EventArgs e)
        {
            urlImgDetalle.ImageUrl = txtUrlImgDetalle.Text;
        }

        protected void btnDetalleRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            ProductosNegocio negocio = new ProductosNegocio();
            List<Productos> listaFav = negocio.listar(id);
            Favoritos.Add(listaFav[0]);
            Response.Redirect("Favoritos.aspx");
     
        }

        
    }
}