using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpContracted.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _service;

    public JobsController(JobsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_service.Find());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        return Ok(_service.FindById(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job job)
    {
      try
      {
        return Ok(_service.Create(job));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Job> Update([FromBody] Job job, int id)
    {
      try
      {
        job.Id = id;
        return Ok(_service.Update(job));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}