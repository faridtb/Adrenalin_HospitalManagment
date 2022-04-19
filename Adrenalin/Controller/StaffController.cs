using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class StaffController
    {
        StaffService staffService = new StaffService();
        StaffServiceController proffesion = new StaffServiceController();
        Staff staff;
        public int choice = 0;

        public void CreateStaff()
        {
            Alert(ConsoleColor.Yellow, "Adding Staf");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Age:");
            int age = TryParse();


            staff = new Staff()
            {
                Name = name,
                Surname = surname,
                Age = age,
                service = proffesion.GetProfession()
            };
            if (!(staff.service is null))
            {
                staffService.Create(staff);
                Alert(ConsoleColor.Green, $"{staff.Name} created!\nInformation of Staff:\n{staff}");
            }
            else
                Alert(ConsoleColor.Yellow, "Advice: Create any vacant profession for adding the staff");

        }
        public void RemoveStaff()
        {
            foreach (var item in GetAllStaff())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkRed, "Deletion of Staff");
            staff = GetStaff();
            if (!(staff is null))
            {
                staff = staffService.Delete(staff.personID);
                Alert(ConsoleColor.DarkYellow, $"Staff:{staff.Name} was deleted");
            }
            else
                Alert(ConsoleColor.Red, $"Deletion failed");
        }
        public Staff GetStaff()
        {
            choice = 0;
            Alert(ConsoleColor.Blue, "Enter the Id of which Staff you want");
            int id = TryParse();
            staff = staffService.GetStaff(id);       
            while (staff is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Staff in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        staff = GetStaff();
                        break;
                }
            }
            if (!(staff is null))
                Console.WriteLine(staff);
            return staff;
        }
        public List<Staff> GetAllStaff()
        {
            Alert(ConsoleColor.DarkCyan, "\nStaff List\n");
            return staffService.GetAll();
        }
        public void EditStaff()
        {
            foreach (var item in GetAllStaff())
                Console.WriteLine(item);
            Alert(ConsoleColor.Yellow, "Renewal of staff's information");
            staff = GetStaff();
            if (!(staff is null))
            {
                Console.WriteLine("What would you like to renew ?\n" +
                $"1){staff.Name}'s name\n" +
                $"2){staff.Name}'s surname\n" +
                $"3){staff.Name}'s age\n");
                Console.Write("Your choice:");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Console.WriteLine($"Editing name of {staff.Name}");
                        staff.Name = Console.ReadLine();
                        staffService.Edit(staff.personID, staff);
                        break;
                    case 2:
                        Console.WriteLine($"Editing surname of {staff.Name}");
                        staff.Surname = Console.ReadLine();
                        staffService.Edit(staff.personID, staff);
                        break;
                    case 3:
                        Console.WriteLine($"Editing age of {staff.Name}");
                        staff.Age = TryParse();
                        staffService.Edit(staff.personID, staff);
                        break;
                }
            }
        }


    }
}
