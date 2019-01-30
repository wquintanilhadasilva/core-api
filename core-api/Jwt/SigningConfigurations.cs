using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace coreapi.Jwt
{
    /// <summary>
    /// Configurações de Login
    /// </summary>
    public class SigningConfigurations
    {
        /// <summary>
        /// Contém a chave de criptografia utilizada na criação de tokens
        /// </summary>
        public SecurityKey Key { get; }

        /// <summary>
        /// Contém a chave de criptografia e o algoritmo de segurança empregados na geração de assinaturas digitais para tokens
        /// </summary>
        public SigningCredentials SigningCredentials { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

    }
}
