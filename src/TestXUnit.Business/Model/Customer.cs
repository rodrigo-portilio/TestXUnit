using System;
using FluentValidation;

namespace TestXUnit.Business.Model
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Email { get; private set; }

        public Customer(Guid id, string firstName, string lastName, DateTime createdDate, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = createdDate;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please, make sure you have inserted the FirstName")
                .Length(2, 150).WithMessage("The FirstName must be between 2 and 150 characters");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please, make sure you have inserted the LastName")
                .Length(2, 100).WithMessage("The LastName must be between 2 and 150 characters");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
