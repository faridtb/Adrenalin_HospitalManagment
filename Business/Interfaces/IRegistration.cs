using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IRegistration
    {
        Registration Create(Registration doctor);
        Registration Delete(int id);
        Registration Edit(int id, Registration newRegistration);
        Registration GetRegistration(int id);
        List<Registration> GetAll();
    }
}
