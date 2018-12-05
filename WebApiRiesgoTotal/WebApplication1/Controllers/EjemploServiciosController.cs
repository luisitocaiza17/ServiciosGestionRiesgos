using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using WebApplication1.Entidades;

namespace Saludsa.WebApiBrokers.Controllers
{
    /// <summary>
    /// url para probar el servicio http://localhost:4259/WebDemo/swagger/ui/index#/
    /// Servicios de Usuario
    /// </summary>
    /// <seealso cref="ApiController" />
    [RoutePrefix("api/Ejemplo")]
    public class EjemploServiciosController : ApiController
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
        [Route("EjemploGetSinArgumentos")]
        [HttpGet()]
        //defies que tipo de respuesta vas a entregar en el servicio y el tipo de dato que va a ser
        [ResponseType(typeof(bool))]
        public HttpResponseMessage EjemploGetSinArgumentos()
        {
            #region Implementacion            
            #region Variables

            
            #endregion Variables
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
            #endregion Implementacion
        }

        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <param name="nombre">Cabecera de la llamada</param>
        /// <param name="apellido"></param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("EjemploGetConArgumentos")]
        [HttpGet()]

        [ResponseType(typeof(string))]
        public HttpResponseMessage EjemploGetConArgumentos(string nombre,string apellido)
        {
            string NombreCompleto = nombre + " " + apellido;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, NombreCompleto);            
        }

        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <param name="persona">Cabecera de la llamada</param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("EjemploPostArgumentos")]
        [HttpPost()]

        [ResponseType(typeof(string))]
        public HttpResponseMessage EjemploPostSinArgumentos(EjemploEntity persona)
        {
            string NombreCompleto = persona.Nombre + " " + persona.Apellido;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, NombreCompleto);
        }
        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <param name="persona">Cabecera de la llamada</param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("EjemploPostArgumentosObjetoDevuelto")]
        [HttpPost()]

        [ResponseType(typeof(string))]
        public HttpResponseMessage EjemploPostArgumentosObjetoDevuelto(EjemploEntity persona)
        {
            persona.NombreCompleto = persona.Nombre + " " + persona.Apellido;
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, persona);
        }

    }
}
