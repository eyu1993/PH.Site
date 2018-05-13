using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PH.Site.DTO;
using PH.Site.IRepository;
using System;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/App")]
    public class AppController : Controller
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public AppController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
            //this._mapper = mapper;
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
            //var app = _mapper.Map<App>(dto);
            _uow.AppRepository.Add(dto);
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