using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using ConexionDb;

namespace ProductosWeb
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }    
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Session.Add("error", "No tienes permiso de Admin");
                    Response.Redirect("Error.aspx");

                }
                filtroAvanzado = chkdFiltroAvanzado.Checked;
                if (!IsPostBack)
                {
                    ProductosNegocio negocio = new ProductosNegocio();
                    Session.Add("listaProductos", negocio.listar());
                    dgvProductos.DataSource = Session["listaProductos"];
                    dgvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
            

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProductos.SelectedDataKey.Value.ToString(); /*GUARDO EL ID EN UNA VARIABLE Y LO MANDO A OTRA PAGINA REDIRECCIONANDO*/
            Response.Redirect("Formulario.aspx?id=" + id);
        }

        protected void dgvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;

            dgvProductos.DataSource = Session["listaProductos"];//no se si va, agreugue porqeu no funcionaba el cambio de pag con el filtro
            dgvProductos.DataBind();
        }

        protected void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Productos> lista = (List<Productos>)Session["listaProductos"];
                List<Productos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txbFiltro.Text.ToUpper())); //FILTRO
                dgvProductos.DataSource = listaFiltrada;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void chkdFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
          
            try
            {
                filtroAvanzado = chkdFiltroAvanzado.Checked;
                txbFiltro.Enabled = !filtroAvanzado;
                if (!filtroAvanzado )
                {
                    ProductosNegocio negocio = new ProductosNegocio();
                    Session.Add("listaProductos", negocio.listar());
                    dgvProductos.DataSource = Session["listaProductos"];
                    dgvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddwnFiltroCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddwnFiltroCriterio.Items.Clear();

            if (ddwnFiltroCampo.SelectedItem.ToString() == "Precio")
            {
                ddwnFiltroCriterio.Items.Add("Mayor a:");
                ddwnFiltroCriterio.Items.Add("Menor a:");
                ddwnFiltroCriterio.Items.Add("Igual a:");
            }
            else
            {
                ddwnFiltroCriterio.Items.Add("Contiene: ");
                ddwnFiltroCriterio.Items.Add("Comienza con: ");
                ddwnFiltroCriterio.Items.Add("Termina con: ");
            }
        }

        protected void btnBuscarFilAv_Click(object sender, EventArgs e)
        {
         string criterio = ddwnFiltroCriterio.Text;
         string campo = ddwnFiltroCampo.Text;
         string valor = txbFiltroAv.Text;   
         ProductosNegocio negocio = new ProductosNegocio();
         negocio.filtrarProductos(dgvProductos, campo, criterio, valor);
        }
    }
}