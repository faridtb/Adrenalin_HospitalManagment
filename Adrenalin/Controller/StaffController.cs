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
            Alert(ConsoleColor.DarkRed, "Deletion of Staff");
            if (!(staff is null))
            {
                staff = staffService.Delete(GetStaff().personID);
                Alert(ConsoleColor.DarkYellow, $"Staff:{staff.Name} was deleted");
                if (GetAllStaff().Count == 0)
                    staff = null;
            }
            else
                Alert(ConsoleColor.Red, $"Deletion failed");
        }
        public Staff GetStaff()
        {
            Alert(ConsoleColor.Blue, "Enter the Id of which Staff you want");
            int id = TryParse();
            staff = staffService.GetStaff(id);
            int choice = 0;
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
            return staffService.GetAll();
        }
        public void EditStaff()
        {
            Alert(ConsoleColor.DarkYellow, "Editing Staff Info\n");
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
