using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class ElementosDegradacionDatos
    {
        public static List<ELEMENTOS_DEGRADACION> ObtenerElementos()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<ELEMENTOS_DEGRADACION> entidad = model.ELEMENTOS_DEGRADACION.ToList();
                return entidad;
            }
        }
        public static ELEMENTOS_DEGRADACION ObtenerElemento(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                ELEMENTOS_DEGRADACION entidad = model.ELEMENTOS_DEGRADACION.Where(x => x.ID_DEGRADACION == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}