using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpContracted.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _service;

    public BidsController(BidsService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Bid>> Get()
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
    public ActionResult<Bid> Get(int id)
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
    public ActionResult<Bid> Create([FromBody] Bid bid)
    {
      try
      {
        return Ok(_service.Create(bid));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Bid> Update([FromBody] Bid bid, int id)
    {
      try
      {
        bid.Id = id;
        return Ok(_service.Update(bid));
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