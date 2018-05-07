using PH.Site.Entity;
using PH.Site.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;
using PH.Site.ViewModel;

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
            string sql = "insert into app(Id,Name,Image,CodeUrl) values(@Id,@Name,@Image,CodeUrl)";
            _conn.Execute(sql, app, _trans);
        }

        public void AddCategory(List<AppCategory> categories)
        {
            string sql2 = "insert into AppCategory(AppId,CategoryId,AppName,AppUrl,QRCode) values(@AppId,@CategoryId,@AppName,@AppUrl,@QRCode)";
            _conn.Execute(sql2, categories, _trans);
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

        public AppViewModel Get(Guid appId)
        {
            AppViewModel model = new AppViewModel();
            string sql = "select a.Id,a.Image,a.Image,ac.App_Id,ac.Category_Id,ac.App_Url,ac.QRCode,ac.Create_Date,ac.Last_Edit_Date from App as a right join AppCategory as ac  on a.Id=ac.App_Id and a.Id =@Id";
            var user = _conn.Query<App, AppCategory, App>(sql, (app, category) =>
            {
                model.AppId = app.Id;
                model.AppName = app.Name;
                model.Image = app.Image;
                model.Categories.Add(category);
                return app;
            }, new { Id = appId }, splitOn: "App_Id");
            //string sql = "select * from App where Id=@AppId;select * from AppCategory where AppId=@AppId";
            //var reader = _conn.QueryMultiple(sql);
            //var app = reader.ReadFirstOrDefault<App>();
            //var categories = reader.Read<AppCategory>().AsList();
            //AppViewModel model = new AppViewModel()
            //{
            //    AppId = app.Id,
            //    AppName = app.Name,
            //    Image = app.Image,
            //    Categories = categories,
            //};
            return model;
        }

        public IEnumerable<AppViewModel> Get()
        {
            throw new NotImplementedException();
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