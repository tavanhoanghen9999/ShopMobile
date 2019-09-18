using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.product;
using ModelClassLibrary.data.request;
using WebApi.service.img;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IImage m_image;
        public ValuesController(IImage image)
        {
            m_image = image;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        [HttpPost("Post")]
        public async Task<string> upfileAsync([FromForm] ProductRequest file)
        {
            Product pr = new Product();
            try
            {
                pr.nameproduct = file.nameproduct;
                pr.createday = file.createday;
                pr.note = file.note;
                pr.price = file.price;
                pr.total = file.total;
                pr.productid = file.productid;
                pr.supplierid = file.supplierid;
                pr.picture = await m_image.uploadFile(file.picture);//
            }catch(Exception e)
            {
                
            }
            return "update khong thanh chong";
        }

    }

}
