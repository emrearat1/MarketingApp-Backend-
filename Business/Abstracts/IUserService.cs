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
        User GetById(int id);
        List<User> Getlist();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
