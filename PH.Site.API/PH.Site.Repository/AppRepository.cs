using Dapper;
using PH.Site.DTO;
using PH.Site.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace PH.Site.Repository
{
    public class AppRepository : BaseRepository, IAppRepository
    {
        public AppRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public void Add(AppDTO app)
        {
            string sql = "insert into app(Id,Name,Image,CodeUrl,Description) values(@Id,@Name,@Image,@CodeUrl,@Description)";
            _conn.Execute(sql, new
            {
                Id = app.AppId,
                Name = app.AppName,
                Image = app.Image,
                CodeUrl = app.CodeUrl,
                Description = app.Description
            }, _trans);
        }

        public void AddCategory(Guid appId, AppCategoryDTO category)
        {
            string sql = "insert into AppCategory(AppId,CategoryId,Url,QRCode,CreateDate,ModifyDate) values(@AppId,@CategoryId,@Url,@QRCode,getdate(),getdate())";
            _conn.Execute(sql, new
            {
                AppId = appId,
                CategoryId = category.CategoryId,
                Url = category.Url,
                QRCode = category.QRCode
            }, _trans);
        }

        public void Delete(Guid appId)
        {
            string sql = "delete from App where Id=@AppId;delete from AppCategory where AppId=@AppId";
            //_conn.Execute(sql, new { Id = appId }, _trans);
            //string sql2 = "delete from AppCategory where AppId=@AppId";
            _conn.Execute(sql, new { AppId = appId }, _trans);
        }

        public void DeleteCategory(Guid appId, Guid categoryId)
        {
            string sql2 = "delete from AppCategory where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql2, new { AppId = appId, CategoryId = categoryId }, _trans);
        }

        public void Update(AppDTO app)
        {
            string sql = "update App set Name=@Name,Image=@Image,CodeUrl=@CodeUrl,Description=@Description where Id=@Id";
            _conn.Execute(sql, new
            {
                Id = app.AppId,
                Name = app.AppName,
                Image = app.Image,
                CodeUrl = app.CodeUrl,
                Description = app.Description
            }, _trans);
        }

        public void UpdateCategory(Guid appId, AppCategoryDTO category)
        {
            string sql = @"update AppCategory set Url=@Url,QRCode=@QRCode,ModifyDate=getdate() where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql, new
            {
                AppId = appId,
                Url = category.Url,
                QRCode = category.QRCode,
                CategoryId = category.CategoryId
            }, _trans);
        }

        public AppDTO Get(Guid appId)
        {
            AppDTO model = null;
            string sql = @"select a.Id AppId,
                                a.Name AppName,
                                a.Image,
                                a.CodeUrl,
                                a.Description,
                                c.Id CategoryId,
                                c.Name,
                                c.Icon,
                                ac.Url,
                                ac.QRCode,
                                ac.CreateDate,
                                ac.ModifyDate 
                            from App as a
                            left join AppCategory as ac 
                            on a.Id = ac.AppId
                            left join Category as c
                            on ac.CategoryId = c.Id 
                            where a.Id = @appId";
            _conn.Query<AppDTO, AppCategoryDTO, AppDTO>(sql, (a, c) =>
            {
                if (model == null)
                    model = a;

                if (c != null)
                    model.Category.Add(c);

                return null;
            }, new { appId }, transaction: _trans, splitOn: "CategoryId");
            return model;
        }

        public IEnumerable<AppDTO> Get()
        {
            List<AppDTO> list = new List<AppDTO>();
            string sql = @"select a.Id AppId,
                                a.Name AppName,
                                a.Image,
                                a.CodeUrl,
                                a.Description,
                                c.Id CategoryId,
                                c.Name,
                                c.Icon,
                                ac.Url,
                                ac.QRCode,
                                ac.CreateDate,
                                ac.ModifyDate 
                            from App as a
                            left join AppCategory as ac 
                            on a.Id = ac.AppId
                            left join Category as c
                            on ac.CategoryId = c.Id ";
            _conn.Query<AppDTO, AppCategoryDTO, AppDTO>(sql, (a, c) =>
            {
                if (!list.Exists(f => f.AppId == a.AppId))
                    list.Add(a);

                if (c != null)
                    list.Find(f => f.AppId == a.AppId).Category.Add(c);

                return null;
            }, transaction: _trans, splitOn: "CategoryId");
            return list;
        }
    }
}
