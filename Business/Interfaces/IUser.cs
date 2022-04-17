using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IUserService
    {
        User Create(User staff);
        User Delete(int id);
        User Edit(int id, User staff);
        List<User> GetAll();
        User GetUser(int id);
    }
}
