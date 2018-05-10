using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PH.Site.WebAPI.Models
{
    /// <summary>
    /// 假数据中心
    /// </summary>
    public class DataManager
    {
        public static List<AppDTO> GetAll()
        {
            List<AppDTO> list = new List<AppDTO>();
            for (int i = 0; i < 10; i++)
            {
                AppDTO app = new AppDTO();
                app.AppId = Guid.NewGuid();
                app.AppName = "QQ" + i;
                app.Image = "这是图片地址" + i;
                app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "ios", QRCode = "这里是二维码", Url = "指向商店地址" });
                app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "andriod", QRCode = "这里是二维码", Url = "指向商店地址" });
                app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "windows", QRCode = "这里是二维码", Url = "指向商店地址" });
                app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "web", QRCode = "这里是二维码", Url = "网址" });
                app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "wechat", QRCode = "这里是二维码", Url = "网址" });
                list.Add(app);
            }
            return list;
        }
        public static AppDTO Get()
        {
            AppDTO app = new AppDTO();
            app.AppId = Guid.NewGuid();
            app.AppName = "QQ";
            app.Image = "这是图片地址";
            app.CodeUrl = "https://github.com";
            app.Description = "1. I found that the data in Billing Address and hipped toare basically the same (except for SHIPTO ADR3), but I see that in the script you provided, Billing Address and Shipped to are obtained from different tables (1 .JDAAPP.ORD_NOTE 2.JDAAPP.ADRMST, JDAAPP.ORD), but there is an ADRCTY field in JDAAPP.ADRMST. Is it possible to read Billing Address from the JDAAPP.ADRMST, JDAAPP.ORD table?";
            app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "ios", QRCode = "这里是二维码", Url = "指向商店地址", CreateDate = DateTime.Now.AddMonths(2), ModifyDate = DateTime.Now });
            app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "andriod", QRCode = "这里是二维码", Url = "指向商店地址", CreateDate = DateTime.Now.AddMonths(2), ModifyDate = DateTime.Now });
            app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "windows", QRCode = "这里是二维码", Url = "指向商店地址", CreateDate = DateTime.Now.AddMonths(2), ModifyDate = DateTime.Now });
            app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "web", QRCode = "这里是二维码", Url = "网址", CreateDate = DateTime.Now.AddMonths(2), ModifyDate = DateTime.Now });
            app.Category.Add(new CategoryDTO() { Id = Guid.NewGuid(), Icon = "这里是小图标", Name = "wechat", QRCode = "这里是二维码", Url = "网址", CreateDate = DateTime.Now.AddMonths(2), ModifyDate = DateTime.Now });
            return app;
        }
    }
}
