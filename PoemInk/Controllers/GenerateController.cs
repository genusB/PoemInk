using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Generate;
using System.Threading.Tasks;

namespace PoemInk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        [HttpGet()]
        public string Get(int number)
        {
            string poem = GeneratePoem.Generate(number);
            return poem;
        }
    }
}
