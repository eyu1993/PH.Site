using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Site.Common;
using PH.Site.Entity;
using PH.Site.UnitOfWork;

namespace PH.Site.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/App")]
    public class AppController : Controller
    {
        public IUnitOfWork UOW { get; set; }
        public AppController(IUnitOfWork unitOfWork)
        {
            this.UOW = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UOW.AppRepository.Get());
        }

        [HttpPost]
        public IActionResult Add([FromBody]App app)
        {
            UOW.AppRepository.Add(app);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            UOW.AppRepository.Delete(id);
            return Ok(id);
        }
    }
}