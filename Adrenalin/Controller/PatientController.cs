using Business.Services;
using Entities.Models;
using System;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class PatientController
    {
        PatientService patientService = new PatientService();
        Patients patients = new Patients();

        public Patients CreatePatient()
        {
            Alert(ConsoleColor.Magenta, "\n-------------------\n" +
                "Adding new Patients\n" +
                "-------------------");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Age:");
            int age = TryParse();
            Patients patient = new Patients() { Name = name, Surname = surname, Age = age };
            patientService.Create(patient);
            Alert(ConsoleColor.Green, $"{patient.Name} added");
            return patient;

        }
        public void RemovePatient()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of User\n");
            patients = patientService.Delete(GetPatient().personID);
            Alert(ConsoleColor.Green, $"Deletion of {patients.Name} completed !");
        }
        public Patients GetPatient()
        {
            Alert(ConsoleColor.Blue, "Enter the Id of which Patient you want");
            int id = TryParse();
            Console.WriteLine(patientService.GetPatient(id));
            return patientService.GetPatient(id);
        }
        public void GetAllPatients()
        {
            Alert(ConsoleColor.Magenta, "\nPatients list");
            foreach (var item in patientService.GetAll())
                Console.WriteLine(item);
        }
        public void EditPatient()
        {
            Alert(ConsoleColor.DarkYellow, "Editing Patient Info\n");
            Patients patient = GetPatient();
            Console.WriteLine("What would you like to renew ?\n" +
                $"1){patient.Name}'s Name\n" +
                $"2){patient.Name}'s Surname\n" +
                $"3){patient.Name}'s Age\n");
            Console.Write("Your choice:");
            int input = TryParse();
            switch (input)
            {
                case 1:
                    Console.WriteLine($"Editing name of Dr.{patient.Name}");
                    patient.Name = Console.ReadLine();
                    patientService.Edit(patient.personID, patient);
                    break;
                case 2:
                    Console.WriteLine($"Editing surname of Dr.{patient.Name}");
                    patient.Surname = Console.ReadLine();
                    patientService.Edit(patient.personID, patient);
                    break;
                case 3:
                    Console.WriteLine($"Editing age of Dr.{patient.Name}");
                    patient.Age = TryParse();
                    patientService.Edit(patient.personID, patient);
                    break;
            }
        }
    }
}
