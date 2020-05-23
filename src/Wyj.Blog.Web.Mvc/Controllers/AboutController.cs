﻿using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Wyj.Blog.Controllers;

namespace Wyj.Blog.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
