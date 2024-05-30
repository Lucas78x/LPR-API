namespace SampleWebApiAspNetCore.Dtos
{
    public class PlaceAlertsDTO
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public DateTime CreateDate { get; set; }


        public long OwnerId { get; set; }
        public AccountDTO Account { get; set;}
    }
}
