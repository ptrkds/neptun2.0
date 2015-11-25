using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Admin : User
    {

        public Admin(String neptunCode, String name, String type, String pw)
            : base(neptunCode, name, type, pw)
        {
        }
    }
}
