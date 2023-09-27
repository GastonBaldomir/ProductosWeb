using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using ConexionDb;
using System.Drawing;
using System.Collections;

namespace ProductosWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductosNegocio negocio = new ProductosNegocio();

                dgvProductosFavoritos.DataSource = Session["Favoritos"];
                dgvProductosFavoritos.DataBind();
            }
        }

        protected void dgvProductosFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
              
            Productos aux = new Productos();
            string id = dgvProductosFavoritos.SelectedDataKey.Value.ToString();
            List<Productos> lista = (List<Productos>)Session["Favoritos"];
            lista.RemoveAll(x => x.Id == int.Parse(id));
           
            dgvProductosFavoritos.DataSource = Session["Favoritos"];
            dgvProductosFavoritos.DataBind();
                
            
            
            //    miLista.RemoveAll(x => x.Id == idToRemove);
        }
    }
}