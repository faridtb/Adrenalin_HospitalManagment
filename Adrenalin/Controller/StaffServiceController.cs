using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class StaffServiceController
    {
        ProfessionService profession = new ProfessionService();
        Staff_Services prof;
        Staff staf = new Staff();
        public int choice = 0;
        public void CreateProfession()
        {
            Alert(ConsoleColor.Yellow, "Adding Profession");
            Console.Write("Enter the name of the service:");
            string name = Console.ReadLine();
            Console.Write("Enter the salary of the service:");
            int salary = TryParse();

            prof = new Staff_Services()
            {
                Name = name,
                Salary = salary
            };
            profession.Create(prof);
            Alert(ConsoleColor.Yellow, $"About the service\n{prof}");
        }
        public Staff_Services GetProfession()
        {
            choice = 0;
            Alert(ConsoleColor.Blue, "Enter the Id of Profession you want");
            int id = TryParse();
            prof = profession.GetStafService(id);
            while (prof is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Profession in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        prof = GetProfession();
                        break;
                }
            }
            if (!(prof is null))
                Console.WriteLine(prof);
            return prof;

        }
        public List<Staff_Services> GetAllProfessions()
        {
            Alert(ConsoleColor.DarkCyan, "All Staff Services");
            return profession.GetAll();
        }
        public void RemoveProfession()
        {
            foreach(var item in GetAllProfessions())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkRed, "Deletion of profession");
            prof =GetProfession();
            if (!(prof is null))
            {
                prof = profession.Delete(prof.profID);
                Alert(ConsoleColor.DarkYellow, $"{prof.Name}- profession deleted");
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
        }
        public void EditStaffService()
        {
            foreach (var item in GetAllProfessions())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkYellow, "Profession Editing\n");
            prof = GetProfession();
            if (!(prof is null))
            {
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
}
