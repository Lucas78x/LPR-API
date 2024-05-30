
using DigitalWorldOnline.Commons.Interfaces;
using MediatR;
using SampleWebApiAspNetCore.Dtos;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class AccountByUsernameQueryHandler : IRequestHandler<AccountByUsernameQuery, AccountDTO?>
    {
        private readonly IAccountQueriesRepository _repository;

        public AccountByUsernameQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDTO?> Handle(AccountByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountByUsernameAsync(request.Email, request.Password);
        }
    }
}