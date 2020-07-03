using DAL.Models;
using Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Recordsets
{
    public class UserRec : IUserRec
    {
        private readonly ISqlDataAccess _db;

        public UserRec(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<UserModel> LogOn(string login, string password)
        {
            string encryptedPwd = Utility.Encrypt(password);

            string query = @"select * from [dbo].[USER] 
                             where emailaddress = @Email and password = @Password";

            return _db.SelectOne<UserModel, dynamic>(query, new { Email = login, Password = encryptedPwd });
        }

        public Task<int> RegisterUser(UserModel user)
        {
            user.Password = Utility.Encrypt(user.Password);

            string query = @"insert into [dbo].[USER] (emailaddress, password, nickname)
                             values (@emailaddress, @password, @nickname);
                             select cast(scope_identity() as int)";

            return _db.SaveData<int, UserModel>(query, user);
        }
    }
}
