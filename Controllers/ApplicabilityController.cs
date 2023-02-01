using Microsoft.AspNetCore.Mvc;
using applicability_service.Models;
using System.Collections.Generic;

namespace applicability_service.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicabilityController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly List<Applicability> _applicability = new List<Applicability>
    {
        new Applicability { Code = "A-10", Store = new[] { "STORE-01", "STORE-02"}, UserName = "test"},
        new Applicability { Code = "B-20", Store = new[] { "STORE-01", "STORE-02"}, UserName = "test"},
        new Applicability { Code = "X-50", Store = new[] { "STORE-01", "STORE-02"}, UserName = "user1"},
        new Applicability { Code = "Y-60", Store = new[] { "STORE-01", "STORE-02"}, UserName = "user1"},
        new Applicability { Code = "Z-70", Store = new[] { "STORE-01", "STORE-02"}, UserName = "user1"},
    };


    private readonly ILogger<ApplicabilityController> _logger;

    public ApplicabilityController(ILogger<ApplicabilityController> logger)
    {
        _logger = logger;
    }

    [HttpGet("get_applicability")]
    public ActionResult<List<Applicability>> Get(string? userName)
    {
        if (userName is not null) 
        {
            _logger.LogInformation($"API called with ..... {userName}");
            return Ok(_applicability.Where(x => x.UserName.ToLower() == userName.ToLower()));
        }

        return Ok(_applicability);
    }
}