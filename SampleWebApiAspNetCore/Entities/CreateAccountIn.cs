using SampleWebApiAspNetCore.Enums;

namespace SampleWebApiAspNetCore.Entities
{
    public class CreateAccountIn
    {
        /// <summary>
        /// Endereço de e-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Enumeração de Tipo de Cadastro.
        /// </summary>
        public CadastroTypeEnum Type { get; set; }

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
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}
