using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.DTO;
using PH.Site.IRepository;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _uow;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }

        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CategoryDTO dto)
        {
            _uow.CategoryRepository.Add(dto);
            _uow.SaveChanges();
            return Ok(dto);
        }

        /// <summary>
        /// 根据CategoryId删除分类
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpDelete("{CategoryId}")]
        public IActionResult Delete(Guid CategoryId)
        {
            _uow.CategoryRepository.Delete(CategoryId);
            _uow.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult Update(CategoryDTO dto)
        {
            _uow.CategoryRepository.Update(dto);
            _uow.SaveChanges();
            return Ok(dto);
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uow.CategoryRepository.Get());
        }

        /// <summary>
        /// 根据CategoryId来获取分类
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet("{CategoryId}")]
        public IActionResult Get(Guid CategoryId)
        {
            return Ok(_uow.CategoryRepository.Get(CategoryId));
        }
    }
}