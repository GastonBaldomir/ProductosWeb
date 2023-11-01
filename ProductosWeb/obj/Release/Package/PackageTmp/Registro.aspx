<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProductosWeb.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color:red;
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex justify-content-center mt-5">
        <h1>Registro de nuevo Usuario</h1>
    </div>
    <div class="d-flex">
        <div class="col-4 mt-4">
        </div>
        <div class="col-4 mt-4 text-center">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label text-center">Email</label>
                <asp:TextBox runat="server" ID="txbUserRegistro" type="" class="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Ingresar formato e-mail." ControlToValidate="txbUserRegistro" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3 text-center">
                <label for="exampleInputPassword1" class="form-label text-center">Contraseña</label>
                <asp:TextBox runat="server" ID="txbPassRegistro" type="password" class="form-control" />
            </div>

            <asp:Button type="submit" Text="Registrar" ID="btnRegistrarUser" OnClick="btnRegistrarUser_Click" CssClass="btn btn-dark" runat="server" />
        </div>
        <div class="col-4 mt-4">
       </div>
    </div>
</asp:Content>
