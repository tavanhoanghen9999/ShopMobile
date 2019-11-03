using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ifromfile;
using WebApi.responsitory.impl;

namespace WebApi.service.img.impl
{
    public class ImgImpl:IImage
    {
      
        private IHostingEnvironment m_hostingEnvironment;
        public ImgImpl(IHostingEnvironment hostingEnvironment)
        {
            m_hostingEnvironment = hostingEnvironment;
        }
        //file loai
        public async Task<string> uploadFilelineproduct(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";
            var temp = file.GetFilename().Split(".");
            var nameimgmain = RandomString(10) + "." + temp[1];
            var fpath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/lineproduct",
                        nameimgmain);//post image to forder 
            using (var stream = new FileStream(fpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return nameimgmain;
        }
        //file san pham
        public async Task<string> uploadFileproduct(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";
            var temp = file.GetFilename().Split(".");
            var nameimgmain = RandomString(10) + "." + temp[1];
            var fpath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/product",
                        nameimgmain);//post image to forder 
            using (var stream = new FileStream(fpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return nameimgmain;
        }
        //file san pham
        public async Task<string> uploadFilecustomer(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";
            var temp = file.GetFilename().Split(".");
            var nameimgmain = RandomString(10) + "." + temp[1];
            var fpath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/customer",
                        nameimgmain);//post image to forder 
            using (var stream = new FileStream(fpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return nameimgmain;
        }
        //file san pham
        public async Task<string> uploadFilesupplier(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";
            var temp = file.GetFilename().Split(".");
            var nameimgmain = RandomString(10) + "." + temp[1];
            var fpath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/supplier",
                        nameimgmain);//post image to forder 
            using (var stream = new FileStream(fpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return nameimgmain;
        }
        public async Task<string> uploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";
            var temp = file.GetFilename().Split(".");
            var nameimgmain = RandomString(10) + "." + temp[1];
            var fpath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/",
                        nameimgmain);//post image to forder 
            using (var stream = new FileStream(fpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return nameimgmain;
        }
        public void deleteFile(string file)
        {
            //delete old picture
            try
            {
                string webRootPath = m_hostingEnvironment.WebRootPath;
                string contentRootPath = m_hostingEnvironment.ContentRootPath;
                var file1 = System.IO.Path.Combine(webRootPath, "img/" + file);
                System.IO.File.Delete(file1);//delete in forder
            }
            catch
            {
            }
        }
        public void deleteFileLineProduct(string file)
        {
            //delete old picture
            try
            {
                string webRootPath = m_hostingEnvironment.WebRootPath;
                string contentRootPath = m_hostingEnvironment.ContentRootPath;
                var file1 = System.IO.Path.Combine(webRootPath, "img/lineproduct" + file);
                System.IO.File.Delete(file1);//delete in forder
            }
            catch
            {
            }
        }

        //delete product
        public void deleteFileProduct(string file)
        {
            //delete old picture
            try
            {
                string webRootPath = m_hostingEnvironment.WebRootPath;
                string contentRootPath = m_hostingEnvironment.ContentRootPath;
                var file1 = System.IO.Path.Combine(webRootPath, "img/product" + file);
                System.IO.File.Delete(file1);//delete in forder
            }
            catch
            {
            }
        }
        //delete customer
        public void deleteFilerCustomer(string file)
        {
            //delete old picture
            try
            {
                string webRootPath = m_hostingEnvironment.WebRootPath;
                string contentRootPath = m_hostingEnvironment.ContentRootPath;
                var file1 = System.IO.Path.Combine(webRootPath, "img/customer" + file);
                System.IO.File.Delete(file1);//delete in forder
            }
            catch
            {
            }
        }
        //delete supplier
        public void deleteFilerSupplier(string file)
        {
            //delete old picture
            try
            {
                string webRootPath = m_hostingEnvironment.WebRootPath;
                string contentRootPath = m_hostingEnvironment.ContentRootPath;
                var file1 = System.IO.Path.Combine(webRootPath, "img/supplier" + file);
                System.IO.File.Delete(file1);//delete in forder
            }
            catch
            {
            }
        }

        //random image 
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghiklmnopqrstwz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Task<string> uploadFile(string picture)
        {
            throw new NotImplementedException();
        }
    }
}
