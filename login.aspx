<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">

    <div class="container">
        <div class="col-xs-12 col-md-8 col-md-offset-2">
            <img class="img-responsive imagenLogo" src="img/logo_pic2job.png" alt="logo" />
        </div>
        <div class="col-xs-8 col-xs-offset-2 col-sm-6 col-sm-offset-3">

            <asp:TextBox CssClass="col-xs-12 email" ID="textBox_email" runat="server" placeholder="Introduce tu email" />
            <asp:TextBox CssClass="col-xs-12 pass" ID="textBox_pass" runat="server" placeholder="Introduce tu pass" TextMode="password" />
            <asp:Button CssClass="col-xs-12 botonLogin" ID="button_validacion" runat="server" Text="ENTRAR" OnClick="validacion_Click" />
            <asp:RequiredFieldValidator CssClass="text-center textoError col-xs-4 col-xs-offset-4 alert alert-danger" ID="validacionEmail" runat="server" ErrorMessage="Introduce tu email" ControlToValidate="textBox_email" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
        <div class="col-xs-4 col-xs-offset-4 alert alert-danger" id="errorUsuario" runat="server" Visible="false">
            <asp:Label ID="LabelError" runat="server" CssClass="alert alert-danger text-center textoError" Text="Usuario o contraseña incorrectos!"></asp:Label>
        </div>

    </div>

</asp:Content>

