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
    public class AccountController : BaseController
    {

        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(
         ISender sender, IMapper mapper, IConfiguration configuration)
        {

            _sender = sender;
            _mapper = mapper;
            _configuration = configuration;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [HttpPost("AccountInfo")]
        public async Task<IActionResult> AccountInfoRequest([FromBody] AccountInfo requestModel)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }

            var account = new AccountInfo(requestModel.Email, requestModel.Password);
            account.Encrypt();

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
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }
            var result = await _sender.Send(new GetPlaceAlertsByIdQuery((long)AccountId));

            if (result.Places == null)
            {
                return NotFound();
            }


            return Ok(result.Places);
        }

        [HttpPost("AddAlert")]
        public async Task<IActionResult> AddAlert(int AccountId, [FromBody] PlaceAlertsModel Place)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }
            try
            {

                await _sender.Send(new CreatePlaceAlertByIdQuery((long)AccountId, Place));
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("CheckRTSP")]
        public async Task<IActionResult> CheckRTSP(string url)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }
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

        [HttpPost("ChangeEmail")]
        public async Task<IActionResult> AccountChangeEmailById([FromBody] AccountChangeRequest request)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new AccountInfoChangeByIdQuery(request.Id, SHA256EncriptExtension.Encrypt(request.Value), ChangeTypeEnum.Email));

            if (!result.Result)
            {
                return NotFound();
            }

            return Ok(request.Value);
        }

        [HttpPost("ChangeName")]
        public async Task<IActionResult> AccountChangeNameById([FromBody] AccountChangeRequest request)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }


            var result = await _sender.Send(new AccountInfoChangeByIdQuery(request.Id, SHA256EncriptExtension.Encrypt(request.Value), ChangeTypeEnum.Nickname));

            if (!result.Result)
            {
                return NotFound();
            }

            return Ok(request.Value);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> AccountChangePasswordById([FromBody] AccountChangeRequest request)
        {
            if (GetToken() != _configuration["Authentication:TokenKey"])
            {
                return Unauthorized();
            }


            var result = await _sender.Send(new AccountInfoChangeByIdQuery(request.Id, SHA256EncriptExtension.Encrypt(request.Value), ChangeTypeEnum.Password));

            if (!result.Result)
            {
                return NotFound();
            }

            return Ok(request.Value);
        }
    }
}
