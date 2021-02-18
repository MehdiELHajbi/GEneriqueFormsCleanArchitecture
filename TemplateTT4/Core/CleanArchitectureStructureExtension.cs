using System;
using System.Collections.Generic;
using System.Reflection;
using TemplateTT4.Composite;
using TemplateTT4.Constants;

namespace TemplateTT4.Core
{

    public static class CleanArchitectureStructureExtension
    {
        public static void AddCommandFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {

            repertoire.add(new Fichier(cleanArchitectureStructure.commandName, cleanArchitectureStructure.GetCommandContent()));
        }

        public static void AddCommandHandleFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {
            repertoire.add(new Fichier(cleanArchitectureStructure.CommandHandlerName, cleanArchitectureStructure.GetCommandHandlerContent()));
        }

        public static void AddValidatorFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {
            repertoire.add(new Fichier(cleanArchitectureStructure.ValidatorName, cleanArchitectureStructure.GetValidatorContent()));
        }

        public static void AddOneOfNameResponseFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {
            repertoire.add(new Fichier(cleanArchitectureStructure.OneOfNameResponseName, cleanArchitectureStructure.GetOneOfNameContent()));
        }

        public static void AddExceptionResponseFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {
            foreach (var resp in cleanArchitectureStructure.Repsonse.ExceptionResponse)
            {
                repertoire.add(new Fichier(resp, cleanArchitectureStructure.GetExpetionResponseContent(resp)));
            }
        }

        public static void AddSuccesResponseFile(this Repertoire repertoire, CleanArchitectureStructure cleanArchitectureStructure)
        {
            foreach (var resp in cleanArchitectureStructure.Repsonse.SuccesResponse)
            {
                repertoire.add(new Fichier(resp, cleanArchitectureStructure.GetSuccesResponseContent(resp)));
            }
        }


        public static Dictionary<string, Type> GetNameProperty<T>() where T : class
        {

            Dictionary<string, Type> propList = new Dictionary<string, Type>();

            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(T).GetProperties(BindingFlags.Public |
                                                            BindingFlags.Instance);
            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2) { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                propList.Add(propertyInfo.Name.ToString(), propertyInfo.PropertyType);
            }

            return propList;
        }

    }

}
