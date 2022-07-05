using PersonApp.Models;

namespace PersonApp.Services;

public class PersonService: IPersonService
{

    private readonly PersonContext _personContext;

    public PersonService(PersonContext personContext)
    {
        _personContext = personContext;
    }

    public Person? FindById(int id)
    {
        return _personContext.Persons.Find(id);
    }

    public List<Person> FindAll()
    {
        return _personContext.Persons.ToList();
    }

    public Person Create(PersonRequest personRequest)
    {
        var res = _personContext.Add(
            new Person(personRequest.Name, personRequest.Age)
            );
        _personContext.SaveChanges();
        return res.Entity;
    }

    public void Update(int id, PersonRequest personRequest)
    {
        var person = _personContext.Find<Person>(id);
        if (person == null) return;
        person.Name = personRequest.Name;
        person.Age = personRequest.Age;
        _personContext.Update(person);
        _personContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var person = _personContext.Find<Person>(id);
        if (person == null) return;
        _personContext.Remove(person);
        _personContext.SaveChanges();
    }
}
