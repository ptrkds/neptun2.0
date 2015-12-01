using System;

namespace Neptun_Structure
{
    class Admin : User
    {

        public Admin(String neptunCode, String name, String type, String pw)
            : base(neptunCode, name, type, pw)
        {
        }
    }
}
