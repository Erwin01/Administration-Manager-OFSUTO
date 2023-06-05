using Microsoft.AspNetCore.Mvc;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Services.Api.Email;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SendMessageController : ControllerBase
    {


        private readonly IEmailSender _emailSender;

        public SendMessageController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

    }
}
