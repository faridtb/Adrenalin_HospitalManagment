using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Interfaces
{
    public interface IServiceRepository<T> where T : IProfession
    {
        bool Create(T entitiy);
        bool Delete(T entitiy);
        bool Edit(T entitiy);

        T GetOne(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);



    }
}
