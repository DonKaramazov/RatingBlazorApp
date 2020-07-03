using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Recordsets
{
    public interface IUserRec
    {
        Task<int> RegisterUser(UserModel user);

        Task<UserModel> LogOn(string login, string password);
    }
}
