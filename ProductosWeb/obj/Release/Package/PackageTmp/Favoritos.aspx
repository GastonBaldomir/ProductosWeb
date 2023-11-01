<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProductosWeb.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mt-5 fs-2">Seccion favoritos</h1>
    <% if (Session["Favoritos"]==null)
        {  %>
    <p class="text-center mt-3 text-primary">Agregá productos a esta sección desde el catálogo principal, accediendo a la opción (Ver detalle) del producto. </p>
    <%} %>
    <div class="row">
        <div class="col-12 text-center">
            <asp:GridView ID="dgvProductosFavoritos" CssClass="table table-secondary mt-4" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductosFavoritos_SelectedIndexChanged" >
                <Columns>
                   <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                   <asp:BoundField  HeaderText="Marca" DataField="Marca.Descripcion"/> 
                   <asp:BoundField  HeaderText="Precio" DataField="Precio"/> 
                   <asp:CommandField  ShowSelectButton="true" SelectText="Eliminar" HeaderText="Accion"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="text-center mt-4">   
                 <a href="Default.aspx" class="btn btn-secondary text-center">Regresar</a>
            </div>
    </div>
</asp:Content>
