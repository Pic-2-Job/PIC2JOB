using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Pic2Job.Entity;
using Pic2Job.UploadImagen;
using System.Web.UI.HtmlControls;

public partial class PerfilUsuario : System.Web.UI.Page
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

        //buscamos las imagenes del usuario con el id
        List<imagenes> imatges = Pic2JobEntity.FindImatgesById(id);

        //para cada imagen de la lista genera un div, con la imagen dentro.
        foreach (imagenes img in imatges)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = "div" + img.id;
            div.Attributes.Add("class", "col-xs-4");
        
            Image imatge = new Image()
            {
                ID = "imatge" + img.id,
                CssClass = "img-responsive",
                ImageUrl = img.src,
                AlternateText = img.descripcion
            };
            
           
            div.Controls.Add(imatge);
            fotos.Controls.Add(div);

        }

        //buscamos los datos del usuario pasandole el id
        usuarios usuario = Pic2JobEntity.FindUsuariById(id);

        //rellenamos los datos que son strings.
        LabelNick.Text = usuario.nick;
        LabelNombre.Text = usuario.nombre;
        LabelApellido.Text = usuario.apellidos;
        LabelCorreo.Text = usuario.correo;
        LabelCiudad.Text = usuario.ciudades.nombre;
        LabelTelefono.Text = usuario.telefono;

        //rellena sexo(que es un bool) con un string segun si es true o false.
        if (usuario.sexo == null)
        {
            LabelSexo.Text = "Introduce tu sexo";
        }
        else
        {
            //Hombre = true/1 Mujer = false/0
            if (usuario.sexo.Value)
            {
                LabelSexo.Text = "Hombre";
            }
            else
            {
                LabelSexo.Text = "Mujer";
            }
        }

        //por defecto la altura es 0, porque no se pide en el registro. 
        if(usuario.altura == 0)
        {
            //le pedimos que la introduzca.
            LabelAltura.Text = "Introduce tu altura";
        }
        else
        {
            //en caso de que no sea 0 la sacamos de la bdd.
            LabelAltura.Text = usuario.altura.ToString();
        }

        //por defecto el peso es null, porque no se pide en el registro.
        if (usuario.peso == null)
        {
            //le pedimos que lo introduzca.
            LabelPeso.Text = "Introduce tu peso";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            LabelPeso.Text = usuario.peso.ToString();
        }

        //por defecto el grupo etnico es null, porque no se pide en el registro. 
        if (usuario.grupo_etnico == null)
        {
            //le pedimos que lo introduzca.
            LabelGrupoEtnico.Text = "Introduce tu grupo etnico";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            LabelGrupoEtnico.Text = DropDownListGrupoEtnico.Items.FindByValue(usuario.grupo_etnico.ToString()).Text; 
        }

        //por defecto la fecha de nacimientoes null, porque no se pide en el registro.
        if (usuario.fecha_nacimiento == null)
        {
            //le pedimos que la introduzca.
            LabelFecha.Text = "Introduce tu fecha de nacimiento";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            string fecha = usuario.fecha_nacimiento.ToString();

            //si fecha de nacimiento es de mas de 10 caracteres le cortamos la parte final que es la hora que se añade sola y no la queremos mostra.
            if (fecha.Length > 10)
            {
                LabelFecha.Text = fecha.Substring(0,10);
            }
            else
            {
                LabelFecha.Text = fecha;
            }
            
        }

        //por defecto el grupo etnico es null
        if (usuario.tipo_trabajo == null)
        {
            //le pedimos que lo introduzca.
            LabelTrabajo.Text = "Introduce tu trabajo";
        }
        else
        {
            //en caso de que no sea null la sacamos de la bdd.
            LabelTrabajo.Text = DropDownListTrabajo.Items.FindByValue(usuario.tipo_trabajo.ToString()).Text;
        }

    }
   
    //funcion que sube una imagen
    protected void botonSubir_Click(object sender, EventArgs e)
    {
        //parseamos el string id de la sesion y tenemos el id en int
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        //llamamos ala super funcion de subir imagenes al servidor y asignamos el string que retorna 
        //que puede ser un error o la ruta, luego miramos si lo que devuelve empieza por "I" en caso 
        //afirmativo lo ha podido guardar i lo que ha devuelto es la ruta que empieza siempre por "I", 
        //en caso contrario asignamos el mensaje de error.
        string ruta = UploadImagen.SubirImagen(subirImagen, id);
        string descripcion = TextBoxDescripcion.Text;

        if (ruta.StartsWith("I"))
        {
            Pic2JobEntity.InsertImagen(ruta, id, descripcion);
            Response.Redirect("PerfilUsuario.aspx");
        }
        else
        {
            LabelMissatge.Text = ruta;
            PanelMissatge.Visible = true;
        }
    }

    //estas 12 funciones se ejecutan al hacer click en el boton editar de los datos del usuario, 
    //sirven para ocultar la label i mostrar el textbox, ocultar el boton de editar i mostrar el 
    //de guardar, para de esta manera permitirnos modificar nuestros datos existentes i darle al 
    //boton guardar que llama ala funcion que se encarga de meterlo en la bdd.
    protected void LinkButtonEditarNick_Click(object sender, EventArgs e)
    {
        LabelNick.Visible = false;
        LinkButtonEditarNick.Visible = false;
        TextBoxNick.Text = LabelNick.Text;
        TextBoxNick.Visible = true;
        LinkButtonGuardarNick.Visible = true;
    }

    protected void LinkButtonEditarNombre_Click(object sender, EventArgs e)
    {
        LabelNombre.Visible = false;
        LinkButtonEditarNombre.Visible = false;
        TextBoxNombre.Text = LabelNombre.Text;
        TextBoxNombre.Visible = true;
        LinkButtonGuardarNombre.Visible = true;
    }

    protected void LinkButtonEditarApellido_Click(object sender, EventArgs e)
    {
        LabelApellido.Visible = false;
        LinkButtonEditarApellido.Visible = false;
        TextBoxApellido.Text = LabelApellido.Text;
        TextBoxApellido.Visible = true;
        LinkButtonGuardarApellido.Visible = true;
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

    protected void LinkButtonEditarSexo_Click(object sender, EventArgs e)
    {
        LabelSexo.Visible = false;
        LinkButtonEditarSexo.Visible = false;
        RadioButtonListSexo.Visible = true;
        LinkButtonGuardarSexo.Visible = true;
    }

    protected void LinkButtonEditarAltura_Click(object sender, EventArgs e)
    {
        LabelAltura.Visible = false;
        LinkButtonEditarAltura.Visible = false;
        TextBoxAltura.Text = LabelAltura.Text;
        TextBoxAltura.Visible = true;
        LinkButtonGuardarAltura.Visible = true;
    }

    protected void LinkButtonEditarPeso_Click(object sender, EventArgs e)
    {
        LabelPeso.Visible = false;
        LinkButtonEditarPeso.Visible = false;
        TextBoxPeso.Text = LabelPeso.Text;
        TextBoxPeso.Visible = true;
        LinkButtonGuardarPeso.Visible = true;
    }

    protected void LinkButtonEditarGrupoEtnico_Click(object sender, EventArgs e)
    {
        LabelGrupoEtnico.Visible = false;
        LinkButtonEditarGrupoEtnico.Visible = false;
        DropDownListGrupoEtnico.Visible = true;
        LinkButtonGuardarGrupoEtnico.Visible = true;
    }

    protected void LinkButtonEditarFecha_Click(object sender, EventArgs e)
    {
        LabelFecha.Visible = false;
        LinkButtonEditarFecha.Visible = false;
        TextBoxFecha.Text = "dd/mm/yyyy";
        TextBoxFecha.Visible = true;
        LinkButtonGuardarFecha.Visible = true;
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
    protected void LinkButtonGuardarNick_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        if (!Pic2JobEntity.comprobarNick(TextBoxNick.Text))
        {
            Pic2JobEntity.modificarUsuario(id, "nick", TextBoxNick.Text);

            LabelNick.Text = TextBoxNick.Text;

            TextBoxNick.Visible = false;
            LinkButtonGuardarNick.Visible = false;

            LabelNick.Visible = true;
            LinkButtonEditarNick.Visible = true;
        }
        else
        {
            TextBoxNick.Text = "El nick ya esta en uso";
        }
    }

    protected void LinkButtonGuardarNombre_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "nombre", TextBoxNombre.Text);

        LabelNombre.Text = TextBoxNombre.Text;

        TextBoxNombre.Visible = false;
        LinkButtonGuardarNombre.Visible = false;

        LabelNombre.Visible = true;
        LinkButtonEditarNombre.Visible = true;
    }

    protected void LinkButtonGuardarApellido_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "apellido", TextBoxApellido.Text);

        LabelApellido.Text = TextBoxApellido.Text;

        TextBoxApellido.Visible = false;
        LinkButtonGuardarApellido.Visible = false;

        LabelApellido.Visible = true;
        LinkButtonEditarApellido.Visible = true;
    }

    protected void LinkButtonGuardarCorreo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        if (!Pic2JobEntity.comprobarEmailUsuario(TextBoxCorreo.Text))
        {
            Pic2JobEntity.modificarUsuario(id, "correo", TextBoxCorreo.Text);

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

        if (!Pic2JobEntity.comprobarTelefonoUsuario(TextBoxTelefono.Text))
        {

            Pic2JobEntity.modificarUsuario(id, "telefono", TextBoxTelefono.Text);

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

    protected void LinkButtonGuardarSexo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "sexo", RadioButtonListSexo.SelectedItem.Value);

        LabelSexo.Text = RadioButtonListSexo.SelectedItem.Text;

        RadioButtonListSexo.Visible = false;
        LinkButtonGuardarSexo.Visible = false;

        LabelSexo.Visible = true;
        LinkButtonEditarSexo.Visible = true;
    }

    protected void LinkButtonGuardarAltura_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        double altura;
        bool error = double.TryParse(TextBoxAltura.Text, out altura);

        if (error)
        {
            Pic2JobEntity.modificarUsuario(id, "altura", altura.ToString());

            LabelAltura.Text = TextBoxAltura.Text;

            TextBoxAltura.Visible = false;
            LinkButtonGuardarAltura.Visible = false;

            LabelAltura.Visible = true;
            LinkButtonEditarAltura.Visible = true;
        }
        else
        {
            TextBoxAltura.Text = "Introduce un numero valido!";
        }
    }

    protected void LinkButtonGuardarPeso_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        double peso;
        bool error = double.TryParse(TextBoxPeso.Text, out peso);

        if (error)
        {
            Pic2JobEntity.modificarUsuario(id, "peso", peso.ToString());

            LabelPeso.Text = TextBoxPeso.Text;

            TextBoxPeso.Visible = false;
            LinkButtonGuardarPeso.Visible = false;

            LabelPeso.Visible = true;
            LinkButtonEditarPeso.Visible = true;
        }
        else
        {
            TextBoxPeso.Text = "Introduce un numero valido!";
        }
    }

    protected void LinkButtonGuardarGrupoEtnico_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "grupoetnico", DropDownListGrupoEtnico.SelectedItem.Value);

        LabelGrupoEtnico.Text = DropDownListGrupoEtnico.SelectedItem.Text;

        DropDownListGrupoEtnico.Visible = false;
        LinkButtonGuardarGrupoEtnico.Visible = false;

        LabelGrupoEtnico.Visible = true;
        LinkButtonEditarGrupoEtnico.Visible = true;
    }

    protected void LinkButtonGuardarFecha_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "fecha", TextBoxFecha.Text);

        LabelFecha.Text = TextBoxFecha.Text;

        TextBoxFecha.Visible = false;
        LinkButtonGuardarFecha.Visible = false;

        LabelFecha.Visible = true;
        LinkButtonEditarFecha.Visible = true;
    }

    protected void LinkButtonGuardarCiudad_Click(object sender, EventArgs e)
    {

    }

    protected void LinkButtonGuardarTrabajo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(System.Web.HttpContext.Current.Session["usuario"].ToString());

        Pic2JobEntity.modificarUsuario(id, "trabajo", DropDownListTrabajo.SelectedItem.Value);

        LabelTrabajo.Text = DropDownListTrabajo.SelectedItem.Text;

        DropDownListTrabajo.Visible = false;
        LinkButtonGuardarTrabajo.Visible = false;

        LabelTrabajo.Visible = true;
        LinkButtonEditarTrabajo.Visible = true;
    }
}