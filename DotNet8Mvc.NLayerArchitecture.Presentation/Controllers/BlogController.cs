﻿using DotNet8Mvc.NLayerArchitecture.BusinessLogic.Features.Blog;
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
            if (result.IsError)
            {
                TempData["error"] = result.Message;
            }

            return View(result);
        }

        [ActionName("CreateBlog")]
        public IActionResult CreateBlogPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogRequestModel requestModel)
        {
            var result = await _bL_Blog.CreateBlog(requestModel);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditBlog(int id)
        {
            var result = await _bL_Blog.GetBlogById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogRequestModel requestModel, int id)
        {
            var result = await _bL_Blog.PatchBlog(requestModel, id);
            if (result.IsError)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bL_Blog.DeleteBlog(id);

            if (result.IsError)
            {
                TempData["error"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
