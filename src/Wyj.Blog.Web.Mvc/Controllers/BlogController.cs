using System;
using System.Drawing;
using System.IO;
using Abp.Application.Services.Dto;
using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wyj.Blog.Blog;
using Wyj.Blog.Controllers;

namespace Wyj.Blog.Web.Controllers
{
    public class BlogController : BlogControllerBase
    {
        private readonly IPostAppService _postAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IPostAppService postAppService, IWebHostEnvironment webHostEnvironment)
        {
            this._postAppService = postAppService;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost]
        public string UpladFilePIC()//id传过来，如需保存可以备用
        {
            IFormCollection fc = HttpContext.Request.Form;
            string savePath = string.Empty;
            int code = 0;
            string msg = "";
            string base64 = fc["base"];
            if (base64 != null)
            {
                string[] spl = base64.Split(',');
                string getImgFormat = spl[0].Split(':')[1].Split('/')[1].Split(';')[0];
                byte[] arr2 = Convert.FromBase64String(spl[1]);
                //上传到服务器
                DateTime today = DateTime.Today;
                string md5 = CommonHelper.CalcMD5(spl[1]);
                string upFileName = md5 + "." + getImgFormat;//生成随机文件名（ System.Guid.NewGuid().ToString() ）
                var pathStart = _webHostEnvironment.WebRootPath + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
                if (Directory.Exists(pathStart) == false)//如果不存在新建
                {
                    Directory.CreateDirectory(pathStart);
                }
                var filePath = pathStart + upFileName;
                string pathNew = filePath.Replace(_webHostEnvironment.WebRootPath, "");
                using (MemoryStream memoryStream = new MemoryStream(arr2, 0, arr2.Length))
                {
                    memoryStream.Write(arr2, 0, arr2.Length);
                    Image image = Image.FromStream(memoryStream);//  转成图片
                    image.Save(filePath);  // 将图片存到本地
                    code = 1;
                    msg = pathNew;
                }
            }
            string jsonResult = CommonHelper.GetJsonResult(code, msg);
            return jsonResult;
        }

        public JsonResult UpImage()//id传过来，如需保存可以备用
        {
            int success = 0;
            string msg = "";
            string pathNew = "";
            try
            {
                var date = Request;
                var files = Request.Form.Files;
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".") + 1, (formFile.FileName.Length - formFile.FileName.LastIndexOf(".") - 1)); //扩展名
                        long fileSize = formFile.Length; //获得文件大小，以字节为单位
                        string md5 = CommonHelper.CalcMD5(formFile.OpenReadStream());
                        string newFileName = md5 + "." + fileExt; //MD5加密生成文件名保证文件不会重复上传
                        var pathStart = _webHostEnvironment.WebRootPath + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
                        if (Directory.Exists(pathStart) == false)//如果不存在新建
                        {
                            Directory.CreateDirectory(pathStart);
                        }
                        var filePath = pathStart + newFileName;
                        pathNew = filePath.Replace(_webHostEnvironment.WebRootPath, "");
                        using var stream = new FileStream(filePath, FileMode.Create);
                        formFile.CopyTo(stream);
                        success = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                success = 0;
                msg = ex.ToString();
            }
            var obj = new { success = success, url = pathNew, message = msg };
            return Json(obj);
        }
    }
}