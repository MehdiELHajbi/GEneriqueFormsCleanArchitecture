using EntityFrameworkCore.Generator.Metadata.Generation;

namespace EntityFrameworkCore.Generator.Templates
{
    public class RepositoryEntityTemplate : CodeTemplateBase
    {
        private readonly Entity _entity;

        public RepositoryEntityTemplate(Entity entity) : base()
        {
            _entity = entity;
        }





        public override string WriteCode()
        {
            CodeBuilder.Clear();

            CodeBuilder.AppendLine("using Application.Contracts;");
            CodeBuilder.AppendLine("using Domain.Entites;");

            CodeBuilder.AppendLine();

            var extensionNamespace = "Persistence.Repositories";

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
            var entityClass = _entity.EntityClass + "Repository";
            string safeName = _entity.EntityNamespace + "." + entityClass;

            //if (Options.Data.Query.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Query extensions for entity <see cref=\"{safeName}\" />.");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}

            CodeBuilder.AppendLine($"public class {entityClass} : BaseRepository<{_entity.EntityClass}>, I{_entity.EntityClass}Repository");
            CodeBuilder.AppendLine("{");

            GenerateConstructor();

            CodeBuilder.AppendLine("}");

        }

        private void GenerateConstructor()
        {
            var entityClass = _entity.EntityClass + "Repository";
            string safeName = _entity.EntityNamespace + "." + entityClass;

            //if (Options.Data.Query.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Query extensions for entity <see cref=\"{safeName}\" />.");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}

            CodeBuilder.AppendLine($"public {entityClass}({_entity.Context.ContextClass} dbContext) : base(dbContext)");
            CodeBuilder.AppendLine("{");

            CodeBuilder.AppendLine("}");

        }

    }
}
