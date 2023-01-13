using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.JWT
{
    public class TokenOptions
    {  
        public string Audience { get; set; }//Bizim token'ımızın kullanıcı kitlesi
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }//Token gerçerlilik süresi 
        public string SecurityKey { get; set; }
    }
}
