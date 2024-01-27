using WebApplication_WebApp.Models;
using WebApplication_WebApp.Repository.IRepository;

namespace WebApplication_WebApp.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRepository(IHttpClientFactory httpClientFactory)
            :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        

    }
}
