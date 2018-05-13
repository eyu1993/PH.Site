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

        public void AddCategory(Guid appId, AppCategory category)
        {
            string sql = "insert into AppCategory(AppId,CategoryId,Url,QRCode,CreateDate,ModifyDate) values(@AppId,@CategoryId,@Url,@QRCode,@CreateDate,@ModifyDate)";
            _conn.Execute(sql, category, _trans);
        }

        public void Delete(Guid appId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Guid appId, Guid categoryId)
        {
            string sql2 = "delete from AppCategory where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql2, new { AppId = appId, CategoryId = categoryId }, _trans);
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
            string sql = "update App set Name=@Name,Image=@Image,CodeUrl=@CodeUrl,Description=@Description where Id=@Id";
            _conn.Execute(sql, app, _trans);
        }

        public void UpdateCategory(AppCategory appCategory)
        {
            string sql = "update AppCategory set AppName=@AppName,AppUrl=@AppUrl,QRCode=@QRCode where AppId=@AppId and CategoryId=@CategoryId";
            _conn.Execute(sql, appCategory, _trans);
        }
    }
}
