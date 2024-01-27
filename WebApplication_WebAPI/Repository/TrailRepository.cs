using Microsoft.EntityFrameworkCore;
using WebApplication_WebAPI.Data;
using WebApplication_WebAPI.Models;
using WebApplication_WebAPI.Repository.IRepository;

namespace WebApplication_WebAPI.Repository
{
    public class TrailRepository:ITrailRepository
    {
        private readonly ApplicationDbcontext _context;
        public TrailRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public bool CreateTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.Trails.Find(trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.Include(t=>t.NatinalPark).ToList();
        }

        public ICollection<Trail> GetTrailsInNationalParks(int nationalParkId)
        {
            //var trailList = _context.Trails.Include(t=>t.NatinalPark).Where(t=>t.NationalParkId==nationalParkId).ToList();
            //return trailList;
            return _context.Trails.Include(r=>r.NationalParkId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true: false;
        }

        public bool TrailExists(int trailId)
        {
            return _context.Trails.Any(t=>t.Id==trailId);
        }

        public bool TrailExists(string trailName)
        {
            return _context.Trails.Any(t => t.Name == trailName);
        }

        public bool UpdateTrail(Trail trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }
    }
}
