namespace Dictionary.Controllers
{
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("dictionary")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly ITermService termService;

        public DictionaryController(ITermService termService)
        {
            this.termService = termService;
        }

        // GET api/values
        [HttpGet("{text}")]
        public async Task<IActionResult> GetAsync([FromRoute]string text,[FromQuery] string fromLang = "en",[FromQuery] string toLang="vi")
        {
            var term = await this.termService.GetTermAsync(text, fromLang, toLang);
            return this.Ok(term);
        }
    }
}