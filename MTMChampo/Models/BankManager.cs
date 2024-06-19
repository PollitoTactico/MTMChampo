using MTMChampo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    internal class BankManager
    {
        private static readonly string nombreArchivo = "cuentas_bancarias.json";

        private static List<CuentaBanco> _cuentas;
        public static List<CuentaBanco> Cuentas
        {
            get
            {
                if (_cuentas == null)
                {
                    CargarCuentasAsync().Wait();
                }
                return _cuentas;
            }
        }

        public static async Task GuardarCuentasAsync()
        {
            await FileHelper.GuardarDatosAsync(nombreArchivo, _cuentas);
        }

        public static async Task<List<CuentaBanco>> CargarCuentasAsync()
        {
            _cuentas = await FileHelper.CargarDatosAsync<CuentaBanco>(nombreArchivo);
            return _cuentas;
        }

        public static void BorrarArchivoCuentas()
        {
            FileHelper.BorrarArchivo(nombreArchivo);
            _cuentas = new List<CuentaBanco>();
        }

        public static bool ExisteNumeroCuenta(string numeroCuenta)
        {
            return Cuentas.Any(c => c.NumeroCuenta == numeroCuenta);
        }
        public static void ActualizarCuenta(CuentaBanco cuentaActualizada)
        {
            var cuentaExistente = Cuentas.FirstOrDefault(c => c.Id == cuentaActualizada.Id);
            if (cuentaExistente != null)
            {
                cuentaExistente.NumeroCuenta = cuentaActualizada.NumeroCuenta;
                cuentaExistente.NombreTitular = cuentaActualizada.NombreTitular;
                cuentaExistente.Saldo = cuentaActualizada.Saldo;
                cuentaExistente.TipoCuenta = cuentaActualizada.TipoCuenta;
            }
        }
    }
}
