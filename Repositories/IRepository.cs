using System.Collections.Generic;

namespace CSharpContracted.Repositories
{
  public interface Irepository<T>
  {
    T Create(T t);
    T FindById(int id);
    List<T> Find();
    T Update(T t);
    bool Delete(int id);
  }
}