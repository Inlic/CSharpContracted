using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Repositories;

namespace CSharpContracted.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }
    public List<Job> Find()
    {
      return _repo.Find();
    }
    public Job FindById(int id)
    {
      var data = _repo.FindById(id);
      if (data == null)
      {
        throw new System.Exception("Invalid Id");
      }
      return data;
    }
    public Job Create(Job job)
    {
      return _repo.Create(job);
    }
    public Job Update(Job job)
    {
      //TODO Logic to prevent weird behavior with null overrides
      return _repo.Update(job);
    }
    public bool Delete(int id)
    {
      var data = FindById(id);
      _repo.Delete(id);
      return true;
    }
  }
}