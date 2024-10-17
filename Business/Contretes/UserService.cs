using Business.Abstracts;
using Business.Request.UserRequests;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contretes
{
    public class UserService : IUserService
    {   /*buraya mapper ekle*/

        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool CreateUser(CreateUserRequest request)
        {
            //burlarda requestleri business rule ile kontrol et
            User userToAdd = new User
            {
                UserName = request.UserName,
                Password = request.Password,  // Ensure this is hashed if it isn't already
                Wallet = request.Wallet,
                //ShoppingCartId = request.ShoppingCartId,
                  // Optional, if ShoppingCart is already populated
            };
            _userDal.Add(userToAdd);
            return true;
        }

        public bool DeleteUser(DeleteUserRequest request)
        {
            //check existance
            User userToDelete = _userDal.Get(f=>f.Id == request.Id);
            _userDal.Delete(userToDelete);
            return true;
        }

        public User GetById(int id)
        {
            User user = _userDal.Get(x=>x.Id == id);
            return user;
        }

        public List<User> Getlist()
        {
            List<User> users = _userDal.GetList();
            return users;
        }

       
        public bool UpdateUser(UpdateUserRequest request)
        {
            User userToUpdate = _userDal.Get(x => x.Id == request.Id);
            userToUpdate.UserName = request.UserName;
            userToUpdate.Password = request.Password;  // Ensure this is hashed if it isn't already
            userToUpdate.Wallet = request.Wallet;
            _userDal.Update(userToUpdate);
            return true;
        }
    }
}
