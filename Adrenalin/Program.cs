using Adrenalin.Controller;
using Entities.Models;
using System;
using static Utilities.Menu;
using static Utilities.Notifications;

namespace Adrenalin
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserController userControl = new UserController();
            StaffController staffControl = new StaffController();
            DoctorController doctorControl = new DoctorController();
            PatientController patControl = new PatientController();
            MedicalServiceController medControl = new MedicalServiceController();
            StaffServiceController profControl = new StaffServiceController();
            RegistrationController regControl = new RegistrationController();
            User user = new User();
            if (userControl.GetAllUsers().Count == 0)
                user = userControl.CreateUser();
            Console.WriteLine("Press Any Key to Continue ....");
            Console.ReadLine();
            bool tester = false;


            #region Entry
            while (tester == false)
            {
                Console.Clear();
                if (userControl.GetAllUsers().Count >1)
                {
                    foreach (var item in userControl.GetAllUsers())
                        Console.WriteLine($"ID:{item.UserId}-{item.Login}");
                    user = userControl.GetUser();
                    
                }
                Console.Clear();
                Console.SetCursorPosition(30, 2);
                Console.BackgroundColor = ConsoleColor.White;
                Alert(ConsoleColor.DarkRed, "Adrenalin Console APP");
                Console.SetCursorPosition(30, 3);
                Console.Write("Login:");
                string login = Console.ReadLine();
                Console.SetCursorPosition(30, 4);
                Console.Write("Password:");
                string paswword = Console.ReadLine();
                Enum role = Role.staff;
                int input = 1;
                if (userControl.CheckUser(login, paswword,user))
                {
                    Console.Clear();
                    tester = true;
                    role = user.Role;
                    Console.SetCursorPosition(75 - user.Login.Length, 0);
                    Alert(ConsoleColor.Yellow, $"User: {user.Login}/{user.Role}");
                    while (input != 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(75 - user.Login.Length, 0);
                        Alert(ConsoleColor.Yellow, $"User: {user.Login}/{user.Role}");

                        if (role.ToString() == Role.admin.ToString())
                            input = AdminMenu();
                        if (role.ToString() == Role.director.ToString())
                            input = DirectorMenu();
                        if (role.ToString() == Role.doctor.ToString())
                            input = DoctorMainMenu();
                        if (role.ToString() == Role.staff.ToString())
                            input = StaffMainMenu();




                        switch (input)
                        {
                            case 1 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (StaffMenu())
                                {
                                    case 1:
                                        staffControl.CreateStaff();
                                        break;
                                    case 2:
                                        staffControl.RemoveStaff();
                                        break;
                                    case 3:
                                        staffControl.EditStaff();
                                        break;
                                    case 4:
                                        staffControl.GetStaff();
                                        break;
                                    case 5:
                                        foreach (var item in staffControl.GetAllStaff())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 2 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (DoctorMenu())
                                {
                                    case 1:
                                        doctorControl.CreateDoctor();
                                        break;
                                    case 2:
                                        doctorControl.RemoveDoctor();
                                        break;
                                    case 3:
                                        doctorControl.EditDoctor();
                                        break;
                                    case 4:
                                        doctorControl.GetDoctor();
                                        break;
                                    case 5:
                                        foreach (var item in doctorControl.GetAllDoctor())
                                            Console.WriteLine(item);
                                        break;
                                    case 6:
                                        doctorControl.AddServiceToDoc();
                                        break;
                                    case 7:
                                        doctorControl.ShowServiceList();
                                        break;
                                    case 8:
                                        doctorControl.ProfitInfo();
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 3 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (PatientMenu())
                                {
                                    case 1:
                                        patControl.CreatePatient();
                                        break;
                                    case 2:
                                        patControl.RemovePatient();
                                        break;
                                    case 3:
                                        patControl.EditPatient();
                                        break;
                                    case 4:
                                        patControl.GetPatient();
                                        break;
                                    case 5:
                                        foreach (var item in patControl.GetAllPatients())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 4 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (MedicalServiceMenu())
                                {
                                    case 1:
                                        medControl.CreateMedService();
                                        break;
                                    case 2:
                                        medControl.RemoveMedService();
                                        break;
                                    case 3:
                                        medControl.EditMedService();
                                        break;
                                    case 4:
                                        medControl.GetMedService();
                                        break;
                                    case 5:
                                        foreach (var item in medControl.GetAllService())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 5 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (StaffServiceMenu())
                                {
                                    case 1:
                                        profControl.CreateProfession();
                                        break;
                                    case 2:
                                        profControl.RemoveProfession();
                                        break;
                                    case 3:
                                        profControl.EditStaffService();
                                        break;
                                    case 4:
                                        profControl.GetProfession();
                                        break;
                                    case 5:
                                        foreach (var item in profControl.GetAllProfessions())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 6 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
                                Console.Clear();
                                switch (RegistrationMenu())
                                {
                                    case 1:
                                        regControl.CreateRegistration();
                                        break;
                                    case 2:
                                        regControl.RemoveRegistration();
                                        break;
                                    case 3:
                                        regControl.EditRegistration();
                                        break;
                                    case 4:
                                        regControl.GetRegistration();
                                        break;
                                    case 5:
                                        regControl.GetSpecificRegistration();
                                        break;
                                    case 6:
                                        foreach (var item in regControl.GetAllRegistration())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 7 when role.ToString() == Role.admin.ToString():
                                Console.Clear();
                                switch (UserMenu())
                                {
                                    case 1:
                                        userControl.CreateUser();
                                        break;
                                    case 2:
                                        userControl.RemoveUser();
                                        break;
                                    case 3:
                                        userControl.EditUser();
                                        break;
                                    case 4:
                                        userControl.GetUser();
                                        break;
                                    case 5:
                                        foreach (var item in userControl.GetAllUsers())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;

                            case 1 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (RegistrationMenuForJunior())
                                {
                                    case 1:
                                        regControl.CreateRegistration();
                                        break;
                                    case 2:
                                        regControl.GetRegistration();
                                        break;
                                    case 3:
                                        regControl.GetSpecificRegistration();
                                        break;
                                    case 4:
                                        foreach (var item in regControl.GetAllRegistration())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 2 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (MedicalServiceMenuForJunior())
                                {
                                    case 1:
                                        medControl.GetMedService();
                                        break;
                                    case 2:
                                        foreach (var item in medControl.GetAllService())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 3 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (DoctorMenuForJunior())
                                {
                                    case 1:
                                        doctorControl.GetDoctor();
                                        break;
                                    case 2:
                                        foreach (var item in doctorControl.GetAllDoctor())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 4 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (PatientMenuJunior())
                                {
                                    case 1:
                                        patControl.GetPatient();
                                        break;
                                    case 2:
                                        foreach (var item in patControl.GetAllPatients())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 5 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (StaffMenuJunior())
                                {
                                    case 1:
                                        staffControl.GetStaff();
                                        break;
                                    case 2:
                                        foreach (var item in staffControl.GetAllStaff())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 6 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (StaffServiceMenuForJunior())
                                {
                                    case 1:
                                        profControl.GetProfession();
                                        break;
                                    case 2:
                                        foreach (var item in profControl.GetAllProfessions())
                                            Console.WriteLine(item);
                                        break;
                                    case 0:
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 1 when role.ToString() == Role.doctor.ToString():
                                Console.Clear();
                                regControl.GetSpecificRegistration(); //muveqqeti
                                Console.ReadKey();
                                break;
                            case 2 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                doctorControl.ProfitInfo(); //muveqqeti
                                Console.ReadKey();
                                break;
                            case 0:
                                tester = false;
                                break;
                        }
                    }





                }
            }




            #endregion
        }

    }
}


