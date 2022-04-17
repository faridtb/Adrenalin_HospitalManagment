using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class MedicalServiceRepository:IServiceRepository<Medical_Services>
    {
        public bool Create(Medical_Services entitiy)
        {
            try
            {
                DataContext.MedicalServices.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Medical_Services entitiy)
        {
            try
            {
                DataContext.MedicalServices.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(Medical_Services entitiy)
        {
            try
            {
                Medical_Services isExist = GetOne(s => s.Name == entitiy.Name);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medical_Services> GetAll(Predicate<Medical_Services> filter = null)
        {
            try
            {
                return filter == null ? DataContext.MedicalServices :
                    DataContext.MedicalServices.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Medical_Services GetOne(Predicate<Medical_Services> filter = null)
        {
            try
            {
                return filter==null?DataContext.MedicalServices[0]:
                    DataContext.MedicalServices.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
