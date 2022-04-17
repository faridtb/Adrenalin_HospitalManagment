using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IStaff
    {
        Staff Create(Staff staff);
        Staff Delete(int id);
        Staff Edit(int id, Staff staff);
        Staff GetStaff(int id);
        List<Staff> GetAll();
    }
}
