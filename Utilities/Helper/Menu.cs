using System;
using System.Collections.Generic;
using System.Text;
using static Utilities.Notifications;

namespace Utilities
{
    public static class Menu
    {
        public static int AdminMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Cyan,$"{i++})Staff's options\n" +
                $"{i++})Doctor's options\n" +
                $"{i++})Patient's options\n" +
                $"{i++})Medical Services options\n" +
                $"{i++})Staff Services options\n" +
                $"{i++})Registration options\n" +
                $"{i++})User's options\n" +
                 $"0)Back To Login");
            return TestChoice(i);
        }
        public static int DirectorMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Yellow,$"{i++})Staff's options\n" +
                $"{i++})Doctor's options\n" +
                $"{i++})Patient's options\n" +
                $"{i++})Medical Services options\n" +
                $"{i++})Staff Services options\n" +
                $"{i++})Registration options\n" +
                 $"0)Back To Main Menu");
            return TestChoice(i);
        }
        public static int StaffMainMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Magenta, $"{i++})Registration\n" +
                 $"{i++})Medical Services\n" +
                 $"{i++})Doctors\n" +
                 $"{i++})Patients\n" +
                 $"{i++})Staffs\n" +
                 $"{i})Staff Services\n" +
                "0)Exit");
            return TestChoice(i);
        }
        public static int DoctorMainMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Magenta, $"{i++})Daily reports\n" +
                 $"{i})My profits\n" +
                "0)Exit");
            return TestChoice(i);
        }
        public static int UserMenu()
        {
            int i = 1;
            Alert(ConsoleColor.DarkCyan, $"{i++})Create User\n" +
                $"{i++})Remove User\n" +
                $"{i++})Edit User\n" +
                $"{i++})Get User\n" +
                $"{i})Get All Users\n" +
                "0)Quit");
           return TestChoice(i);
        }
        public static int StaffMenu()
        {
            int i = 1;
            Alert(ConsoleColor.DarkCyan, $"{i++})Create Staff\n" +
               $"{i++})Remove Staff\n" +
               $"{i++})Edit Staff\n" +
               $"{i++})Get Staff\n" +
               $"{i})Get All Staffs\n" +
               "0)Quit");
            return TestChoice(i);

        }
        public static int StaffMenuJunior()
        {
            int i = 1;
            Alert(ConsoleColor.DarkCyan, $"{i++})Get Staff\n" +
               $"{i})Get All Staffs\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int DoctorMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Blue, $"{i++})Create Doctor\n" +
               $"{i++})Remove Doctor\n" +
               $"{i++})Edit Doctor\n" +
               $"{i++})Get Doctor\n" +
               $"{i++})Get All Doctors\n" +
               $"{i++})Add service to Doctor\n" +
               $"{i++})Sort Doctors by service\n" +
               $"{i})Doctors Profit Info\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int DoctorMenuForJunior()
        {
            int i = 1;
            Alert(ConsoleColor.Blue, $"{i++})Get Doctor\n"+
               $"{i})Get All Doctors\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int PatientMenu()
        {
            int i = 1;
            Alert(ConsoleColor.White, $"{i++})Create Patient\n" +
               $"{i++})Remove Patient\n" +
               $"{i++})Edit Patient\n" +
               $"{i++})Get Patient\n" +
               $"{i})Get All Patients\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int PatientMenuJunior()
        {
            int i = 1;
            Alert(ConsoleColor.White, $"{i++})Get Patient\n" +
               $"{i++})Get All Patients\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int StaffServiceMenu()
        {
            int i = 1;
            Alert(ConsoleColor.DarkYellow, $"{i++})Create StaffService\n" +
               $"{i++})Remove StaffService\n" +
               $"{i++})Edit StaffService\n" +
               $"{i++})Get StaffService\n" +
               $"{i})Get All StaffServices\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int StaffServiceMenuForJunior()
        {
            int i = 1;
            Alert(ConsoleColor.DarkYellow, $"{i++})Get StaffService\n" +
               $"{i})Get All StaffServices\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int MedicalServiceMenu()
        {
            int i = 1;
            Alert(ConsoleColor.DarkRed, $"{i++})Create MedicalService\n" +
               $"{i++})Remove MedicalService\n" +
               $"{i++})Edit MedicalService\n" +
               $"{i++})Get MedicalService\n" +
               $"{i})Get All MedicalServices\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int MedicalServiceMenuForJunior()
        {
            int i = 1;
            Alert(ConsoleColor.DarkRed, $"{i++})Get MedicalService\n" +
               $"{i})Get All MedicalServices\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int RegistrationMenu()
        {
            int i = 1;
            Alert(ConsoleColor.Magenta, $"{i++})Add Registration\n" +
               $"{i++})Remove Registration\n" +
               $"{i++})Edit Registration\n" +
               $"{i++})Get Registration\n" +
               $"{i++})Get Specific Registration\n" +
               $"{i})Get All Registrations\n" +
               "0)Quit");
            return TestChoice(i);
        }
        public static int RegistrationMenuForJunior()
        {
            int i = 1;
            Alert(ConsoleColor.DarkRed, $"{i++})Add Registration\n" +
               $"{i++})Get Registration\n" +
               $"{i++})Get Specific Registration\n" +
               $"{i})Get All Registrations\n" +
               "0)Quit");
           return TestChoice(i);
        }
        public static int TestChoice(int i)
        {
            Console.Write("Your choice:");
            int input = TryParse();
            while (input < 0 || input > i)
            {
                Alert(ConsoleColor.Red, "Enter number which is valid for choice !");
                input = TryParse();
            }
            return input;
        }


    }
}
