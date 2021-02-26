using EntityFrameworkCore.Generator.Metadata.Generation;
using System.Linq;

namespace EntityFrameworkCore.Generator.Templates
{
    public class DataContextTemplate : CodeTemplateBase
    {
        private readonly EntityContexts _entityContext;

        public DataContextTemplate(EntityContexts entityContext) : base()
        {
            _entityContext = entityContext;
        }

        public override string WriteCode()
        {
            CodeBuilder.Clear();

            CodeBuilder.AppendLine("using System;");
            CodeBuilder.AppendLine("using Microsoft.EntityFrameworkCore;");
            CodeBuilder.AppendLine("using Microsoft.EntityFrameworkCore.Metadata;");
            CodeBuilder.AppendLine();

            CodeBuilder.AppendLine($"namespace {_entityContext.ContextNamespace}");
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
            var contextClass = _entityContext.ContextClass;
            var baseClass = _entityContext.ContextBaseClass;


            //CodeBuilder.AppendLine("/// <summary>");
            //CodeBuilder.AppendLine("/// A <see cref=\"DbContext\" /> instance represents a session with the database and can be used to query and save instances of entities. ");
            //CodeBuilder.AppendLine("/// </summary>");


            CodeBuilder.AppendLine($"public partial class {contextClass} : {baseClass}");
            CodeBuilder.AppendLine("{");

            using (CodeBuilder.Indent())
            {
                GenerateConstructors();
                GenerateDbSets();
                GenerateOnConfiguring();
                GenerateSaveChange();
            }

            CodeBuilder.AppendLine("}");


        }
        private void GenerateSaveChange()
        {
            var contextName = _entityContext.ContextClass;


            //CodeBuilder.AppendLine("/// <summary>");
            //CodeBuilder.AppendLine($"/// Initializes a new instance of the <see cref=\"{contextName}\"/> class.");
            //CodeBuilder.AppendLine("/// </summary>");
            //CodeBuilder.AppendLine("/// <param name=\"options\">The options to be used by this <see cref=\"DbContext\" />.</param>");
            CodeBuilder.AppendLine("#region Generate SaveChange");
            CodeBuilder.AppendLine($"public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())");
            CodeBuilder.AppendLine("{");
            CodeBuilder.AppendLine("foreach (var entry in ChangeTracker.Entries<AuditableEntity>())");
            CodeBuilder.AppendLine("{");
            CodeBuilder.AppendLine("switch (entry.State)");
            CodeBuilder.AppendLine("{");
            CodeBuilder.AppendLine($"case EntityState.Added:");
            CodeBuilder.AppendLine($"entry.Entity.Created = DateTime.Now;");
            CodeBuilder.AppendLine($"break;");
            CodeBuilder.AppendLine($"case EntityState.Modified:");
            CodeBuilder.AppendLine($"entry.Entity.LastModified = DateTime.Now;");
            CodeBuilder.AppendLine($"break;");
            CodeBuilder.AppendLine("}");
            CodeBuilder.AppendLine("}");
            CodeBuilder.AppendLine($"return base.SaveChangesAsync(cancellationToken); ");
            CodeBuilder.AppendLine("}");
            CodeBuilder.AppendLine("#endregion");

        }

        private void GenerateConstructors()
        {
            var contextName = _entityContext.ContextClass;


            CodeBuilder.AppendLine("/// <summary>");
            CodeBuilder.AppendLine($"/// Initializes a new instance of the <see cref=\"{contextName}\"/> class.");
            CodeBuilder.AppendLine("/// </summary>");
            CodeBuilder.AppendLine("/// <param name=\"options\">The options to be used by this <see cref=\"DbContext\" />.</param>");


            CodeBuilder.AppendLine($"public {contextName}(DbContextOptions<{contextName}> options)")
                .IncrementIndent()
                .AppendLine(": base(options)")
                .DecrementIndent()
                .AppendLine("{")
                .AppendLine("}")
                .AppendLine();
        }

        private void GenerateDbSets()
        {
            CodeBuilder.AppendLine("#region Generated Properties");
            foreach (var entityType in _entityContext.Entities.OrderBy(e => e.ContextProperty))
            {
                var entityClass = entityType.EntityClass;
                var propertyName = entityType.ContextProperty;
                var fullName = $"{entityType.EntityNamespace}.{entityClass}";


                //CodeBuilder.AppendLine("/// <summary>");
                //CodeBuilder.AppendLine($"/// Gets or sets the <see cref=\"T:Microsoft.EntityFrameworkCore.DbSet`1\" /> that can be used to query and save instances of <see cref=\"{fullName}\"/>.");
                //CodeBuilder.AppendLine("/// </summary>");
                //CodeBuilder.AppendLine("/// <value>");
                //CodeBuilder.AppendLine($"/// The <see cref=\"T:Microsoft.EntityFrameworkCore.DbSet`1\" /> that can be used to query and save instances of <see cref=\"{fullName}\"/>.");
                //CodeBuilder.AppendLine("/// </value>");


                CodeBuilder.AppendLine($"public virtual DbSet<{fullName}> {propertyName} {{ get; set; }}");
                CodeBuilder.AppendLine();
            }

            CodeBuilder.AppendLine("#endregion");

            if (_entityContext.Entities.Any())
                CodeBuilder.AppendLine();
        }

        private void GenerateOnConfiguring()
        {

            //CodeBuilder.AppendLine("/// <summary>");
            //CodeBuilder.AppendLine("/// Configure the model that was discovered from the entity types exposed in <see cref=\"T:Microsoft.EntityFrameworkCore.DbSet`1\" /> properties on this context.");
            //CodeBuilder.AppendLine("/// </summary>");
            //CodeBuilder.AppendLine("/// <param name=\"modelBuilder\">The builder being used to construct the model for this context.</param>");


            CodeBuilder.AppendLine("protected override void OnModelCreating(ModelBuilder modelBuilder)");
            CodeBuilder.AppendLine("{");

            using (CodeBuilder.Indent())
            {
                CodeBuilder.AppendLine("#region Generated Configuration");
                foreach (var entityType in _entityContext.Entities.OrderBy(e => e.ConfigureClass))
                {
                    var mappingClass = entityType.ConfigureClass;

                    CodeBuilder.AppendLine($"modelBuilder.ApplyConfiguration(new {entityType.ConfigureNamespace}.{mappingClass}());");
                }

                CodeBuilder.AppendLine("#endregion");
            }

            CodeBuilder.AppendLine("}");
        }
    }
}
