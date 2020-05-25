using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Wyj.Blog.Blog;
using Wyj.Blog.Controllers;

namespace Wyj.Blog.Web.Controllers
{
    public class BlogController : BlogControllerBase
    {
        private IPostAppService _postAppService;

        public BlogController(IPostAppService postAppService)
        {
            this._postAppService = postAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Preview(Guid postId)
        {
            var post = _postAppService.GetById(new EntityDto<Guid>(postId));
            return View(post);
        }

        public IActionResult Edit(Guid postId)
        {
            var post = _postAppService.GetById(new EntityDto<Guid>(postId));
            return View(post);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}