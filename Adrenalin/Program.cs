using Adrenalin.Controller;
using Entities.Models;
using System;
using static Utilities.Notifications;
using static Utilities.Menu;

namespace Adrenalin
{
    public class Program
    {
        #region Testler
        #region Klasslarin islemesi (test1)
        //Staff_Services sts1 = new Staff_Services();
        //sts1.Name = "Admistravie affair";

        //Staff stf1 = new Staff();
        //stf1.Name = "Ferid";
        //stf1.Surname = "Baliyev";
        //stf1.Age = 25;
        //stf1.service = sts1;
        //Console.WriteLine("\n"+stf1);

        //Medical_Services med1 = new Medical_Services();
        //med1.Name = "Umumi Cerrah";
        //Medical_Services med2 = new Medical_Services();
        //med2.Name = "Nefrektomiya";
        //Medical_Services med3 = new Medical_Services();
        //med3.Name = "Qasiq yirtigi";

        //Doctors dc1 = new Doctors();
        //dc1.Name = "Prof.Sefer";
        //dc1.Surname = "Hemidov";
        //dc1.Age = 58;
        //dc1.services.Add(med1);
        //dc1.services.Add(med2);
        //dc1.services.Add(med3);
        //Console.WriteLine(dc1);
        //for (int i = 0; i < dc1.services.Count; i++)
        //{
        //    Console.WriteLine($"{i+1}) {dc1.services[i]}");
        //}






        #endregion
        #region Test-2: Doctor servis elaqesi (ok)
        //DoctorService doctorService = new DoctorService();

        //Notifications.Alert(ConsoleColor.Yellow, "Welcome!");
        //Console.WriteLine("Hekim yaratmaq ucun 1 duymesini secin");
        //int input=Notifications.TryParse();
        //Console.Write("Ad daxil edin:");
        //string name = Console.ReadLine();
        //Console.Write("Soyadi daxil edin:");
        //string surname = Console.ReadLine();
        //Console.Write("Yas daxil edin:");
        //int age=Notifications.TryParse();


        //Doctor doc1 = new Doctor()
        //{
        //    Name = name,
        //    Surname = surname,
        //    Age = age,              
        //};
        //doctorService.Create(doc1);



        //foreach (var item in DataContext.Doctors)
        //{
        //    Console.WriteLine(item);
        //}

        //Medical_Services med1 = new Medical_Services();
        //med1.Name = "Umumi Cerrah";
        //Medical_Services med2 = new Medical_Services();
        //med2.Name = "Nefrektomiya";
        //Medical_Services med3 = new Medical_Services();
        //med3.Name = "Qasiq yirtigi";

        //Console.WriteLine("Actardigin hekimin adin yaz");
        //string name2 = Console.ReadLine();
        //Doctor isexist= DataContext.Doctors.Find(s => s.Name == name2);
        //isexist.services.Add(med1);
        //isexist.services.Add(med2);
        //isexist.services.Add(med3);

        //foreach (var item in isexist.services)
        //{
        //    Console.WriteLine(item);
        //}

        //foreach (var item in DataContext.Doctors)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion
        #region Test-2 Doctor servis elaqesi(servis uzerinden)
        //DoctorService doctorService = new DoctorService();
        //StaffService staffservice = new StaffService();
        //PatientService patientService = new PatientService();
        //Medical_Services med1 = new Medical_Services();
        //med1.Name = "Umumi Cerrah";
        //Medical_Services med2 = new Medical_Services();
        //med2.Name = "Nefrektomiya";
        //Medical_Services med3 = new Medical_Services();
        //med3.Name = "Qasiq yirtigi";




