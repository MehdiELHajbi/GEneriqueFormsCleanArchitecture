using EntityFrameworkCore.Generator.Metadata.Generation;
using System.Linq;

namespace EntityFrameworkCore.Generator.Templates
{
    public class HandlerTemplate : CodeTemplateBase
    {
        private readonly Entity _entity;
        private readonly ModelType _crudType;
        private readonly string nameType;

        public HandlerTemplate(Entity entity, ModelType CrudType) : base()
        {
            _entity = entity;
            _crudType = CrudType;
            nameType = CrudType.ToString();
        }





        public override string WriteCode()
        {
            CodeBuilder.Clear();
            CodeBuilder.AppendLine("using Application.Contracts;");
            CodeBuilder.AppendLine("using Application.Features.Common.BaseResponse;");
            CodeBuilder.AppendLine("using AutoMapper;");
            CodeBuilder.AppendLine("using MediatR;");
            CodeBuilder.AppendLine("using Newtonsoft.Json;");
            CodeBuilder.AppendLine("using System.Threading;");
            CodeBuilder.AppendLine("using System.Threading.Tasks;");
            CodeBuilder.AppendLine($"using {_entity.EntityClass}.Data.Entities");

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

        private void GenerateProperty()
        {
            CodeBuilder.AppendLine($" private readonly I{_entity.EntityClass}Repository _{_entity.EntityClass}Repository;");
            CodeBuilder.AppendLine($"private readonly IMapper _mapper;");
        }

        private void GenerateConstructor()
        {
            CodeBuilder.AppendLine($" public {nameType}{_entity.EntityClass}CommandHandler(IMapper mapper, I{_entity.EntityClass}Repository {_entity.EntityClass}Repository)");
            CodeBuilder.AppendLine("{");
            CodeBuilder.AppendLine($" _mapper = mapper;");
            CodeBuilder.AppendLine($" _{_entity.EntityClass}Repository = {_entity.EntityClass}Repository;");
            CodeBuilder.AppendLine(" }");

        }

        private void GenerateHandel()
        {
            if (_crudType == ModelType.Delete)
                CodeBuilder.AppendLine($" public async Task<Unit> Handle({nameType}{_entity.EntityClass}Command request, CancellationToken cancellationToken)");
            else
                CodeBuilder.AppendLine($" public async Task<{_entity.EntityClass}> Handle({nameType}{_entity.EntityClass}Command request, CancellationToken cancellationToken)");

            CodeBuilder.AppendLine("{");

            if (_crudType == ModelType.Read)
            {
                CodeBuilder.AppendLine($" var response = await _{_entity.EntityClass}Repository.GetMuliple();");
                CodeBuilder.AppendLine($" return  response;");
            }

            if (_crudType == ModelType.Create)
            {
                CodeBuilder.AppendLine($" var response = await _{_entity.EntityClass}Repository.AddAsync(request);");
                CodeBuilder.AppendLine($" return  response;");
            }

            if (_crudType == ModelType.Update)
            {
                var KeyTable = _entity.Properties.PrimaryKeys?.FirstOrDefault();
                if (KeyTable != null)
                {
                    CodeBuilder.AppendLine($"var entity = await _{_entity.EntityClass}Repository.GetByIdAsync(request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine($"if (entity == null)");
                    CodeBuilder.AppendLine("{");
                    CodeBuilder.AppendLine($" throw new NotFoundException(nameof({_entity.EntityClass}), request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine("}");
                    CodeBuilder.AppendLine($"  await _{_entity.EntityClass}Repository.UpdateAsync(request);");
                    CodeBuilder.AppendLine($"var response = await _{_entity.EntityClass}Repository.GetByIdAsync(request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine($" return  response;");

                }

            }
            if (_crudType == ModelType.Delete)
            {
                var KeyTable = _entity.Properties.PrimaryKeys?.FirstOrDefault();
                if (KeyTable != null)
                {
                    CodeBuilder.AppendLine($"var entity = await _{_entity.EntityClass}Repository.GetByIdAsync(request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine($"if (entity == null)");
                    CodeBuilder.AppendLine("{");
                    CodeBuilder.AppendLine($" throw new NotFoundException(nameof({_entity.EntityClass}), request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine("}");
                    CodeBuilder.AppendLine($"  await _{_entity.EntityClass}Repository.DeleteAsync(request);");
                    CodeBuilder.AppendLine($"var response = await _{_entity.EntityClass}Repository.GetByIdAsync(request.{KeyTable.PropertyName});");
                    CodeBuilder.AppendLine($"return Unit.Value;");
                }

            }


            CodeBuilder.AppendLine(" }");

        }
        private void GenerateClass()
        {
            var entityClass = nameType + _entity.EntityClass + "CommandHandler";
            string safeName = _entity.EntityNamespace + "." + entityClass;

            //if (Options.Data.Query.Document)
            //{
            //    CodeBuilder.AppendLine("/// <summary>");
            //    CodeBuilder.AppendLine($"/// Query extensions for entity <see cref=\"{safeName}\" />.");
            //    CodeBuilder.AppendLine("/// </summary>");
            //}


            CodeBuilder.AppendLine($"public class {entityClass} : IRequestHandler<{nameType}{_entity.EntityClass}Command, {_entity.EntityClass}>");


            CodeBuilder.AppendLine("{");
            GenerateProperty();
            GenerateConstructor();
            GenerateHandel();
            CodeBuilder.AppendLine("}");





        }



    }
}
