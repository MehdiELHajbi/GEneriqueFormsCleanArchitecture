using System;
using FluentValidation;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Validation
{
    public partial class DataBaseCreateModelValidator
        : AbstractValidator<DataBaseCreateModel>
    {
        public DataBaseCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.NameDataBase).NotEmpty();
            RuleFor(p => p.NameDataBase).MaximumLength(50);
            RuleFor(p => p.ConnetionName).MaximumLength(50);
            RuleFor(p => p.ConnectionString).MaximumLength(50);
            RuleFor(p => p.TypeDataBase).MaximumLength(50);
            #endregion
        }

    }
}
