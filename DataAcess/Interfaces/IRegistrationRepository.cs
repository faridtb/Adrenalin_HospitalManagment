using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Interfaces
{
    public interface IRegistrationRepository<Registration>
    {
        bool Create(Registration entitiy);
        bool Delete(Registration entitiy);
        bool Edit(Registration entitiy);

        Registration GetOne(Predicate<Registration> filter = null);
        List<Registration> GetAll(Predicate<Registration> filter = null);
    }
}
