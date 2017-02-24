using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pic2Job.Entity;

public partial class registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Se quitan los mensajes si hubiera
        ErrorCamposEmpresa.Visible = false;
        ErrorCamposUsuario.Visible = false;

        ErrorEmailEmpresa.Visible = false;
        ErrorEmailEmpresa.Visible = false;

        ErrorTelefonoEmpresa.Visible = false;
        ErrorTelefonoUsuario.Visible = false;

        ErrorNick.Visible = false;

        LabelMensajeEmpresa.Visible = false;
        LabelMensajeUsuario.Visible = false;

    }
    protected void ButtonUsuario_Click(object sender, EventArgs e)
    {
        PanelUsuarios.Visible = true;
        PanelBotones.Visible = false;
    }
    protected void ButtonEmpresa_Click(object sender, EventArgs e)
    {
        PanelEmpresas.Visible = true;
        PanelBotones.Visible = false;
    }

    protected void ValidacionUsuario_Click(object sender, EventArgs e)
    {
        //Se quitan los mensajes si hubiera
        ErrorCamposUsuario.Visible = false;
        ErrorEmailUsuario.Visible = false;
        ErrorNick.Visible = false;
        ErrorTelefonoUsuario.Visible = false;
        LabelMensajeUsuario.Visible = false;

        String  nick = TextBoxNick.Text,
                nombre = TextBoxNombreUsuario.Text,
                apellidos = TextBoxApellidos.Text,
                email = TextBoxEmailUsuario.Text,
                telefono = TextBoxTelefonoUsuario.Text,
                pass = TextBoxPassUsuario.Text;


        if (nick == "" || nombre == "" || apellidos == "" || email == "" || telefono == "")
        {
            ErrorCamposUsuario.Visible = true;
        }
        else
        {
            if (Pic2JobEntity.comprobarNick(nick))
            {
                ErrorNick.Visible = true;
            }
            else
            {
                if (Pic2JobEntity.comprobarEmailUsuario(email) || Pic2JobEntity.comprobarEmailEmpresa(email))
                {
                    ErrorEmailUsuario.Visible = true;
                }
                else
                {
                    if (Pic2JobEntity.comprobarTelefonoUsuario(telefono) || Pic2JobEntity.comprobarTelefonoEmpresa(telefono))
                    {
                        ErrorTelefonoUsuario.Visible = true;
                    }
                    else
                    {
                        LabelMensajeUsuario.Text = Pic2JobEntity.InsertarUsuario(nick, nombre, apellidos, email, telefono, pass);

                        if (LabelMensajeUsuario.Text == "Usuario Registrado!")
                        {
                            Session["correo"] = email;
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            LabelMensajeUsuario.Visible = true;
                        }
                    }
                }
            }
        }
    }
    protected void ValidacionEmpresa_Click(object sender, EventArgs e)
    {
        //Se quitan los mensajes si hubiera
        ErrorCamposEmpresa.Visible = false;
        ErrorEmailEmpresa.Visible = false;
        ErrorTelefonoEmpresa.Visible = false;
        LabelMensajeEmpresa.Visible = false;

        String  cif = TextBoxCif.Text,
                nombre = TextBoxNombreEmpresa.Text,
                direccion = TextBoxDireccion.Text,
                email = TextBoxEmailEmpresa.Text,
                telefono = TextBoxTelefonoEmpresa.Text,
                contacto = TextBoxContacto.Text,
                pass = TextBoxPassEmpresa.Text;


        if (cif == "" || nombre == "" || direccion == "" || email == "" || telefono == "" || contacto == "") 
        {
            ErrorCamposEmpresa.Visible = true;
        }
        else
        {
            if (Pic2JobEntity.comprobarCifEmpresa(cif))
            {
                ErrorCif.Visible = true;
            }
            else
            {
                if (Pic2JobEntity.comprobarNomEmpresa(nombre))
                {
                    ErrorNombre.Visible = true;
                }
                else
                {
                    if (Pic2JobEntity.comprobarEmailUsuario(email) || Pic2JobEntity.comprobarEmailEmpresa(email))
                    {
                        ErrorEmailEmpresa.Visible = true;
                    }
                    else
                    {
                        if (Pic2JobEntity.comprobarTelefonoUsuario(telefono) || Pic2JobEntity.comprobarTelefonoEmpresa(telefono))
                        {
                            ErrorTelefonoEmpresa.Visible = true;
                        }
                        else
                        {
                            LabelMensajeEmpresa.Text = Pic2JobEntity.InsertarEmpresa(cif, nombre, direccion, email, telefono, contacto, pass);

                            if (LabelMensajeEmpresa.Text == "Usuario Registrado!")
                            {
                                Session["correo"] = email;
                                Response.Redirect("login.aspx");
                            }
                            else
                            {
                                LabelMensajeEmpresa.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}