using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoemInk.Data;
using PoemInk.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoemInk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoemController : ControllerBase
    {
        private readonly PoemInkDbContext _appDbContext;
        private readonly ClaimsPrincipal _caller;

        public PoemController(PoemInkDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [HttpPost]
        [Authorize(Policy = "ApiUser")]
        public async Task<IActionResult> Post([FromBody]Poem poem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _appDbContext.Poems.AddAsync(new Poem { Title = poem.Title, Body = poem.Body, Poet = poem.Poet });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Poem created");
        }

        [HttpPut]
        [Authorize(Policy = "ApiUser")]
        public async Task<IActionResult> Update([FromBody]Poem poem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (CurrentPoet().Id != poem.Poet.Id)
            {
                return BadRequest("You can't update this poem");
            }

            await _appDbContext.Poems.AddAsync(new Poem { Title = poem.Title, Body = poem.Body, Poet = poem.Poet });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Poem updated");
        }

        [HttpGet]
        public IEnumerable<Poem> Get()
        {
            return _appDbContext.Poems.ToList();
        }

        [HttpGet("{id}")]
        public Poem Get(int id)
        {
            return _appDbContext.Poems.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet("{penName}")]
        public IEnumerable<Poem> Get(string penName)
        {
            return _appDbContext.Poems.Where(p => p.Poet.PenName == penName).ToList();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ApiUser")]

        public async Task<IActionResult> Delete(int id)
        {
            Poem poem = _appDbContext.Poems.FirstOrDefault(p => p.Id == id);
            
            if (poem != null && CurrentPoet().Id == poem.Poet.Id)
            {
                _appDbContext.Poems.Remove(poem);
                await _appDbContext.SaveChangesAsync();
            }
            return Ok(poem);
        }

        private async Task<Poet> CurrentPoet()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            Poet poet = await _appDbContext.Poets.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
            return poet;
        }
    }
}
