using FluentValidation;
using Hahn.Application.Domain.Models;

namespace Hahn.Application.Web.Helpers.ModelValidations
{
    public class CandidateValidator : AbstractValidator<CandidateModel>
    {
        public CandidateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                            .WithMessage("Name is required")
                            .MinimumLength(5).WithMessage("Name length must be at least 5 Character long.");
            RuleFor(x => x.LastName).NotEmpty()
                    .WithMessage("Last Name is required")
                    .MinimumLength(5).WithMessage("FamilyName length must be at least 5 Character long.");
            RuleFor(x => x.DateOfBirth).NotEmpty()
                          .WithMessage("Name is required");
            RuleFor(x => x.PhoneNumber).NotEmpty()
                    .WithMessage("Last Name is required");
            RuleFor(x => x.JobOptionId).NotEmpty()
                    .WithMessage("Last Name is required");
            RuleFor(x => x.Address).NotEmpty()
                    .WithMessage("Address is required")
                    .MinimumLength(10).WithMessage("Address length must be at least 10 Character long.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                         .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.CountryOfOrigin).NotEmpty().WithMessage($"CountryOfOrigin required");
        }


    }
}
