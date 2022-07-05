using PersonApp.Models;

namespace PersonApp.Services;

public interface IPersonService
{
    Person? FindById(int id);
    List<Person> FindAll();
    Person Create(PersonRequest personRequest);
    void Update(int id, PersonRequest personRequest);
    void Delete(int id);
}
