﻿namespace lib_dominio.Nucleo
{
    public class DatosGenerales
    {
        public static string ruta_json = @"C:\Users\sebas\OneDrive\Escritorio\Aranceles\Secretos.json"; //Habra cambio?
        public static bool usa_azure = false;
        public static string clave = "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";
        public static string usuario_datos = EncriptarConversor.Encriptar("Test.Trghhjsgdj"); // Original : Test.Trghhjsgdj // lo cambie a null para probar
    }
}