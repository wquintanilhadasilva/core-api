using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.Model
{
    public class Contador
    {
        private int _requisicoes = 0;
        public int Requisicoes { get => this._requisicoes; }
        public void Incrementar() => this._requisicoes++;
    }
}
