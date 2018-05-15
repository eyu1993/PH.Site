using Dapper;
using PH.Site.DTO;
using PH.Site.IRepository;
using PH.Site.Model;
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

        public void Add(App app)
        {
            string sql = "insert into app(Id,Name,Image,CodeUrl,Description) values(@Id,@Name,@Image,@CodeUrl,@Description)";
            _conn.Execute(sql, app, _trans);
        }

        public void AddCategory(AppCategory category)
        {
            string sql = "insert into AppCategory(AppId,CategoryId,Url,QRCode,CreateDate,ModifyDate) values(@AppId,@CategoryId,@Url,@QRCode,@CreateDate,@ModifyDate)";
            _conn.Execute(sql, category, _trans);
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

        public void Update(App app)
        {
            string sql = "update App set Name=@Name,Image=@Image,CodeUrl=@CodeUrl,Description=@Description where Id=@Id";
            _conn.Execute(sql, app, _trans);
        }

        public void UpdateCategory(AppCategory category)
        {
            string sql = "update AppCategory set Url=@Url,QRCode=@QRCode,ModifyDate=@ModifyDate where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql, category, _trans);
        }

        public AppDTO Get(Guid appId)
        {
            AppDTO model = new AppDTO();
            string sql = "select a.Id,a.Name,a.Image,a.CodeUrl,a.Description,c.Id CategoryId,c.Name,c.Icon,ac.Url,ac.QRCode,ac.CreateDate,ac.ModifyDate " +
                "from App as a " +
                "left join AppCategory as ac " +
                "on a.Id = ac.AppId " +
                "left join Category as c " +
                "on ac.CategoryId = c.Id " +
                "where a.Id = @appId";
            _conn.Query<App, CategoryDTO, App>(sql, (a, c) =>
            {
                model.AppId = a.Id;
                model.AppName = a.Name;
                model.CodeUrl = a.CodeUrl;
                model.Description = a.Description;
                model.Image = a.Image;
                if (c != null)
                {
                    model.Category.Add(c);
                }
                return null;
            }, new { appId = appId }, transaction: _trans, splitOn: "CategoryId");
            return model;
        }

        public IEnumerable<AppDTO> Get()
        {
            List<AppDTO> list = new List<AppDTO>();
            string sql = "select a.Id,a.Name,a.Image,a.CodeUrl,a.Description,c.Id CategoryId,c.Name,c.Icon,ac.Url,ac.QRCode,ac.CreateDate,ac.ModifyDate " +
                "from App as a " +
                "left join AppCategory as ac " +
                "on a.Id = ac.AppId " +
                "left join Category as c " +
                "on ac.CategoryId = c.Id ";
            _conn.Query<App, CategoryDTO, App>(sql, (a, c) =>
            {
                AppDTO model = new AppDTO();
                model.AppId = a.Id;
                model.AppName = a.Name;
                model.CodeUrl = a.CodeUrl;
                model.Description = a.Description;
                model.Image = a.Image;

                if (!list.Exists(f => f.AppId == a.Id))
                {
                    list.Add(model);
                }

                if (c != null)
                {
                    list.Find(f => f.AppId == a.Id).Category.Add(c);
                }

                return null;
            }, transaction: _trans, splitOn: "CategoryId");
            return list;
        }
    }
}
