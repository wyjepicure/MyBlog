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
    public class CategoryController : BlogControllerBase
    {
        private ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            this._categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int categoryId)
        {
            var output = await _categoryAppService.GetForEdit(new NullableIdDto<int>(categoryId));

            return PartialView("_EditModal", output.Category);
        }
    }
}