using SampleWebApiAspNetCore.Enums;
using SampleWebApiAspNetCore.Helpers;

namespace SampleWebApiAspNetCore.Models
{
    public class AccountModel

    {    /// <summary>
         /// Unique Identifier
         /// </summary>
        public long Id { get; set; }

        public List<PlaceAlertsModel> Alerts { get; set; }

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

        public AccountModel()
        {

        }

        public AccountModel(CadastroTypeEnum type, string registro, string username, string email, string password)
        {
            Alerts = new List<PlaceAlertsModel>();
            Type = type;
            CreateDate = DateTime.Now;
            Registro = registro;
            Username = username;
            Email = SHA256EncriptExtension.Encrypt(email);
            Password = SHA256EncriptExtension.Encrypt(password); 
        }
        
    }
}
