using Business.Abstracts;
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

        public void Add(User user)
        {
            //burlarda requestleri business rule ile kontrol et
            User userToAdd = new User
            {
                UserName = user.UserName,
                Password = user.Password,  // Ensure this is hashed if it isn't already
                Wallet = user.Wallet,
                ShoppingCartId = user.ShoppingCartId,
                ShoppingCart = user.ShoppingCart  // Optional, if ShoppingCart is already populated
            };
            _userDal.Add(userToAdd);
        }

        public void Delete(int id)
        {
            //check existance
            User userToDelete = _userDal.Get(f=>f.Id == id);
            _userDal.Delete(userToDelete);
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

        public void Update(User user)
        {
            User userToUpdate = _userDal.Get(x => x.Id ==user.Id);
            userToUpdate.UserName = user.UserName;
            userToUpdate.Password = user.Password;  // Ensure this is hashed if it isn't already
            userToUpdate.Wallet = user.Wallet;
            userToUpdate.ShoppingCartId = user.ShoppingCartId;
            userToUpdate.ShoppingCart = user.ShoppingCart;  // Optional, if ShoppingCart is already populated
            _userDal.Update(userToUpdate);
        }
    }
}
