using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class DoctorController
    {
        DoctorService doctorService = new DoctorService();
        MedicalServiceController medservice = new MedicalServiceController();
        public void CreateDoctor()
        {
            Alert(ConsoleColor.Yellow, "\n-------------\n" +
                "Adding Doctor\n" +
                "-------------");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Age:");
            int age = TryParse();

            Doctor doctor = new Doctor()
            {
                Name = name,
                Surname = surname,
                Age = age
            };
            doctorService.Create(doctor);
            Alert(ConsoleColor.Green, $"\nInformation of Doctor:\n" +
                $"{doctor}");
        }
        public void RemoveDoctor()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of Doctor\n");
            Doctor doc = doctorService.Delete(GetDoctor().personID);
            Alert(ConsoleColor.DarkYellow, $"Dr.{doc.Name} was deleted.");
        }
        public Doctor GetDoctor()
        {
            Alert(ConsoleColor.Blue, "\n" +
                "~Enter the Id of which Doctor you want");
            int id = TryParse();
            Console.WriteLine(doctorService.GetDoctor(id));
            return doctorService.GetDoctor(id);
        }
        public List<Doctor> GetAllDoctor()
        {
            Alert(ConsoleColor.Yellow, "Doctors list");
            return doctorService.GetAll();
        }
        public void EditDoctor()
        {
            Alert(ConsoleColor.DarkYellow, "Editing Doctor Info\n");
            Doctor newDoctor = GetDoctor();
            Console.WriteLine("What would you like to renew ?\n" +
                $"1)Dr.{newDoctor.Name}'s Name\n" +
                $"2)Dr.{newDoctor.Name}'s Surname\n" +
                $"3)Dr.{newDoctor.Name}'s Age\n");
            Console.Write("Your choice:");
            int input = TryParse();
            switch (input)
            {
                case 1:
                    Console.WriteLine($"Editing name of Dr.{newDoctor.Name}");
                    newDoctor.Name = Console.ReadLine();
                    doctorService.Edit(newDoctor.personID, newDoctor);
                    break;
                case 2:
                    Console.WriteLine($"Editing surname of Dr.{newDoctor.Name}");
                    newDoctor.Surname = Console.ReadLine();
                    doctorService.Edit(newDoctor.personID, newDoctor);
                    break;
                case 3:
                    Console.WriteLine($"Editing age of Dr.{newDoctor.Name}");
                    newDoctor.Age = TryParse();
                    doctorService.Edit(newDoctor.personID, newDoctor);
                    break;
            }
        }
        public void AddServiceToDoc()
        {
            Doctor docsrv = GetDoctor();
            while (docsrv is null)
            {
                Alert(ConsoleColor.Red, "There is not any Doctor in that id");
                docsrv = GetDoctor();
            }
            Medical_Services med = medservice.GetMedService();
            while (med is null)
            {
                Alert(ConsoleColor.Red, "There is not any Medical Services in that id");
                med = medservice.GetMedService();
            }
            doctorService.AddService(med, docsrv.personID);
            Alert(ConsoleColor.Green, $"{med.Name} service add to DR.{docsrv.Name}");
            //Console.Write(@$"Do you want change price of {med.Name} for Dr.{docsrv.Name} \n" +
            //    $"Existing price:{med.ServiceFee}\n");
            //Alert(ConsoleColor.DarkYellow, "Yes - press 1");
            //Console.Write("Your choice:");
            //int choice = TryParse();
            //if (choice == 1)
            //{
            //    Console.Write("New Price:");
            //    docsrv.services.Find(i => i.profID == med.profID).ServiceFee = TryParse();
            //}
        }
        public void ShowServiceList()
        {
            doctorService.ShowServiceList(GetDoctor());
        }
        public void ProfitInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            doctorService.ProfitInfo(GetAllDoctor());
            Console.ResetColor();
        }
    }
}
