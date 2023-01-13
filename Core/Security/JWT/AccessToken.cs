using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.JWT
{
    public class AccessToken
    {   //AccesToken nesnelerim
        public string Token { get; set; }//giriş yapan kullanıcıya vereceğim token 
        public DateTime Expiration { get; set; }// kullanıcının token süresinin geçerliliği
    }
}
