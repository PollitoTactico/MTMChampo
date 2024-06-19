using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTMChampo.Helpers;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    internal class UserManager
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        private static readonly string nombreArchivo = "usuarios_registrados.json";

        private static List<UserManager> _usuariosRegistrados;
        public static List<UserManager> UsuariosRegistrados
        {
            get
            {
                if (_usuariosRegistrados == null)
                {
                    CargarUsuariosAsync().Wait();
                }
                return _usuariosRegistrados;
            }
        }

        public static async Task GuardarUsuariosAsync()
        {
            await FileHelper.GuardarDatosAsync(nombreArchivo, _usuariosRegistrados);
        }

        public static async Task CargarUsuariosAsync()
        {
            _usuariosRegistrados = await FileHelper.CargarDatosAsync<UserManager>(nombreArchivo);
        }

        public static void BorrarArchivoUsuarios()
        {
            FileHelper.BorrarArchivo(nombreArchivo);
            _usuariosRegistrados = new List<UserManager>();
        }
    }
}
