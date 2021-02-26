using System;
using FluentValidation;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Validation
{
    public partial class FieldsCreateModelValidator
        : AbstractValidator<FieldsCreateModel>
    {
        public FieldsCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.FieldFriendlyName).NotEmpty();
            RuleFor(p => p.FieldFriendlyName).MaximumLength(50);
            RuleFor(p => p.FieldName).NotEmpty();
            RuleFor(p => p.FieldName).MaximumLength(50);
            RuleFor(p => p.Type).NotEmpty();
            RuleFor(p => p.Type).MaximumLength(50);
            RuleFor(p => p.RelationValue).MaximumLength(50);
            #endregion
        }

    }
}
