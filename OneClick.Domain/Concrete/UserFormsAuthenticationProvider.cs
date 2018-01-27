using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Concrete
{
    public class UserFormsAuthenticationProvider : IUserAuthentication
    {
        private readonly EFDbContext context = new EFDbContext();
        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefault(u => u.UserName == username &&
                                                        u.Password == password);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Logout()
        {
            return true;
        }
    }
}
