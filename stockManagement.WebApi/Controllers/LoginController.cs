using Microsoft.AspNetCore.Mvc;
using stockManagement.Business.Interfaces;
using stockManagement.Data.Models;

namespace stockManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("seConnecter")]
        public Login SeConnecter([FromBody] Login login)
        {
            Login log = this._loginService.SeConnecter(login); //appel au service 
            return log;
        }
    }
}
