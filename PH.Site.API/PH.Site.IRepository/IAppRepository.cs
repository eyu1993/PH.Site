using PH.Site.DTO;
using PH.Site.Entity;
using PH.Site.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PH.Site.IRepository
{
    public interface IAppRepository : IBaseRepository<AppViewModel>
    {
        /// <summary>
        /// 添加app
        /// </summary>
        /// <param name="app"></param>
        void Add(App app);

        /// <summary>
        /// 给app添加分类
        /// </summary>
        /// <param name="categories"></param>
        void AddCategory(AppCategory category);

        /// <summary>
        /// 删除整个app及分类
        /// </summary>
        /// <param name="appId"></param>
        void Delete(Guid appId);

        /// <summary>
        /// 删除指定app下的某个分类
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="categoryId"></param>
        void DeleteCategory(Guid appId, Guid categoryId);

        /// <summary>
        /// 删除指定app下的某个分类
        /// </summary>
        /// <param name="appCategory"></param>
        void DeleteCategory(AppCategory appCategory);

        /// <summary>
        /// 更新app
        /// </summary>
        /// <param name="model"></param>
        void Update(App app);

        /// <summary>
        /// 更新指定app下的分类
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="category"></param>
        void UpdateCategory(AppCategory appCategory);

        /// <summary>
        /// 根据appId获取
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        AppDTO Get(Guid appId);

        /// <summary>
        /// 获取所有app
        /// </summary>
        /// <returns></returns>
        IEnumerable<AppDTO> Get();
    }
}
