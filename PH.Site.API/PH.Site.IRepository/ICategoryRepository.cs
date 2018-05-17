using PH.Site.DTO;
using PH.Site.Model;
using System;
using System.Collections.Generic;

namespace PH.Site.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="category"></param>
        void Add(CategoryDTO category);

        /// <summary>
        /// 删除指定分类
        /// </summary>
        /// <param name="categoryId"></param>
        void Delete(Guid categoryId);

        /// <summary>
        /// 更新某一分类
        /// </summary>
        /// <param name="category"></param>
        void Update(CategoryDTO category);

        /// <summary>
        /// 根据categoryId获取分类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        CategoryDTO Get(Guid categoryId);

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        IEnumerable<CategoryDTO> Get();
    }
}
