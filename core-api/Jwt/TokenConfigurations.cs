
namespace coreapi.Jwt
{
    /// <summary>
    /// Representa a configuração de geração do Token JWT
    /// </summary>
    public class TokenConfigurations
    {
        /// <summary>
        /// Aplicação destinatária que irá utilizar o Token
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Emissor do Token
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Duração do Token
        /// </summary>
        public int Seconds { get; set; }
    }
}
