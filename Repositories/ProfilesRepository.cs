using System.Data;
using CSharpContracted.Models;
using Dapper;

namespace CSharpContracted
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      return _db.QueryFirstOrDefault<Profile>(@"
      SELECT *
      FROM profiles
      WHERE id = @id
      ", new { id });
    }

    internal Profile Create(Profile newProfile)
    {
      _db.Execute(@"
      INSERT INTO profiles
        (id, email, name, picture)
        VALUES
        (@Id, @Email, @Name, @Picture)
      ", newProfile);
      return newProfile;
    }
  }
}