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
    [RoutePrefix("api/MapaCalor")]
    public class MapaCalorController : ApiController
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
        [Route("TraerMapas")]
        [HttpGet()]
        [ResponseType(typeof(List<MAPA_CALOR>))]
         //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerMapas()
        {
             Msg respuesta = new Msg();
            try
            {
                var mapas = MapaCalorDatos.ObtenerMapas();
                if (mapas.Count>0)
                {

                    respuesta.Datos = mapas;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = mapas;
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
        [Route("TraerMapa")]
        [HttpGet()]
        [ResponseType(typeof(MAPA_CALOR))]
        //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage TraerMapa(int id_Amenaza)
        {
            UsuarioEntity usuarioComprobado = new UsuarioEntity();
            Msg respuesta = new Msg();
            try
            {
                var mapa = MapaCalorDatos.ObtenerMapa(id_Amenaza);

                if (mapa == null)
                {

                    respuesta.Datos = mapa;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = mapa;
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
