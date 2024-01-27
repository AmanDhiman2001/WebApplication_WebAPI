using WebApplication_WebAPI.Models;

namespace WebApplication_WebAPI.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trail>GetTrails();
        ICollection<Trail> GetTrailsInNationalParks(int nationalParkId);
        Trail GetTrail(int trailId);
        bool TrailExists(int trailId);
        bool TrailExists(string trailName);
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);
        bool DeleteTrail(Trail trail);
        bool Save();
    }
}
