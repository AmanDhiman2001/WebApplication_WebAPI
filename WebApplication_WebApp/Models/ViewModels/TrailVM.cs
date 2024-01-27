using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication_WebApp.Models.ViewModels
{
    public class TrailVM
    {
        public Trail Trail { get; set; }
        public IEnumerable<SelectListItem> nationalParkList { get; set; }
    }
}
