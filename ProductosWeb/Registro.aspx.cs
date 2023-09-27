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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarUser_Click(object sender, EventArgs e)
        {

            try
            {
               Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                if ((txbUserRegistro.Text == "") || (txbPassRegistro.Text == ""))
                {
                    Session.Add("error", "Debes completar ambos campos, con los datos requeridos");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    Persona registro = new Persona();
                    PersonaNegocio negocio = new PersonaNegocio();
                    registro.Email = txbUserRegistro.Text;
                    registro.Pass = txbPassRegistro.Text;

                    registro.Id = negocio.InsertarRegistro(registro);

                    Session.Add("usuario", registro);
                    Response.Redirect("MenuLogin.aspx");
                }
            }
            catch (Exception)
            {

                Session.Add("error", false);
            }
                    

                
            
        }

    }
}