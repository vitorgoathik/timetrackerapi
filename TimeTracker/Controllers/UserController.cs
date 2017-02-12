using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Repository.Models;
using Repository.Repositories;
using System.Web.Http.Cors;

namespace TimeTrackerApi.Controllers
{
    [Route("api/User")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/values
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(UserRepository.ReadAll());
        }

        // GET api/values/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(UserRepository.ReadById(id));
        }

        // POST api/values
        // Create
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post([FromBody]User value)
        {
            UserRepository.Create(value);
            return Ok();
        }

        // PUT api/values/5
        // Update
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int id, [FromBody]User value)
        {
            value.UserID = id;
            UserRepository.Update(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int id)
        {
            UserRepository.Delete(id);
            return Ok();
        }
    }
}
