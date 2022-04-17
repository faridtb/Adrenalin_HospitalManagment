using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAcess
{
    public class DataContext
    {
        public static List<Doctor> Doctors { get; set; }
        public static List<Staff> Staffs { get; set; }
        public static List<User> Users { get; set; }
        public static List<Medical_Services> MedicalServices { get; set; }
        public static List<Staff_Services> StaffServices { get; set; }
        public static List<Patients> Patients { get; set; }
        public static List<Registration>Registrations { get; set; }

        static  DataContext()
        {
            Doctors = new List<Doctor>();
            Staffs = new List<Staff>();
            MedicalServices = new List<Medical_Services>();
            StaffServices = new List<Staff_Services>();
            Patients = new List<Patients>();
            Registrations = new List<Registration>();
            Users = new List<User>();

        }


    }
}
