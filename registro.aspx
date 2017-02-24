<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">

    <div class="container">

        <div class="col-xs-12 col-md-8 col-md-offset-2">
            <img class="img-responsive imagenLogo" src="img/logo_pic2job.png" alt="logo" />
        </div>
        <asp:Panel ID="PanelBotones" runat="server" CssClass="col-xs-12 col-md-8 col-md-offset-2">
            <asp:Button ID="ButtonUsuario" runat="server" Text="Usuario" OnClick="ButtonUsuario_Click" />
            <asp:Button ID="ButtonEmpresa" runat="server" Text="Empresa" OnClick="ButtonEmpresa_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelUsuarios" runat="server" Visible="false">
            <div class="col-xs-8 col-xs-offset-2 col-sm-6 col-sm-offset-3">

                <div class="col-xs-12 alert alert-danger" id="ErrorCamposUsuario" runat="server" visible="false">
                    <p class="text-center textoError">Rellena todos los campos!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxNick" runat="server" placeholder="Introduce un Nick" />
                <div class="col-xs-12 alert alert-danger" id="ErrorNick" runat="server" visible="false">
                    <p class="text-center textoError">El nick ya existe!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxNombreUsuario" runat="server" placeholder="Introduce tu nombre" />
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxApellidos" runat="server" placeholder="Introduce tus apellidos" />
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxEmailUsuario" runat="server" placeholder="Introduce tu email" />
                <div class="col-xs-12 alert alert-danger" id="ErrorEmailUsuario" runat="server" visible="false">
                    <p class="text-center textoError">Ese email ya está asociado a una cuenta!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxTelefonoUsuario" runat="server" placeholder="Introduce tu teléfono" />
                <div class="col-xs-12 alert alert-danger" id="ErrorTelefonoUsuario" runat="server" visible="false">
                    <p class="text-center textoError">Ese teléfono ya está asociado a una cuenta!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxPassUsuario" runat="server" placeholder="Introduce tu pass" TextMode="password" CausesValidation="True" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassUsuario" runat="server" ErrorMessage="Introduce una contraseña por favor!" ControlToValidate="TextBoxPassUsuario" Display="Dynamic" CssClass="col-xs-12 alert alert-danger text-center"></asp:RequiredFieldValidator>
                <asp:TextBox CssClass="col-xs-12 pass" ID="TextBoxPassConfirmarUsuario" runat="server" placeholder="Introduce tu pass de nuevo" TextMode="password" CausesValidation="True" />
                <asp:CompareValidator ID="CompareValidatorPassUsuario" runat="server" ErrorMessage="Las contraseñas introducidas no son iguales!" Display="Dynamic" ControlToValidate="TextBoxPassUsuario" ControlToCompare="TextBoxPassConfirmarUsuario" ValidateRequestMode="Enabled" CssClass="col-xs-12 alert alert-danger text-center"></asp:CompareValidator>
                <asp:Button CssClass="col-xs-12 botonLogin" ID="ButtonValidarUsuario" runat="server" Text="ENTRAR" OnClick="ValidacionUsuario_Click" />
                <asp:Label ID="LabelMensajeUsuario" runat="server" CssClass="col-xs-12 alert alert-danger" Visible="false"></asp:Label>

            </div>
        </asp:Panel>
        <asp:Panel ID="PanelEmpresas" runat="server" Visible="false">
            <div class="col-xs-8 col-xs-offset-2 col-sm-6 col-sm-offset-3">

                <div class="col-xs-12 alert alert-danger" id="ErrorCamposEmpresa" runat="server" visible="false">
                    <p class="text-center textoError">Rellena todos los campos!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxNombreEmpresa" runat="server" placeholder="Introduce un Nombre" />
                <div class="col-xs-12 alert alert-danger" id="ErrorNombre" runat="server" visible="false">
                    <p class="text-center textoError">El nombre ya existe!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxCif" runat="server" placeholder="Introduce el cif" />
                <div class="col-xs-12 alert alert-danger" id="ErrorCif" runat="server" visible="false">
                    <p class="text-center textoError">El cif ya existe!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxDireccion" runat="server" placeholder="Introduce tus direccion" />
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxEmailEmpresa" runat="server" placeholder="Introduce tu email" />
                <div class="col-xs-12 alert alert-danger" id="ErrorEmailEmpresa" runat="server" visible="false">
                    <p class="text-center textoError">Ese email ya está asociado a una cuenta!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxTelefonoEmpresa" runat="server" placeholder="Introduce tu teléfono" />
                <div class="col-xs-12 alert alert-danger" id="ErrorTelefonoEmpresa" runat="server" visible="false">
                    <p class="text-center textoError">Ese teléfono ya está asociado a una cuenta!</p>
                </div>
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxContacto" runat="server" placeholder="Introduce un Nombre de contacto" />
                <asp:TextBox CssClass="col-xs-12 email" ID="TextBoxPassEmpresa" runat="server" placeholder="Introduce tu pass" TextMode="password" CausesValidation="True" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassEmpresa" runat="server" ErrorMessage="Introduce una contraseña por favor!" ControlToValidate="TextBoxPassEmpresa" Display="Dynamic" CssClass="col-xs-12 alert alert-danger text-center"></asp:RequiredFieldValidator>
                <asp:TextBox CssClass="col-xs-12 pass" ID="TextBoxPassConfirmarEmpresa" runat="server" placeholder="Introduce tu pass de nuevo" TextMode="password" CausesValidation="True" />
                <asp:CompareValidator ID="CompareValidatorPassEmpresa" runat="server" ErrorMessage="Las contraseñas introducidas no son iguales!" Display="Dynamic" ControlToValidate="TextBoxPassEmpresa" ControlToCompare="TextBoxPassConfirmarEmpresa" ValidateRequestMode="Enabled" CssClass="col-xs-12 alert alert-danger text-center"></asp:CompareValidator>
                <asp:Button CssClass="col-xs-12 botonLogin" ID="ButtonValidarEmpresa" runat="server" Text="ENTRAR" OnClick="ValidacionEmpresa_Click" />
                <asp:Label ID="LabelMensajeEmpresa" runat="server" CssClass="col-xs-12 alert alert-danger" Visible="false"></asp:Label>

            </div>
        </asp:Panel>
    </div>
</asp:Content>

