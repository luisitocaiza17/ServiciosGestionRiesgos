using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using Saludsa.UtilidadesRest;
using Saludsa.UtilidadesRest.SvcBitacoraSistema;
using System.Collections.Generic;
using Saludsa.UtilidadesRest;
namespace Saludsa.WebApiBrokers.Controllers
{
    /// <summary>
    /// Servicios de Rol
    /// </summary>
    /// <seealso cref="ApiController" />
    [RoutePrefix("api/rol")]
    public class CorredoresRolController : ApiController
    {
        
        /// <summary>
        /// Obtiene Rol por idRol
        /// </summary>
        /// <param name="cabecera">Cabecera de la llamada</param>
        /// <param name="idRol"></param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("CorredoresObtenerRolxId")]
        [HttpGet()]
        [ResponseType(typeof(RespuestaGenericaServicio<bool>))]
        public HttpResponseMessage CorredoresObtenerRolxId([AtributoCabecera]CabeceraServicioRest cabecera, int idRol)
        {
            #region Implementacion

            #region Variables

            //Objeto a enviar para el registro de la bitácora
            BitacoraSistema bitacora = null;

            #endregion Variables

            try
            {


                var a= "correcto";

                if (a==null)
                    throw new ExcepcionNegocio($"No se econtraron datos para el Rol {idRol}");

                return MensajeRespuesta.CrearRespuestaExito(Request, a, bitacora);
            }
            catch (ExcepcionNegocio exn)
            {
                return MensajeRespuesta.CrearRespuestaErrorNegocio(Request, exn, bitacora);
            }
            catch (Exception ex)
            {
                return MensajeRespuesta.CrearRespuestaErrorInterno(Request, ex, bitacora);
            }
            #endregion Implementacion
        }

        

    }
}
