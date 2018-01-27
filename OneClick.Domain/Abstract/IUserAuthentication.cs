using OneClick.Domain._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Abstract
{
    public interface IUserAuthentication
    {
        bool Authenticate(string username, string password);
        bool Logout();

    }
}