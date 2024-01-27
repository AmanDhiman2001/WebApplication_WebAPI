using WebApplication_WebApp.Models;
using WebApplication_WebApp.Repository.IRepository;

namespace WebApplication_WebApp.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRepository(IHttpClientFactory httpClientFactory)
            :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
