using FluentValidation;
using Hahn.Application.Domain.Models;

namespace Hahn.Application.Web.Helpers.ModelValidations
{
    public class JobOptionValidator : AbstractValidator<JobOptionModel>
    {
        public JobOptionValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                       .WithMessage("Name is required");


        }
    }
}
