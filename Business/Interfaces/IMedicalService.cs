using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IMedicalService
    {
        Medical_Services Create(Medical_Services medicalService);
        Medical_Services Delete(int id);
        Medical_Services Edit(int id, Medical_Services medicalService);
        Medical_Services GetMedicalService(int id);
        List<Medical_Services> GetAll();
    }
}
