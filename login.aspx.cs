using System;
using System.Data.Entity.Validation;
using System.Linq;
using Pic2Job.Entity;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["correo"] != null)
        {
            textBox_email.Text = Session["correo"].ToString();
            Session["correo"] = null;
        }
    }

    protected void validacion_Click(object sender, EventArgs e)
    {
        int id;

        string  email = textBox_email.Text,
                pass = textBox_pass.Text,
                comprobacion = Pic2JobEntity.comprobarUsuariPass(email, pass);

        bool correcto = int.TryParse(comprobacion, out id);

        if (correcto)
        {
            Session["id"] = id;
            Response.Redirect("PerfilUsuario.aspx");
        }
        else
        {
            LabelError.Text = comprobacion;
            errorUsuario.Visible = true;
        }

    }
}