using System.Collections.Generic;
using System.Data;
using System.Linq;
using CSharpContracted.Models;
using Dapper;

namespace CSharpContracted.Repositories
{
  public class ContractorsRepository : Irepository<Contractor>
  {
    private readonly IDbConnection _db;
    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Contractor> Find()
    {
      return _db.Query<Contractor>(@"
      SELECT * FROM contractors 
      ").ToList();
    }

    public Contractor FindById(int id)
    {
      return _db.Query<Contractor>(@"
      SELECT * FROM contractors WHERE id = @id", new { id }).FirstOrDefault();
    }
    public Contractor Create(Contractor contractor)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO contractors(name, address, contact, skills) VALUES(@Name, @Address, @Contact, @Skills); SELECT LAST_INSERT_ID();", contractor);
      contractor.Id = id;
      return contractor;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM contractors WHERE id = @id
      ", new { id });
      return success > 0;
    }

    public Contractor Update(Contractor contractor)
    {
      _db.Execute(@"
      UPDATE contractors
      SET 
      name = @Name,
      address = @Address,
      contact = @Contact,
      skills = @Skills
      WHERE id = @Id;", contractor);
      return contractor;
    }
  }
}