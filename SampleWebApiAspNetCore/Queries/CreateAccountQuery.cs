using MediatR;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class CreateAccountQuery : IRequest<AccountModel?>
    { 
        public AccountModel Account { get; set; }
        public CreateAccountQuery(AccountModel account)
        {

            Account = account;
        }
    }
}

