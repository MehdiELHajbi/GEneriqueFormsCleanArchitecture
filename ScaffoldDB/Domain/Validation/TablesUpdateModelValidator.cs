using System;
using FluentValidation;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Validation
{
    public partial class TablesUpdateModelValidator
        : AbstractValidator<TablesUpdateModel>
    {
        public TablesUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.ObjName).NotEmpty();
            RuleFor(p => p.ObjName).MaximumLength(50);
            RuleFor(p => p.ObjFriendlyName).NotEmpty();
            RuleFor(p => p.ObjFriendlyName).MaximumLength(50);
            #endregion
        }

    }
}
