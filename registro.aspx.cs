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
        errorNick.Visible = false;
        errorEmail.Visible = false;
        errorTelf.Visible = false;
        LabelMensaje.Visible = false;
    }

    protected void validacion_Click(object sender, EventArgs e)
    {
        //Se quitan los mensajes si hubiera
        errorNick.Visible = false;
        errorEmail.Visible = false;
        errorTelf.Visible = false;
        LabelMensaje.Visible = false;

        String  nick = textBoxNick.Text,
                nombre = textBox_nombre.Text,
                apellidos = textBox_apellidos.Text,
                email = textBox_email.Text,
                telefono = textBoxTelf.Text,
                pass = textBox_pass.Text;


        if (nick == "" || nombre == "" || apellidos == "" || email == "" || telefono == "")
        {
            errorCampos.Visible = true;
        }
        else
        {
            if (Pic2JobEntity.comprobarNick(nick))
            {
                errorNick.Visible = true;
            }
            else
            {
                if (Pic2JobEntity.comprobarEmail(email))
                {
                    errorEmail.Visible = true;
                }
                else
                {
                    if (Pic2JobEntity.comprobarTelefono(telefono))
                    {
                        errorTelf.Visible = true;
                    }
                    else
                    {
                        LabelMensaje.Text = Pic2JobEntity.InsertarUsuario(nick, nombre, apellidos, email, telefono, pass);
                        
                        if (LabelMensaje.Text == "Usuario Registrado!")
                        {
                            Session["correo"] = email;
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            LabelMensaje.Visible = true;
                        }
                    }
                }
            }
        }
    }
}