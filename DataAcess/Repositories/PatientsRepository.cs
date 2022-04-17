using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class PatientsRepository:IPersonRepository<Patients>
    {
        public bool Create(Patients entitiy)
        {
            try
            {
                DataContext.Patients.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Patients entitiy)
        {
            try
            {
                DataContext.Patients.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Patients entitiy)
        {
            try
            {
                Patients isExist = GetOne(s => s.Name == entitiy.Name);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Patients> GetAll(Predicate<Patients> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Patients :
                    DataContext.Patients.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Patients GetOne(Predicate<Patients> filter = null)
        {
            try
            {
                return filter==null?DataContext.Patients[0]:
                    DataContext.Patients.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
