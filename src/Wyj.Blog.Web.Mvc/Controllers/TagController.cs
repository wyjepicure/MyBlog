using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wyj.Blog.Controllers;

namespace Wyj.Blog.Web.Controllers
{
    public class TagController : BlogControllerBase
    {
        public async Task<IActionResult> Index()
        {
            //var permissions = (await _roleAppService.GetAllPermissions()).Items;
            //var model = new RoleListViewModel
            //{
            //    Permissions = permissions
            //};

            return View();
        }
    }
}