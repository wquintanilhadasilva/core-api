using Microsoft.AspNetCore.Mvc;

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
    