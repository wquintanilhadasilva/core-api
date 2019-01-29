using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.Controllers
{

    [Route("api/[controller]")]
    public class SamuelController
    {

        [HttpGet]
        public object Dinheiro()
        {
            return new { valor = 5000 };
        }
    }
}
    