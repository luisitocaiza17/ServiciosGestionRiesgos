using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class AmenazasDatos
    {
        public static List<AMENAZAS> ObtenerAmenazas()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<AMENAZAS> entidad = model.AMENAZAS.ToList();
                return entidad;
            }
        }
        public static AMENAZAS ObtenerAmenaza(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                AMENAZAS entidad = model.AMENAZAS.Where(x => x.ID_AMENAZA == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}