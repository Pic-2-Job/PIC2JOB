<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeFile="PerfilUsuario.aspx.cs" Inherits="PerfilUsuario" %>

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
                        <h3 class="panel-title">Datos Usuario</h3>
                    </div>

                    <div class="panel-body">

                        <!--TAULA-AMB-DADES-USUARI-->
                        <table>

                            <!--NICK-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">NICK</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelNick" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxNick" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarNick" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarNick_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarNick" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarNick_Click"></asp:LinkButton>
                                </td>
                            </tr>
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
                            <!--COGNOMS-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">APELLIDOS</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10 ">
                                    <asp:Label ID="LabelApellido" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxApellido" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2 ">
                                    <asp:LinkButton ID="LinkButtonEditarApellido" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarApellido_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarApellido" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarApellido_Click"></asp:LinkButton>

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
                            <!--SEXE-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">SEXO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelSexo" runat="server" CssClass=""></asp:Label>
                                    <asp:RadioButtonList ID="RadioButtonListSexo" runat="server" Visible="false">
                                        <asp:ListItem Value="true">Hombre</asp:ListItem>
                                        <asp:ListItem Value="false">Mujer</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarSexo" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarSexo_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarSexo" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarSexo_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <!--ALTURA-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">ALTURA</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelAltura" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxAltura" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarAltura" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarAltura_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarAltura" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarAltura_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <!--PES-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">PESO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelPeso" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxPeso" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarPeso" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarPeso_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarPeso" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarPeso_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <!--GRUPO-ETNICO-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">GRUPO ETNICO</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelGrupoEtnico" runat="server" CssClass=""></asp:Label>
                                    <asp:DropDownList ID="DropDownListGrupoEtnico" runat="server" Visible="false">
                                        <asp:ListItem Value="1">Caucasico</asp:ListItem>
                                        <asp:ListItem Value="2">Africano</asp:ListItem>
                                        <asp:ListItem Value="3">Asiatico</asp:ListItem>
                                        <asp:ListItem Value="4">Arabe</asp:ListItem>
                                        <asp:ListItem Value="5">Gitano</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarGrupoEtnico" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarGrupoEtnico_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarGrupoEtnico" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarGrupoEtnico_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <!--DATA-NAIXEMENT-->
                            <tr>
                                <th colspan="2" class="col-xs-12 ">FECHA</th>
                            </tr>
                            <tr>
                                <td class="col-xs-10">
                                    <asp:Label ID="LabelFecha" runat="server" CssClass=""></asp:Label>
                                    <asp:TextBox ID="TextBoxFecha" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="col-xs-2">
                                    <asp:LinkButton ID="LinkButtonEditarFecha" runat="server" CssClass="btn glyphicon glyphicon-pencil" OnClick="LinkButtonEditarFecha_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonGuardarFecha" runat="server" CssClass="btn glyphicon glyphicon-tick" Visible="false" OnClick="LinkButtonGuardarFecha_Click"></asp:LinkButton>
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
                        <div class="col-xs-12">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#subirimagen">
                                Subir imagen
                            </button>
                        </div>

                    </div>

                </div>

            </div>

        </div>

        <!--COLUMNA-FOTOS-->
        <div class="col-xs-9 " runat="server" id="fotos"></div>

    </div>

    <div class="modal fade" id="subirimagen" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Subir imagen</h4>
                </div>
                <div class="modal-body">
                    <asp:FileUpload CssClass="col-xs-12" ID="subirImagen" runat="server"></asp:FileUpload>
                    <asp:TextBox CssClass="col-xs-9" ID="TextBoxDescripcion" runat="server" placeholder="Introduce una descripcion" TextMode="SingleLine" CausesValidation="True" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" runat="server" ErrorMessage="Introduce una descripcion por favor!" ControlToValidate="TextBoxDescripcion" Display="Dynamic" CssClass="col-xs-12 alert alert-danger text-center"></asp:RequiredFieldValidator>
                    <asp:LinkButton ID="LinkButtonSubir" runat="server" CssClass="btn btn-success" OnClick="botonSubir_Click"><span class="glyphicon glyphicon-upload" aria-hidden="true"></span> Subir</asp:LinkButton>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" aria-label="Close" class="btn btn-primary">Finalizar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
