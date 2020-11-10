
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PoemInk.Data;
using PoemInk.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PoemInk.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly PoemInkDbContext _appDbContext;

        public ProfileController(PoemInkDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/profile/me
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            // retrieve the user info
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var poet = await _appDbContext.Poets.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            return new OkObjectResult(new
            {
                poet.Identity.FirstName,
                poet.Identity.LastName,
                poet.Identity.PictureUrl,
                poet.Identity.FacebookId,
                poet.PenName
            });
        }
    }
}
