using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.AccesoDatos
{
    public class VulnerabilidadesDatos
    {
        public static List<VULNERABILIDADES> ObtenerVulnerabilidades()
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                List<VULNERABILIDADES> entidad = model.VULNERABILIDADES.ToList();
                return entidad;
            }
        }
        public static VULNERABILIDADES ObtenerVulnerabilidad(int id)
        {
            using (RIESGO_TOTAL_Entities model = new RIESGO_TOTAL_Entities())
            {
                VULNERABILIDADES entidad = model.VULNERABILIDADES.Where(x=> x.ID_VULNERABILIDAD == id).FirstOrDefault();
                return entidad;
            }
        }
    }
}