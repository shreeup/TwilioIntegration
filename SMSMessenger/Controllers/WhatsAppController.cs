using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSMessenger.BL.Entities;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;

namespace SMSMessenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        public WhatsAppController(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("sendWhatsApp")]
        public IActionResult SendWhatsApp(WhatsAppMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber("whatsapp:"+model.To),
                from: new PhoneNumber("whatsapp:"+model.From),
                body: model.Message,
                client: _client); // pass in the custom client

            return Ok(message.Sid);
        }

        [HttpPost]
        [Route("getWhatsApp")]
        public IActionResult GetWhatsApp(WhatsAppMessage model)
        {
            var message = new MessagingResponse();
            message.Message("Received your mesage");

            return Ok(message.ToString());
        }
    }
}