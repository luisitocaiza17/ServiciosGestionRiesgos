using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using WebApplication1.Entidades;
using System.Web.Http.Cors;

namespace Saludsa.WebApiBrokers.Controllers
{
    /// <summary>
    /// url para probar el servicio http://localhost:4259/WebDemo/swagger/ui/index#/
    /// Servicios de Usuario
    /// </summary>
    /// <seealso cref="ApiController" />
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// En la cabezaran van los parametros que se solicitaran
        /// </summary>
        /// <param name="usuario">Cabecera de la llamada</param>
        /// <param name="password"></param>
        /// <returns>
        /// HttpResponseMessage
        /// </returns>
        /// <response code="200">Si se ejecuta con éxito y retorna el valor esperado</response>
        /// <response code="400">Error datos enviados en la cabecera</response>
        /// <response code="500">Si existe un error interno</response>
        [Route("LoginVerificacion")]
        [HttpGet()]
        [ResponseType(typeof(string))]
         //[EnableCorsAttribute("http://localhost:44522", "*", "*")]//para permitir CORS 
        public HttpResponseMessage LoginVerificacion(string usuario, string password)
        {
            UsuarioEntity usuarioComprobado = new UsuarioEntity();
            Msg respuesta = new Msg();
            try
            {
                if (usuario.Equals("admin") && password.Equals("123456"))
                {

                    usuarioComprobado.id = 1;
                    usuarioComprobado.nombres = "administrador";
                    usuarioComprobado.apellidos = "pruebas";
                    respuesta.Datos = usuarioComprobado;
                    respuesta.Estado = "OK";
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, respuesta);
                }
                else
                {
                    respuesta.Datos = usuarioComprobado;
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

    }
}
