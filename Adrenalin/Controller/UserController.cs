using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class UserController
    {
        UserService userService = new UserService();

        public User CreateUser()
        {
            Alert(ConsoleColor.Blue, "---------------\n" +
                "User Creation\n" +
                "--------------");
            Console.Write("Login:");
            string login = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("\nSet the role");
            Alert(ConsoleColor.Blue, "1-Admin");
            Alert(ConsoleColor.Yellow, "2-Director");
            Alert(ConsoleColor.DarkRed, "3-Doctor");
            Alert(ConsoleColor.White, "4-Staff");
            int input = TryParse();
            Enum role = Role.staff;
            while (input < 1 || input > 4)
            {
                Alert(ConsoleColor.Red, "Enter number which is valid for choice !");
                input = TryParse();
            }
            switch (input)
            {
                case 1:
                    role = Role.admin;
                    Alert(ConsoleColor.Blue, "Admin - role selected");
                    break;
                case 2:
                    role = Role.director;
                    Alert(ConsoleColor.Yellow, "Director - role selected");
                    break;
                case 3:
                    role = Role.doctor;
                    Alert(ConsoleColor.DarkRed, "Doctor - role selected");
                    break;
                case 4:
                    role = Role.staff;
                    Alert(ConsoleColor.White, "Staff - role selected");
                    break;

            }
            User user = new User()
            {
                Login = login,
                Password = password,
                Role = role
            };
            userService.Create(user);
            Alert(ConsoleColor.Green, $"{user.Login} created.");
            return user;
        }
        public void RemoveUser()
        {
            Alert(ConsoleColor.DarkRed, "Deletion of User\n");
            User user = userService.Delete(GetUser().UserId);
            Alert(ConsoleColor.Green, $"Deletion of {user.Login} completed !");
        }
        public User GetUser()
        {
            Alert(ConsoleColor.Blue, "Enter the Id of which User you want");
            int id = TryParse();
            return userService.GetUser(id);
        }
        public void GetAllUsers()
        {
            Alert(ConsoleColor.Yellow, "List Of Users \n");
            foreach (var item in userService.GetAll())
                Console.WriteLine(item);
        }
        public void EditUser()
        {
            GetAllUsers();
            User user = GetUser();
            Alert(ConsoleColor.DarkYellow, $"Please write {user.Login}'s password for able to edit");
            string password = Console.ReadLine();
            if (password == user.Password)
            {
                Console.WriteLine("What would you like to renew ?\n" +
                "1)Login\n" +
                "2)Password\n");
                Console.Write("Your choice:");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Login changing");
                        user.Login = Console.ReadLine();
                        userService.Edit(user.UserId, user);
                        break;
                    case 2:
                        Console.WriteLine("Password changing");
                        user.Password = Console.ReadLine();
                        userService.Edit(user.UserId, user);
                        break;
                }
            }
            else
            {
                Alert(ConsoleColor.Red, "Not Found Exception");
            }

        }
        public bool CheckUser(string login, string password)
        {
            bool tester = true;
            if (userService.CheckUser(login, password) is null)
                tester = false;

            return tester;
        }

    }
}
