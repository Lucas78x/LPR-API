
using DigitalWorldOnline.Commons.Interfaces;
using MediatR;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class CreateAccountQueryHandler : IRequestHandler<CreateAccountQuery, AccountModel?>
    {
        private readonly IAccountQueriesRepository _repository;

        public CreateAccountQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountModel?> Handle(CreateAccountQuery request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAccountAsync(request.Account);
        }
    }
}