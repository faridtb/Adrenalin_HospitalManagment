using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class RegistrationRepository : IRegistrationRepository<Registration>
    {
        public bool Create(Registration entitiy)
        {
            try
            {
                DataContext.Registrations.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Registration entitiy)
        {
            try
            {
                DataContext.Registrations.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Registration entitiy)
        {
            try
            {
                Registration isExist = GetOne(s => s.RegistrationID == entitiy.RegistrationID);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Registration> GetAll(Predicate<Registration> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Registrations :
                   DataContext.Registrations.FindAll(filter);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Registration GetOne(Predicate<Registration> filter = null)
        {
            try
            {
                return filter==null?DataContext.Registrations[0]:
                    DataContext.Registrations.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
