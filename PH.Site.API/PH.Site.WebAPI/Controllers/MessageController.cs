using Microsoft.AspNetCore.Mvc;
using PH.Site.IRepository;
using PH.Site.Model;
using System;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        public MessageController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }

        public IUnitOfWork _uow { get; set; }

        /// <summary>
        /// 发布一条留言
        /// </summary>
        /// <param name="appId">在app下留言（可空）</param>
        /// <param name="content">留言内容</param>
        /// <param name="replyId">回复的留言id（可空）</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(string content, Guid? appId, int replyId = 0)
        {
            int order = 0;//当前的楼层，需根据appId查询出最新的楼层
            string ip = "127.0.0.1";//获取ip地址
            string address = "本地";//根据ip查询归属地
            Guid userId = Guid.NewGuid();//用户的userid
            Message message = new Message()
            {
                AppId = appId,
                UserId = userId,
                Content = content,
                ReplyTime = DateTime.Now,
                ReplyId = replyId,
                Order = order,
                Ip = ip,
                Address = address,
                IsPass = false,
                IsShow = false
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

        /// <summary>
        /// 获取留言
        /// </summary>
        /// <param name="AppId">（可选的）若输入AppId，则获取app的留言，若为空则是公用留言板</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid? AppId)
        {
            return Ok(_uow.MessageRepository.Get(AppId));
        }

        /// <summary>
        /// 获取所有未处理的留言
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUnProcessed")]
        public IActionResult GetUnProcessed()
        {
            return Ok(_uow.MessageRepository.GetUnProcessed());
        }

        [HttpPatch]
        public IActionResult Update(int id)
        {
            _uow.MessageRepository.Process(id);
            _uow.SaveChanges();
            return Ok();
        }
    }
}