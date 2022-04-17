using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class MedicalService : IMedicalService
    {
        private MedicalServiceRepository _medicalServiceRepository;
        public MedicalService()
        {
            _medicalServiceRepository = new MedicalServiceRepository();
        }
        public Medical_Services Create(Medical_Services medicalService)
        {
            ID.serviceID++;
            medicalService.profID = ID.serviceID;
            _medicalServiceRepository.Create(medicalService);
            return medicalService;
        }

        public Medical_Services Delete(int id)
        {
            Medical_Services isExist = _medicalServiceRepository.GetOne(ms => ms.profID == id);
            if (isExist == null)
                return null;
            _medicalServiceRepository.Delete(isExist);
            return isExist;
        }

        public Medical_Services Edit(int id, Medical_Services medicalService)
        {
            Medical_Services isExist = _medicalServiceRepository.GetOne(ms => ms.profID == id);
            if (isExist == null)
                return null;
            isExist = medicalService;
            _medicalServiceRepository.Edit(isExist);
            return isExist;
        }

        public List<Medical_Services> GetAll()
        {
            return _medicalServiceRepository.GetAll();
        }

        public Medical_Services GetMedicalService(int id)
        {
            return _medicalServiceRepository.GetOne(ms => ms.profID == id);
        }
    }
}
