using FluentValidation;

namespace Application.Features.DataBases.Commands.Update
{
    public class UpdateDataBesesCommandValidator : AbstractValidator<UpdateDataBesesCommand>
    {
        public UpdateDataBesesCommandValidator()
        {
            RuleFor(p => p.NameDataBase)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }

    }
}
