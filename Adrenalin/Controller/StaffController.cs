using Business.Services;
using Entities.Models;
using System;
using Utilities;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class StaffController
    {
        StaffService staffService = new StaffService();
        StaffServiceController proffesion = new StaffServiceController();

        public void CreateStaff()
        {
            Alert(ConsoleColor.Yellow, "Adding Staf");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Age:");
            int age = TryParse();
            Console.Write("For adding profession:");

            Staff staff = new Staff()
            {
                Name = name,
                Surname = surname,
                Age = age,
                service = proffesion.GetProfession()
            };

            staffService.Create(staff);
            Alert(ConsoleColor.Green, $"\nInformation of Staff:\n{staff}");
        }
        public void RemoveStaff()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of Staff\n");
            Staff staff = staffService.Delete(GetStaff().personID);
            Alert(ConsoleColor.DarkYellow, $"Staff:{staff.Name} was deleted");
        }
        public Staff GetStaff()
        {
            Alert(ConsoleColor.DarkYellow, "Please enter the id for searching staff");
            int id = TryParse();
            Console.WriteLine(staffService.GetStaff(id));
            return staffService.GetStaff(id);
        }
        public void GetAllStaff()
        {
            Alert(ConsoleColor.Yellow, "List of Staff\n");
            foreach (var item in staffService.GetAll())
                Console.WriteLine(item);
        }
        public void EditStaff()
        {
            Alert(ConsoleColor.DarkYellow, "Editing Staff Info\n");
            Staff newStaff = GetStaff();
            Console.WriteLine("What would you like to renew ?\n" +
                $"1){newStaff.Name}'s name\n" +
                $"2){newStaff.Name}'s surname\n" +
                $"3){newStaff.Name}'s age\n");
            Console.Write("Your choice:");
            int input = TryParse();
            switch (input)
            {
                case 1:
                    Console.WriteLine($"Editing name of {newStaff.Name}");
                    newStaff.Name = Console.ReadLine();
                    staffService.Edit(newStaff.personID, newStaff);
                    break;
                case 2:
                    Console.WriteLine($"Editing surname of {newStaff.Name}");
                    newStaff.Surname = Console.ReadLine();
                    staffService.Edit(newStaff.personID, newStaff);
                    break;
                case 3:
                    Console.WriteLine($"Editing age of {newStaff.Name}");
                    newStaff.Age = TryParse();
                    staffService.Edit(newStaff.personID, newStaff);
                    break;
            }
        }



    }
}
