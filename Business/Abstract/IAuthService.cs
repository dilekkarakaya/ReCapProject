using Core.Security.JWT;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password); //Kayıt operasyonu
        IDataResult<User> Login(UserForLoginDto userForLoginDto);//Giriş operasyonu
        IResult UserExists(string email);//Kullanıcı var mı
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
