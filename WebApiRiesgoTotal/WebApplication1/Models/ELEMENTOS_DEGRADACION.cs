//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ELEMENTOS_DEGRADACION
    {
        public int ID_DEGRADACION { get; set; }
        public Nullable<int> ID_VULNERABILIDAD { get; set; }
        public Nullable<int> ID_ESCALA_DEGRADACION { get; set; }
        public string D_NOMBRE { get; set; }
        public string D_DESCRIPCION { get; set; }
        public Nullable<System.DateTime> D_FECHA_CREACION { get; set; }
    }
}
