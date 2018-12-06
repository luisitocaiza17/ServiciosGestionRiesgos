using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entidades
{
    public class UsuarioEntity
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
    }

    class Msg
    {

        public string Estado { get; set; }
        public object Datos { get; set; }
        public string Mensajes { get; set; }
    
     }

}