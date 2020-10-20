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
      //TODO Logic to prevent weird behavior with null overrides
      return _repo.Update(review);
    }
    public bool Delete(int id)
    {
      var data = FindById(id);
      _repo.Delete(id);
      return true;
    }
  }
}