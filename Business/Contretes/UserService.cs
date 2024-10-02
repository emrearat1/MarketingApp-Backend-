using Business.Abstracts;
using Business.Request.UserRequests;
using Core;
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
                /*Password = request.Password,*/  // Ensure this is hashed if it isn't already
                Wallet = request.Wallet,
                
                //ShoppingCartId = request.ShoppingCartId,
                  // Optional, if ShoppingCart is already populated
            };
            ShoppingCart shoppingCart = new ShoppingCart
            {
                /*Products = "",*/ // Initialize with default or empty products
                TotalPrice = 0,
                User = userToAdd, // Link the shopping cart to the user
                UserId = userToAdd.Id,
            };
            userToAdd.ShoppingCarts.Add(shoppingCart);
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

        public User GetById(Guid id)
        {
            User user = _userDal.Get(x=>x.Id == id);
            return user;
        }

        //public List<User> Getlist()
        //{
        //    List<User> users = _userDal.GetList();
        //    return users;
        //}

        public List<User> Getlist()
        {
            return _userDal.GetList();
        }
        public List<T> GetList<T>(QueryObject query, List<T> items, Func<T, bool> searchPredicate)
        {
            if (!string.IsNullOrEmpty(query.SearchKeyword))
            {
                items = items.Where(searchPredicate).ToList();
            }
            return items;
        }


        //public List<User> GetUsers(QueryObject query)
        //    {
        //        // Fetch users from the DAL
        //        List<User> users = _userDal.GetList(); // Assuming _userDal.GetList() returns a List<User>

        //        // Use the generic method to filter users
        //        return GetList<User>(query, users,
        //            u => u.UserName.Contains(query.SearchKeyword, StringComparison.OrdinalIgnoreCase));

        //    }
        public List<User> GetUsers(QueryObject query)
        {
            // Fetch users from the DAL
            List<User> users = _userDal.GetList(); // Assuming _userDal.GetList() returns a List<User>

            // If no search keyword is provided, return all users
            if (string.IsNullOrEmpty(query.SearchKeyword))
            {
                return users;
            }

            // Use the generic method to filter users based on the search keyword
            return GetList<User>(query, users,
                u => u.UserName.ToLower().Contains(query.SearchKeyword.ToLower()));
        }

        public bool UpdateUser(UpdateUserRequest request)
        {
            User userToUpdate = _userDal.Get(x => x.Id == request.Id);
            userToUpdate.UserName = request.UserName;
            /*userToUpdate.Password = request.Password; */ // Ensure this is hashed if it isn't already
            userToUpdate.Wallet = request.Wallet;
            _userDal.Update(userToUpdate);
            return true;
        }
    }
}
