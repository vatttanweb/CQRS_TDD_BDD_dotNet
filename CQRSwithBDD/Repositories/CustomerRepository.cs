using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CQRSwithBDD.Data;
using CQRSwithBDD.DomainModel;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Projections;
using EventStore.ClientAPI.SystemData;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace CQRSwithBDD.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        IEventStoreConnection connection;
        private CustomerDbContext _dbContext;
        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
            CreateConnection("tcp://admin:changeit@localhost:1113");
        }
        public async Task<Customer> AddCustomerToESAsync(Customer customer)
        {
            var validCustomer = new CustomerDbValidationProxy(this,
    customer.Id,
    customer.FirstName, customer.LastName, customer.DateOfBirth,
    customer.PhoneNumber, customer.Email,
    customer.BankAccountNumber, true).customer;
            string jsonData = JsonConvert.SerializeObject(validCustomer);
            byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);
            try
            {
                var streamName = "customer-" + validCustomer.Id.ToString();
                var eventPayload = new EventData(
                eventId: Guid.NewGuid(),
                type: "event-type",
                isJson: true,
                data: dataBytes,
                metadata: Encoding.UTF8.GetBytes("{}")
                );
                await connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventPayload);
                return validCustomer;
            }
            catch(Exception exc)
            {
                throw exc;
            }
        }
        public async Task<Customer> UpdateCustomerInES(Customer customer)
        {
            var addedCustomer = await AddCustomerToESAsync(customer);
            return addedCustomer;
        }

        public async Task<Customer> AddReplayedCustomerToSql(Guid Id)
        {
            Customer customerForAdd = new Customer();
            string streamName = "customer-" + Id.ToString();
            var retrievedCstomer = connection.ReadStreamEventsBackwardAsync(streamName, StreamPosition.End, 1, false).Result;
            foreach (var result in retrievedCstomer.Events)
            {
                var customerInfo = Encoding.UTF8.GetString(result.Event.Data);
                customerForAdd = JsonConvert.DeserializeObject<Customer>(customerInfo);
                var cutomerForEF =await _dbContext.Customers.AddAsync(customerForAdd);
                await _dbContext.SaveChangesAsync();
            }
            return customerForAdd;
        }

        public void CreateConnection(string uri)
        {
            connection = EventStoreConnection.Create(new Uri(uri));
             connection.ConnectAsync().Wait();
            //connection.ReadAllEventsBackwardAsync(StreamPosition.End, 1000, true);
        }

        public async Task<Customer> UpdateReplayedCustomerInSql(Guid Id)
        {
            Customer customerForAdd = _dbContext.Customers.SingleOrDefault(c=>c.Id == Id);
            string streamName = "customer-" + Id.ToString();
            var retrievedCstomer = connection.ReadStreamEventsBackwardAsync(streamName, StreamPosition.End, 1, false).Result;
            foreach (var result in retrievedCstomer.Events)
            {
                var customerInfo = Encoding.UTF8.GetString(result.Event.Data);
                customerForAdd = JsonConvert.DeserializeObject<Customer>(customerInfo);
                await _dbContext.SaveChangesAsync();
            }
            return customerForAdd;
        }

        public async Task<Customer> GetCustomerAsync(Guid guid)
        {
            var customer =await _dbContext.Customers.FindAsync(guid);
            return customer;
        }

        public bool GetUniqueInEmail(string email)
        {
            return _dbContext.Customers.Where(
                            c => c.Email == email).Any();
        }

        public bool GetUniqueInFirstAndLastName(string firstName, string lastName, DateTime dateOfBirth)
        {
            return _dbContext.Customers.Where(
                            c => c.FirstName == firstName &&
                            c.LastName == lastName &&
                            c.DateOfBirth == dateOfBirth).Any();
        }

    }
}
