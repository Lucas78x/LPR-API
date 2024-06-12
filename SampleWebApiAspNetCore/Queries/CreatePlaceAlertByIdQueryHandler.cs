
using DigitalWorldOnline.Commons.Interfaces;
using MediatR;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class CreatePlaceAlertByIdQueryHandler : IRequestHandler<CreatePlaceAlertByIdQuery, PlaceAlertsModel?>
    {
        private readonly IAccountQueriesRepository _repository;

        public CreatePlaceAlertByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PlaceAlertsModel?> Handle(CreatePlaceAlertByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.CreatePlaceAlertByIdAsync(request.Id, request.Alert);
        }
    }
}