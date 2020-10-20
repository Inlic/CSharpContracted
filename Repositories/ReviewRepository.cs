using System.Collections.Generic;
using System.Data;
using System.Linq;
using CSharpContracted.Models;
using Dapper;

namespace CSharpContracted.Repositories
{
  public class ReviewsRepository : Irepository<Review>
  {
    private readonly IDbConnection _db;
    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Review> Find()
    {
      return _db.Query<Review>(@"
      SELECT * FROM reviews 
      ").ToList();
    }

    public Review FindById(int id)
    {
      return _db.Query<Review>(@"
      SELECT * FROM reviews WHERE id = @id", new { id }).FirstOrDefault();
    }
    public Review Create(Review review)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO reviews(title, body, rating, date, contractorid) VALUES(@Title, @Body, @Rating, @Date, @ContractorId); SELECT LAST_INSERT_ID();", review);
      review.Id = id;
      return review;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM reviews WHERE id = @id
      ", new { id });
      return success > 0;
    }

    public Review Update(Review review)
    { //TODO update this sql
      _db.Execute(@"
      UPDATE reviews
      SET 
      title = @Title,
      body = @Body,
      rating = @Rating,
      date = @Date,
      contractorid = @ContractorId
      WHERE id = @Id;", review);
      return review;
    }
  }
}