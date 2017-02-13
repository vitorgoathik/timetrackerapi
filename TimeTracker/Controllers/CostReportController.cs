using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Repository.Models;
using Repository.Repositories;
using System.Web.Http.Cors;

namespace TimeTrackerApi.Controllers
{
    [Route("api/costreport")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CostReportController : ApiController
    {
        // GET: api/values
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(CostReportRepository.ReadAll());
        }

        // GET api/values/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(CostReportRepository.ReadById(id));
        }
    }
}
