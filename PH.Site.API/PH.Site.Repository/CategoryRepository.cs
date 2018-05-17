using Dapper;
using PH.Site.DTO;
using PH.Site.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace PH.Site.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public void Add(CategoryDTO category)
        {
            string sql = @"insert into Category(Id,Name,Icon) values(@Id,@Name,@Icon)";
            _conn.Execute(sql, new
            {
                Id = category.CategoryId,
                Name = category.Name,
                Icon = category.Icon
            }, transaction: _trans);
        }

        public void Delete(Guid categoryId)
        {
            string sql = @"delete from Category where Id=@categoryId";
            _conn.Execute(sql, new
            {
                categoryId = categoryId
            }, transaction: _trans);
        }

        public CategoryDTO Get(Guid categoryId)
        {
            string sql = @"select Id CategoryId,Name,Icon from Category where Id=@categoryId";
            return _conn.QueryFirstOrDefault<CategoryDTO>(sql, new
            {
                categoryId = categoryId
            }, transaction: _trans);
        }

        public IEnumerable<CategoryDTO> Get()
        {
            string sql = @"select Id CategoryId,Name,Icon from Category";
            return _conn.Query<CategoryDTO>(sql, transaction: _trans);
        }

        public void Update(CategoryDTO category)
        {
            string sql = @"update Category set Name=@Name,Icon=@Icon where Id=@CategoryId";
            _conn.Execute(sql, new
            {
                Name = category.Name,
                Icon = category.Icon,
                CategoryId = category.CategoryId
            }, transaction: _trans);
        }
    }
}
