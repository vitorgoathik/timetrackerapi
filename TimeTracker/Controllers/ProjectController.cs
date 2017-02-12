using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Repository.Models;
using Repository.Repositories;
using System.Web.Http.Cors;

namespace TimeTrackerApi.Controllers
{
    [Route("api/Project")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        // GET: api/values
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(ProjectRepository.ReadAll());
        }

        // GET api/values/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(ProjectRepository.ReadById(id));
        }

        // POST api/values
        // Create
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post([FromBody]Project value)
        {
            ProjectRepository.Create(value);
            return Ok();
        }

        // PUT api/values/5
        // Update
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int id, [FromBody]Project value)
        {
            value.ProjectID = id;
            ProjectRepository.Update(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int id)
        {
            ProjectRepository.Delete(id);
            return Ok();
        }
    }
}
