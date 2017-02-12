using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Repository.Models;
using Repository.Repositories;
using System.Web.Http.Cors;

namespace TimeTrackerApi.Controllers
{
    [Route("api/TimeRecord")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TimeRecordController : ApiController
    {
        // GET: api/values
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(TimeRecordRepository.ReadAll());
        }

        // GET api/values/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(TimeRecordRepository.ReadById(id));
        }

        // POST api/values
        // Create
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post([FromBody]TimeRecord value)
        {
            TimeRecordRepository.Create(value);
            return Ok();
        }

        // PUT api/values/5
        // Update
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int id, [FromBody]TimeRecord value)
        {
            value.TimeRecordID = id;
            TimeRecordRepository.Update(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int id)
        {
            TimeRecordRepository.Delete(id);
            return Ok();
        }
    }
}
