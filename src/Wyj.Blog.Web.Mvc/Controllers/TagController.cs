using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Wyj.Blog.Blog;
using Wyj.Blog.Blog.Dtos;
using Wyj.Blog.Controllers;
using Wyj.Blog.Web.Models.Roles;

namespace Wyj.Blog.Web.Controllers
{
    public class TagController : BlogControllerBase
    {
        private ITagAppService _tagAppService;

        public TagController(ITagAppService tagAppService)
        {
            this._tagAppService = tagAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int tagId)
        {
            var output = await _tagAppService.GetForEdit(new NullableIdDto<int>(tagId));

            return PartialView("_EditModal", output.Tag);
        }
    }
}