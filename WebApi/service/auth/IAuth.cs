using ModelClassLibrary.data;
using ModelClassLibrary.respond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.auth
{
   public interface IAuth
    {
        DataRespond login(Auth auth);

    }
}
