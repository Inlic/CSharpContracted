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
      var data = FindById(job.Id);
      if (data.CreatorId != job.CreatorId)
      {
        throw new System.Exception("Invalid Edit Permissions");
      }
      job.Description = job.Description != null ? job.Description : data.Description;
      job.Location = job.Location != null ? job.Location : data.Location;
      return _repo.Update(job);
    }
    public bool Delete(int id, string userId)
    {
      var data = FindById(id);
      if (data.CreatorId != userId)
      {
        throw new System.Exception("Invalid Edit Permissions");
      }
      _repo.Delete(id);
      return true;
    }
  }
}