using System;
using HWMS.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HWMS.Web.Controllers
{
    [Route("/api/Product")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel model)
        {
            return Ok("已创建");
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id)
        {
            return Ok();
        }
    }
}