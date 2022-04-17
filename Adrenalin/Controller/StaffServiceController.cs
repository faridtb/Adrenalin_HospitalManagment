using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class StaffServiceController
    {
        ProfessionService profession = new ProfessionService();
        Staff_Services prof = new Staff_Services();
        public void CreateProfession()
        {
            Alert(ConsoleColor.Yellow, "Adding Profession");
            Console.Write("Enter the name of the service:");
            string name = Console.ReadLine();
            Console.Write("Enter the salary of the service:");
            int salary = TryParse();

            Staff_Services service = new Staff_Services()
            {
                Name = name,
                Salary = salary
            };
            profession.Create(service);
            Alert(ConsoleColor.Yellow, $"About the service\n{service}");
        }
        public Staff_Services GetProfession()
        {
            Alert(ConsoleColor.DarkYellow, "Enter the ID of the Profession you are looking for");
            int id = TryParse();
            Console.WriteLine(profession.GetStafService(id));
            return profession.GetStafService(id);
        }
        public void GetAllProfessions()
        {
            Alert(ConsoleColor.Yellow, "List of Professions\n");
            foreach (var item in profession.GetAll())
                Console.WriteLine(item);
        }
        public void RemoveProfession()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of profession\n");
            prof = profession.Delete(GetProfession().profID);
            Alert(ConsoleColor.DarkYellow, $"{prof.Name}- profession deleted");
        }
        public void EditStaffService()
        {
            prof = GetProfession();
            Console.WriteLine("What would you like to renew ?\n" +
            "1)Profession Name\n" +
            "2)Profession Salary\n");
            Console.Write("Your choice:");
            int input = TryParse();
            switch (input)
            {
                case 1:
                    Console.WriteLine("Name changing");
                    prof.Name = Console.ReadLine();
                    profession.Edit(prof.profID, prof);
                    break;
                case 2:
                    Console.WriteLine("Price changing");
                    prof.Salary = TryParse();
                    profession.Edit(prof.profID, prof);
                    break;
            }

        }
    }
}
