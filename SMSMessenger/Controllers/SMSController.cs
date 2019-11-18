using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSMessenger.BL.Entities;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSMessenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        public SMSController(ITwilioRestClient client)
        {
            _client = client;
        }

        public ActionResult Index()
        {
            Console.Write("frominde");
            return new EmptyResult();
        }

        [HttpPost]
        [Route("sendSMS")]
        public IActionResult SendSMS(SMSMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: _client); // pass in the custom client

            return Ok(message.Sid);
        }

        
    }
}