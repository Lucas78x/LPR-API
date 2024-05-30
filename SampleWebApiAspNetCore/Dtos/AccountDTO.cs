using SampleWebApiAspNetCore.Enums;

namespace SampleWebApiAspNetCore.Dtos
{
    public class AccountDTO

    {    /// <summary>
         /// Unique Identifier
         /// </summary>
        public long Id { get; set; }

        public List<PlaceAlertsDTO> Alerts { get; set; }

        /// <summary>
        /// Enumeração de Tipo de Cadastro.
        /// </summary>
        public CadastroTypeEnum Type { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Registro de Cadastro.
        /// </summary>
        /// 
        public string Registro { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

    }
}
