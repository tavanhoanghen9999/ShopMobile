using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using WebApi.data;
using WebApi.service.admin.customer;
using WebApi.service.admin.customer.impl;
using WebApi.service.admin.order;
using WebApi.service.admin.order.impl;
using WebApi.service.admin.product;
using WebApi.service.admin.product.impl;
using WebApi.service.admin.supplier;
using WebApi.service.admin.supplier.impl;
using WebApi.service.auth;
using WebApi.service.auth.impl;
using WebApi.service.img;
using WebApi.service.img.impl;
using WebApi.service.product;
using WebApi.service.product.impl;

using WebApi.service.user;
using WebApi.service.user.impl;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MyDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataMobile")));
            // Server Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true, // có validate Server tạo JWT không ?
                   ValidateAudience = true,
                   ValidateLifetime = true, //có validate expire time hay không ?
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            //Ifromfile
            //Ifromfile LineProduct
            services.AddSingleton<IFileProvider>(
               new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/lineproduct")));
            //Ifromfile Product
            services.AddSingleton<IFileProvider>(
               new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product")));
            //Ifromfile Customer
            services.AddSingleton<IFileProvider>(
               new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/customer")));
            //Ifromfile Supplier
            services.AddSingleton<IFileProvider>(
               new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/supplier")));


            services.AddScoped<IUser, UserImlp>();// khai bao service
            services.AddScoped<IAuth, AuthImpl>();// khai bao service
            services.AddScoped<ILineProduct, LineProductImpl>();// khai bao service
            services.AddScoped<IProduct, ProductImpl>();// khai bao service
            services.AddScoped<ICustomer, CustomerImpl>();// khai bao service
            services.AddScoped<ISupplier, SupplierImpl>();// khai bao service
            services.AddScoped<IOrder, OrderImpl>();// khai bao service
            services.AddScoped<IDetailOrder, DetailOrderImpl>();// khai bao service
           services.AddTransient<IImage, ImgImpl>();// khai bao service
    


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
