<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">

    <div class="container">

        <div class="col-xs-12 col-md-8 col-md-offset-2">
            <img class="img-responsive imagenLogo" src="img/logo_pic2job.png" alt="logo" />
        </div>

        <div class="col-xs-8 col-xs-offset-2 col-sm-6 col-sm-offset-3">
            <div class="col-xs-12 alert alert-danger" id="errorCampos" runat="server" visible="false">
                <p class="text-center textoError">Rellena todos los campos!</p>
            </div>
            <asp:TextBox CssClass="col-xs-12 email" ID="textBoxNick" runat="server" placeholder="Introduce un Nick" />
            <div class="col-xs-12 alert alert-danger" id="errorNick" runat="server" visible="false">
                <p class="text-center textoError">El nick ya existe!</p>
            </div>
            <asp:TextBox CssClass="col-xs-12 email" ID="textBox_nombre" runat="server" placeholder="Introduce tu nombre" />
            <asp:TextBox CssClass="col-xs-12 email" ID="textBox_apellidos" runat="server" placeholder="Introduce tus apellidos" />
            <asp:TextBox CssClass="col-xs-12 email" ID="textBox_email" runat="server" placeholder="Introduce tu email" />
            <div class="col-xs-12 alert alert-danger" id="errorEmail" runat="server" visible="false">
                <p class="text-center textoError">Ese email ya está asociado a una cuenta!</p>
            </div>
            <asp:TextBox CssClass="col-xs-12 email" ID="textBoxTelf" runat="server" placeholder="Introduce tu teléfono" />
            <div class="col-xs-12 alert alert-danger" id="errorTelf" runat="server" visible="false">
                <p class="text-center textoError">Ese teléfono ya está asociado a una cuenta!</p>
            </div>
            <asp:TextBox CssClass="col-xs-12 email" ID="textBox_pass" runat="server" placeholder="Introduce tu pass" TextMode="password" CausesValidation="True" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Introduce una contraseña por favor!" ControlToValidate="textBox_pass" Display="Dynamic" CssClass="col-xs-12 alert alert-danger text-center"></asp:RequiredFieldValidator>
            <asp:TextBox CssClass="col-xs-12 pass" ID="textBox_passConfirmar" runat="server" placeholder="Introduce tu pass de nuevo" TextMode="password" CausesValidation="True" />
            <asp:CompareValidator ID="CompareValidatorPass" runat="server" ErrorMessage="Las contraseñas introducidas no son iguales!" Display="Dynamic" ControlToValidate="textBox_pass" ControlToCompare="textBox_passConfirmar" ValidateRequestMode="Enabled" CssClass="col-xs-12 alert alert-danger text-center"></asp:CompareValidator>
            <asp:Button CssClass="col-xs-12 botonLogin" ID="button_validacion" runat="server" Text="ENTRAR" OnClick="validacion_Click" />
            <asp:Label ID="LabelMensaje" runat="server" CssClass="col-xs-12 alert alert-danger" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>

