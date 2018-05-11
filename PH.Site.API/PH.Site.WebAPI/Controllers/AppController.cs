using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.Common;
using PH.Site.Entity;
using PH.Site.UnitOfWork;
using PH.Site.WebAPI.Models;

namespace PH.Site.WebAPI.Controllers
{
    [Authorize]
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

        /// <summary>
        /// 获取所有的app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(DataManager.GetAll());
        }

        /// <summary>
        /// 根据appId获取单个app
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        [HttpGet("{AppId}")]
        [AllowAnonymous]
        public IActionResult Get(Guid AppId)
        {
            return Ok(DataManager.Get());
        }

        /// <summary>
        /// 添加一个app
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AppDTO dto)
        {
            var app = _mapper.Map<App>(dto);
            _uow.AppRepository.Add(app);
            _uow.SaveChanges();
            return Ok(dto);
        }

        /// <summary>
        /// 删除一个app
        /// </summary>
        /// <param name="id">appId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //UOW.AppRepository.Delete(id);
            return Ok(id);
        }

        /// <summary>
        /// 给app添加一个分类
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="category"></param>
        /// <returns></returns>
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