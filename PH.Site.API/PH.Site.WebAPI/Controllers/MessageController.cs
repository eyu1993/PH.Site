using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.IRepository;
using PH.Site.Model;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        public IUnitOfWork _uow { get; set; }
        public MessageController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }

        /// <summary>
        /// 发布一条留言
        /// </summary>
        /// <param name="appId">在app下留言（可空）</param>
        /// <param name="content">留言内容</param>
        /// <param name="replyId">回复的留言id（可空）</param>
        /// <returns></returns>
        public IActionResult Add(string content, Guid? appId, int replyId = 0)
        {
            int order = 0;//根据appip查询最大的order
            string ip = "127.0.0.1";//获取ip地址
            string address = "";//根据ip查询归属地
            Guid userId = Guid.NewGuid();//用户的userid
            Message message = new Message()
            {
                AppId = appId,
                Content = content,
                IsPass = false,
                IsShow = false,
                ReplyTime = DateTime.Now,
                ReplyId = replyId,
                Ip = ip,
                Address = address,
                Order = order,
                UserId = userId
            };
            _uow.MessageRepository.Add(message);
            _uow.SaveChanges();
            return Ok(message);
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Detete(int id)
        {
            _uow.MessageRepository.Delete(id);
            _uow.SaveChanges();
            return Ok();
        }


    }
}