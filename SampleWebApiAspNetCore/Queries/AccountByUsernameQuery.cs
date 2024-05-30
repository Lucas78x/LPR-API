using MediatR;
using SampleWebApiAspNetCore.Dtos;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class AccountByUsernameQuery : IRequest<AccountDTO?>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountByUsernameQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

