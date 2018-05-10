using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.Common;
using PH.Site.Entity;
using PH.Site.UnitOfWork;
using PH.Site.WebAPI.Models;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/App")]
    public class AppController : Controller
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public AppController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DataManager.GetAll());
        }

        [HttpGet("{AppId}")]
        public IActionResult Get(Guid AppId)
        {
            return Ok(DataManager.Get());
        }

        [HttpPost]
        public IActionResult Add(App app)
        {
            var testApp = new App()
            {
                Id = Guid.NewGuid(),
                CodeUrl = "https://github.com/eyu1993/PH.Site",
                Image = Guid.NewGuid().ToString(),
                Name = "个人网站",
                Description = "个人网站，用来记录自己做过的项目"
            };
            _uow.AppRepository.Add(testApp);
            _uow.SaveChanges();
            return Ok(app);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //UOW.AppRepository.Delete(id);
            return Ok(id);
        }

        [HttpPost("Category")]
        public IActionResult AddCategory(Guid appId, CategoryDTO category)
        {
            AppCategory cat = _mapper.Map<AppCategory>(category);
            cat.AppId = appId;
            _uow.AppRepository.AddCategory(cat);
            _uow.SaveChanges();
            return Ok();
        }
    }
}