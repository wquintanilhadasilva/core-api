using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace coreapi.Controllers
{

    /// <summary>
    /// Converte alturas
    /// </summary>
    [Route("api/[controller]")]
    public class ConversorAlturasController: Controller
    {
        /// <summary>
        /// Converte uma altura dada em pés para metros
        /// </summary>
        /// <param name="alturaPes">valor da altura (decimal)</param>
        /// <returns>Altura fornecida convertida em metros</returns>
        [Authorize("Bearer")]
        [HttpGet("PesMetros/{alturaPes}")]
        public object Get(double alturaPes)
        {
            return new
            {
                AlturaPes = alturaPes,
                AlturaMetros = Math.Round(alturaPes * 0.3048, 4)
            };
        }
    }
}
