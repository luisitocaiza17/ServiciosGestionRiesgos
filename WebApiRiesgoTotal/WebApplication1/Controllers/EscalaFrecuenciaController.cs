using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using WebApplication1.Entidades;
using System.Web.Http.Cors;
using WebApplication1.AccesoDatos;
using WebApplication1.Models;

namespace Saludsa.WebApiBrokers.Controllers
{
    /// <summary>
    /// url para probar el servicio http://localhost:4259/WebDemo/swagger/ui/index#/
    /// Servicios de Usuario
    /// </summary>
    /// <seealso cref="ApiController" />
    [RoutePrefix("api/Frecuencia")]
    public class EscalaFrecuenciaController : ApiController
    {
        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("TraerFrecuencias")]
        [HttpGet()]
        [ResponseType(typeof(List<ESCALA_FRECUENCIA>))]
         //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerFrecuencias()
        {
             Msg respuesta = new Msg();
            try
            {
                var frecuencias = EscalaFrecuenciaDatos.ObtenerFrecuencias();
                if (frecuencias.Count>0)
                {

                    respuesta.Datos = frecuencias;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = frecuencias;
                    respuesta.Estado = "False";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
            }
            catch(Exception e)
            {
                respuesta.Mensajes = e.Message.ToString();
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, respuesta);
            }            
        }
        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <param name="id_Amenaza">Cabecera de la llamada</param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("TraerFrecuencia")]
        [HttpGet()]
        [ResponseType(typeof(ESCALA_FRECUENCIA))]
        //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerFrecuencia(int id_Amenaza)
        {
            UsuarioEntity usuarioComprobado = new UsuarioEntity();
            Msg respuesta = new Msg();
            try
            {
                var frecuencia = EscalaFrecuenciaDatos.ObtenerFrecuencia(id_Amenaza);

                if (frecuencia == null)
                {

                    respuesta.Datos = frecuencia;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = frecuencia;
                    respuesta.Estado = "False";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
            }
            catch (Exception e)
            {
                respuesta.Mensajes = e.Message.ToString();
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, respuesta);
            }
        }

    }
}
