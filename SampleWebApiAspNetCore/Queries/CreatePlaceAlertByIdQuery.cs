using MediatR;
using SampleWebApiAspNetCore.Dtos;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class CreatePlaceAlertByIdQuery : IRequest<PlaceAlertsModel?>
    {
        public long Id { get; set; }
        public PlaceAlertsModel Alert { get; set; }
        public CreatePlaceAlertByIdQuery(long id, PlaceAlertsModel alert)
        {
            Id = id;
            Alert = alert;
        }
    }
}

