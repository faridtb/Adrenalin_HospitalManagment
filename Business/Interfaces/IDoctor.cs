using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IDoctor
    {
        Doctor Create(Doctor doctor);
        Doctor Delete(int id);
        Doctor Edit(int id, Doctor newDoctor);
        Doctor GetDoctor(int id);
        List<Doctor> GetAll();

    }
}
