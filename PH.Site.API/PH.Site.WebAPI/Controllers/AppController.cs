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
        public AppController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }

        /// <summary>
        /// 添加一个app
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AppDTO dto)
        {
            _uow.AppRepository.Add(dto);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 给app添加一个分类
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("Category")]
        public IActionResult Add(AppCategoryDTO dto)
        {
            _uow.AppRepository.AddCategory(dto);
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
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 删除app的分类
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete("{appId}/Category/{categoryId}")]
        public IActionResult Delete(Guid appId, Guid categoryId)
        {
            _uow.AppRepository.DeleteCategory(appId, categoryId);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 获取所有的app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        public IActionResult Get(Guid appId)
        {
            return Ok(_uow.AppRepository.Get(appId));
        }
    }
}