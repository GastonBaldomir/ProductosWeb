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
    public partial class FiltroDefault : System.Web.UI.Page
    {
        public List<Productos> MostrarFiltro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductosNegocio negocio = new ProductosNegocio();
                MostrarFiltro = (List<Productos>)Session["listaFiltrada"];
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void btnVolverFiltroDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}