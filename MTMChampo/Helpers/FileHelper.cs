using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MTMChampo.Helpers
{
    static class FileHelper
    {
        private static string ObtenerRutaArchivo(string nombreArchivo) =>
             Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nombreArchivo);

        public static async Task GuardarDatosAsync<T>(string nombreArchivo, List<T> datos)
        {
            string rutaArchivo = ObtenerRutaArchivo(nombreArchivo);
            string jsonDatos = JsonSerializer.Serialize(datos);
            await File.WriteAllTextAsync(rutaArchivo, jsonDatos);
        }

        public static async Task<List<T>> CargarDatosAsync<T>(string nombreArchivo)
        {
            try
            {
                string rutaArchivo = ObtenerRutaArchivo(nombreArchivo);
                if (!File.Exists(rutaArchivo))
                    return new List<T>();

                string jsonDatos = await File.ReadAllTextAsync(rutaArchivo);
                return JsonSerializer.Deserialize<List<T>>(jsonDatos);
            }
            catch
            {
                return new List<T>();
            }
        }

        public static void BorrarArchivo(string nombreArchivo)
        {
            string rutaArchivo = ObtenerRutaArchivo(nombreArchivo);
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
        }
    }
}
