using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmtpWebService.Domain.Models;
using SmtpWebService.Domain.Services;

namespace SmtpWebService.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Smtp")]
    public class SendMailController : Controller
    {
        private readonly IMailService _mailService;

        public SendMailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// Repository pages
        /// </summary>        
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("send_mail")]
        public async Task<IActionResult> SendMail(MessageSetting message, MailSetting mail) =>
            await (await _mailService.SmtpSendEmailAsync(message, mail))
                .MatchAsync<IActionResult>(
                    async o => {
                        return await Task.FromResult(new OkObjectResult(o));
                    },
                    async ex => {
                        return await Task.FromResult(new BadRequestObjectResult(ex.GetType().Name));
                    });
    }
}