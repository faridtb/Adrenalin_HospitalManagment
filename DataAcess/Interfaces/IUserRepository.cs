using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Interfaces
{
    public interface IUserRepository<T>where T:IUser
    {
        bool Create(User entitiy);
        bool Delete(User entitiy);
        bool Edit(User entitiy);
        List<User> GetAll(Predicate<User> filter = null);
        T GetOne(Predicate<T> filter = null);
    }
}
