using System;
using System.Collections.Generic;
using TemplateTT4.Core;
using TemplateTT4.Entities;

namespace TemplateTT4.Constants
{

    public static class LocationConstants
    {
        static Dictionary<Type, string> _typeAlias = new Dictionary<Type, string>
            {
                { typeof(bool), "bool" },
                { typeof(byte), "byte" },
                { typeof(char), "char" },
                { typeof(decimal), "decimal" },
                { typeof(double), "double" },
                { typeof(float), "float" },
                { typeof(int), "int" },
                { typeof(long), "long" },
                { typeof(object), "object" },
                { typeof(sbyte), "sbyte" },
                { typeof(short), "short" },
                { typeof(string), "string" },
                { typeof(uint), "uint" },
                { typeof(ulong), "ulong" },
                { typeof(IList<>), "IList" },
                
                // Yes, this is an odd one.  Technically it's a type though.
                { typeof(void), "void" }
            };
        private static Type itemType;

        static string TypeNameOrAlias(Type type)
        {
            // Lookup alias for type
            if (_typeAlias.TryGetValue(type, out string alias))
                return alias;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
                itemType = type.GetGenericArguments()[0];
            // Default to CLR type name
            return type.ToString();
        }


        private static string GetNamsSpace(CleanArchitectureStructure cleanArchitectureStructure)
        {
            return cleanArchitectureStructure.Feature + "." +
                    cleanArchitectureStructure.FeatureType + "." +
                    cleanArchitectureStructure.FeatureCommande;
        }
        private static string GetUsing<T>() where T : class
        {
            var prop = CleanArchitectureStructureExtension.GetNameProperty<T>();

            var cnt = "";
            foreach (var propertyInfo in prop)
            {
                cnt = cnt + @"using  " + propertyInfo.Value.Namespace
                           + @"
                            ";
            }
            return cnt;
        }
        private static string GeTProertiesContent<T>() where T : class
        {
            var prop = CleanArchitectureStructureExtension.GetNameProperty<T>();
            var cnt = "";
            foreach (var propertyInfo in prop)
            {
                cnt = cnt + @"public " + TypeNameOrAlias(propertyInfo.Value) + @"  " + propertyInfo.Key + @" { get; set; } "
                           + @"
                            ";
            }
            return cnt;
        }


        public static string GetCommandContent(this CleanArchitectureStructure cleanArchitectureStructure)
        {

            return @"using Application.Features.Common.BaseResponse;
                     using MediatR;
                        " + GetUsing<DataBase>() + @"
                      namespace Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @"
                       {
                           public class " + cleanArchitectureStructure.commandName + @" : IRequest<ResponseAbstract>
                            {
                                        " + GeTProertiesContent<DataBase>() + @"           
                            }
                      }";
        }

        public static string GetCommandHandlerContent(this CleanArchitectureStructure cleanArchitectureStructure)
        {
            ClassConfig classConfig = new ClassConfig();

            return @"using Application.Contracts;
                    using Application.Features.Common.BaseResponse;
                    using AutoMapper;
                    using MediatR;
                    using Newtonsoft.Json;
                    using System.Threading;
                    using System.Threading.Tasks;

                    namespace Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @"
                    {
                        public class " + cleanArchitectureStructure.CommandHandlerName + @" : IRequestHandler<" + cleanArchitectureStructure.commandName + @", ResponseAbstract>
                        {
                            private readonly IDataBaseRepository _dataBaseRepository;
                            private readonly IMapper _mapper;

                            public CreateDataBesesCommandHandler(IMapper mapper, IDataBaseRepository dataBaseRepository)
                            {
                                _mapper = mapper;
                                _dataBaseRepository = dataBaseRepository;
                            }
                            public async Task<ResponseAbstract> Handle(" + cleanArchitectureStructure.commandName + @" request, CancellationToken cancellationToken)
                            {

                                var ctx = new Context();
                               
                                // Do A Job

                                return ctx.ResponseAbstract;
                            }
                            }
                        }";
        }

        public static string GetValidatorContent(this CleanArchitectureStructure cleanArchitectureStructure)
        {
            ClassConfig classConfig = new ClassConfig();

            return @"using FluentValidation;

                    namespace Application.Features" + GetNamsSpace(cleanArchitectureStructure) + @"
                    {
                        public class " + cleanArchitectureStructure.ValidatorName + @" : AbstractValidator<" + cleanArchitectureStructure.commandName + @">
                        {

                            public " + cleanArchitectureStructure.ValidatorName + @"()
                            {

                                 // Do Job 
                                 // -- Example
                                        //var c = RuleFor(p => p.NameDataBase)
                                        //    .NotEmpty().WithMessage(""{ PropertyName} is required."")
                                        //     .NotNull()
                                        //     .MaximumLength(50).WithMessage(""{PropertyName} must not exceed 10 characters."");


                            }

                        }
                    }
                    ";
        }


        public static string GetExpetionResponseContent(this CleanArchitectureStructure cleanArchitectureStructure, string resName)
        {
            ClassConfig classConfig = new ClassConfig();

            return @"using Application.Features.Common.BaseResponse;

                    namespace Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @".Responses.KO
                    {
                        public class " + resName + @"  : KoObject<string>
                        {
                            public " + resName + @"(string msg)
                               : base(msg, "")
                            {
                            }
                        }
                    }
                    ";
        }


        public static string GetSuccesResponseContent(this CleanArchitectureStructure cleanArchitectureStructure, string resName)
        {
            ClassConfig classConfig = new ClassConfig();

            return @"using Application.Features.Common.BaseResponse;
                    namespace Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @".Responses.OK
                    {
                        public class " + resName + @" : OkObject
                        {
                            public " + resName + @"(string msg) : base(msg)
                            {

                            }
                        }
                    }
                                        ";
        }


        #region NameOfResponse
        public static string GetOneOfNameContent(this CleanArchitectureStructure cleanArchitectureStructure)
        {
            ClassConfig classConfig = new ClassConfig();

            return @"using Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @".Responses.KO;
                     using Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @".Responses.OK;

                    namespace Application.Features." + GetNamsSpace(cleanArchitectureStructure) + @".Responses.DocumentationAPI
                    {
                        public class " + cleanArchitectureStructure.OneOfNameResponseName + @" 
                        {
                            #region OK
                            " + GetResponseSuccees(cleanArchitectureStructure.Repsonse) + @" 

                            #endregion

                            #region KO
                            " + GetResponseFalid(cleanArchitectureStructure.Repsonse) + @" 
                            #endregion
                        }
                    }"
        ;
        }

        private static string GetResponseSuccees(Response response)
        {
            string cnt = @"";
            foreach (var res in response.SuccesResponse)
            {
                cnt = cnt + @"public " + res + @"  " + res + @"{ get; set; }";

            }
            return cnt;
        }
        private static string GetResponseFalid(Response response)
        {
            string cnt = @"";
            foreach (var res in response.ExceptionResponse)
            {
                cnt = cnt + @"public " + res + @"  " + res + @"{ get; set; }";

            }
            return cnt;
        }
        #endregion

    }

    public class ClassConfig
    {
        public string UsingStatment { get; set; }
        public string NamespaceStatment { get; set; }
        public string NameClass { get; set; }
        public string Ctor { get; set; }
        public string Injection { get; set; }
        public string Heritage { get; set; }


        public string GetContent()
        {
            return @"" + UsingStatment + @"

                      namespace " + NamespaceStatment + @"
                       {
                           public class " + NamespaceStatment + @" : " + Heritage + @"
                            {
                                                   
                            }
                      }";
        }

    }
}
