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
    [RoutePrefix("api/EscalaDegradacion")]
    public class EscalaDegradacionController : ApiController
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
        [Route("TraerEscalaDegradacion")]
        [HttpGet()]
        [ResponseType(typeof(List<ESCALA_DEGRADACION>))]
         //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerEscalaDegradacion()
        {
             Msg respuesta = new Msg();
            try
            {
                var degradaciones = EscalaDegradacionDatos.ObtenerEscalas();
                if (degradaciones.Count>0)
                {

                    respuesta.Datos = degradaciones;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = degradaciones;
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
        /// <param name="id_Elemento_Degradacion">Cabecera de la llamada</param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("TraerElementoDegradacionEspecifica")]
        [HttpGet()]
        [ResponseType(typeof(ESCALA_DEGRADACION))]
        //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerElementoDegradacionEspecifica(int id_Elemento_Degradacion)
        {
            UsuarioEntity usuarioComprobado = new UsuarioEntity();
            Msg respuesta = new Msg();
            try
            {
                var degradaciones = EscalaDegradacionDatos.ObtenerEscala(id_Elemento_Degradacion);

                if (degradaciones == null)
                {

                    respuesta.Datos = degradaciones;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = degradaciones;
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
