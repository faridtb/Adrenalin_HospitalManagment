using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using static Utilities.Notifications;

namespace Adrenalin.Controller
{
    public class RegistrationController
    {
        Patients pat = new Patients();
        Doctor doc = new Doctor();
        Medical_Services med = new Medical_Services();
        Registration registration;
        PatientController patControl = new PatientController();
        DoctorController docControl = new DoctorController();
        MedicalServiceController medControl = new MedicalServiceController();
        RegistrationService registrationService = new RegistrationService();
        public int choice = 0;

        public void CreateRegistration()
        {
            Alert(ConsoleColor.DarkMagenta, "\n----------------------\n" +
                "New Registration Panel\n" +
                "----------------------");
            int counter = 0;
            int counter1 = 0;
            int counter2 = 0;
            foreach (var item in patControl.GetAllPatients())
                Console.WriteLine(item);

            pat = patControl.GetPatient();
            while (pat is null && patControl.choice != 1)
            {
                counter++;
                Alert(ConsoleColor.DarkRed, "We cant found any patient in our base");
                Alert(ConsoleColor.Yellow, "-Press 1 for create new patient");
                Alert(ConsoleColor.White, "-Press any number for try again");
                int choice = TryParse();
                if (choice == 1)
                    pat = patControl.CreatePatient();
                if (counter > 1 && pat is null)
                    Alert(ConsoleColor.Green, $"--Advice--\n" +
                        $" You must Create new Patient another try ");
                pat = patControl.GetPatient();
            }
            if (!(pat is null))
            {
                foreach (var item in medControl.GetAllService())
                    Console.WriteLine(item);      
                med = medControl.GetMedService();
            }
            while (!(pat is null) && med is null && medControl.choice != 1)
            {
                counter1++;
                Alert(ConsoleColor.Red, $"There is not any Service in that id !");
                if (med is null && counter1 > 2)
                {
                    Alert(ConsoleColor.Yellow, $"--Advice--\n" +
                    $" You must Talk your seniors to create new service ");
                    return;
                }
                med = medControl.GetMedService();
            }
            if (!(pat is null) && !(med is null))
            {
                Alert(ConsoleColor.Yellow, $"\n{med.Name} - medical service is provided by the following doctors");
                List<Doctor> doctors = docControl.GetAllDoctor().FindAll(i => i.services.Contains(med));
                foreach (var item in doctors)
                    Alert(ConsoleColor.Blue, $"{item}");
                Alert(ConsoleColor.Yellow, $"Please Choose one of them");
                int id = TryParse();
                doc = doctors.Find(i => i.personID == id);
            }
            while (!(pat is null) && !(med is null) && doc is null && docControl.choice != 1)
            {
                counter2++;
                if (doc is null && counter2 > 2)
                {
                    Alert(ConsoleColor.Yellow, $"--Advice--\n" +
                    $" You must Talk your seniors to create new doctor ");
                    return;
                }
                doc = docControl.GetDoctor();
            }
            if (!(med is null) && !(doc is null) && !(pat is null))
            {
                registration = new Registration()
                {
                    Doctor = this.doc,
                    MedicalService = this.med,
                    Patients = this.pat,
                    Profit = med.ServiceFee * 0.6
                };
                doc.Profit = med.ServiceFee * 0.4;
                registrationService.Create(registration);
                Alert(ConsoleColor.Green, "Registration added succesfully !");
            }
            else
                Alert(ConsoleColor.Red, "Registration Creation Fail !");

        }
        public Registration GetRegistration()
        {
            choice = 0;
            Alert(ConsoleColor.Blue, "Enter the Id of which Registration you want");
            int id = TryParse();
            registration = registrationService.GetRegistration(id);
            while (registration is null && choice != 1)
            {
                Alert(ConsoleColor.Red, "There is not any Registrations in that id");
                choice = BackContinue();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        registration = GetRegistration();
                        break;
                }
            }
            if (!(registration is null))
                Console.WriteLine(registration);
            return registration;
        }
        public void RemoveRegistration() 
        {
            foreach (var item in GetAllRegistration())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkRed, "Deletion of Registration");
            registration = GetRegistration();
            if (!(registration is null))
            {
                registration = registrationService.Delete(registration.RegistrationID);
                Alert(ConsoleColor.DarkYellow, $"{registration} was deleted.");
            }
            else
                Alert(ConsoleColor.Red, "Deletion Failed!");
        }
        public List<Registration> GetAllRegistration()
        {
            Alert(ConsoleColor.DarkCyan, "All Registrations\n");
            return registrationService.GetAll();
        }
        public List<Registration> GetSpecificRegistration()
        {
            List<Registration> reg = new List<Registration>();
            Alert(ConsoleColor.Yellow, "Which category do you search BY\n" +
                "1)Medical Service\n" +
                "2)Patient\n" +
                "3)Doctor\n");
            int input = TryParse();
            switch (input)
            {
                case 1:
                    med = medControl.GetMedService();
                    reg = GetAllRegistration().FindAll(i => i.MedicalService == med);
                    break;
                case 2:
                    pat = patControl.GetPatient();
                    reg = GetAllRegistration().FindAll(i => i.Patients == pat);
                    break;
                case 3:
                    doc = docControl.GetDoctor();
                    reg = GetAllRegistration().FindAll(i => i.Doctor == doc);
                    break;
            }
            return reg;
        }
        public void EditRegistration()
        {
            foreach (var item in GetAllRegistration())
                Console.WriteLine(item);
            Alert(ConsoleColor.DarkYellow, "Registration Editing\n");
            registration = GetRegistration();
            if (!(registration is null))
            {
                Alert(ConsoleColor.Yellow, "Which category do you want to change ?\n" +
                    "1)Medical Service\n" +
                    "2)Patient\n" +
                    "3)Doctor\n");
                int input = TryParse();
                switch (input)
                {
                    case 1:
                        Alert(ConsoleColor.DarkRed, "Medical Service changing");
                        registration = GetRegistration();
                        registration.MedicalService = medControl.GetMedService();
                        registrationService.Edit(registration.RegistrationID, registration);
                        break;
                    case 2:
                        Alert(ConsoleColor.DarkCyan, "Patient changing");
                        registration = GetRegistration();
                        registration.Patients = patControl.GetPatient();
                        registrationService.Edit(registration.RegistrationID, registration);
                        break;
                    case 3:
                        Alert(ConsoleColor.Blue, "Doctor Changing");
                        registration = GetRegistration();
                        registration.Doctor = docControl.GetDoctor();
                        registrationService.Edit(registration.RegistrationID, registration);
                        break;
                    default:
                        Alert(ConsoleColor.Red, "Write the number which is valid for menu!");
                        break;
                }
            }
        }

    }
}
