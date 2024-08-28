using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concreates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        private readonly MarketAppContext _context;
        public EfUserDal(MarketAppContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User? Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users.FirstOrDefault(expression);
        }

        public List<User> GetList(Expression<Func<User, bool>> expression = null)
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<User> GetById(int id) 
        {
        
        return _context.Users.Where(x=> x.Id == id).ToList();
        
        }
    }
}
