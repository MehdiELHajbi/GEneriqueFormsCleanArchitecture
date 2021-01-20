using FluentValidation;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBesesValidator : AbstractValidator<CreateDataBesesCommand>
    {
        public CreateDataBesesValidator()
        {
            RuleFor(p => p.NameDataBase)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.TypeDataBase)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }

    }
}
