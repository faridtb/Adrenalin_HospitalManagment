using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class DoctorService : IDoctor
    {
        private DoctorRepository _doctorRepository;
        public DoctorService ()
        {
            _doctorRepository = new DoctorRepository();
        }
        public Doctor Create(Doctor doctor)
        {
            ID.personID++;
            doctor.personID = ID.personID;
            _doctorRepository.Create(doctor);
            return doctor;
        }
        public Doctor Delete(int id)
        {
            Doctor isExist = _doctorRepository.GetOne(d => d.personID == id);
            if (isExist == null)
                return null;
            _doctorRepository.Delete(isExist);
            return isExist;
        }

        public Doctor Edit(int id, Doctor newDoctor)
        {
            Doctor isExist = _doctorRepository.GetOne(d => d.personID == id);
            if (isExist == null)
                return null;
            isExist = newDoctor;
            _doctorRepository.Edit(isExist);
            return isExist;
        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctor(int id)
        {
            return _doctorRepository.GetOne(d=>d.personID==id);
        }
        public Doctor AddService(Medical_Services med,int id)
        {
            Doctor doctorExist = _doctorRepository.GetOne(d => d.personID == id);
            if (doctorExist == null)
                return null;
            _doctorRepository.AddService(doctorExist, med);

            return doctorExist;
        }
        public void ShowServiceList(Doctor doctor)
        {
            _doctorRepository.ShowServiceList(doctor);
        }
        public void ProfitInfo(List<Doctor> doctors)
        {
            _doctorRepository.ProfitInfo(doctors);
        }



    }
}
