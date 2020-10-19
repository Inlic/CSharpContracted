using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CSharpContracted.Models;
using Dapper;

namespace CSharpContracted.Repositories
{
  public class JobsRepository : Irepository<Job>
  {
    private readonly IDbConnection _db;
    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Job> Find()
    {
      return _db.Query<Job>(@"
      SELECT * FROM jobs 
      ").ToList();
    }

    public Job FindById(int id)
    {
      return _db.Query<Job>(@"
      SELECT * FROM jobs WHERE id = @id", new { id }).FirstOrDefault();
    }
    public Job Create(Job job)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO jobs(location, description, contact) VALUES(@Location, @Description, @Contact); SELECT LAST_INSERT_ID();", job);
      job.Id = id;
      return job;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM jobs WHERE id = @id
      ", new { id });
      return success > 0;
    }


    public Job Update(Job job)
    {
      _db.Execute(@"
      UPDATE jobs
      SET location = @Location, description = @Description, contact = @Contact WHERE id = @Id;", job);
      return job;
    }
  }
}