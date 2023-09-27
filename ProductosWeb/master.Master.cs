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
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Page is Login || Page is Default || Page is Registro || Page is Error /*|| Page is Detalle*/))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx");
            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Persona user = ((Persona)Session["usuario"]);

                if ((user.ImgPerfil != "") && (user.ImgPerfil != null))
                    imgAvatar.ImageUrl = "~/Images/" + ((Persona)Session["usuario"]).ImgPerfil;
                else
                    imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s";

            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuLogin.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}