<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeFile="PerfilEmpresa.aspx.cs" Inherits="PerfilEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">

    <!--NAVBAR-->
    <nav class="navbar navbar-default navbar-fixed-top text-center">

        <a href="#">
            <h2 class="brand">PIC2JOB</h2>
        </a>

    </nav>

    <!--CONTAINER-PRINCIPAL-->
    <div class="container-fluid marge-superior">

        <div class="alert alert-danger" role="alert" runat="server" id="PanelMissatge" visible="false">
            <asp:Label ID="LabelMissatge" runat="server" Text=""></asp:Label>
        </div>

        <!--COLUMNA-PER-PERFIL-->
        <div class="col-xs-3 ">

            <!--IMATGE-PERFIL-->
            <div class="col-xs-12 ">

                <div class="panel panel-default" runat="server" id="PanelFoto">
                    <img src="img/perfil_01.jpg" class="img-responsive img-thumbnail" />
                </div>

            </div>
            <!--DADES-PERFIL-->
            <div class="col-xs-12 ">

                <div class="panel panel-default" runat="server" id="PanelInformacio">

                    <div class="panel-heading">
                        <h3 class="panel-title">Datos Empresa</h3>
                    </div>

                    <div class="panel-body">

                        <!--TAULA-AMB-DADES-USUARI-->
                        <table>

                            <!--NOM-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">NOMBRE</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelNombre" runat="server" CssClass=""></asp:Label>

                                    <asp:TextBox ID="TextBoxNombre" runat="server" Visible="false"></asp:TextBox>

                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarNombre" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarNombre_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarNombre" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarNombre_Click"></asp:LinkButton>

                                </td>
                            </tr>

                            <!--DIRECCIO-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">DIRECCIÓN</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelDireccion" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxDireccion" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarDireccion" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarDireccion_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarDireccion" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarDireccion_Click"></asp:LinkButton>

                                </td>
                            </tr>

                            <!--CIUTAT-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">CIUDAD</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelCiudad" runat="server" CssClass=""></asp:Label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Visible="false"></asp:DropDownList>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarCiudad" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarCiudad_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarCiudad" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarCiudad_Click"></asp:LinkButton>
                                </td>
                            </tr>

                            <!--CORREU-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">CORREO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelCorreo" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxCorreo" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarCorreo" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarCorreo_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarCorreo" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarCorreo_Click"></asp:LinkButton>
                                </td>
                            </tr>

                            <!--TELEFON-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">TELEFONO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelTelefono" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxTelefono" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarTelefono" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarTelefono_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarTelefono" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarTelefono_Click"></asp:LinkButton>
                                </td>
                            </tr>

                            <!--DESCRIPCIO-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">DESCRIPCIÓN</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelDescripcion" runat="server" CssClass=""></asp:Label>

                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" Visible="false"></asp:TextBox>

                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarDescripcion" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarDescripcion_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarDescripcion" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarDescripcion_Click"></asp:LinkButton>

                                </td>
                            </tr>

                            <!--PERSONA CONTACTO-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">PERSONA DE CONTACTO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelContacto" runat="server" CssClass=""></asp:Label>

                                    <asp:TextBox ID="TextBoxContacto" runat="server" Visible="false"></asp:TextBox>

                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarContacto" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarContacto_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarContacto" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarContacto_Click"></asp:LinkButton>

                                </td>
                            </tr>
                            <!--TREBALL-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">TRABAJO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelTrabajo" runat="server" CssClass=""></asp:Label>
                                    <asp:DropDownList ID="DropDownListTrabajo" runat="server" Visible="false">
                                        <asp:ListItem Value="1">Administracion de empresas</asp:ListItem>
                                        <asp:ListItem Value="2">Profesiones, artes y oficios</asp:ListItem>
                                        <asp:ListItem Value="3">Calidad de produccion I + D</asp:ListItem>
                                        <asp:ListItem Value="4">Informatica y telecomunicaciones</asp:ListItem>
                                        <asp:ListItem Value="5">Fabricacion, montages y mantenimientos</asp:ListItem>
                                        <asp:ListItem Value="6">Comercial y ventas</asp:ListItem>
                                        <asp:ListItem Value="7">Turismo y restauracion</asp:ListItem>
                                        <asp:ListItem Value="8">Ingenieria</asp:ListItem>
                                        <asp:ListItem Value="9">Educación, formación e investigación</asp:ListItem>
                                        <asp:ListItem Value="10">Inmobiliaria y construccion</asp:ListItem>
                                        <asp:ListItem Value="11">Atencion al cliente</asp:ListItem>
                                        <asp:ListItem Value="12">Compras, logistica y almacen</asp:ListItem>
                                        <asp:ListItem Value="13">Sanidad y salud</asp:ListItem>
                                        <asp:ListItem Value="14">Finanzas y banca</asp:ListItem>
                                        <asp:ListItem Value="15">Marqueting y comunicacion</asp:ListItem>
                                        <asp:ListItem Value="16">Recursos humanos</asp:ListItem>
                                        <asp:ListItem Value="17">Servicios personales</asp:ListItem>
                                        <asp:ListItem Value="18">Personal no especializado</asp:ListItem>
                                        <asp:ListItem Value="19">Mineria e industria</asp:ListItem>
                                        <asp:ListItem Value="20">Diseño y artes graficas</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarTrabajo" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarTrabajo_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarTrabajo" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarTrabajo_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>

        </div>

    </div>
</asp:Content>