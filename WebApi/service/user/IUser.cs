using ModelClassLibrary.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.responsitory;

namespace WebApi.service.user
{
     public interface IUser
    {
        IEnumerable<Users> getAll();
        void insert(Users user);
        void update(Users user);
        void delete(object id);
        Users getById(object id);
        Users getByUsername(string username);
    }
}
