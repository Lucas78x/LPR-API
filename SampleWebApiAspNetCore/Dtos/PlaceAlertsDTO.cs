namespace SampleWebApiAspNetCore.Dtos
{
    public class PlaceAlertsDTO
    {
        public Guid Id { get; set; }

        public string Placa { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public long AccountDTOId { get; set; }

        public void SetId(Guid id) => Id = id;

        public void SetPlaca(string placa) => Placa = placa;

        public void SetCreateDate(DateTime createDate) => CreateDate = createDate;

        public void SetName(string name) => Name = name;

        public void SetAccountdId(long id) => AccountDTOId = id;

    }
}
