using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ProfessionService : IStaffService
    {
        private StaffServiceRepository _staffServiceRepository;
        public ProfessionService()
        {
            _staffServiceRepository = new StaffServiceRepository();
        }
        public Staff_Services Create(Staff_Services staffService)
        {
            ID.serviceID++;
            staffService.profID = ID.serviceID;
            _staffServiceRepository.Create(staffService);
            return staffService;
        }

        public Staff_Services Delete(int id)
        {
            Staff_Services isExist = _staffServiceRepository.GetOne(ss => ss.profID == id);
            if (isExist == null)
                return null;
            _staffServiceRepository.Delete(isExist);
            return isExist;
        }

        public Staff_Services Edit(int id, Staff_Services staffService)
        {
            Staff_Services isExist = _staffServiceRepository.GetOne(ss => ss.profID == id);
            if (isExist == null)
                return null;
            isExist = staffService;
            _staffServiceRepository.Edit(isExist);
            return isExist;
        }

        public List<Staff_Services> GetAll()
        {
            return _staffServiceRepository.GetAll();
        }

        public Staff_Services GetStafService(int id)
        {
            return _staffServiceRepository.GetOne(ss => ss.profID == id);
        }
    }
}
