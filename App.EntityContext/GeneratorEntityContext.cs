﻿using DataBaseSchema;
using EntityFrameworkCore.Generator.Metadata.Generation;
using EntityFrameworkCore.Generator.Options;
using EntityFrameworkCore.Generator.Templates;
using EntityFrameworkCore.Schema.Extensions;
using EntityFrameWorkShema;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PropertyCollection = EntityFrameworkCore.Generator.Metadata.Generation.PropertyCollection;

namespace App.dd.project
{
    public static class GeneratorEntityContext
    {
        private static IRelationalTypeMappingSource _typeMapper;
        private static DatabaseOptions _databseOption;

        public static EntityContexts genrate(DatabaseOptions databseOption)
        {
            _databseOption = databseOption;
            var databaseModel = CommunicationService.GEtSchema(_databseOption);
            var databaseProviders = Shemadatabase.GetDatabaseProviders(_databseOption);

            // Build object context,entity..
            var context = Generate(databaseModel, databaseProviders.mapping);


            GenerateFiles(context);
            return context;
        }


        #region Genrate File
        private static void GenerateFiles(EntityContexts entityContext)
        {
            GenerateDataContext(entityContext);
            GenerateEntityClasses(entityContext);
            GenerateConfigureClasses(entityContext);
            GenerateIEntityRepository(entityContext);
            GenerateEntityRepository(entityContext);
            GenerateDIPersistance(entityContext);


            // Application
            GenerateIEntityRepository(entityContext);
            // Create
            GenerateCommandClass(entityContext, ModelType.Create);
            GenerateHandlerClass(entityContext, ModelType.Create);
            GenerateValidatorClasses(entityContext, ModelType.Create);

            // Update
            GenerateCommandClass(entityContext, ModelType.Update);
            GenerateHandlerClass(entityContext, ModelType.Update);
            GenerateValidatorClasses(entityContext, ModelType.Update);
            // Delete
            GenerateCommandClass(entityContext, ModelType.Delete);
            GenerateHandlerClass(entityContext, ModelType.Delete);
            GenerateValidatorClasses(entityContext, ModelType.Delete);
            // Read
            GenerateCommandClass(entityContext, ModelType.Read);
            GenerateHandlerClass(entityContext, ModelType.Read);
            GenerateValidatorClasses(entityContext, ModelType.Read);


            //GenerateModelClasses(entityContext);



        }

        private static void GenerateHandlerClass(EntityContexts entityContext, ModelType CrudType)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Application\\Features\\" + entity.EntityClass + "\\Commands\\" + CrudType;
                var file = CrudType + entity.EntityClass + "CommandHandler.cs";
                var path = Path.Combine(directory, file);



