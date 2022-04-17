using Business.Interfaces;
using DataAcess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public User Create(User user)
        {
            ID.UserID++;
            user.UserId = ID.UserID;
            _userRepository.Create(user);
            return user;
        }

        public User Delete(int id)
        {
            User isExist = _userRepository.GetOne(us => us.UserId == id);
            if (isExist == null)
                return null;
            _userRepository.Delete(isExist);
            return isExist;
        }

        public User Edit(int id, User user)
        {
            User isExist = _userRepository.GetOne(us => us.UserId == id);
            if (isExist == null)
                return null;
            isExist = user;
            _userRepository.Edit(isExist);
            return isExist;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetOne(s => s.UserId == id);
        }
        public User CheckUser(string login, string password,User user)
        {
            return _userRepository.CheckUser(u => user.Login == login && user.Password == password);
        }
    }
}
