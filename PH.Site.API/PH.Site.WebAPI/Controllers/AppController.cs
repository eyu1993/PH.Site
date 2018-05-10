using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.Common;
using PH.Site.Entity;
using PH.Site.UnitOfWork;
using PH.Site.ViewModel;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/App")]
    public class AppController : Controller
    {
        public IUnitOfWork UOW { get; set; }
        public AppController()
        {
            //this.UOW = unitOfWork;
        }

        public IActionResult Get()
        {
            List<APP1> list = new List<APP1>();
            for (int i = 0; i < 5; i++)
            {
                var app = new APP1();
                app.AppId = Guid.NewGuid();
                app.AppName = "QQ" + i;
                app.Image = "图片" + 1;
                app.Category = new List<Category1>()
                {
                    new Category1()
                    {
                         AppUrl="http://google.com",
                          DisplayName="谷歌商店",
                           Icon="google"
                    },
                    new Category1()
                    {
                         AppUrl="http://microsoft.com",
                          DisplayName="微软商店",
                           Icon="microsoft"
                    },
                    new Category1()
                    {
                         AppUrl="http://apple.com",
                          DisplayName="苹果商店",
                           Icon="apple"
                    }
                };
                list.Add(app);
            }
            return Ok(list);
        }

        [HttpGet("{AppId}")]
        public IActionResult Get(Guid AppId)
        {
            var app = new APP2();
            app.AppId = Guid.NewGuid();
            app.AppName = "QQ1";
            app.Image = "dsa";
            app.CodeUrl = "htttps://github.com/eyu1993/PH.Site";
            app.Description = "app的详细描述";
            app.Category = new List<Category2>()
                {
                    new Category2()
                    {
                         AppUrl="http://google.com",
                          DisplayName="谷歌商店",
                           Icon="google",
                            QRCode="二维码地址"
                           ,
                            AppUrl2="http://google2.com"
                    },
                    new Category2()
                    {
                         AppUrl="http://microsoft.com",
                          DisplayName="微软商店",
                           Icon="microsoft",
                            QRCode="二维码地址"


                    },
                    new Category2()
                    {
                         AppUrl="http://apple.com",
                          DisplayName="苹果商店",
                           Icon="apple",
                            QRCode="二维码地址"

                    }
                };
            return Ok(app);
        }


        [HttpPost]
        public IActionResult Add([FromBody]App app)
        {
            UOW.AppRepository.Add(app);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            UOW.AppRepository.Delete(id);
            return Ok(id);
        }
    }
    public class APP1
    {
        public APP1()
        {
            Category = new List<Category1>();
        }
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Image { get; set; }
        public List<Category1> Category { get; set; }
    }
    public class Category1
    {
        public string AppUrl { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
    }

    public class APP2
    {
        public APP2()
        {
            Category = new List<Category2>();
        }
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Image { get; set; }
        public string CodeUrl { get; set; }
        public string Description { get; set; }
        public List<Category2> Category { get; set; }
    }
    public class Category2
    {
        public string AppUrl { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public string AppUrl2 { get; set; }
        public string QRCode { get; set; }
    }
}