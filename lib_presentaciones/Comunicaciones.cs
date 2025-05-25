using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lib_dominio.Nucleo;
using static System.Collections.Specialized.BitVector32;
namespace lib_presentaciones
{
    public class Comunicaciones
    {
        private string? Protocolo = string.Empty,
        Host = string.Empty,
        Servicio = string.Empty,
        token = null;
        public Comunicaciones(string servicio = "asp_Servicios/",
        string protocolo = "http://",
        string host = "localhost:5018") //probando puertos... bueno almenos ya se que es el puerto 5018
        {
            Protocolo = protocolo;
            Host = host;
            Servicio = servicio;
        }
       public Dictionary<string, object> ConstruirUrl(Dictionary<string, object>data, string Metodo)
       {
            data["Url"] = Protocolo + Host + "/" + Servicio + Metodo;
            data["UrlToken"] = Protocolo + Host + "/" + Servicio + "Token/Autenticar"; //Cambio de autentificador
            return data;
       }
        public async Task<Dictionary<string, object>> Execute(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                respuesta = await Authenticate(datos); //Espera la respuesta
                if (respuesta == null || respuesta.ContainsKey("Error"))
                    return respuesta!;
                respuesta.Clear(); //Cambio para probar
                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlToken");
                datos["Bearer"] = token!;
                var stringData = JsonConversor.ConvertirAString(datos);
                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);
                
                var message = await httpClient.PostAsync(url, new StringContent(stringData));
                
                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }
                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
        private async Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> datos) //por aqui esta el error
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var url = datos["UrlToken"].ToString();
                var temp = new Dictionary<string, object>();
                temp["Usuario"] = DatosGenerales.usuario_datos;
                var stringData = JsonConversor.ConvertirAString(temp);
                var httpClient = new HttpClient(); //Parece que el base address es null, wtf?
                httpClient.Timeout = new TimeSpan(0, 1, 0);
                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData)); //Aqui esta el problema
                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }
                var resp = await mensaje.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                token = respuesta["Token"].ToString();
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
            .Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\\\"", "\"")
            .Replace("\"", "'")
            .Replace("'[", "[")
            .Replace("]'", "]")
            .Replace("'{'", "{'")
            .Replace("\\\\", "\\")
            .Replace("'}'", "'}")
            .Replace("}'", "}")
            .Replace("\\n", "")
            .Replace("\\r", "")
            .Replace(" ", "")
            .Replace("'{", "{")
            .Replace("\"", "")
            .Replace(" ", "")
            .Replace("null", "''");
        }
    }
}