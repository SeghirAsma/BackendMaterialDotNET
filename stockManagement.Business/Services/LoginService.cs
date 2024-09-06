using stockManagement.Business.Interfaces;
using stockManagement.Data;
using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stockManagement.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly DBContextManagementStock _dbContext;
        public LoginService(DBContextManagementStock dbContext)
        {
            _dbContext = dbContext;
        }

        public Login SeConnecter(Login login)
        {
            try
            {
                Login find = null;
                if (login != null)
                {
                    find = this._dbContext.Login.AsQueryable().FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
                }
                return find;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
