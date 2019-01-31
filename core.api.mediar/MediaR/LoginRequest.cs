using core.api.mediar.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.mediar.MediaR
{
    public class LoginRequest: IRequest<Credential>
    {
        public Credential Credencial { get; set; }
    }
}
