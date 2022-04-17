using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Staff_Services:Services
    {
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Service ID:{profID}\n" +
                $"Service name:{Name}\n" +
                $"Service salary:{Salary}";
        }
    }
}
