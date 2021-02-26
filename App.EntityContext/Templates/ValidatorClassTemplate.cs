using EntityFrameworkCore.Generator.Extensions;
using EntityFrameworkCore.Generator.Metadata.Generation;

namespace EntityFrameworkCore.Generator.Templates
{
    public class ValidatorClassTemplate : CodeTemplateBase
    {
        private readonly Entity _entity;
        private readonly ModelType _crudType;
        private readonly string nameType;

        public ValidatorClassTemplate(Entity entity, ModelType CrudType) : base()
        {
            _entity = entity;
            nameType = CrudType.ToString();
            _crudType = CrudType;
        }

        public override string WriteCode()
        {
            CodeBuilder.Clear();

            CodeBuilder.AppendLine("using System;");
            CodeBuilder.AppendLine("using FluentValidation;");




            CodeBuilder.AppendLine();

            CodeBuilder.AppendLine($"namespace Application.Features.{_entity.EntityClass}Commands.{nameType}");
            CodeBuilder.AppendLine("{");

            using (CodeBuilder.Indent())
            {
                GenerateClass();
            }

            CodeBuilder.AppendLine("}");

            return CodeBuilder.ToString();
        }

        private void GenerateClass()
        {
            var validatorClass = $"{nameType}{_entity.EntityClass}CommandValidator";

            //if (Options.entity.Validator.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Validator class for <see cref=\"{entityClass}\"/> .");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}

            CodeBuilder.AppendLine($"public partial class {validatorClass} : AbstractValidator<{nameType}{_entity.EntityClass}Command> ");


            CodeBuilder.AppendLine("{");

            using (CodeBuilder.Indent())
            {
                GenerateConstructor();
            }

            CodeBuilder.AppendLine("}");
        }

        private void GenerateConstructor()
        {
            var validatorClass = $"{nameType}{_entity.EntityClass}CommandValidator";


            //if (Options.entity.Validator.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Initializes a new instance of the <see cref=\"{validatorClass}\"/> class.");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}

            CodeBuilder.AppendLine($"public {validatorClass}()");
            CodeBuilder.AppendLine("{");

            using (CodeBuilder.Indent())
            {
                CodeBuilder.AppendLine("#region Generated Constructor");
                foreach (var property in _entity.Properties)
                {
                    if (property.ValueGenerated.HasValue)
                        continue;

                    var propertyName = property.PropertyName.ToSafeName();

                    if (property.IsRequired && property.SystemType == typeof(string))
                    {
                        CodeBuilder.AppendLine($"RuleFor(p => p.{propertyName})");
                        CodeBuilder.AppendLine($"       .NotEmpty().WithMessage(\"{propertyName} is required.\");");

                    }
                    if (property.Size.HasValue && property.SystemType == typeof(string))
                    {
                        if (!property.IsRequired)
                            CodeBuilder.AppendLine($"RuleFor(p => p.{propertyName})");

                        CodeBuilder.AppendLine($"       .MaximumLength({property.Size}).WithMessage(\"{ propertyName} must not exceed {property.Size} characters.\");");

                    }

                }
                CodeBuilder.AppendLine("#endregion");
            }

            CodeBuilder.AppendLine("}");
            CodeBuilder.AppendLine();
        }

    }
}
