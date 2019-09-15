using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelClassLibrary.data;
using ModelClassLibrary.respond;
using WebApi.service.user;

namespace WebApi.service.auth.impl
{
    public class AuthImpl : IAuth
    {
        private readonly IConfiguration m_config;
        public IUser m_user;
        
        public AuthImpl(IUser user, IConfiguration config)
        {
            m_user = user;
            m_config = config;
        }
        public DataRespond login(Auth auth)
        {
            DataRespond data = new DataRespond();
            var user = m_user.getByUsername(auth.username);
            if (user == null)
            {
                data.success = false;
                data.messger = "taif khoan khong ton tai";

            }
            else
            {
                if (user.password == auth.password)
                {
                    data.success = true;
                    data.messger = "dang nhap thanh cong";
                    data.data = new { toke = BuildToken(user), id = user.userid };//tra ve ma token
                }
            }
                


            return data;

        }
        private string BuildToken(Users user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.username),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,user.roleid.ToString())//check quyen
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(m_config["Jwt:Issuer"],
                m_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(1), //expire time là 30 phút
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DataRespond login()
        {
            throw new NotImplementedException();
        }
    }
}
