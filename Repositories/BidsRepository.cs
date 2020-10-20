using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CSharpContracted.Models;
using Dapper;

namespace CSharpContracted.Repositories
{
  public class BidsRepository : Irepository<Bid>
  {
    private readonly IDbConnection _db;
    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Bid> Find()
    {
      return _db.Query<Bid>(@"
      SELECT * FROM bids 
      ").ToList();
    }

    public Bid FindById(int id)
    {
      return _db.Query<Bid>(@"
      SELECT * FROM bids WHERE id = @id", new { id }).FirstOrDefault();
    }
    public Bid Create(Bid bid)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO bids(jobid, contractorid, bidrate) VALUES(@JobId, @ContractorId, @BidRate); SELECT LAST_INSERT_ID();", bid);
      bid.Id = id;
      return bid;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM bids WHERE id = @id
      ", new { id });
      return success > 0;
    }

    internal IEnumerable<ContractorBidViewModel> GetBidsByContractorId(int id)
    {
      return _db.Query<ContractorBidViewModel>(@"
      SELECT c.*, b.id AS ContractorBidId, b.bidrate AS ContractorBidRate
      FROM contractors c
      JOIN bids b on b.contractorid = c.id
      WHERE c.id = @id
      ", new { id });
    }

    public Bid Update(Bid bid)
    {
      _db.Execute(@"
      UPDATE bids
      SET 
      jobid = @JobId,
      contractorid = @ContractorId,
      bidrate = @BidRate
      WHERE id = @Id;", bid);
      return bid;
    }
  }
}