
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Doctor : Person
    {
        public List<Medical_Services> services;
        public double Profit { get; set; } = 0;
        public static double _profit;

        public Doctor()
        {
            services = new List<Medical_Services>();
            _profit = Profit;
        }

    }
}
