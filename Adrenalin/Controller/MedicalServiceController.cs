using Business.Services;
using Entities.Models;
using System;
using Utilities;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    class MedicalServiceController
    {
        MedicalService medservice = new MedicalService();

        public void CreateMedService()
        {
            Alert(ConsoleColor.DarkRed, "\n-----------------------\n" +
                "Adding Medical Services\n" +
                "-----------------------");
            Console.Write("Enter the name of the service:");
            string name = Console.ReadLine();
            Console.Write("Enter the price of the service:");
            int price = TryParse();

            Medical_Services medical = new Medical_Services()
            {
                Name = name,
                ServiceFee = price
            };
            medservice.Create(medical);
            Notifications.Alert(ConsoleColor.Yellow, $"\nAbout the service\n{medical}");
        }
        public Medical_Services GetMedService()
        {
            Alert(ConsoleColor.Blue, "Enter the ID of the Medical Service you are looking for");
            int id = TryParse();
            Console.WriteLine(medservice.GetMedicalService(id));
            return medservice.GetMedicalService(id);
        }
        public void GetAllService()
        {
            Alert(ConsoleColor.DarkRed, "\nMedical Serivces");
            foreach (var item in medservice.GetAll())
                Console.WriteLine(item);
        }
        public void RemoveMedService()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of medical service\n");
            Medical_Services med = medservice.Delete(GetMedService().profID);
            Alert(ConsoleColor.DarkYellow, $"{med.Name}- service deleted");
        }
        public void EditMedService()
        {
            Alert(ConsoleColor.DarkYellow, "\nRegistration Editing\n");
            Medical_Services med = GetMedService();
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
