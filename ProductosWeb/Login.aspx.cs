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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            Persona persona = new Persona();
            PersonaNegocio negocio = new PersonaNegocio();
            try
            {
                if ((txbUser.Text == "") || (txbPass.Text == ""))
                {
                    Session.Add("error", "Debes completar ambos campos, con los datos requeridos");
                    Response.Redirect("Error.aspx", false);
                }

                persona.Email = txbUser.Text;
                persona.Pass = txbPass.Text;

                if (negocio.Loguear(persona))
                {
                    Session.Add("usuario", persona);
                    Response.Redirect("MenuLogin.aspx", false);
                }
                else if (((txbUser.Text != "") && (txbPass.Text != "")))
                {

                    Session.Add("error", "Usuario o contrasela incorrecta.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {

                Session.Add("error", false);
            }
                
        }
            
        
    }
}