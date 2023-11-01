<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="FiltroDefault.aspx.cs" Inherits="ProductosWeb.FiltroDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-3 mb-3">
        <div class="mb-3">
            <h1>Filtro Aplicado</h1>
            <%if (MostrarFiltro.Count != 0)
                { %>
            <p>Productos que coinciden con tu busqueda.</p>
            <%} %>
            <%else
                { %>
            <p>No hay productos que coincidan con tu busqueda.</p>
            <%} %>
        </div>
        <div class="mb-3">
            <asp:Button Text="Volver" runat="server" ID="btnVolverFiltroDefault" OnClick="btnVolverFiltroDefault_Click" CssClass="btn btn-dark" />
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-2 g-4 mt-4s">
        <%  foreach (var item in MostrarFiltro)
            {
        %>
        <div class="col text-center d-flex justify-content-center align-items-center " height="600">
            <div class="card w-50 border-2">
                <img src="<%:item.Imagen %>" class="card-img-top" height="200" alt="...">
                <div class="card-body bg-light">
                    <h5 class="card-title"><%:item.Nombre%></h5>
                    <%--item porque en el for each no cambie y la deje asi.--%>
                    <p class="card-text"><%:"$"+item.Precio %></p>
                    <a href="Detalle.aspx?Id=<%:item.Id %>">Ver Detalle</a>
                </div>
            </div>
        </div>
        <%  }%>
    </div>
</asp:Content>
