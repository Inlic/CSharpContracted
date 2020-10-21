using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using CSharpContracted.Models;
using CSharpContracted.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult<Review>> Create([FromBody] Review review)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        review.CreatorId = userInfo.Id;
        review.Creator = userInfo;
        return Ok(_service.Create(review));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Review>> Update([FromBody] Review review, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        review.CreatorId = userInfo.Id;
        review.Creator = userInfo;
        review.Id = id;
        return Ok(_service.Update(review));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<bool>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}