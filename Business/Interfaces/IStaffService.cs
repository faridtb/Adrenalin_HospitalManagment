using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    interface IStaffService
    {
        Staff_Services Create(Staff_Services staffService);
        Staff_Services Delete(int id);
        Staff_Services Edit(int id, Staff_Services staffService);
        Staff_Services GetStafService(int id);
        List<Staff_Services> GetAll();
    }
}
