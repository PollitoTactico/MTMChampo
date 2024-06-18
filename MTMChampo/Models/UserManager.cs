using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTMChampo.Models
{
    internal class UserManager
    {
      public string username { get; set; }
        public string password { get; set; }

        public static List<UserManager> RegisteredUsers { get; set; } = new List<UserManager>();
    }
}
