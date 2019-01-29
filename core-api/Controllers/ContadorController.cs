using core.api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.Controllers
{

    /// <summary>
    /// API para geração de contadores
    /// </summary>
    [Route("api/[controller]")]
    public class ContadorController: Controller
    {

        private static Contador contador = new Contador();

        /// <summary>
        /// Lista os valores prefixados
        /// </summary>
        /// <returns>Listagem de valores gerados usando o recurso de Tuplas</returns>
        [HttpGet]
        public object Get()
        {

            var tupla1 = (valor1: 1, valor2: 2);
            var tupla2 = (valor1: 1, valor2: 2);
            var tupla3 = (valor1: 2, valor2: 4);

            lock (contador)
            {
                contador.Incrementar();
                return new
                {
                    contador.Requisicoes,
                    Environment.MachineName,
                    Environment.UserName,
                    Environment.OSVersion.Platform,
                    Environment.OSVersion.Version,
                    tupla1EqualsTupla2 = tupla1 == tupla2,
                    tupla2EqualsTupla3 = tupla2 != tupla3,
                    bruno = "Bruninho!"
                };
            }
        }
    }
}
