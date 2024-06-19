using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    internal class CuentaBanco
    {
        public string NumeroCuenta { get; set; }
        public string NombreTitular { get; set; }
        public decimal Saldo { get; set; }
        public string TipoCuenta { get; set; }
    }
}
