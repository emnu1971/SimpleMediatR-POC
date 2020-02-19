using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator.Logic;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEnumerable<INotifier> _notifiers;
        private readonly INotifierMediatorService _notifierMediatorService;

        public ValuesController(IEnumerable<INotifier> notifiers, INotifierMediatorService notifierMediatorService)
        {
            _notifiers = notifiers;
            _notifierMediatorService = notifierMediatorService;
        }

        /// <summary>
        /// Simple notifier
        /// </summary>
        /// <returns></returns>
        [HttpGet("NotifyAll")]
        public ActionResult<string> NotifyAll()
        {
            _notifiers.ToList().ForEach(x => x.Notify());
            return "Completed";
        }

        /// <summary>
        /// Service based notifier (prefered)
        /// </summary>
        /// <returns></returns>
        [HttpGet("NotifyAllService")]
        public ActionResult<string> NotifyAllService()
        {
            _notifierMediatorService.Notify();
            return "Completed";
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
