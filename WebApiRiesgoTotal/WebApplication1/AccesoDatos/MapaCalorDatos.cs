using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class MapaCalorDatos
    {
        public static List<MAPA_CALOR> ObtenerMapas()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<MAPA_CALOR> entidad = model.MAPA_CALOR.ToList();
                return entidad;
            }
        }
        public static MAPA_CALOR ObtenerMapa(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                MAPA_CALOR entidad = model.MAPA_CALOR.Where(x => x.ID_MAPA_CALOR == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}