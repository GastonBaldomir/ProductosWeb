<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProductosWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sriptManager2" runat="server" />
    <h1 class="text-center  mt-5 fs-2"><em>Detalle del producto seleccionado.</em></h1>

    <div class="row m-3 mt-5">
        <div class="col-4 m-4 ">
            <div class="mb-4 ">
                <asp:Label Text="Nombre" ID="lblNombreDetalle" runat="server" class="form-label fs-5" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txbNombreDetalle" />
            </div>
            <div class="mb-4">
                <asp:Label Text="Precio" ID="idPrecioDetalle" runat="server" class="form-label fs-5" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txbPrecioDetalle" />
            </div>
            <div class="mb-4">
                <asp:Label Text="Descripcion del Producto" ID="lblDescripcionDetalle" runat="server" class="form-label text-dark fs-5 text-center " />
                <asp:TextBox CssClass="form-control text-secondary" runat="server" ID="txbDescrDetalle" TextMode="MultiLine" Enabled="false"/>
            </div>
            <div class="mb-4">
                <asp:Button Text="Regresar" runat="server" CssClass="btn btn-primary" ID="btnDetalleRegresar" OnClick="btnDetalleRegresar_Click"   />
               <asp:Button Text="Agregar a Favoritos" runat="server" id="btnFav" CssClass="btn btn-secondary" OnClick="btnFav_Click" />
            </div>
        </div>
        <div class="col-2 m-4"></div>
        <div class="col-4 m-4">
            <asp:UpdatePanel ID="updatePanel3" runat="server">
                <ContentTemplate>
                    <div class="mb-3">                         
                            <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s" runat="server" ID="urlImgDetalle" style="Height:350px; Width: 400px;" />                    
                        <asp:TextBox CssClass="form-control d-none" runat="server" ID="txtUrlImgDetalle"  />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
         
    </div>
</asp:Content>
