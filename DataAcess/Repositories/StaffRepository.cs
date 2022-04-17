using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class StaffRepository:IPersonRepository<Staff>
    {
        public bool Create(Staff entitiy)
        {
            try
            {
                DataContext.Staffs.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Staff entitiy)
        {
            try
            {
                DataContext.Staffs.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Staff entitiy)
        {
            try
            {
                Staff isExist = GetOne(s => s.Name == entitiy.Name);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Staff> GetAll(Predicate<Staff> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Staffs :
                    DataContext.Staffs.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Staff GetOne(Predicate<Staff> filter = null)
        {
            try
            {
                return filter==null?DataContext.Staffs[0]:
                    DataContext.Staffs.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
