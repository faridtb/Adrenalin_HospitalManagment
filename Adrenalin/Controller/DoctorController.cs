﻿using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;


namespace Adrenalin.Controller
{
    public class DoctorController
    {
        DoctorService doctorService = new DoctorService();
        MedicalServiceController medservice = new MedicalServiceController();
        Medical_Services med;
        Doctor doc;
        public int choice = 0;
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

            doc = new Doctor()
            {
                Name = name,
                Surname = surname,
                Age = age
            };
            doctorService.Create(doc);
            Alert(ConsoleColor.Green, $"\nInformation of Doctor:\n" +
                $"{doc}");
        }
        public void RemoveDoctor()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of Doctor");
            if (!(doc is null))
            {
                doc = doctorService.Delete(GetDoctor().personID);
                Alert(ConsoleColor.DarkYellow, $"Dr.{doc.Name} was deleted.");
                if (GetAllDoctor().Count == 0)
                    doc = null;
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
        }
        public Doctor GetDoctor()
        {
            Alert(ConsoleColor.Blue, "\n" +
                "~Enter the Id of which Doctor you want");
            int id = TryParse();
            doc = doctorService.GetDoctor(id);
            while (doc is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Doctor in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        doc = GetDoctor();
                        break;
                }
            }
            if (!(doc is null))
                Console.WriteLine(doc);
            return doc;
        }
        public List<Doctor> GetAllDoctor()
        {
            return doctorService.GetAll();
        }
        public void EditDoctor()
        {
            Alert(ConsoleColor.DarkYellow, "Renewal of doctor's information");
            doc = GetDoctor();
            if (!(doc is null))
            {
                Console.WriteLine("What would you like to renew ?\n" +
                    $"1)Dr.{doc.Name}'s Name\n" +
                    $"2)Dr.{doc.Name}'s Surname\n" +
                    $"3)Dr.{doc.Name}'s Age\n");
                Console.Write("Your choice:");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Console.WriteLine($"Editing name of Dr.{doc.Name}");
                        doc.Name = Console.ReadLine();
                        doctorService.Edit(doc.personID, doc);
                        break;
                    case 2:
                        Console.WriteLine($"Editing surname of Dr.{doc.Name}");
                        doc.Surname = Console.ReadLine();
                        doctorService.Edit(doc.personID, doc);
                        break;
                    case 3:
                        Console.WriteLine($"Editing age of Dr.{doc.Name}");
                        doc.Age = TryParse();
                        doctorService.Edit(doc.personID, doc);
                        break;
                }
            }
        }
        public void AddServiceToDoc()
        {
            doc = GetDoctor();
            if (!(doc is null))
                 med = medservice.GetMedService();         
            if (!(med is null)&&!(doc is null))
            {
                if (!(doc.services.Contains(med)))
                {
                    doctorService.AddService(med, doc.personID);
                    Alert(ConsoleColor.Green, $"{med.Name} service add to DR.{doc.Name}");
                }
                else
                    Alert(ConsoleColor.DarkYellow, $"{doc.Name} already exist {med.Name} service");
            }
            
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
            List<Doctor> doctors = GetAllDoctor().FindAll(i => i.services.Contains(medservice.GetMedService()));
                foreach (var item in doctors)
                    Console.WriteLine(item);
        }
        public void ProfitInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            doctorService.ProfitInfo(GetAllDoctor());
            Console.ResetColor();
        }
    }
}
