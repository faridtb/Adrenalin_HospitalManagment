using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class RegistrationService : IRegistration
    {
        private RegistrationRepository _registrationService;
        public RegistrationService()
        {
            _registrationService = new RegistrationRepository();
        }
        public Registration Create(Registration registration)
        {
            ID.RegistrationID++;
            registration.RegistrationID = ID.RegistrationID;
            _registrationService.Create(registration);
            return registration;
        }

        public Registration Delete(int id)
        {
            Registration isExist = _registrationService.GetOne(r => r.RegistrationID == id);
            if (isExist == null)
                return null;
            _registrationService.Delete(isExist);
            return isExist;
        }

        public Registration Edit(int id, Registration newRegistration)
        {
            Registration isExist = _registrationService.GetOne(r => r.RegistrationID == id);
            if (isExist == null)
                return null;
            isExist = newRegistration;
            _registrationService.Edit(isExist);
            return isExist;
        }

        public List<Registration> GetAll()
        {
            return _registrationService.GetAll();
        }

        public Registration GetRegistration(int id)
        {
            return _registrationService.GetOne(r => r.RegistrationID == id);
        }
    }
}