        //while (true)
        //{
        //    Console.WriteLine("1)Create Doctor\n" +
        //  "2)Add Service To Doctor\n" +
        //  "3)Doktorlarin siyahisi\n" +
        //  "4)Create Staff\n" +
        //  "5)Create Patient\n" +
        //  "6)Staf heyeti\n" +
        //  "7)Pasientler bazasi");
        //    int input = Notifications.TryParse();
        //    switch (input)
        //    {
        //        case 1:
        //            Console.WriteLine("Adi daxil edin");
        //            string name = Console.ReadLine();
        //            Console.Write("Soyadi daxil edin:");
        //            string surname = Console.ReadLine();
        //            Console.Write("Yas daxil edin:");
        //            int age = Notifications.TryParse();
        //            Doctor doc1 = new Doctor()
        //            {
        //                Name = name,
        //                Surname = surname,
        //                Age = age,
        //            };
        //            doctorService.Create(doc1);
        //            break;
        //        case 2:
        //            int id = Notifications.TryParse();
        //            doctorService.AddService(med1, id);
        //            doctorService.AddService(med2, id);
        //            doctorService.AddService(med3, id);
        //            break;
        //        case 3:
        //            foreach (var item in DataContext.Doctors)
        //            {
        //                Console.WriteLine(item);
        //                foreach (var jitem in item.services)
        //                {
        //                    Console.WriteLine(jitem);
        //                }
        //            }
        //            break;
        //        case 4:
        //            Console.WriteLine("Adi daxil edin");
        //            string name1 = Console.ReadLine();
        //            Console.Write("Soyadi daxil edin:");
        //            string surname1 = Console.ReadLine();
        //            Console.Write("Yas daxil edin:");
        //            int age1 = Notifications.TryParse();
        //            Staff stf1 = new Staff() { Name = name1, Surname = surname1, Age = age1 };
        //            staffservice.Create(stf1);

        //            break;
        //        case 5:
        //            Console.WriteLine("Adi daxil edin");
        //            string name2 = Console.ReadLine();
        //            Console.Write("Soyadi daxil edin:");
        //            string surname2 = Console.ReadLine();
        //            Console.Write("Yas daxil edin:");
        //            int age2 = Notifications.TryParse();
        //            Patients pat2 = new Patients() { Name = name2, Surname = surname2, Age = age2 };
        //            patientService.Create(pat2);
        //            break;
        //        case 6:
        //            foreach (var item in DataContext.Staffs)
        //            {
        //                Console.WriteLine(item);

        //            }
        //            break;
        //        case 7:
        //            foreach (var item in DataContext.Patients)
        //            {
        //                Console.WriteLine(item);

        //            }break;
        //        default:
        //            break;
        //    }

        #endregion
        #endregion

        static void Main(string[] args)
        {
            UserController userControl = new UserController();
            StaffController staffControl = new StaffController();
            DoctorController doctorControl = new DoctorController();
            PatientController patControl = new PatientController();
            MedicalServiceController medControl = new MedicalServiceController();
            StaffServiceController profControl = new StaffServiceController();
            RegistrationController regControl = new RegistrationController();

            User user = userControl.CreateUser();
            Console.WriteLine("Press Any Key to Continue ....");
            Console.ReadLine();
            bool tester = false;
            int input = 1;
            #region Entry
            while (tester == false)
            {
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

                if (userControl.CheckUser(login, paswword))
                {
                    Console.Clear();
                    tester = true;
                    role = user.Role;
                    if (role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString())
                        input = MainMenu();
                    if (role.ToString() == Role.staff.ToString())
                        input = MainMenuJunior();
                    while (input != 0)
                    {
                        switch (input)
                        {
                            case 1 when role.ToString() == Role.admin.ToString():
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
                                        userControl.GetAllUsers();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 2 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        staffControl.GetAllStaff();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 3 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        doctorControl.GetAllDoctor();
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
                                break;
                            case 4 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        patControl.GetAllPatients();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 5 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        medControl.GetAllService();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 6 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        profControl.GetAllProfessions();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 7 when role.ToString() == Role.admin.ToString() || role.ToString() == Role.director.ToString():
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
                                        regControl.GetAllRegistration();
                                        break;
                                    case 0:
                                        break;
                                }
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
                                        regControl.GetAllRegistration();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 2 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (MedicalServiceMenuForJunior())
                                {
                                    case 1:
                                        medControl.GetMedService();
                                        break;
                                    case 2:
                                        medControl.GetAllService();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 3 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (DoctorMenuForJunior())
                                {
                                    case 1:
                                        doctorControl.GetDoctor();
                                        break;
                                    case 2:
                                        doctorControl.GetAllDoctor();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 4 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (PatientMenuJunior())
                                {
                                    case 1:
                                        patControl.GetPatient();
                                        break;
                                    case 2:
                                        patControl.GetAllPatients();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 5 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (StaffMenuJunior())
                                {
                                    case 1:
                                        staffControl.GetStaff();
                                        break;
                                    case 2:
                                        staffControl.GetAllStaff();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 6 when role.ToString() == Role.staff.ToString():
                                Console.Clear();
                                switch (StaffServiceMenuForJunior())
                                {
                                    case 1:
                                        profControl.GetProfession();
                                        break;
                                    case 2:
                                        profControl.GetAllProfessions();
                                        break;
                                    case 0:
                                        break;
                                }
                                break;
                            case 0:
                                break;
                        }
                    }





                }
            }




            #endregion
        }

    }
}


