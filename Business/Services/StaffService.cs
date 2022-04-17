using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class StaffService : IStaff
    {
        private StaffRepository _staffRepository;
        public StaffService()
        {
            _staffRepository = new StaffRepository();
        }
        public Staff Create(Staff staff)
        {
            ID.personID++;
            staff.personID = ID.personID;
            _staffRepository.Create(staff);
            return staff;
        }
        public Staff Delete(int id)
        {
            Staff isExist = _staffRepository.GetOne(s => s.personID == id);
            if (isExist == null)
                return null;
            _staffRepository.Delete(isExist);
            return isExist;
        }
        public Staff Edit(int id, Staff newStaff)
        {
            Staff isExist = _staffRepository.GetOne(s => s.personID == id);
            if (isExist == null)
                return null;
            isExist = newStaff;
            _staffRepository.Edit(isExist);
            return isExist;
        }
        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }
        public Staff GetStaff(int id)
        {
            return _staffRepository.GetOne(s => s.personID == id);
        }    

    }
}
