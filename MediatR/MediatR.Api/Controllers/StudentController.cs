using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR.Dto;
using MediatR.Logic.Commands;
using MediatR.Logic.Queries;
using MediatR.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudenController : ControllerBase
    {

        private readonly ILogger<StudenController> _logger;
        private readonly INotifierMediatorService _notifierMediatorService;
        private readonly ICommandBusMediatorService _commandBusMediatorService;
        private readonly IQueryBusMediatorService _queryBusMediatorService;
        

        public StudenController(ILogger<StudenController> logger, 
            INotifierMediatorService notifierMediatorService,
            ICommandBusMediatorService commandBusMediatorService,
            IQueryBusMediatorService queryBusMediatorService
            )
        {
            _logger = logger;
            _notifierMediatorService = notifierMediatorService;
            _commandBusMediatorService = commandBusMediatorService;
            _queryBusMediatorService = queryBusMediatorService;
        }


        [HttpGet("NotifyAll")]
        public ActionResult<string> NotifyAll()
        {
            _notifierMediatorService.Notify($"This is a test notification from {nameof(StudenController)}.NotifyAll()");
            return "Completed";
        }

        [HttpPost("Register")] 
        public async Task<ActionResult<string>> RegisterAsync([FromBody] StudentDto student)
        {
            var registerCmd = new RegisterCommand(student.Name,student.Email);
            await _commandBusMediatorService.PublishAsync(registerCmd);
            return await Task.Run(() => "Completed");
        }

        [HttpGet("RegisteredStudents")]
        public async Task<IActionResult> GetRegisteredStudentsAsync() 
        {
            var query = new GetAllRegisteredStudentsQuery();
            var result = await _queryBusMediatorService.SendAsync(query) as List<StudentDto>;
            return Ok(result);
        }
        
        [HttpGet("RegisteredStudentByEmail/{email}")]
        public async Task<IActionResult> GetRegisteredStudentByEmailAsync(string email)
        {
            var query = new GetRegisteredStudentByEmailQuery(email);
            var result = await _queryBusMediatorService.SendAsync(query) as StudentDto;
            return result != null ? Ok(result) : NotFound() as IActionResult;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
