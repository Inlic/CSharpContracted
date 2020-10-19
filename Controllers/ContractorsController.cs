using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpContracted.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _service;

    public ContractorsController(ContractorsService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
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
    public ActionResult<Contractor> Get(int id)
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
    public ActionResult<Contractor> Create([FromBody] Contractor contractor)
    {
      try
      {
        return Ok(_service.Create(contractor));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Contractor> Update([FromBody] Contractor contractor, int id)
    {
      try
      {
        contractor.Id = id;
        return Ok(_service.Update(contractor));
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