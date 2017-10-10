using Microsoft.AspNetCore.Mvc;
using YelpCamp_ASPNET_Angular.Data;

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
    }
}