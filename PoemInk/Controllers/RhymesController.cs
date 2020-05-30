using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rhymer;
using Rhymer.Parser;

namespace PoemInk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RhymesController : ControllerBase
    {
        List<string> rhymes = new List<string>();
        RhymesDownloader<RhymesByCategory> downloader;
        private readonly ILogger<RhymesController> _logger;

        public RhymesController(ILogger<RhymesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<string>> Get(string id)
        {
            downloader = new RhymesDownloader<RhymesByCategory>(new RhymerParser());
            downloader.OnNewData += Downloader_OnNewData;

            downloader.Settings = new RhymerSettings(id, "");
            await downloader.Start();
                
            return rhymes.ToArray();
        }

        private void Downloader_OnNewData(object arg1, RhymesByCategory newRhymes)
        {
            foreach (var key in newRhymes.AllRhymes.Keys)
            {
                rhymes.Add(key + ": ");
                rhymes.AddRange(newRhymes.AllRhymes[key].ToArray<string>());
            }
        }
    }
}