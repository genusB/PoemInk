using GoogleTranslateFreeApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemInk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellingController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get(string misspellingsText)
        {
            var translator = new GoogleTranslator();

            var result = await translator.TranslateLiteAsync(misspellingsText, Language.Auto, Language.English);

            if (result.Corrections.CorrectedText != null)
            {
                return result.Corrections.CorrectedText;
            }
            else {
                return misspellingsText;
            }
        }
    }
}
