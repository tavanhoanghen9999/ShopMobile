using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.img
{
    public interface IImage
    {
         Task<string> uploadFile(IFormFile file);
        void deleteFile(string file);
    }
}
