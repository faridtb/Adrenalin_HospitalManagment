using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class PatientService : IPatient
    {
        private PatientsRepository _patientrepository;
        public PatientService()
        {
            _patientrepository = new PatientsRepository();
        }

        public Patients Create(Patients patient)
        {
            ID.personID++;
            patient.personID = ID.personID;
            _patientrepository.Create(patient);
            return patient;
        }

        public Patients Delete(int id)
        {
            Patients isExist = _patientrepository.GetOne(p => p.personID == id);
            if (isExist == null)
                return null;
            _patientrepository.Delete(isExist);
            return isExist;
        }

        public Patients Edit(int id, Patients patient)
        {
            Patients isExist = _patientrepository.GetOne(p => p.personID == id);
            if (isExist == null)
                return null;
            isExist = patient;
            _patientrepository.Edit(isExist);
            return isExist;
        }

        public List<Patients> GetAll()
        {
            return _patientrepository.GetAll();
        }

        public Patients GetPatient(int id)
        {
            return _patientrepository.GetOne(p => p.personID == id);
        }
    }
}
