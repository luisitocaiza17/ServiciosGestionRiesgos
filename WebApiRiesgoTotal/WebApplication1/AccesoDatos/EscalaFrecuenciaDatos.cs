using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class EscalaFrecuenciaDatos
    {
        public static List<ESCALA_FRECUENCIA> ObtenerFrecuencias()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<ESCALA_FRECUENCIA> entidad = model.ESCALA_FRECUENCIA.ToList();
                return entidad;
            }
        }
        public static ESCALA_FRECUENCIA ObtenerFrecuencia(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                ESCALA_FRECUENCIA entidad = model.ESCALA_FRECUENCIA.Where(x => x.ID_ESCALA_FRECUENCIA == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}