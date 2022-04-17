using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class PatientController
    {
        PatientService patientService = new PatientService();
        Patients patients;
        public int choice = 0;

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
             patients = new Patients() { Name = name, Surname = surname, Age = age };
            patientService.Create(patients);
            Alert(ConsoleColor.Green, $"{patients.Name} added");
            return patients;

        }
        public void RemovePatient()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of Patients");
            if (!(patients is null))
            { 
                patients = patientService.Delete(GetPatient().personID);
                Alert(ConsoleColor.Green, $"Deletion of {patients.Name} completed !");
                if (GetAllPatients().Count == 0)
                    patients = null;
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
            }
        public Patients GetPatient()
        {
            Alert(ConsoleColor.Blue, "Enter the Id of which Patient you want");
            int id = TryParse();
            patients = patientService.GetPatient(id);
            while (patients is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Patients in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        patients = GetPatient();
                        break;
                }
            }
            if (!(patients is null)) 
                Console.WriteLine(patients);
            return patients;
        }
        public List <Patients> GetAllPatients()
        {
            return patientService.GetAll();             
        }
        public void EditPatient()
        {
            Alert(ConsoleColor.DarkYellow, "Editing Patient Info\n");
             patients = GetPatient();
            if (!(patients is null))
            {
                Console.WriteLine("What would you like to renew ?\n" +
                $"1){patients.Name}'s Name\n" +
                $"2){patients.Name}'s Surname\n" +
                $"3){patients.Name}'s Age\n");
                Console.Write("Your choice:");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Console.WriteLine($"Editing name of Dr.{patients.Name}");
                        patients.Name = Console.ReadLine();
                        patientService.Edit(patients.personID, patients);
                        break;
                    case 2:
                        Console.WriteLine($"Editing surname of Dr.{patients.Name}");
                        patients.Surname = Console.ReadLine();
                        patientService.Edit(patients.personID, patients);
                        break;
                    case 3:
                        Console.WriteLine($"Editing age of Dr.{patients.Name}");
                        patients.Age = TryParse();
                        patientService.Edit(patients.personID, patients);
                        break;
                }
            }
        }
    }
}
