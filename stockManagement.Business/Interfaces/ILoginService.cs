using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Business.Interfaces
{
    public interface ILoginService
    {
        Login SeConnecter(Login login);
    }
}
