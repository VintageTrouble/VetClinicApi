using FluentValidation;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private DateTime _maxYears = DateTime.Now.AddYears(-150);
        private DateTime _end = DateTime.Now;
        private DateTime _ageRestriction = DateTime.Today.AddYears(-18);
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Must(FirstName => VerificationOnlyLatter(FirstName) == true)
                .WithMessage("The field must contain only letters and must not be empty");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .Must(lastName => VerificationOnlyLatter(lastName) == true)
                .WithMessage("The field must contain only letters and must not be empty");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"([8]|[+][7]) [(]\d{3}[)] \d{3}[-]\d{2}[-]\d{2}$")
                .WithMessage("The field must contain only digits and must not be empty");
            RuleFor(x => x.PassportNumber)
                .NotEmpty()
                .Matches(@"\d{4}[-]\d{6}")
                .WithMessage("The field must contain only digits and must not be empty");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .InclusiveBetween(_maxYears, _end)
                .LessThan(_ageRestriction);
        }

        private bool VerificationOnlyLatter(string property)
        {
            foreach (char c in property)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        protected bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
