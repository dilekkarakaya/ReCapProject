using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Encryption
{
    public class SigningCredentialsHelper
    {//security key ve algoritmamı belirlediğim nesnem
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//Şifrelenmiş kimliği oluşturuyoruz.
        }
    }
}
