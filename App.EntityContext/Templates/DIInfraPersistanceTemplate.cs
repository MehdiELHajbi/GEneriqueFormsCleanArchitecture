using EntityFrameworkCore.Generator.Metadata.Generation;

namespace EntityFrameworkCore.Generator.Templates
{
    public class DIInfraPersistanceTemplate : CodeTemplateBase
    {
        private readonly Entity _entity;

        public DIInfraPersistanceTemplate(Entity entity) : base()
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

            CodeBuilder.AppendLine($"public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)");
            CodeBuilder.AppendLine("{");
            CodeBuilder.AppendLine($"services.AddDbContext<{_entity.Context.ContextClass}>(options =>");
            CodeBuilder.AppendLine("       options.UseSqlServer(configuration.GetConnectionString(\"ApplicationConnectionString\")));");

            CodeBuilder.AppendLine("");
            CodeBuilder.AppendLine("services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));");


            GenerateRepository();
            CodeBuilder.AppendLine("return services;");


            CodeBuilder.AppendLine("}");

        }

        private void GenerateRepository()
        {

            foreach (var en in _entity.Context.Entities)
            {
                CodeBuilder.AppendLine($" services.AddScoped<I{en.EntityClass}Repository, {en.EntityClass}Repository>();");
                CodeBuilder.AppendLine("");

            }


        }

    }
}
