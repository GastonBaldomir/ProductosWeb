<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="ProductosWeb.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container row mt-5">
        <div class="col-md-4 text-center mt-4">
            <div class="mb- mt-2 text-center">
                <label class=" text-primary fs-5">Nombre</label>
                <asp:TextBox runat="server" ID="txbNombrePerfil" CssClass="form-control text-center" />
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txbNombrePerfil" runat="server" />
            </div>
            <div class="mb3 mt-2 text-center">
                <label class=" text-primary fs-5">Apellido</label>
                <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control text-center" />
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txbApellido" runat="server" />
            </div>
            <div class="mb- mt-2 text-center">
                <label class=" text-primary fs-5">Email</label>
                <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control text-center" />
            </div>
            <div class="mb- mt-3 text-center">
                <label class=" text-primary fs-5">Imagen de Perfil</label>
                <input type="file" id="txtImgPerfil" runat="server" class="form-control mt-2" />
            </div>
            <div class="mb-3 mt-2 text-center">
                <asp:Button Text="Guardar" CssClass="btn btn-primary m-3" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
                <a href="Default.aspx" class="btn btn-primary m-3">Cancelar</a>
            </div>

        </div>
        <div class="col-md-3 text-center mt-4"></div>
        <div class="col-md-4 text-center mt-4">
            <div class="mb-4">
            </div>
            <asp:Image ID="nuevoPerfilImg" runat="server" CssClass=" mb-3" Width="100%"
                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s" />
        </div>

    </div>
</asp:Content>
