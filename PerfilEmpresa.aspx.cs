using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Pic2Job.Entity;
using Pic2Job.UploadImagen;
using System.Web.UI.HtmlControls;

public partial class PerfilEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //si no se ha guardado el id en la sesion vuelves al login
        if (System.Web.HttpContext.Current.Session["usuario"] == null)
        {
            Response.Redirect("login.aspx");
        }

        //parseamos el string id de la sesion y tenemos el id en int
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        //buscamos los datos del usuario pasandole el id
        empresas empresa = Pic2JobEntity.FindEmpresaById(id);

        //rellenamos los datos que son strings.
        LabelNombre.Text = empresa.nombre;
        LabelDireccion.Text = empresa.direccion;
        LabelCiudad.Text = empresa.ciudades.nombre;
        LabelCorreo.Text = empresa.correo;
        LabelTelefono.Text = empresa.telefono;
        LabelContacto.Text = empresa.personacontacto;
       
        //por defecto la descripcion es null
        if (empresa.descripcion == null)
        {
            //le pedimos que lo introduzca.
            LabelDescripcion.Text = "Introduce una descripcion";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            LabelDescripcion.Text = empresa.descripcion;
        }

        //por defecto el trabajo es null
        if (empresa.tipo_trabajo == null)
        {
            //le pedimos que lo introduzca.
            LabelTrabajo.Text = "Introduce tu trabajo";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            LabelTrabajo.Text = DropDownListTrabajo.Items.FindByValue(empresa.tipo_trabajo.ToString()).Text;
        }

    }
    
    //estas 12 funciones se ejecutan al hacer click en el boton editar de los datos del usuario, 
    //sirven para ocultar la label i mostrar el textbox, ocultar el boton de editar i mostrar el 
    //de guardar, para de esta manera permitirnos modificar nuestros datos existentes i darle al 
    //boton guardar que llama ala funcion que se encarga de meterlo en la bdd.
    
    protected void LinkButtonEditarNombre_Click(object sender, EventArgs e)
    {
        LabelNombre.Visible = false;
        LinkButtonEditarNombre.Visible = false;
        TextBoxNombre.Text = LabelNombre.Text;
        TextBoxNombre.Visible = true;
        LinkButtonGuardarNombre.Visible = true;
    }
    protected void LinkButtonEditarDireccion_Click(object sender, EventArgs e)
    {
        LabelDireccion.Visible = false;
        LinkButtonEditarDireccion.Visible = false;
        TextBoxDireccion.Text = LabelDireccion.Text;
        TextBoxDireccion.Visible = true;
        LinkButtonGuardarDireccion.Visible = true;
    }
    protected void LinkButtonEditarDescripcion_Click(object sender, EventArgs e)
    {
        LabelDescripcion.Visible = false;
        LinkButtonEditarDescripcion.Visible = false;
        TextBoxDescripcion.Text = LabelDescripcion.Text;
        TextBoxDescripcion.Visible = true;
        LinkButtonGuardarDescripcion.Visible = true;
    }
    protected void LinkButtonEditarContacto_Click(object sender, EventArgs e)
    {
        LabelContacto.Visible = false;
        LinkButtonEditarContacto.Visible = false;
        TextBoxContacto.Text = LabelContacto.Text;
        TextBoxContacto.Visible = true;
        LinkButtonGuardarContacto.Visible = true;
    }
    protected void LinkButtonEditarCorreo_Click(object sender, EventArgs e)
    {
        LabelCorreo.Visible = false;
        LinkButtonEditarCorreo.Visible = false;
        TextBoxCorreo.Text = LabelCorreo.Text;
        TextBoxCorreo.Visible = true;
        LinkButtonGuardarCorreo.Visible = true;
    }

    protected void LinkButtonEditarTelefono_Click(object sender, EventArgs e)
    {
        LabelTelefono.Visible = false;
        LinkButtonEditarTelefono.Visible = false;
        TextBoxTelefono.Text = LabelTelefono.Text;
        TextBoxTelefono.Visible = true;
        LinkButtonGuardarTelefono.Visible = true;
    }

    protected void LinkButtonEditarCiudad_Click(object sender, EventArgs e)
    {
        LabelCiudad.Visible = false;
        LinkButtonEditarCiudad.Visible = false;
        LinkButtonGuardarCiudad.Visible = true;
    }

    protected void LinkButtonEditarTrabajo_Click(object sender, EventArgs e)
    {
        LabelTrabajo.Visible = false;
        LinkButtonEditarTrabajo.Visible = false;
        DropDownListTrabajo.Visible = true;
        LinkButtonGuardarTrabajo.Visible = true;
    }

    //estas 12 funciones se ejecutan al hacer click al boton guardar, lo que hacen 
    //es cojer el nuevo dato modificado que ha insertado el usuario i actualizar ese 
    //dato de su usuario en la bdd, la del nick, correo, y telefono a parte llaman 
    //ala funcion comprobar para asegurarse de que no esta repetido.
   
    protected void LinkButtonGuardarNombre_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        if (!Pic2JobEntity.comprobarNomEmpresa(TextBoxNombre.Text))
        {
            Pic2JobEntity.modificarEmpresa(id, "nombre", TextBoxNombre.Text);

            LabelNombre.Text = TextBoxNombre.Text;

            TextBoxNombre.Visible = false;
            LinkButtonGuardarNombre.Visible = false;

            LabelNombre.Visible = true;
            LinkButtonEditarNombre.Visible = true;
        }
        else
        {
            TextBoxTelefono.Text = "El nombre ya esta en uso";
        }
    }

    protected void LinkButtonGuardarDireccion_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarEmpresa(id, "direccion", TextBoxDireccion.Text);

        LabelDireccion.Text = TextBoxDireccion.Text;

        TextBoxDireccion.Visible = false;
        LinkButtonGuardarDireccion.Visible = false;

        LabelDireccion.Visible = true;
        LinkButtonEditarDireccion.Visible = true;
    }

    protected void LinkButtonGuardarDescripcion_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarEmpresa(id, "descripcion", TextBoxDescripcion.Text);

        LabelDescripcion.Text = TextBoxDescripcion.Text;

        TextBoxDescripcion.Visible = false;
        LinkButtonGuardarDescripcion.Visible = false;

        LabelDescripcion.Visible = true;
        LinkButtonEditarDescripcion.Visible = true;
    }
    protected void LinkButtonGuardarContacto_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarEmpresa(id, "contacto", TextBoxContacto.Text);

        LabelContacto.Text = TextBoxContacto.Text;

        TextBoxContacto.Visible = false;
        LinkButtonGuardarContacto.Visible = false;

        LabelContacto.Visible = true;
        LinkButtonEditarContacto.Visible = true;
    }
    protected void LinkButtonGuardarCorreo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        if (!Pic2JobEntity.comprobarEmailEmpresa(TextBoxCorreo.Text))
        {
            Pic2JobEntity.modificarEmpresa(id, "correo", TextBoxCorreo.Text);

            LabelCorreo.Text = TextBoxCorreo.Text;

            TextBoxCorreo.Visible = false;
            LinkButtonGuardarCorreo.Visible = false;

            LabelCorreo.Visible = true;
            LinkButtonEditarCorreo.Visible = true;
        }
        else
        {
            TextBoxCorreo.Text = "El correo ya esta en uso";
        }
    }

    protected void LinkButtonGuardarTelefono_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        if (!Pic2JobEntity.comprobarTelefonoEmpresa(TextBoxTelefono.Text))
        {

            Pic2JobEntity.modificarEmpresa(id, "telefono", TextBoxTelefono.Text);

            LabelTelefono.Text = TextBoxTelefono.Text;

            TextBoxTelefono.Visible = false;
            LinkButtonGuardarTelefono.Visible = false;

            LabelTelefono.Visible = true;
            LinkButtonEditarTelefono.Visible = true;
        }
        else
        {
            TextBoxTelefono.Text = "El telefono ya esta en uso";
        }
    }
    
    protected void LinkButtonGuardarCiudad_Click(object sender, EventArgs e)
    {

    }

    protected void LinkButtonGuardarTrabajo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarEmpresa(id, "trabajo", DropDownListTrabajo.SelectedItem.Value);

        LabelTrabajo.Text = DropDownListTrabajo.SelectedItem.Text;

        DropDownListTrabajo.Visible = false;
        LinkButtonGuardarTrabajo.Visible = false;

        LabelTrabajo.Visible = true;
        LinkButtonEditarTrabajo.Visible = true;
    }
}