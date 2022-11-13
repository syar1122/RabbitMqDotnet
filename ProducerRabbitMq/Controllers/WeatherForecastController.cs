using Microsoft.AspNetCore.Mvc;
using ProducerRabbitMq.Entities;
using ProducerRabbitMq.Repositories;

namespace ProducerRabbitMq.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly UserRepository _repo;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, UserRepository repo)
    {
        _logger = logger;
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        await _repo.CreateUser(user);
        return CreatedAtAction(nameof(Get), user.Id, user);
    }

    [HttpGet("user")]
    public async Task<IActionResult> ListUsers()
    {
        var users = await _repo.ListUsers();
        return Ok(users);
    }
}