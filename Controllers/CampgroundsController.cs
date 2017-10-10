using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YelpCamp_ASPNET_Angular.Data;
using YelpCamp_ASPNET_Angular.Models;
using System.Threading.Tasks;

namespace YelpCamp_ASPNET_Angular.Controllers
{
    [Route("api/campgrounds")]
    public class CampgroundsController : Controller
    {
        private readonly CampgroundContext _context;

        public CampgroundsController (CampgroundContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Campground> GetAll()
        {
            return _context.Campgrounds.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById (long id)
        {
            var item = _context.Campgrounds.FirstOrDefault(cg => cg.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Campground item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Campgrounds.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetCampground", new { id = item.Id, item }, item);
        }
    }
}