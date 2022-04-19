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
            choice = 0;
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
            Alert(ConsoleColor.DarkCyan, "\nMedical Services\n");
            return medservice.GetAll();
        }
        public void RemoveMedService()
        {
            foreach (var item in GetAllService())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkRed, "Deletion of medical service");
            med = GetMedService();
            if (!(med is null))
            {
                med = medservice.Delete(med.profID);
                Alert(ConsoleColor.DarkYellow, $"{med.Name}- service deleted");
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
        }
        public void EditMedService()
        {
            foreach (var item in GetAllService())
                Console.WriteLine(item);
            Alert(ConsoleColor.Yellow, "Renewal of Medical services information");
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
            else
                Alert(ConsoleColor.Red, "There is Not Any Service");
        }
    }
}
