using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpContracted.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _service;

    public ReviewsController(ReviewsService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get()
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
    public ActionResult<Review> Get(int id)
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
    public ActionResult<Review> Create([FromBody] Review review)
    {
      try
      {
        return Ok(_service.Create(review));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Review> Update([FromBody] Review review, int id)
    {
      try
      {
        review.Id = id;
        return Ok(_service.Update(review));
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