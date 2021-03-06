using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public CreateCustomerCommand(Guid id,string firstName, string lastName
            , DateTime dateOfBirth, string phoneNumber, string email
            , string bankAcountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAcountNumber;
            Active = true;
        }

        public Guid Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }
        public bool Active { get; }
    }
}
