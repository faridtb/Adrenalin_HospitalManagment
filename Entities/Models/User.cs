using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class User:IUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Enum Role { get; set; }

        public override string ToString()   
        {
            return $"User ID:{UserId}\n" +
                $"User Login:{Login}\n" +
                $"User Role:{Role}\n" +
                $"------------------";
        }
    }
}
