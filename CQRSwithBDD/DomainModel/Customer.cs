using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public bool Active { get; set; }
        public Customer() { }
        public Customer(string firstName,string lastName,DateTime dateOfBirth,string phoneNumber,
            string email,string bankAcountNumber,bool active)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAcountNumber;
            Active = active;
        }
        public Customer(string firstName,string lastName,DateTime dateOfBirth,string phoneNumber,
            string email,string bankAcountNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAcountNumber;
            Active = true;
        }
        public Customer(Guid id,string firstName,string lastName,DateTime dateOfBirth,string phoneNumber,
            string email,string bankAcountNumber,bool active)
        {
            Id =id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAcountNumber;
            Active = active;
        }
        public Customer(Guid id,string firstName,string lastName,DateTime dateOfBirth,string phoneNumber,
            string email,string bankAcountNumber)
        {
            Id =id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAcountNumber;
            Active = true;
        }
    }
}
