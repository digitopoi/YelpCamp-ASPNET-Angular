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

            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Campground item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var campground = _context.Campgrounds.FirstOrDefault(c => c.Id == id);

            if (campground == null)
            {
                return NotFound();
            }

            _context.Campgrounds.Update(campground);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var campground = _context.Campgrounds.FirstOrDefault(c => c.Id == id);
            if (campground == null)
            {
                return NotFound();
            }

            _context.Campgrounds.Remove(campground);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}