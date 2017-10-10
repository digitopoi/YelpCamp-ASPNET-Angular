using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YelpCamp_ASPNET_Angular.Data;

namespace YelpCamp_ASPNET_Angular.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CampgroundContext (
                serviceProvider.GetRequiredService<DbContextOptions<CampgroundContext>>())) 
                {
                    //  Look for any campgrounds
                    if (context.Campgrounds.Any()) 
                    {
                        return;             //  DB already seeded
                    }

                    context.Campgrounds.AddRange(
                        new Campground 
                        {
                            Id = 0,
                            Name = "Cloud's Rest",
                            Price = "$12.00",
                            Image = "https://farm6.staticflickr.com/5181/5641024448_04fefbb64d.jpg",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        }, 

                        new Campground 
                        {
                            Id = 1,
                            Name = "Redneck Riviera",
                            Price = "$15.00",
                            Image = "https://farm5.staticflickr.com/4153/4835814837_feef6f969b.jpg",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },

                        new Campground 
                        {
                            Id = 2,
                            Name = "Beach Bliss",
                            Price = "$35.00",
                            Image = "https://farm4.staticflickr.com/3872/14435096036_39db8f04bc.jpg",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        }
                    );

                    context.SaveChanges();
                }
        }
    }
}