using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PH.Site.DTO;
using PH.Site.IRepository;
using PH.Site.Model;
using System;

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

        /// <summary>
        /// 获取所有的app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_uow.AppRepository.Get());
        }

        /// <summary>
        /// 根据appId获取单个app
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        [HttpGet("{appId}")]
        [AllowAnonymous]
        public IActionResult Get(Guid appId)
        {
            return Ok(_uow.AppRepository.Get(appId));
        }

        /// <summary>
        /// 添加一个app
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AppDTO dto)
        {
            App app = _mapper.Map<App>(dto);
            _uow.AppRepository.Add(app);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 删除一个app
        /// </summary>
        /// <param name="id">appId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _uow.AppRepository.Delete(id);
            return Ok();
        }

        /// <summary>
        /// 给app添加一个分类
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("Category")]
        public IActionResult AddCategory(AppCategoryDTO dto)
        {
            AppCategory category = _mapper.Map<AppCategory>(dto);
            _uow.AppRepository.AddCategory(category);
            _uow.SaveChanges();
            return Ok();
        }
    }
}