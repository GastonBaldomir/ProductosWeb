<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="ProductosWeb.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sriptManager2" runat="server" />
    <h1 class="mb-3 mt-5">Listado de Productos</h1>
    <asp:UpdatePanel ID="updatePanel2" runat="server">
        <ContentTemplate>
            <div class="row">   
         <div class="col-4"> 
             <div class="mb-3">  
                <label>Filtrar</label>
                <asp:TextBox runat="server" ID="txbFiltro" CssClass="form-control" AutoPostBack="True" OnTextChanged="txbFiltro_TextChanged" />
              </div>
          </div>
        <div class="col-4" style="display:flex; flex-direction:column; justify-content: flex-end">
            <div class="mb-3">   
                <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkdFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkdFiltroAvanzado_CheckedChanged"  />
            </div>
        </div>
    </div>
    <%if (filtroAvanzado)
        {%>

    <div class="row">
        <div class="col-4"> 
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" CssClass="" />
                <asp:DropDownList runat="server" ID="ddwnFiltroCampo" AutoPostBack="true" OnSelectedIndexChanged="ddwnFiltroCampo_SelectedIndexChanged" CssClass="form-control">
                     <asp:ListItem Text="Seleccionar..."/>
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4"> 
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddwnFiltroCriterio" CssClass="form-control">
                
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4"> 
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" id="txbFiltroAv" CssClass="form-control"/>
            </div>
        </div>
    </div>
    <div class="row">   
        <div class="col-3 mb-3">
            <asp:Button Text="Buscar" runat="server" id="btnBuscarFilAv" OnClick="btnBuscarFilAv_Click" CssClass="btn btn-dark"/>
        </div>
    </div>
        <% } %>

    <div class="row">
        <div class="col-10">
            <asp:GridView ID="dgvProductos" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" OnPageIndexChanging="dgvProductos_PageIndexChanging" AllowPaging="true" PageSize="4">
                <Columns>
                   <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                   <asp:BoundField  HeaderText="Marca" DataField="Marca.Descripcion"/> 
                   <asp:BoundField  HeaderText="Precio" DataField="Precio"/> 
                   <asp:CommandField  ShowSelectButton="true" SelectText="Modificar" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <%--<asp:Button Text="Agregar"  CssClass="btn btn-primary" id="btnAgregar" runat="server"  />--%>
            <a href="Formulario.aspx" class="btn btn-primary">Agregar</a>

        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
