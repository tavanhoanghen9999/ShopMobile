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
         Task<string> uploadFilelineproduct(IFormFile file);
         Task<string> uploadFileproduct(IFormFile file);
         Task<string> uploadFilecustomer(IFormFile file);
         Task<string> uploadFilesupplier(IFormFile file);
        void deleteFile(string file);
        Task<string> uploadFile(string picture);

    }
}
