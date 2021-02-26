using EntityFrameworkCore.Generator.Extensions;
using EntityFrameworkCore.Generator.Metadata.Generation;

namespace EntityFrameworkCore.Generator.Templates
{
    public class CommandTemplate : CodeTemplateBase
    {
        private readonly Entity _entity;
        private readonly ModelType _crudType;
        private readonly string nameType;

        public CommandTemplate(Entity entity, ModelType CrudType) : base()
        {
            _entity = entity;
            nameType = CrudType.ToString();
            _crudType = CrudType;
        }





        public override string WriteCode()
        {
            CodeBuilder.Clear();
            CodeBuilder.AppendLine("using Application.Features.Common.BaseResponse;");
            CodeBuilder.AppendLine("using MediatR;");


            CodeBuilder.AppendLine();

            var extensionNamespace = "Application.Features." + _entity.EntityClass + ".Commands." + nameType;

            CodeBuilder.AppendLine($"namespace {extensionNamespace}");
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
            var entityClass = nameType + _entity.EntityClass + "Command";
            string safeName = _entity.EntityNamespace + "." + entityClass;

            //if (Options.Data.Query.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Query extensions for entity <see cref=\"{safeName}\" />.");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}
            CodeBuilder.AppendLine($"public class {entityClass} : IRequest<{_entity.EntityClass}>");
            CodeBuilder.AppendLine("{");


            CodeBuilder.AppendLine("}");


            GenerateProperties();


            CodeBuilder.AppendLine("}");

        }

        private void GenerateProperties()
        {
            CodeBuilder.AppendLine("#region Generated Properties");
            foreach (var property in _entity.Properties)
            {
                var propertyType = property.SystemType.ToNullableType(property.IsNullable == true);
                var propertyName = property.PropertyName;


                //CodeBuilder.AppendLine("/// <summary>");
                //CodeBuilder.AppendLine($"/// Gets or sets the property value representing column '{property.ColumnName}'.");
                //CodeBuilder.AppendLine("/// </summary>");
                //CodeBuilder.AppendLine("/// <value>");
                //CodeBuilder.AppendLine($"/// The property value representing column '{property.ColumnName}'.");
                //CodeBuilder.AppendLine("/// </value>");


                CodeBuilder.AppendLine($"public {propertyType} {propertyName} {{ get; set; }}");
                CodeBuilder.AppendLine();
            }
            CodeBuilder.AppendLine("#endregion");
            CodeBuilder.AppendLine();
        }


    }
}
