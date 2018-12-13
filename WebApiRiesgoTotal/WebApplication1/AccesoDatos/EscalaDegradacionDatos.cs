using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class EscalaDegradacionDatos
    {
        public static List<ESCALA_DEGRADACION> ObtenerEscalas()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<ESCALA_DEGRADACION> entidad = model.ESCALA_DEGRADACION.ToList();
                return entidad;
            }
        }
        public static ESCALA_DEGRADACION ObtenerEscala(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                ESCALA_DEGRADACION entidad = model.ESCALA_DEGRADACION.Where(x => x.ID_ESCALA_DEGRADACION == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}