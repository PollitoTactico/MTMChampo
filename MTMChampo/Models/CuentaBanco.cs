using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    public class CuentaBanco
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("numCuenta")]
        public string NumeroCuenta { get; set; }
        [Column("nombreTitular")]
        public string NombreTitular { get; set; }
        [Column("saldo")]
        public decimal Saldo { get; set; }
        [Column("tipoCuenta")]
        public string TipoCuenta { get; set; }

        
    }
    
}
