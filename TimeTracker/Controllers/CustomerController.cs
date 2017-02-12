using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Repository.Models;
using Repository.Repositories;
using System.Web.Http.Cors;

namespace TimeTrackerApi.Controllers
{
    [Route("api/customer")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        // GET: api/values
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(CustomerRepository.ReadAll());
        }

        // GET api/values/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(CustomerRepository.ReadById(id));
        }

        // POST api/values
        // Create
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post([FromBody]Customer value)
        {
            CustomerRepository.Create(value);
            return Ok();
        }

        // PUT api/values/5
        // Update
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int id, [FromBody]Customer value)
        {
            value.CustomerID = id;
            CustomerRepository.Update(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int id)
        {
            CustomerRepository.Delete(id);
            return Ok();
        }
    }
}
