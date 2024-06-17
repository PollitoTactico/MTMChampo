using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    internal static class UserManager
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static bool RegistrarUsuario(string nombreUsuario, string contraseña)
        {
            
            if (usuarios.Any(u => u.NombreUsuario == nombreUsuario))
            {
                return false; 
            }

            
            usuarios.Add(new Usuario(nombreUsuario, contraseña));
            return true; 
        }

        public static bool ValidarUsuario(string nombreUsuario, string contraseña)
        {
            return usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        }
    }
}
