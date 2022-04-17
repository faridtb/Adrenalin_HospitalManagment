using DataAcess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        public bool Create(User entitiy)
        {
            try
            {
                DataContext.Users.Add(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(User entitiy)
        {
            try
            {
                DataContext.Users.Remove(entitiy);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(User entitiy)
        {
            try
            {
                User isExist = GetOne(s => s.Login == entitiy.Login);
                isExist = entitiy;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAll(Predicate<User> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Users :
                    DataContext.Users.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetOne(Predicate<User> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Users[0] :
                    DataContext.Users.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User CheckUser(Predicate<User> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Users[0] :
                    DataContext.Users.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

