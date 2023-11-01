<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="ProductosWeb.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color:gray;
            font-size: 15px;
        }
        .lbl{
            color:dodgerblue;
            margin-left:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager id="scriptManager1" runat="server" />
    <div class="row mt-4">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Id" ID="lblId" runat="server" class="form-label lbl" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txbId" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" class="form-label lbl" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txbNombre" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Proucto tiene que ingresarse con un Nombre." ControlToValidate="txbNombre" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Codigo de Articulo" ID="lblCodArt" runat="server" class="form-label lbl" />
                <asp:TextBox CssClass="form-control " runat="server" ID="txbCodArt" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" ID="lblPrecio" runat="server" class="form-label lbl" />
                <asp:TextBox CssClass="form-control" type="" runat="server" ID="txbPrecio" />              
                <asp:RequiredFieldValidator CssClass="validacion " ErrorMessage="El campo es requerido." ControlToValidate="txbPrecio" runat="server" />
                <asp:RegularExpressionValidator  CssClass="validacion" ErrorMessage="Solo Caractéres Numéricos." ControlToValidate="txbPrecio" ValidationExpression="^[0-9]+([.,][0-9]+)?$" runat="server" />
            </div>
           
            <div class="mb-3">
                <label for="dropDawnMarca" class="form-label lbl">Marca</label>
                <asp:DropDownList ID="dropDawnMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="dropDawnCategoria" class="form-label lbl">Categoria</label>
                <asp:DropDownList ID="dropDawnCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click"  />
                <asp:Button Text="Cancelar" CssClass="btn btn-secondary" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"  />
                
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label Text="Imagen" ID="txbImagen" runat="server" class="form-label lbl" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtUrlImg" AutoPostBack="true" OnTextChanged="txtUrlImg_TextChanged1" />
                    </div>
                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s" runat="server" ID="urlImg" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3 mt-3">
                <asp:Label Text="Descripcion" ID="lblDescripcion" runat="server" class="form-label lbl" />
                <asp:TextBox CssClass="form-control" TextMode="MultiLine" runat="server" ID="txbDescripcion" />
            </div>
        </div>
      </div>
     <div class="row">
            <div class="col-6"> 
                <asp:UpdatePanel ID="updatepanelEliminar" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">   
                            <asp:Button Text="Eliminar" Cssclass="btn btn-danger" OnClick="btnEliminar_Click" id="btnEliminar" runat="server" />
                        </div>                 
                     <%if (confirmaEliminacion){%>
                      <div class="mb-3">   
                        <asp:CheckBox Text="Confirmar Eliminar" id="chkboxConfirmaEliminar" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnconfirmaEliminar" OnClick="btnconfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                      </div>

                     <% } %>
                 </ContentTemplate>
            </asp:UpdatePanel>
        </div>
     </div>
</asp:Content>
