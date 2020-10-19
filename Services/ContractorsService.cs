using System.Collections.Generic;
using CSharpContracted.Models;
using CSharpContracted.Repositories;

namespace CSharpContracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }
    public List<Contractor> Find()
    {
      return _repo.Find();
    }
    public Contractor FindById(int id)
    {
      var data = _repo.FindById(id);
      if (data == null)
      {
        throw new System.Exception("Invalid Id");
      }
      return data;
    }
    public Contractor Create(Contractor contractor)
    {
      return _repo.Create(contractor);
    }
    public Contractor Update(Contractor contractor)
    {
      //TODO Logic to prevent weird behavior with null overrides
      return _repo.Update(contractor);
    }
    public bool Delete(int id)
    {
      var data = FindById(id);
      _repo.Delete(id);
      return true;
    }
  }
}