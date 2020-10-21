using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Repositories;

namespace CSharpContracted.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _repo;

    public ReviewsService(ReviewsRepository repo)
    {
      _repo = repo;
    }
    public List<Review> Find()
    {
      return _repo.Find();
    }
    public Review FindById(int id)
    {
      var data = _repo.FindById(id);
      if (data == null)
      {
        throw new System.Exception("Invalid Id");
      }
      return data;
    }
    public Review Create(Review review)
    {
      return _repo.Create(review);
    }
    public Review Update(Review review)
    {
      var original = FindById(review.Id);
      if (original == null)
      {
        throw new System.Exception("Bad Request");
      }
      if (original.CreatorId != review.CreatorId)
      {
        throw new System.Exception("Invalid Permissions");
      }
      review.ContractorId = original.ContractorId;
      review.Title = review.Title != null ? review.Title : original.Title;
      review.Body = review.Body != null ? review.Body : original.Body;
      //NOTE other properties can be tested for as well, but this is just for example
      return _repo.Update(review);
    }
    public bool Delete(int id, string userId)
    {
      var data = FindById(id);
      if (data == null)
      {
        throw new System.Exception("Bad Request");
      }
      if (data.CreatorId != userId)
      {
        throw new System.Exception("Invalid Permissions");
      }
      _repo.Delete(id);
      return true;
    }
  }
}