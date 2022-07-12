using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Model
{
    public interface IAuthManager
    {
        AuthToken Authenticate(string username, string password);
    }
}