                var template = new HandlerTemplate(entity, CrudType);
                template.WriteCode(path);

            }
        }


        private static void GenerateCommandClass(EntityContexts entityContext, ModelType CrudType)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Application\\Features\\" + entity.EntityClass + "\\Commands\\" + CrudType;
                var file = CrudType + entity.EntityClass + "Command.cs";
                var path = Path.Combine(directory, file);



                var template = new CommandTemplate(entity, CrudType);
                template.WriteCode(path);

            }
        }

        private static void GenerateValidatorClasses(EntityContexts entityContext, ModelType CrudType)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Application\\Features\\" + entity.EntityClass + "\\Commands\\" + CrudType;
                var file = CrudType + entity.EntityClass + "CommandValidator.cs";

                var path = Path.Combine(directory, file);



                var template = new ValidatorClassTemplate(entity, CrudType);
                template.WriteCode(path);

            }
        }


        private static void GenerateDIPersistance(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Infrastructure\\Persistence";
                var file = "DependencyInjection.cs";
                var path = Path.Combine(directory, file);



                var template = new DIInfraPersistanceTemplate(entity);
                template.WriteCode(path);

            }
        }

        private static void GenerateEntityRepository(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Infrastructure\\Persistence\\Repositories";
                var file = entity.EntityClass + "Repository.cs";
                var path = Path.Combine(directory, file);



                var template = new RepositoryEntityTemplate(entity);
                template.WriteCode(path);

            }
        }
        private static void GenerateIEntityRepository(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Application\\Contracts\\Persistence";
                var file = "I" + entity.EntityClass + "Repository.cs";
                var path = Path.Combine(directory, file);



                var template = new IRepositoryEntityTemplate(entity);
                template.WriteCode(path);

            }
        }

        private static void GenerateQueryExtensions(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Data\\Query";
                var file = entity.EntityClass + "Extensions.cs";
                var path = Path.Combine(directory, file);



                var template = new QueryExtensionTemplate(entity);
                template.WriteCode(path);

            }
        }

        private static void GenerateConfigureClasses(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {
                var directory = _databseOption.Directory + "\\Infrastructure\\Persistence\\Configurations";
                var file = entity.ConfigureClass + ".cs";
                var path = Path.Combine(directory, file);



                var template = new ConfigureClassTemplate(entity);
                template.WriteCode(path);

            }
        }

        private static void GenerateDataContext(EntityContexts entityContext)
        {

            var directory = _databseOption.Directory + "\\Infrastructure\\Persistence";
            var file = entityContext.ContextClass + ".cs";
            var path = Path.Combine(directory, file);



            var template = new DataContextTemplate(entityContext);
            template.WriteCode(path);
        }

        private static void GenerateEntityClasses(EntityContexts entityContext)
        {
            foreach (var entity in entityContext.Entities)
            {

                var directory = _databseOption.Directory + "\\Domain\\Entities";
                var file = entity.EntityClass + ".cs";
                var path = Path.Combine(directory, file);



                var template = new EntityClassTemplate(entity);
                template.WriteCode(path);

            }
        }


        #endregion



        public static EntityContexts Generate(DatabaseModel databaseModel, IRelationalTypeMappingSource typeMappingSource)
        {
            if (databaseModel == null)
                throw new ArgumentNullException(nameof(databaseModel));

            _typeMapper = typeMappingSource;


            //---------------- ------------------ ---------------------
            //---------------- Creation Context ---------------------
            //---------------- ------------------ ---------------------
            var entityContext = new EntityContexts();
            entityContext.DatabaseName = databaseModel.DatabaseName;


            string contextNamespace = databaseModel.DatabaseName + ".Context";
            string contextBaseClass = "DbContext";

            entityContext.ContextClass = databaseModel.DatabaseName + "Context";
            entityContext.ContextNamespace = contextNamespace;
            entityContext.ContextBaseClass = contextBaseClass;


            //---------------- ------------------ ---------------------
            //---------------- For Each Table ---------------------
            //---------------- ------------------ ---------------------
            var tables = databaseModel.Tables;

            foreach (var table in tables)
            {
                if (IsIgnored(table, _databseOption.Exclude))
                {
                    continue;
                }


                var entity = GetEntity(entityContext, table);
                //GetModels(entity);
            }


            return entityContext;
        }



        private static Entity GetEntity(EntityContexts entityContext, DatabaseTable tableSchema, bool processRelationships = true, bool processMethods = true)
        {
            Entity entity = entityContext.Entities.ByTable(tableSchema.Name, tableSchema.Schema)
                ?? CreateEntity(entityContext, tableSchema);

            if (!entity.Properties.IsProcessed)
                CreateProperties(entity, tableSchema.Columns);

            if (processRelationships && !entity.Relationships.IsProcessed)
                CreateRelationships(entityContext, entity, tableSchema);

            if (processMethods && !entity.Methods.IsProcessed)
            {
                CreateMethodsPrimaryIndexForeinKey(entity, tableSchema);
                CreateMethodsByColumns(entity, tableSchema);
                CreateMethodsByAllColmns(entity, tableSchema);
                //CreateMethodsByColumns(entity, tableSchema.);
            }

            entity.IsProcessed = true;
            return entity;
        }

        private static Entity CreateEntity(EntityContexts entityContext, DatabaseTable tableSchema)
        {
            var entity = new Entity
            {
                Context = entityContext,
                TableName = tableSchema.Name,
                TableSchema = tableSchema.Schema

            };


            string entityClass = tableSchema.Name;
            if (entityClass.IsNullOrEmpty())
                entityClass = ToClassName(tableSchema.Name, tableSchema.Schema);

            //entityClass = _namer.UniqueClassName(entityClass);

            string entityNamespace = entityClass + ".Data.Entities";
            //string entiyBaseClass = _options.Data.Entity.BaseClass;

            //string commandName = _options.Cqrs.Read.Name;
            //commandName = _namer.UniqueClassName(commandName);
            //entity.CqrsClass = commandName;
            //entity.CqrsNamespace = _options.Cqrs.Read.Namespace;
            //entity.CqrsBaseClass = _options.Cqrs.Command.BaseClass;


            string mappingName = entityClass + "Configuration";
            //mappingName = _namer.UniqueClassName(mappingName);

            string mappingNamespace = entityClass + ".Data.Configuration";

            string contextName = ContextName(entityClass);
            contextName = ToPropertyName(entityContext.ContextClass, contextName);
            //contextName = _namer.UniqueContextName(contextName);

            entity.EntityClass = entityClass;
            entity.EntityNamespace = entityNamespace;
            //entity.EntityBaseClass = entiyBaseClass;

            entity.ConfigureClass = mappingName;
            entity.ConfigureNamespace = mappingNamespace;

            entity.ContextProperty = contextName;

            entity.IsView = tableSchema is DatabaseView;

            entityContext.Entities.Add(entity);

            return entity;
        }


        private static void CreateProperties(Entity entity, IEnumerable<DatabaseColumn> columns)
        {
            foreach (var column in columns)
            {
                var table = column.Table;

                var mapping = _typeMapper.FindMapping(column.StoreType);
                if (mapping == null)
                {
                    //_logger.LogWarning("Failed to map type {storeType} for {column}.", column.StoreType, column.Name);
                    continue;
                }

                var property = entity.Properties.ByColumn(column.Name);

                if (property == null)
                {
                    property = new Property
                    {
                        Entity = entity,
                        ColumnName = column.Name
                    };
                    entity.Properties.Add(property);
                }

                string propertyName = ToPropertyName(entity.EntityClass, column.Name);
                //propertyName = _namer.UniqueName(entity.EntityClass, propertyName);

                property.PropertyName = propertyName;

                property.IsNullable = column.IsNullable;

                property.IsRowVersion = column.IsRowVersion();

                property.IsPrimaryKey = table.PrimaryKey?.Columns.Contains(column) == true;
                property.IsForeignKey = table.ForeignKeys.Any(c => c.Columns.Contains(column));

                property.IsUnique = table.UniqueConstraints.Any(c => c.Columns.Contains(column))
                    || table.Indexes.Where(i => i.IsUnique).Any(c => c.Columns.Contains(column));

                property.Default = column.DefaultValueSql;
                property.ValueGenerated = column.ValueGenerated;

                if (property.ValueGenerated == null && !string.IsNullOrWhiteSpace(column.ComputedColumnSql))
                    property.ValueGenerated = ValueGenerated.OnAddOrUpdate;

                property.StoreType = mapping.StoreType;
                property.NativeType = mapping.StoreTypeNameBase;
                property.DataType = mapping.DbType ?? DbType.AnsiString;
                property.SystemType = mapping.ClrType;
                property.Size = mapping.Size;

                property.IsProcessed = true;
            }

            entity.Properties.IsProcessed = true;
        }


        private static void CreateRelationships(EntityContexts entityContext, Entity entity, DatabaseTable tableSchema)
        {
            foreach (var foreignKey in tableSchema.ForeignKeys)
            {
                // skip relationship if principal table is ignored
                if (IsIgnored(foreignKey.PrincipalTable, _databseOption.Exclude))
                {
                    //_logger.LogDebug("  Skipping Relationship : {name}", foreignKey.Name);
                    continue;
                }

                CreateRelationship(entityContext, entity, foreignKey);
            }

            entity.Relationships.IsProcessed = true;
        }

        private static void CreateRelationship(EntityContexts entityContext, Entity foreignEntity, DatabaseForeignKey tableKeySchema)
        {
            Entity primaryEntity = GetEntity(entityContext, tableKeySchema.PrincipalTable, false, false);

            string primaryName = primaryEntity.EntityClass;
            string foreignName = foreignEntity.EntityClass;

            string relationshipName = tableKeySchema.Name;
            //relationshipName = _namer.UniqueRelationshipName(relationshipName);

            var foreignMembers = GetKeyMembers(foreignEntity, tableKeySchema.Columns, tableKeySchema.Name);
            bool foreignMembersRequired = foreignMembers.Any(c => c.IsRequired);

            var primaryMembers = GetKeyMembers(primaryEntity, tableKeySchema.PrincipalColumns, tableKeySchema.Name);
            bool primaryMembersRequired = primaryMembers.Any(c => c.IsRequired);

            // skip invalid fkeys
            if (foreignMembers.Count == 0 || primaryMembers.Count == 0)
                return;

            Relationship foreignRelationship = foreignEntity.Relationships
                .FirstOrDefault(r => r.RelationshipName == relationshipName && r.IsForeignKey);

            if (foreignRelationship == null)
            {
                foreignRelationship = new Relationship
                {
                    RelationshipName = relationshipName
                };
                foreignEntity.Relationships.Add(foreignRelationship);
            }
            foreignRelationship.IsMapped = true;
            foreignRelationship.IsForeignKey = true;
            foreignRelationship.Cardinality = foreignMembersRequired ? Cardinality.One : Cardinality.ZeroOrOne;

            foreignRelationship.PrimaryEntity = primaryEntity;
            foreignRelationship.PrimaryProperties = new PropertyCollection(primaryMembers);

            foreignRelationship.Entity = foreignEntity;
            foreignRelationship.Properties = new PropertyCollection(foreignMembers);

            string prefix = GetMemberPrefix(foreignRelationship, primaryName, foreignName);

            string foreignPropertyName = ToPropertyName(foreignEntity.EntityClass, prefix + primaryName);
            //foreignPropertyName = _namer.UniqueName(foreignEntity.EntityClass, foreignPropertyName);
            foreignRelationship.PropertyName = foreignPropertyName;

            // add reverse
            Relationship primaryRelationship = primaryEntity.Relationships
                .FirstOrDefault(r => r.RelationshipName == relationshipName && r.IsForeignKey == false);

            if (primaryRelationship == null)
            {
                primaryRelationship = new Relationship { RelationshipName = relationshipName };
                primaryEntity.Relationships.Add(primaryRelationship);
            }

            primaryRelationship.IsMapped = false;
            primaryRelationship.IsForeignKey = false;

            primaryRelationship.PrimaryEntity = foreignEntity;
            primaryRelationship.PrimaryProperties = new PropertyCollection(foreignMembers);

            primaryRelationship.Entity = primaryEntity;
            primaryRelationship.Properties = new PropertyCollection(primaryMembers);

            bool isOneToOne = IsOneToOne(tableKeySchema, foreignRelationship);
            if (isOneToOne)
                primaryRelationship.Cardinality = primaryMembersRequired ? Cardinality.One : Cardinality.ZeroOrOne;
            else
                primaryRelationship.Cardinality = Cardinality.Many;

            string primaryPropertyName = prefix + foreignName;
            if (!isOneToOne)
                primaryPropertyName = RelationshipName(primaryPropertyName);

            primaryPropertyName = ToPropertyName(primaryEntity.EntityClass, primaryPropertyName);
            //primaryPropertyName = _namer.UniqueName(primaryEntity.EntityClass, primaryPropertyName);

            primaryRelationship.PropertyName = primaryPropertyName;

            foreignRelationship.PrimaryPropertyName = primaryRelationship.PropertyName;
            foreignRelationship.PrimaryCardinality = primaryRelationship.Cardinality;

            primaryRelationship.PrimaryPropertyName = foreignRelationship.PropertyName;
            primaryRelationship.PrimaryCardinality = foreignRelationship.Cardinality;

            foreignRelationship.IsProcessed = true;
            primaryRelationship.IsProcessed = true;
        }

        private static void CreateMethodsByColumns(Entity entity, DatabaseTable tableSchema)
        {
            var tableSchemas = tableSchema.Columns.Where((item) => !tableSchema.PrimaryKey.Columns.Any((item2) => item.Name == item2.Name));
            Method method = new Method();
            foreach (var sch in tableSchemas)
            {
                method = GetMethodFromColumn(entity, sch);
                if (method != null)
                {
                    //method.IsKey = false;
                    //method.SourceName = tableSchema.PrimaryKey.Name;

                    if (entity.Methods.All(m => m.NameSuffix != method.NameSuffix))
                        entity.Methods.Add(method);
                }


                //GetIndexMethods(entity, tableSchema);

            }




            entity.Methods.IsProcessed = true;
        }
        private static void CreateMethodsByAllColmns(Entity entity, DatabaseTable tableSchema)
        {

            //tableSchema.Columns.Where((item) => !tableSchema.PrimaryKey.Columns.Any((item2) => item.Name == item2.Name));
            //var method = GetMethodFromColumns(entity, tableSchema.PrimaryKey.Columns);
            var method = GetMethodFromColumns(entity, tableSchema.Columns);
            if (method != null)
            {

                method.NameSuffix = "All" + tableSchema.Name;
                if (entity.Methods.All(m => m.NameSuffix != method.NameSuffix))
                    entity.Methods.Add(method);
            }



            entity.Methods.IsProcessed = true;
        }

        private static void CreateMethodsPrimaryIndexForeinKey(Entity entity, DatabaseTable tableSchema)
        {
            if (tableSchema.PrimaryKey != null)
            {
                //tableSchema.Columns.Where((item) => !tableSchema.PrimaryKey.Columns.Any((item2) => item.Name == item2.Name));
                var method = GetMethodFromColumns(entity, tableSchema.PrimaryKey.Columns);
                //var method = GetMethodFromColumns(entity, tableSchema.Columns);
                if (method != null)
                {
                    method.IsKey = true;
                    method.SourceName = tableSchema.PrimaryKey.Name;

                    if (entity.Methods.All(m => m.NameSuffix != method.NameSuffix))
                        entity.Methods.Add(method);
                }
            }

            GetIndexMethods(entity, tableSchema);
            GetForeignKeyMethods(entity, tableSchema);

            entity.Methods.IsProcessed = true;
        }

        private static void GetForeignKeyMethods(Entity entity, DatabaseTable table)
        {
            var columns = new List<DatabaseColumn>();

            foreach (var column in table.ForeignKeys.SelectMany(c => c.Columns))
            {
                columns.Add(column);

                var method = GetMethodFromColumns(entity, columns);
                if (method != null && entity.Methods.All(m => m.NameSuffix != method.NameSuffix))
                    entity.Methods.Add(method);

                columns.Clear();
            }
        }

        private static void GetIndexMethods(Entity entity, DatabaseTable table)
        {
            foreach (var index in table.Indexes)
            {
                var method = GetMethodFromColumns(entity, index.Columns);
                if (method == null)
                    continue;

                method.SourceName = index.Name;
                method.IsUnique = index.IsUnique;
                method.IsIndex = true;

                if (entity.Methods.All(m => m.NameSuffix != method.NameSuffix))
                    entity.Methods.Add(method);
            }
        }

        private static Method GetMethodFromColumn(Entity entity, DatabaseColumn column)
        {
            var method = new Method { Entity = entity };
            var methodName = new StringBuilder();


            var property = entity.Properties.ByColumn(column.Name);
            //if (property == null)
            //    return ;

            method.Properties.Add(property);
            methodName.Append(property.PropertyName);


            if (method.Properties.Count == 0)
                return null;

            method.NameSuffix = methodName.ToString();
            return method;
        }

        private static Method GetMethodFromColumns(Entity entity, IEnumerable<DatabaseColumn> columns)
        {
            var method = new Method { Entity = entity };
            var methodName = new StringBuilder();

            foreach (var column in columns)
            {
                var property = entity.Properties.ByColumn(column.Name);
                if (property == null)
                    continue;

                method.Properties.Add(property);
                methodName.Append(property.PropertyName);
            }

            if (method.Properties.Count == 0)
                return null;

            method.NameSuffix = methodName.ToString();
            return method;
        }


        //private static void GetModels(Entity entity)
        //{
        //    if (entity == null || entity.Models.IsProcessed)
        //        return;

        //    //_options.Variables.Set(entity);

        //    //if (_options.Model.Read.Generate)
        //        CreateModel(entity, _options.Model.Read, ModelType.Read);

        //    if (_options.Model.Create.Generate)
        //        CreateModel(entity, _options.Model.Create, ModelType.Create);
        //    if (_options.Model.Update.Generate)
        //        CreateModel(entity, _options.Model.Update, ModelType.Update);
        //    if (_options.Model.Delete.Generate)
        //        CreateModel(entity, _options.Model.Delete, ModelType.Delete);

        //    ///  Ajouter Command  XX
        //    if (_options.Model.ReadQuery.Generate)
        //        CreateModel(entity, _options.Model.ReadQuery, ModelType.QueryRead);
        //    if (_options.Model.CreateCommand.Generate)
        //        CreateModel(entity, _options.Model.CreateCommand, ModelType.CommandCreate);
        //    if (_options.Model.UpdateCommand.Generate)
        //        CreateModel(entity, _options.Model.UpdateCommand, ModelType.CommandUpdate);
        //    if (_options.Model.DeleteCommand.Generate)
        //        CreateModel(entity, _options.Model.DeleteCommand, ModelType.CommandDelete);

        //    // Handler
        //    if (_options.Model.ReadHandler.Generate)
        //        CreateModel(entity, _options.Model.ReadHandler, ModelType.HandlerQueryRead);
        //    if (_options.Model.CreateHandler.Generate)
        //        CreateModel(entity, _options.Model.CreateHandler, ModelType.HandlerCreate);
        //    if (_options.Model.UpdateHandler.Generate)
        //        CreateModel(entity, _options.Model.UpdateHandler, ModelType.HandlerUpdate);
        //    if (_options.Model.DeleteHandler.Generate)
        //        CreateModel(entity, _options.Model.DeleteHandler, ModelType.HandlerDelete);





        //    // Ajouter Mapper

        //    if (entity.Models.Count > 0)
        //    {
        //        var mapperNamespace = _options.Model.Mapper.Namespace;

        //        var mapperClass = ToLegalName(_options.Model.Mapper.Name);
        //        mapperClass = _namer.UniqueModelName(mapperNamespace, mapperClass);

        //        entity.MapperClass = mapperClass;
        //        entity.MapperNamespace = mapperNamespace;
        //        entity.MapperBaseClass = _options.Model.Mapper.BaseClass;

        //    }

        //    _options.Variables.Remove(entity);

        //    entity.Models.IsProcessed = true;
        //}


        //private static void CreateModel<TOption>(Entity entity, TOption options, ModelType modelType)
        //    where TOption : ModelOptionsBase
        //{
        //    if (IsIgnored(entity, options, _options.Model.Shared))
        //        return;

        //    var modelNamespace = options.Namespace.HasValue()
        //        ? options.Namespace
        //        : _options.Model.Shared.Namespace;

        //    var modelClass = ToLegalName(options.Name);
        //    modelClass = _namer.UniqueModelName(modelNamespace, modelClass);

        //    var model = new Model
        //    {
        //        Entity = entity,
        //        ModelType = modelType,
        //        ModelBaseClass = options.BaseClass,
        //        ModelNamespace = modelNamespace,
        //        ModelClass = modelClass
        //    };

        //    if (options.Parameters != null)

        //    {
        //        model.Methods = new MethodCollection()
        //            {
        //                new Method()
        //                {
        //                    NameSuffix = "Handle",
        //                    Properties =  new PropertyCollection()

        //                }
        //            };


        //        foreach (var p in options.Parameters)
        //        {
        //            model.Methods.FirstOrDefault().Properties.Add(
        //                new Property()
        //                {
        //                    NativeType = p,
        //                    PropertyName = p,
        //                });

        //        }

        //        _options.Variables.Set(model);

        //    }
        //    foreach (var property in entity.Properties)
        //    {
        //        if (IsIgnored(property, options, _options.Model.Shared))
        //            continue;

        //        model.Properties.Add(property);
        //    }

        //    _options.Variables.Set(model);

        //    var validatorNamespace = _options.Model.Validator.Namespace;
        //    var validatorClass = ToLegalName(_options.Model.Validator.Name);
        //    validatorClass = _namer.UniqueModelName(validatorNamespace, validatorClass);

        //    model.ValidatorBaseClass = _options.Model.Validator.BaseClass;
        //    model.ValidatorClass = validatorClass;
        //    model.ValidatorNamespace = validatorNamespace;




        //    entity.Models.Add(model);

        //    _options.Variables.Remove(model);
        //}


        private static List<Property> GetKeyMembers(Entity entity, IEnumerable<DatabaseColumn> members, string relationshipName)
        {
            var keyMembers = new List<Property>();

            foreach (var member in members)
            {
                var property = entity.Properties.ByColumn(member.Name);

                //if (property == null)
                //    //_logger.LogWarning("Could not find column {columnName} for relationship {relationshipName}.", member.Name, relationshipName);
                //else
                if (property != null)
                    keyMembers.Add(property);
            }

            return keyMembers;
        }

        private static string GetMemberPrefix(Relationship relationship, string primaryClass, string foreignClass)
        {
            string thisKey = relationship.Properties
                .Select(p => p.PropertyName)
                .FirstOrDefault() ?? string.Empty;

            string otherKey = relationship.PrimaryProperties
                .Select(p => p.PropertyName)
                .FirstOrDefault() ?? string.Empty;

            bool isSameName = thisKey.Equals(otherKey, StringComparison.OrdinalIgnoreCase);
            isSameName = (isSameName || thisKey.Equals(primaryClass + otherKey, StringComparison.OrdinalIgnoreCase));

            string prefix = string.Empty;
            if (isSameName)
                return prefix;

            prefix = thisKey.Replace(otherKey, "");
            prefix = prefix.Replace(primaryClass, "");
            prefix = prefix.Replace(foreignClass, "");
            prefix = Regex.Replace(prefix, @"(_ID|_id|_Id|\.ID|\.id|\.Id|ID|Id)$", "");
            prefix = Regex.Replace(prefix, @"^\d", "");

            return prefix;
        }

        private static bool IsOneToOne(DatabaseForeignKey tableKeySchema, Relationship foreignRelationship)
        {
            var foreignColumn = foreignRelationship.Properties
                .Select(p => p.ColumnName)
                .FirstOrDefault();

            bool isFkeyPkey = tableKeySchema.PrincipalTable.PrimaryKey != null
                              && tableKeySchema.Table.PrimaryKey != null
                              && tableKeySchema.Table.PrimaryKey.Columns.Count == 1
                              && tableKeySchema.Table.PrimaryKey.Columns.Any(c => c.Name == foreignColumn);

            if (isFkeyPkey)
                return true;

            return false;

            // if f.key is unique
            //return tableKeySchema.ForeignKeyMemberColumns.All(column => column.IsUnique);
        }


        private static string RelationshipName(string name)
        {
            var naming = RelationshipNaming.Plural;
            if (naming == RelationshipNaming.Preserve)
                return name;

            if (naming == RelationshipNaming.Suffix)
                return name + "List";

            return name.Pluralize(false);
        }

        private static string ContextName(string name)
        {
            var naming = ContextNaming.Plural;
            if (naming == ContextNaming.Preserve)
                return name;

            if (naming == ContextNaming.Suffix)
                return name + "DataSet";

            return name.Pluralize(false);
        }

        private static string EntityName(string name)
        {
            var tableNaming = TableNaming.Plural;
            var entityNaming = EntityNaming.Singular;

            if (tableNaming != TableNaming.Plural && entityNaming == EntityNaming.Plural)
                name = name.Pluralize(false);
            else if (tableNaming != TableNaming.Singular && entityNaming == EntityNaming.Singular)
                name = name.Singularize(false);

            return name;
        }


        private static string ToClassName(string tableName, string tableSchema)
        {
            tableName = EntityName(tableName);
            var className = tableName;
            var PrefixWithSchemaName = false;

            if (PrefixWithSchemaName && tableSchema != null)
                className = $"{tableSchema}{tableName}";

            string legalName = ToLegalName(className);

            return legalName;
        }

        private static string ToPropertyName(string className, string name)
        {
            string propertyName = ToLegalName(name);
            if (className.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                propertyName += "Member";

            return propertyName;
        }

        private static string ToLegalName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            string legalName = name;

            // remove invalid leading identifiers
            if (Regex.IsMatch(name, @"^[^a-zA-Z_]+"))
                legalName = Regex.Replace(legalName, @"^[^a-zA-Z_]+", "");

            // prefix with column when all characters removed
            if (legalName.IsNullOrWhiteSpace())
                legalName = "Number" + name;

            legalName = legalName.ToPascalCase();

            return legalName;
        }


        #region IsIgnored

        private static bool IsIgnored(DatabaseTable table, IEnumerable<MatchOptions> exclude)
        {
            var name = $"{table.Schema}.{table.Name}";
            var includeExpressions = Enumerable.Empty<MatchOptions>();
            var excludeExpressions = exclude ?? Enumerable.Empty<MatchOptions>();

            return IsIgnored(name, excludeExpressions, includeExpressions);
        }


        private static bool IsIgnored(string name, IEnumerable<MatchOptions> excludeExpressions, IEnumerable<MatchOptions> includeExpressions)
        {
            foreach (var expression in includeExpressions)
                if (expression.IsMatch(name))
                    return false;

            foreach (var expression in excludeExpressions)
                if (expression.IsMatch(name))
                    return true;

            return false;
        }

        #endregion
    }
}