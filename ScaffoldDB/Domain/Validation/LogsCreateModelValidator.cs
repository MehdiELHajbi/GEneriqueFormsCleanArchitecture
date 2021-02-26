using System;
using FluentValidation;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Validation
{
    public partial class LogsCreateModelValidator
        : AbstractValidator<LogsCreateModel>
    {
        public LogsCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
