using core.api.mediar.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace core.api.mediar.MediaR
{
    public class LoginHandler : IRequestHandler<LoginRequest, Credential>
    {
        public Task<Credential> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var cred = request.Credencial;
            if(String.IsNullOrEmpty(cred.Login) || String.IsNullOrEmpty(cred.Senha))
            {
                cred.IsAuthenticated = false;
                cred.Mensagem = "Erro ao efetuar o login!";
            }else
            {
                cred.IsAuthenticated = true;
                cred.Mensagem = "Login efetuado com sucesso!";
            }
            return Task.FromResult(cred);
        }
    }
}
