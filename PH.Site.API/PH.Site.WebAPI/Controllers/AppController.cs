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
            //TODO:要保存上传的图片
            _uow.AppRepository.Add(dto);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 给app添加一个分类
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("{AppId}/Category")]
        public IActionResult Add(Guid AppId, AppCategoryDTO dto)
        {
            _uow.AppRepository.AddCategory(AppId, dto);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 删除一个app
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        [HttpDelete("{AppId}")]
        public IActionResult Delete(Guid AppId)
        {
            _uow.AppRepository.Delete(AppId);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 删除app的分类
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpDelete("{AppId}/Category/{CategoryId}")]
        public IActionResult Delete(Guid AppId, Guid CategoryId)
        {
            _uow.AppRepository.DeleteCategory(AppId, CategoryId);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 更新app
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult Update(AppDTO dto)
        {
            _uow.AppRepository.Update(dto);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 更新app下的某个分类
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch("{AppId}/Category")]
        public IActionResult Update(Guid AppId, AppCategoryDTO dto)
        {
            _uow.AppRepository.UpdateCategory(AppId, dto);
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
        /// 根据AppId获取单个app
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        [HttpGet("{AppId}")]
        public IActionResult Get(Guid AppId)
        {
            return Ok(_uow.AppRepository.Get(AppId));
        }
    }
}