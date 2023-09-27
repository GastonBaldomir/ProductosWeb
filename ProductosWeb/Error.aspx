<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ProductosWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .candado{
            border-radius:50%;
            height:250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center m-5">   
    <%if (!ConexionDb.Seguridad.sesionActiva(Session["usuario"]))
        { %>
    <div class="text-center mt-5">
        <h1>Se produjo un error en el proceso.</h1>
        <h3 class="mt-3">Por favor ingresa desde el Login o Registrate para crear tu perfil.</h3>
        <h5 class="mt-3">Asegurate de que si ingresaste datos, sean los correctos.</h5>
         <asp:Label CssClass="text-danger" Text="" ID="lblError" runat="server" />
    </div>
    <% }%>

    <%else if (!ConexionDb.Seguridad.esAdmin(Session["usuario"]))
        { %>
    <div class="text-center mt-5">
        <h2 class="m-5">Para tener acceso a esta Sección debes ser un usuario con permiso de Administrador.</h2>
        <asp:Image CssClass="candado" ImageUrl="https://previews.123rf.com/images/ylivdesign/ylivdesign1507/ylivdesign150701178/41861099-imagen-de-candado-cerrado-en-el-c%C3%ADrculo-negro-aislado-en-blanco.jpg" runat="server" />
    </div>
    <% }%>
    <%else
        { %>
        <div>   
            <h1>pagina de error</h1>
           
        </div>
    
    <% }%>
        </div>
</asp:Content>
