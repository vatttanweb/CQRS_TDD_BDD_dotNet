using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSwithBDD.DomainModel;
using CQRSwithBDD.DomainModel.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSwithBDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<Customer> Post([FromBody] CreateCustomerCommand createCustomerCommand)
        {

            Customer customer = await _mediator.Send(createCustomerCommand);
            return customer;
            //return CretedAtAction(nameof(GetCustomerById), new { customerId = customer.Id }, customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            Customer customer = await _mediator.Send(updateCustomerCommand);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            DeleteCustomerCommand deleteCustomerCommand = new DeleteCustomerCommand(id);
            Customer customer = await _mediator.Send(deleteCustomerCommand);
        }
    }
}
