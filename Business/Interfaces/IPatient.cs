using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IPatient
    {
        Patients Create(Patients patient);
        Patients Delete(int id);
        Patients Edit(int id, Patients patient);
        Patients GetPatient(int id);
        List<Patients> GetAll();
    }
}
