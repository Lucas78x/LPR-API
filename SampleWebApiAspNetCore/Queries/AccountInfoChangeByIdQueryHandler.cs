
using DigitalWorldOnline.Commons.Interfaces;
using MediatR;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class AccountInfoChangeByIdQueryHandler : IRequestHandler<AccountInfoChangeByIdQuery, AccountChangeModel?>
    {
        private readonly IAccountQueriesRepository _repository;

        public AccountInfoChangeByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountChangeModel?> Handle(AccountInfoChangeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ChangeAccountInfoChangeByIdAsync(request.Id,request.Value,request.Type);
        }
    }
}