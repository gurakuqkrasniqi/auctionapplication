using AuctionApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Domain.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserLogin(string username, string password);
    }
}
