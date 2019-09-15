using ModelClassLibrary.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory;
using WebApi.responsitory.impl;

namespace WebApi.service.user.impl
{
    public class UserImlp : Responsitory<Users>, IUser
    {
        public UserImlp(MyDbContext context) : base(context)
        {
        }

        public Users getByUsername(string username)
        {
            return getAll().Where(p=>p.username==username).FirstOrDefault();
        }
    }
}
