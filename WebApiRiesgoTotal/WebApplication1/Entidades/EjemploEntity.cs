using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entidades
{
    public class EjemploEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
    }
}