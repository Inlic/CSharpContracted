using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Repositories;

namespace CSharpContracted.Services
{
  public class BidsService
  {
    private readonly BidsRepository _repo;

    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }
    public List<Bid> Find()
    {
      return _repo.Find();
    }
    public Bid FindById(int id)
    {
      var data = _repo.FindById(id);
      if (data == null)
      {
        throw new System.Exception("Invalid Id");
      }
      return data;
    }
    public Bid Create(Bid bid)
    {
      return _repo.Create(bid);
    }
    public Bid Update(Bid bid)
    {
      //TODO Logic to prevent weird behavior with null overrides
      return _repo.Update(bid);
    }
    public bool Delete(int id)
    {
      var data = FindById(id);
      _repo.Delete(id);
      return true;
    }
  }
}