using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.mediar.Model
{
    public class Credential
    {
        public Boolean IsAuthenticated { get; set; } = false;
        public String Login { get; set; }
        public String Senha { get; set; }
        public string Mensagem { get; set; }
    }
}
