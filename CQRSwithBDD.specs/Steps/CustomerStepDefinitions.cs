using CQRSwithBDD.Controllers;
using CQRSwithBDD.Data;
using CQRSwithBDD.DomainModel;
using CQRSwithBDD.DomainModel.Commands;
using CQRSwithBDD.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
namespace CQRSwithBDD.specs.Steps
{
    [Binding]
    public sealed class CustomerStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        CreateCustomerCommand createCustomer;
        Customer customerInDb;
        Mock<IMediator> _mockMediator;
        CreateCustomerCommandHandler handler;
        ValuesController _valuesController;
        public CustomerStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have the following customer:")]
        public void GivenIhaveTheFollowingCustomer(Table customer)
        {
            var insertedCustomer = customer.CreateInstance<Customer>();
            createCustomer = new CreateCustomerCommand(insertedCustomer.Id,insertedCustomer.FirstName
                ,insertedCustomer.LastName,insertedCustomer.DateOfBirth,insertedCustomer.PhoneNumber
                ,insertedCustomer.Email,insertedCustomer.BankAccountNumber);
            _mockMediator = new Mock<IMediator>();
            var _repository = new CustomerRepository(new CustomerDbContext());
            handler = new CreateCustomerCommandHandler(_repository, _mockMediator.Object);
        }

        [When("the customer is created")]
        public void WhenTheCustomerIsCreated()
        {
            customerInDb = handler.Handle(createCustomer, new System.Threading.CancellationToken()).Result;
        }

        [Then("the result should have the following values:")]
        public void ThenTheResultShouldHaveTheFollowingValues(Table result)
        {
            result.CompareToInstance<Customer>(customerInDb);
        }
    }
}
