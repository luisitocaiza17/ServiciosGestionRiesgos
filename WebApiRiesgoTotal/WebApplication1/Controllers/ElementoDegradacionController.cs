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
    [RoutePrefix("api/ElementoDegradacion")]
    public class ElementoDegradacionController : ApiController
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
        [Route("TraerElementosDegradacion")]
        [HttpGet()]
        [ResponseType(typeof(List<ELEMENTOS_DEGRADACION>))]
         //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerElementosDegradacion()
        {
             Msg respuesta = new Msg();
            try
            {
                var elementos = ElementosDegradacionDatos.ObtenerElementos();
                if (elementos.Count>0)
                {

                    respuesta.Datos = elementos;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = elementos;
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
        [ResponseType(typeof(ELEMENTOS_DEGRADACION))]
        //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerElementoDegradacionEspecifica(int id_Elemento_Degradacion)
        {
            UsuarioEntity usuarioComprobado = new UsuarioEntity();
            Msg respuesta = new Msg();
            try
            {
                var elementos = ElementosDegradacionDatos.ObtenerElemento(id_Elemento_Degradacion);

                if (elementos == null)
                {

                    respuesta.Datos = elementos;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = elementos;
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
