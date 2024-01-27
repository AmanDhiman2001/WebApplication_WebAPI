using WebApplication_WebAPI.Models;

namespace WebApplication_WebAPI.Repository.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetNatinalParks();
        NationalPark GetNatinalPark(int nationalParkid);
        bool NationalParkExists(int nationalParkid);
        bool NationalParkExists(string nationalParkName);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();
    }
}
