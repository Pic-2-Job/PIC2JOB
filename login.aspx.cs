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
        string email = textBox_email.Text,
                pass = textBox_pass.Text;

        int id = Pic2JobEntity.comprobarUsuariPass(email, pass);
        
        if (id != 0)
        {
            if ((string)Session["usuario"] == "usuari")
            {
                Session["usuario"] = id;
                Response.Redirect("PerfilUsuario.aspx");
            }
            else if ((string)Session["usuario"] == "empresa")
            {
                Session["usuario"] = id;
                Response.Redirect("PerfilEmpresa.aspx");
            }
        }
        else
        {
            errorUsuario.Visible = true;
        }

    }
}