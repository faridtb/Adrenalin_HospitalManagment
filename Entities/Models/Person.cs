using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Person:IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int personID { get; set; }

        public override string ToString()
        {
            return $"ID:{personID}\n" +
                $"Name:{Name}\n" +
                $"Surname:{Surname}\n" +
                $"Age:{Age}\n" +
                $"--------------";

        }
    }
}
