using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;


namespace Adrenalin.Controller
{
    class MedicalServiceController
    {
        MedicalService medservice = new MedicalService();
        Medical_Services med;
        public int choice = 0;

        public void CreateMedService()
        {
            Alert(ConsoleColor.DarkRed, "\n-----------------------\n" +
                "Adding Medical Services\n" +
                "-----------------------");
            Console.Write("Enter the name of the service:");
            string name = Console.ReadLine();
            Console.Write("Enter the price of the service:");
            int price = TryParse();

            med = new Medical_Services()
            {
                Name = name,
                ServiceFee = price
            };
            medservice.Create(med);
            Alert(ConsoleColor.Yellow, $"\nAbout the service\n{med}");
        }
        public Medical_Services GetMedService()
        {
            Alert(ConsoleColor.Blue, "Enter the ID of the Medical Service you are looking for");
            int id = TryParse();
            med = medservice.GetMedicalService(id);
            while (med is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Medical Service in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        med = GetMedService();
                        break;
                }
            }
            if (!(med is null))
                Console.WriteLine(med);
            return med;
        }
        public List<Medical_Services> GetAllService()
        {
            return medservice.GetAll();
        }
        public void RemoveMedService()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of medical service");
            if (!(med is null))
            {
                med = medservice.Delete(GetMedService().profID);
                Alert(ConsoleColor.DarkYellow, $"{med.Name}- service deleted");
                if (GetAllService().Count == 0)
                    med = null;
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
        }
        public void EditMedService()
        {
            Alert(ConsoleColor.DarkYellow, "Medical Service Editing\n");
            med = GetMedService();
            if (!(med is null))
            {
                Console.WriteLine("What would you like to renew ?\n" +
                "1)Service name\n" +
                "2)Service Fee\n");
                Console.Write("Your choice:");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Name changing");
                        med.Name = Console.ReadLine();
                        medservice.Edit(med.profID, med);
                        break;
                    case 2:
                        Console.WriteLine("Price changing");
                        med.ServiceFee = TryParse();
                        medservice.Edit(med.profID, med);
                        break;
                }

            }
        }
    }
}
