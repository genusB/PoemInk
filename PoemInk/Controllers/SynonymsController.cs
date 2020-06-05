using GoogleTranslateFreeApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GoogleTranslateFreeApi.TranslationData.ExtraTranslations;

namespace PoemInk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynonymsController : ControllerBase
    {
        private readonly ILogger<RhymesController> _logger;

        public SynonymsController(ILogger<RhymesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get(string text)
        {
            var translator = new GoogleTranslator();

            TranslationResult result = await translator.TranslateAsync(text, Language.Auto, Language.English);
            string synonyms = "";
            if (result.Synonyms != null)
            {
                synonyms = result.Synonyms.ToString();
            }
            else
            {
                synonyms = "There are no available synonyms";
            }

            return synonyms;
        }
    }
}
