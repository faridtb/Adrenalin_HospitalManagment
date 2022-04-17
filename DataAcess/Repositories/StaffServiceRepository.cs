using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class StaffServiceRepository : IServiceRepository<Staff_Services>
    {
        public bool Create(Staff_Services entitiy)
        {
            try
            {
                DataContext.StaffServices.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Staff_Services entitiy)
        {
            try
            {
                DataContext.StaffServices.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Staff_Services entitiy)
        {
            try
            {
                Staff_Services isExist = GetOne(s => s.Name == entitiy.Name);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Staff_Services> GetAll(Predicate<Staff_Services> filter = null)
        {
            try
            {
                return filter == null ? DataContext.StaffServices :
                    DataContext.StaffServices.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Staff_Services GetOne(Predicate<Staff_Services> filter = null)
        {
            try
            {
                return filter ==null?DataContext.StaffServices[0]:
                    DataContext.StaffServices.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
