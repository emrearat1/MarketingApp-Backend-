using Business.Request.UserRequests;
using Core;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        User GetById(Guid id);
        List<User> Getlist();
        bool CreateUser(CreateUserRequest request);
        bool UpdateUser(UpdateUserRequest request);
        bool DeleteUser(DeleteUserRequest request);
        List<User> GetUsers(QueryObject query);
    }
}
