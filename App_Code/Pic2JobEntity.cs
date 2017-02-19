using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;

namespace Pic2Job.Entity
{
    public static partial class Pic2JobEntity
    {
        static pic2jobEntities contexto = new pic2jobEntities();

        //Funcion que comprueba si el nick esta repetido.
        public static bool comprobarNick(string nick)
        {
            bool retorno = false;

            usuarios usuari = 
                (from c in contexto.usuarios
                 where c.nick == nick
                 select c).FirstOrDefault();

            if (usuari != null)
            {
                retorno = true;
            }

            return retorno;
        }

        //Funcion que comprueba si el correo esta repetido.
        public static bool comprobarEmail(string email)
        {
            bool retorno = false;

            usuarios usuari =
                (from c in contexto.usuarios
                 where c.correo == email
                 select c).FirstOrDefault();


            if (usuari != null)
            {
                retorno = true;
            }

            return retorno;
        }

        //Funcion que comprueba si el telefono esta repetido.
        public static bool comprobarTelefono(string telefono)
        {
            bool retorno = false;

            usuarios usuari =
                (from c in contexto.usuarios
                 where c.telefono == telefono
                 select c).FirstOrDefault();


            if (usuari != null)
            {
                retorno = true;
            }

            return retorno;
        }

        //Funcion comprueba hace el login.
        public static string comprobarUsuariPass(string email, string pass)
        {
            string retorno;

            usuarios usuari = 
                (from c in contexto.usuarios
                 where c.correo == email && c.pass == pass 
                 select c).FirstOrDefault();

            if (usuari != null)
            {
                retorno = usuari.id_usuario.ToString();
            }
            else
            {
                retorno = "Usuario o contraseña incorrectos!";
            }
            return retorno;
        }

        //Funcion que guarda un usuario.
        public static String InsertarUsuario(String nick, String nombre, String apellidos, String email, String telefono, String pass)
        {
            usuarios usuari = new usuarios();

            usuari.nick = nick;
            usuari.nombre = nombre;
            usuari.apellidos = apellidos;
            usuari.correo = email;
            usuari.telefono = telefono;
            usuari.pass = pass;
            usuari.id_ciudad = 1;

            contexto.usuarios.Add(usuari);

            try
            {
                contexto.SaveChanges();

                return "Usuario Registrado!";
            }
            catch (DbEntityValidationException ex)
            {
                return ex.EntityValidationErrors.ToString();
            }
        }

        //Funcion que obtiene todas las imagenes por id de usuario, retorna una lista de imagenes.
        public static List<imagenes> FindImatgesById(int id)
        {
            List<imagenes> imatges =
                (from c in contexto.imagenes
                 where c.id_usuario == id
                 select c).ToList();

            return imatges;
        }

        //funcion que devuelve el usuario con el id indicado
        public static usuarios FindUsuariById(int id)
        {
            usuarios usuari =
                (from c in contexto.usuarios
                 where c.id_usuario == id
                 select c).FirstOrDefault();

            return usuari;
        }

        //Funcion que modifica un usuario
        public static void modificarUsuario(int id, string campo_modificado, string valor)
        {
            usuarios usuari = FindUsuariById(id);

            switch (campo_modificado)
            {
                case ("nick"):
                    usuari.nick = valor;
                    break;
                case ("nombre"):
                    usuari.nombre = valor;
                    break;
                case ("apellido"):
                    usuari.apellidos = valor;
                    break;
                case ("correo"):
                    usuari.correo = valor;
                    break;
                case ("telefono"):
                    usuari.telefono = valor;
                    break;
                case ("sexo"):
                    usuari.sexo = bool.Parse(valor);
                    break;
                case ("peso"):
                    usuari.peso = double.Parse(valor);
                    break;
                case ("altura"):
                    usuari.altura = double.Parse(valor);
                    break;
                case ("grupoetnico"):
                    usuari.grupo_etnico = int.Parse(valor);
                    break;
                case ("fecha"):
                    int año = int.Parse(valor.Substring(6, 4)), 
                        mes = int.Parse(valor.Substring(3, 2)), 
                        dia = int.Parse(valor.Substring(0, 2));
                    DateTime fecha = new DateTime(año,mes,dia);
                    usuari.fecha_nacimiento = fecha;
                    break;
                case ("ciudad"):
                    break;
                case ("trabajo"):
                    usuari.tipo_trabajo = int.Parse(valor);
                    break;
            }
            contexto.SaveChanges();
        }

        //funcion que busca una imagen por id de imagen
        public static imagenes FindImatgeById(int id)
        {
            imagenes imatge =
                (from c in contexto.imagenes
                 where c.id == id
                 select c).FirstOrDefault();

            return imatge;
        }

        //funcion que añade un registro de una imagen subida ala base de datos
        public static void InsertImagen(String source, int id)
        {
            imagenes imagen = new imagenes();

            imagen.src = source;
            imagen.id_usuario = id;

            contexto.imagenes.Add(imagen);

            contexto.SaveChanges();
        }

        //funcion que borra una imagen con un id en concreto.
        public static String DeleteImatge(int id)
        {
            String missatge = "";

            imagenes imatge = FindImatgeById(id);

            try
            {
                contexto.imagenes.Remove(imatge);
                contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException sqlEx = (SqlException)ex.InnerException.InnerException;
                missatge = sqlEx.Message;

                contexto.imagenes.Add(imatge);
            }

            return missatge;
        }
    }
}




