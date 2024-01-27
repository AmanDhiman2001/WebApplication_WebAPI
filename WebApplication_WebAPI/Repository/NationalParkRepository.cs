using WebApplication_WebAPI.Data;
using WebApplication_WebAPI.Models;
using WebApplication_WebAPI.Repository.IRepository;

namespace WebApplication_WebAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbcontext _context;
        public NationalParkRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NatinalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.NatinalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNatinalPark(int nationalParkid)
        {
            return _context.NatinalParks.Find(nationalParkid);
        }

        public ICollection<NationalPark> GetNatinalParks()
        {
            return _context.NatinalParks.ToList();
        }

        public bool NationalParkExists(int nationalParkid)
        {
            return _context.NatinalParks.Any(np=> np.Id== nationalParkid);
        }

        public bool NationalParkExists(string nationalParkName)
        {
           return _context.NatinalParks.Any(np=> np.Name== nationalParkName);
        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true: false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.NatinalParks.Update(nationalPark);
            return Save();
        }
    }
}
