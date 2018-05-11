using PH.Site.Entity;
using PH.Site.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;
using PH.Site.ViewModel;
using PH.Site.DTO;

namespace PH.Site.Repository
{
    public class AppRepository : IAppRepository
    {
        private IDbConnection _conn;
        private IDbTransaction _trans;
        public AppRepository(IDbConnection connection, IDbTransaction transaction)
        {
            this._conn = connection;
            this._trans = transaction;
        }

        public void Add(App app)
        {
            string sql = "insert into app(Id,Name,Image,CodeUrl,Description) values(@Id,@Name,@Image,@CodeUrl,@Description)";
            _conn.Execute(sql, app, _trans);
        }

        public void AddCategory(AppCategory category)
        {
            string sql2 = "insert into AppCategory(AppId,CategoryId,Url,QRCode,CreateDate,ModifyDate) values(@AppId,@CategoryId,@Url,@QRCode,@CreateDate,@ModifyDate)";
            _conn.Execute(sql2, category, _trans);
        }

        public void Delete(Guid appId)
        {
            string sql = "delete from App where Id=@Id";
            _conn.Execute(sql, new { Id = appId }, _trans);
            string sql2 = "delete from AppCategory where AppId=@AppId";
            _conn.Execute(sql2, new { AppId = appId }, _trans);
        }

        public void DeleteCategory(Guid appId, Guid categoryId)
        {
            string sql2 = "delete from AppCategory where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql2, new { AppId = appId, CategoryId = categoryId }, _trans);
        }

        public void DeleteCategory(AppCategory appCategory)
        {
            string sql = "delete from AppCategory where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql, new { AppId = appCategory.AppId, CategoryId = appCategory.CategoryId }, _trans);
        }

        public AppDTO Get(Guid appId)
        {
            AppDTO model = new AppDTO();
            string sql = "select a.Id,a.Name,a.Image,a.CodeUrl,a.Description,c.Id,c.Name,c.Icon,ac.Url,ac.QRCode,ac.CreateDate,ac.ModifyDate " +
                "from App as a " +
                "left join AppCategory as ac " +
                "on a.Id = ac.AppId " +
                "left join Category as c " +
                "on ac.CategoryId = c.Id " +
                "where a.Id = @Id";
            var user = _conn.Query<App, Category, AppCategory, App>(sql, (a, c, ac) =>
              {
                  model.AppId = a.Id;
                  model.AppName = a.Name;
                  model.CodeUrl = a.CodeUrl;
                  model.Description = a.Description;
                  model.Image = a.Image;
                  model.Category.Add(new CategoryDTO()
                  {
                      Id = c.Id,
                      Name = c.Name,
                      Icon = c.Icon,
                      Url = ac.Url,
                      QRCode = ac.QRCode,
                      CreateDate = ac.CreateDate,
                      ModifyDate = ac.ModifyDate
                  });

                  return null;
              }, new { Id = appId }, transaction: _trans, splitOn: "Id,Url");
            return model;
        }

        public IEnumerable<AppDTO> Get()
        {
            List<AppDTO> list = new List<AppDTO>();
            string sql = "select a.Id,a.Name,a.Image,a.CodeUrl,a.Description,c.Id,c.Name,c.Icon,ac.Url,ac.QRCode,ac.CreateDate,ac.ModifyDate " +
                "from App as a " +
                "left join AppCategory as ac " +
                "on a.Id = ac.AppId " +
                "left join Category as c " +
                "on ac.CategoryId = c.Id ";
            _conn.Query<App, Category, AppCategory, App>(sql, (a, c, ac) =>
            {
                AppDTO model = new AppDTO();
                model.AppId = a.Id;
                model.AppName = a.Name;
                model.CodeUrl = a.CodeUrl;
                model.Description = a.Description;
                model.Image = a.Image;
                if (!list.Exists(l => l.AppId == a.Id))
                {
                    list.Add(model);
                }
                else
                {
                    if (c != null && ac != null)
                    {
                        model.Category.Add(new CategoryDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Icon = c.Icon,
                            Url = ac.Url,
                            QRCode = ac.QRCode,
                            CreateDate = ac.CreateDate,
                            ModifyDate = ac.ModifyDate
                        });
                    }
                }
                return null;
            }, transaction: _trans, splitOn: "Id,Url");
            return list;
        }

        public void Update(App app)
        {
            string sql = "update App set Name=@Name,Image=@Image,CodeUrl=@CodeUrl,Remark=@Remark where Id=@Id";
            _conn.Execute(sql, app, _trans);
        }

        public void UpdateCategory(AppCategory appCategory)
        {
            string sql = "update AppCategory set AppName=@AppName,AppUrl=@AppUrl,QRCode=@QRCode where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql, appCategory, _trans);
        }
    }
}