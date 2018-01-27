using OneClick.Domain._Entities;
using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        IEnumerable<User> IUserRepository.users
        {
            get { return context.Users; }

        }

        public void saveUser(User users)
        {
            if (users.UserId == 0)
            {
                context.Users.Add(users);
            }
            else
            {
                User dbEntry = context.Users.Find(users.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserName = users.UserName;
                    dbEntry.Password = users.Password;
                    dbEntry.Email = users.Email;
                    dbEntry.College = users.College;
                    dbEntry.PhoneNo = users.PhoneNo;
                    dbEntry.Department = users.Department;
                    dbEntry.Semester = users.Semester;
                }
            }
            context.SaveChanges();
        }
    }
}
