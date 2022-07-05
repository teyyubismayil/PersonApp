using Microsoft.AspNetCore.Mvc;
using PersonApp.Models;
using PersonApp.Services;

namespace PersonApp.Controllers;

[ApiController]
[Route("/api/v1/persons")]
public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("{id:int}")]
    public Person? FindById([FromRoute] int id)
    {
        _logger.Log(LogLevel.Information, "Get person by id: {0}", id);
        return _personService.FindById(id);
    }
    
    [HttpGet]
    public List<Person> FindAll()
    {
        _logger.Log(LogLevel.Information, "Get all persons");
        return _personService.FindAll();
    }
    
    [HttpPost]
    public Person Create([FromBody] PersonRequest personRequest)
    {
        _logger.Log(LogLevel.Information, "Create person: {0}", personRequest);
        return _personService.Create(personRequest);
    }

    [HttpPut("{id:int}")]
    public void Update([FromRoute] int id, [FromBody] PersonRequest personRequest)
    {
        _logger.Log(LogLevel.Information, "Update person {0}: {1}", id, personRequest);
        _personService.Update(id, personRequest);
    }

    [HttpDelete("{id:int}")]
    public void Delete([FromRoute] int id)
    {
        _logger.Log(LogLevel.Information, "Delete person: {0}", id);
        _personService.Delete(id);
    }
}
