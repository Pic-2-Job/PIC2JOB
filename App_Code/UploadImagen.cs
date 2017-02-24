using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

namespace Pic2Job.UploadImagen
{
    public static partial class UploadImagen
    {
        public static String SubirImagen(FileUpload subirImagen, int id)
        {
            //comprueba si hay archivo
            if (subirImagen.HasFile)
            {
                //comprueba si es una imagen
                if (subirImagen.PostedFile.ContentType == "image/jpeg" || subirImagen.PostedFile.ContentType == "image/gif" || subirImagen.PostedFile.ContentType == "image/png")
                {
                    //comprueba si pesa menos de 15mB.
                    if (subirImagen.PostedFile.ContentLength < 15985760)
                    {
                        //crea el nombre de la imagen con la fecha del momento + el id + la extension.
                        DateTime fecha = DateTime.Now;
                        string ext = Path.GetExtension(subirImagen.FileName);
                        string nombreImagen = id + "_" + fecha.Day.ToString() + fecha.Month.ToString() + fecha.Year.ToString() + "_" + fecha.Hour.ToString() + fecha.Minute.ToString() + fecha.Second.ToString() + fecha.Millisecond.ToString() + ext;

                        //comprueba si existe el directorio en el servidor, sino lo crea.
                        if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(@"IMAGENES_SUBIDAS\" + id))) ;
                        {
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(@"IMAGENES_SUBIDAS\" + id));
                        }

                        //guardamos la ruta de la carpeta de imagenes del usuario.
                        string carpeta = System.Web.HttpContext.Current.Server.MapPath(@"IMAGENES_SUBIDAS\" + id + "\\");

                        //creamos un bitmap con la imagen subida.
                        Bitmap BMPoriginal = new Bitmap(subirImagen.FileContent);

                        //variables para redimensionar la imagen.
                        int newHeight = 0, newWidth = 0;
                        Bitmap BMP;

                        //si es una imagen horizontal:
                        //si la imagen es mas ancha que 1600 calcula la proporcion de la imagen y 
                        //la nueva altura, y la guarda en el bitmap definitivo con las medidas 
                        //establecidas para que sea maximo 1600 de ancho, si es menos 
                        //ancha que 1600 la guardamos tal cual.
                        if (BMPoriginal.Width >= BMPoriginal.Height)
                        {
                            if (BMPoriginal.Width > 1600)
                            {
                                decimal origWidth = BMPoriginal.Width;
                                decimal origHeight = BMPoriginal.Height;
                                decimal imgRatio = origHeight / origWidth;
                                newWidth = 1600; //ANCHO PREDEFINIDO
                                decimal newHeight_temp = newWidth * imgRatio;
                                newHeight = Convert.ToInt16(newHeight_temp);

                                BMP = new Bitmap(BMPoriginal, newWidth, newHeight);
                            }
                            else
                            {
                                BMP = BMPoriginal;
                            }
                        }
                        //else si es una imagen vertical:
                        //si la imagen es mas alta que 1600 calcula la proporcion de la imagen y 
                        //el nuevo ancho, y la guarda en el bitmap definitivo con las medidas 
                        //establecidas para que sea maximo 1600 de alto, si es menos 
                        //alta que 1600 la guardamos tal cual.
                        else
                        {
                            if (BMPoriginal.Height > 1600)
                            {
                                decimal origWidth = BMPoriginal.Width;
                                decimal origHeight = BMPoriginal.Height;
                                decimal imgRatio = origWidth / origHeight;
                                newHeight = 1600; //Alto PREDEFINIDO
                                decimal newWidth_temp = newHeight * imgRatio;
                                newWidth = Convert.ToInt16(newWidth_temp);

                                BMP = new Bitmap(BMPoriginal, newWidth, newHeight);
                            }
                            else
                            {
                                BMP = BMPoriginal;
                            }
                        }

                        //convertimos el bitmap en un grafico y le aplicamos unos retoques de calidad.
                        Graphics Grafico = Graphics.FromImage(BMP);
                        Grafico.SmoothingMode = SmoothingMode.AntiAlias;
                        Grafico.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Grafico.DrawImage(BMPoriginal, 0, 0, newWidth, newHeight);

                        //probamos de guardar la imagen en el servidor, y capturamos excepcion.
                        try
                        {
                            BMP.Save(carpeta + nombreImagen);
                        }
                        catch (ExternalException ex)
                        {
                            return ex.InnerException.Message;
                        }

                        //vaciamos los objetos usados.
                        BMPoriginal.Dispose();
                        BMP.Dispose();
                        Grafico.Dispose();

                        //retornamos la ruta exacta de la imagen para poder guardala en la base de datos.
                        return "IMAGENES_SUBIDAS\\" + id + "\\" + nombreImagen;
                    }
                    //distintos mensajes de error de los ifs del principio de la funcion.
                    else
                    {
                        return "ERROR: Tamaño maximo 15MB.";
                    }
                }
                else
                {
                    return "ERROR: El archivo seleccionado no es una imagen.";
                }
            }
            else
            {
                return "ERROR: Selecciona una imagen porfavor";
            }
        }
        public static void DeleteImatge(string src)
        {
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(src)))
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(src));
            }
        }
    }
}