using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class UserController
    {
        UserService userService = new UserService();
        User user;
        public int choice = 0;
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
            user = new User()
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
            foreach (var item in GetAllUsers())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkRed, "Deletion of User");
            user = GetUser();
            if (!(user is null))
            {
                user = userService.Delete(user.UserId);
                Alert(ConsoleColor.Green, $"Deletion of {user.Login} completed !");
                if (GetAllUsers().Count == 0)
                    user = null;
            }
            else
                Alert(ConsoleColor.Red, $"Deletion Failed!");
        }
        public User GetUser()
        {
            choice = 0;
            Alert(ConsoleColor.Blue, "Enter the Id of User you want");
            int id = TryParse();
            user = userService.GetUser(id); 
            while (user is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any User in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        user = GetUser();
                        break;
                }
            }
            if (!(user is null))
                Console.WriteLine(user);

            return user;
        }
        public List<User> GetAllUsers()
        {
            return userService.GetAll();
        }
        public void EditUser()
        {
            Alert(ConsoleColor.Yellow, "User Editing");
            foreach (var item in GetAllUsers())
                Console.WriteLine(item);
            user = GetUser();
            if (!(user is null))
            {         
                Alert(ConsoleColor.Yellow, $"Please write {user.Login}'s password for able to edit");
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
                    Alert(ConsoleColor.Red, "Passwords do not match");

            }

        }
        public bool CheckUser(string login, string password, User user)
        {
            bool tester = true;
            if (userService.CheckUser(login, password, user) is null)
                tester = false;

            return tester;
        }

    }
}
