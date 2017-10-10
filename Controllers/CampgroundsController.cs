using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YelpCamp_ASPNET_Angular.Data;
using YelpCamp_ASPNET_Angular.Models;

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
    }
}