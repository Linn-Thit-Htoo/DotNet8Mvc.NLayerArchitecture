using DotNet8Mvc.NLayerArchitecture.BusinessLogic.Features.Blog;
using DotNet8Mvc.NLayerArchitecture.Models.Features;
using DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8Mvc.NLayerArchitecture.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bL_Blog.GetBlogs();
            return View(result);
        }
    }
}
