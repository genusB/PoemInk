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
    public class TranslationController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get(string from, string to, string text)
        {
            var translator = new GoogleTranslator();

            Language From;
            if (from != "Auto")
            {
                From = GoogleTranslator.GetLanguageByName(from);
            }
            else {
                From = Language.Auto;
            }
            
            Language To = GoogleTranslator.GetLanguageByName(to);

            TranslationResult result = await translator.TranslateLiteAsync(text, From, To);
            return result.MergedTranslation;
        }
    }
}
