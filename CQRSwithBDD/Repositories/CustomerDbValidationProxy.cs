using CQRSwithBDD.Data;
using CQRSwithBDD.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.Repositories
{
    public class CustomerDbValidationProxy
    {
        public CustomerDbValidationProxy(ICustomerRepository customerRepository,
            Guid id,string firstName,string lastName
            ,DateTime dateOfBirth,string phoneNumber,string email,string bankAccount
            ,bool active)
        {
            var uniqueInFirstAndLastName = customerRepository.GetUniqueInFirstAndLastName(
                firstName, lastName, dateOfBirth);

            if (uniqueInFirstAndLastName)
            {
                throw new Exception("There is a customer with this FirstName and LstName and DateOfBirth");
            }
            var uniqueInEmail = customerRepository.GetUniqueInEmail(email);

            if (uniqueInEmail)
            {
                throw new Exception("There is a customer with this Email");
            }
            this.customer = new Customer(id, firstName,lastName,dateOfBirth,
                phoneNumber,email, bankAccount, true);

            //ToDo : This part should be refactor with "Pipe & Filter" Pattern 
        }

       public Customer customer { get; private set; }

    }
}
