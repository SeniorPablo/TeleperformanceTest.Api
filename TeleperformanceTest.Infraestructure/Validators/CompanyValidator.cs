using FluentValidation;
using TeleperformanceTest.Core.DTOs;

namespace TeleperformanceTest.Infraestructure.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            //RuleFor(c => c.IdentificationNumber)
            //    .NotNull()
            //    .WithMessage("El número de identificación es obligatorio.");

            RuleFor(c => c.IdentificationTypeId)
                .NotNull()
                .WithMessage("El tipo de identificación es obligatorio.");
        }
    }
}
