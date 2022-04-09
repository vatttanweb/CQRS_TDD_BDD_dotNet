using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.Email).EmailAddress();
            RuleFor(customer => customer.PhoneNumber).Matches(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
            //other validation
        }
    }
}
