using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResourceAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(200, "All ok");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post()
        {
            return StatusCode(200, "Secret message you have to be authorized to see");
        }
    }
}