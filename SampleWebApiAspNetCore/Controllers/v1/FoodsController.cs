using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.Services;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using System.Text.Json;
using SampleWebApiAspNetCore.Converters;
using Microsoft.Extensions.WebEncoders.Testing;
using DigitalWorldOnline.Application.Separar.Queries;
using MediatR;
using SampleWebApiAspNetCore.Enums;
using DigitalWorldOnline.Application.Admin.Queries;
using RtspClientSharp;

namespace SampleWebApiAspNetCore.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public AccountController(
         ISender sender, IMapper mapper)
        {

            _sender = sender;
            _mapper = mapper;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [HttpPost("AccountInfo")]
        public async Task<IActionResult> AccountInfoRequest([FromBody] AccountInfo requestModel)
        {
            var account = new AccountInfo(requestModel.Email.Encrypt(), requestModel.Password.Encrypt());
            var accountModel = _mapper.Map<AccountModel>(await _sender.Send(new AccountByUsernameQuery(account.Email, account.Password)));

            if (accountModel == null)
            {
                return NotFound((int)ErrorTypeEnum.Email);
            }
            else if (string.IsNullOrEmpty(accountModel.Password))
            {
                return NotFound((int)ErrorTypeEnum.Password);
            }

            return Ok(accountModel.Id);
        }

        [HttpGet("AlertsInfo")]
        public async Task<IActionResult> AlertsInfoRequest(int AccountId)
        {

            var result = await _sender.Send(new GetPlaceAlertsByIdQuery((long)AccountId));

            if (result.Places == null)
            {
                return NotFound();
            }


            return Ok(result.Places);
        }

        [HttpGet("CheckRTSP")]
        public async Task<IActionResult> CheckRTSP(string url)
        {
            var connectionParameters = new ConnectionParameters(new Uri(url));
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            try
            {
                using (var rtspClient = new RtspClient(connectionParameters))
                {

                    rtspClient.FrameReceived += (sender, e) =>
                    { 
                    };

                    await rtspClient.ConnectAsync(cancellationToken);
                    rtspClient.Dispose();

                    return Ok();
                }
            }      
            catch (Exception ex)
            {
                return NotFound();
            }

        }
    }
}
