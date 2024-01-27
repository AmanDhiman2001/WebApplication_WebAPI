using Microsoft.EntityFrameworkCore;
using WebApplication_WebAPI.Models;

namespace WebApplication_WebAPI.Data
{
    public class ApplicationDbcontext:DbContext     
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
             : base(options)
        {

        }
        public DbSet<NationalPark> NatinalParks { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
