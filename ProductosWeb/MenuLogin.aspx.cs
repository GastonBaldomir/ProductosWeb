using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConexionDb;
using Dominio;

namespace ProductosWeb
{
    public partial class MenuLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    
                    Persona user = (Persona)Session["usuario"];
                    txbEmail.Enabled = false;
                    if (!IsPostBack)
                    {

                        txbEmail.Text = user.Email.ToString();

                        if (user.Apellido != null)
                            txbApellido.Text = user.Apellido;
                        if (user.Nombre != null)
                            txbNombrePerfil.Text = user.Nombre.ToString();

                        if ((user.ImgPerfil != "") && (user.ImgPerfil != null))
                        {

                            nuevoPerfilImg.ImageUrl = "~/Images/" + ((Persona)Session["usuario"]).ImgPerfil;
                        }
                        else
                            nuevoPerfilImg.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                Session.Add("error", ex.ToString());
            }
           
           

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                PersonaNegocio negocio = new PersonaNegocio();
                Persona user =(Persona)Session["usuario"];

                if (txtImgPerfil.PostedFile.FileName != "") // si no hay nada seleccionado
                {
                  
                    string ruta = Server.MapPath("./Images/");
                    txtImgPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImgPerfil = "perfil-" + user.Id  + ".jpg";
                }

                // if((txbNombrePerfil.Text != null)&&(txbNombrePerfil.Text != ""))          
                user.Nombre = txbNombrePerfil.Text;
               // if ((txbApellido.Text != null) && (txbApellido.Text != ""))
                    user.Apellido = txbApellido.Text;
                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImgPerfil;
                nuevoPerfilImg.ImageUrl = "~/Images/" + ((Persona)Session["usuario"]).ImgPerfil;

            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                Session.Add("error", ex.ToString());
            }
        }
    }
}