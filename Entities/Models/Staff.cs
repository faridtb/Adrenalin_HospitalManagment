using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Staff:Person
    {
        public Staff_Services service;
        public override string ToString()
        {
            return $"ID:{personID}\n" +
                $"Name:{Name}\n" +
                $"Surname:{Surname}\n" +
                $"Age:{Age}\n" +
                $"Profession:{service.Name}\n" +
                $"Salary:{service.Salary}";
        }
    }
}
