using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Registration
    {
        public Patients Patients { get; set; }
        public Doctor Doctor { get; set; }
        public Medical_Services MedicalService { get; set; }
        public int RegistrationID { get; set; }
        public DateTime SharedDate { get; set; }
        public double Profit { get; set; }
        public Registration()
        {
            SharedDate = DateTime.Now;
        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"Registration ID:{RegistrationID} || {SharedDate}\n" +
                $"Pasient :{Patients.Name}\n" +
                $"Doctor:{Doctor.Name} \n" +
                $"Service:{MedicalService.Name} \n" +
                $"Clinic profit:{Profit}\n" +
                $"-------------------------";

        }
    }
}

