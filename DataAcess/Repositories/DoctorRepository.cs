using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAcess.Repositories
{
    public class DoctorRepository : IPersonRepository<Doctor>
    {
        public bool Create(Doctor entitiy)
        {
            try
            {
                DataContext.Doctors.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Doctor entitiy)
        {
            try
            {
                DataContext.Doctors.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Doctor entitiy)
        {
            try
            {
                Doctor isExist = GetOne(s => s.Name == entitiy.Name);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Doctor> GetAll(Predicate<Doctor> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Doctors :
                    DataContext.Doctors.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Doctor GetOne(Predicate<Doctor> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Doctors[0] :
                    DataContext.Doctors.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AddService(Doctor entitiy, Medical_Services med)
        {
            try
            {
                entitiy.services.Add(med);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ShowServiceList(Doctor entitiy)
        {
            foreach (var item in entitiy.services)
                Console.WriteLine(item);
        }
        public void ProfitInfo(List<Doctor> doctors)
        {
            foreach (Doctor item in doctors)
                Console.WriteLine($"Dr.{item.Name} - {item.Profit}azn");
        }
    }
}
