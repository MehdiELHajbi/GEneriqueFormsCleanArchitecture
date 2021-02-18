using TemplateTT4.Composite;
using TemplateTT4.Core;

namespace TemplateTT4
{


    class Program
    {
        static void Main(string[] args)
        {


            //var x = CleanArchitectureStructureExtension.GetProperty<DataBase>();

            string path = @"P:\.NET\CleanArchitecture.Plurasight";
            string Feature = "DataBases";
            string FeatureType = TypeCqrs.Command.ToString();
            string FeatureCommande = "Delete";


            CleanArchitectureStructure cleanArchitectureStructure = new CleanArchitectureStructure
                (path, Feature, FeatureType, FeatureCommande);


            // Add Response File with Content
            cleanArchitectureStructure.AddExceptionResponse("AlreadyExists");
            cleanArchitectureStructure.AddSuccesResponse("");





            // ADD Directory
            Repertoire RepDataBases = new Repertoire(cleanArchitectureStructure.Feature);
            Repertoire RepCommands = new Repertoire(cleanArchitectureStructure.FeatureType);
            Repertoire RepType = new Repertoire(cleanArchitectureStructure.FeatureCommande);
            Repertoire RepReponses = new Repertoire("Reponses");
            Repertoire RepDocumentationAPI = new Repertoire("DocumentationAPI");
            Repertoire RepKO = new Repertoire("KO");
            Repertoire RepOK = new Repertoire("OK");



            RepDataBases.add(RepCommands);
            RepCommands.add(RepType);
            RepType.add(RepReponses);
            RepReponses.add(RepDocumentationAPI);
            RepReponses.add(RepKO);
            RepReponses.add(RepOK);


            // ADD File to Directory with Content
            RepType.AddCommandFile(cleanArchitectureStructure);
            RepType.AddCommandHandleFile(cleanArchitectureStructure);
            RepType.AddValidatorFile(cleanArchitectureStructure);

            RepDocumentationAPI.AddOneOfNameResponseFile(cleanArchitectureStructure);

            RepKO.AddExceptionResponseFile(cleanArchitectureStructure);

            RepOK.AddSuccesResponseFile(cleanArchitectureStructure);


            // Execute
            RepDataBases.operation(path);



        }
    }
}


//string Name = FeatureCommande + Feature;

// File 
//string commandName = Name + "Command";
//string CommandHandlerName = Name + "CommandHandler";
//string ValidatorName = Name + "Validator";
//string OneOfNameResponse = "OneOf" + Name + "Response";

//var proc = new Process
//{
//    StartInfo =
//        {
//            FileName = "TextTransform.exe",
//            Arguments = "TextTemplate1.tt"
//        }
//};

//proc.Start();
//proc.WaitForExit();


//List<string> ExceptionResponse = new List<string>();
//ExceptionResponse.Add("Exception" + "AlreadyExists" + Name + "Response");
//ExceptionResponse.Add("Exception" + "Validation" + Name + "Response");


//List<string> SuccesResponse = new List<string>();
//SuccesResponse.Add(Name + "Response");
//RepType.add(new Fichier(cleanArchitectureStructure.commandName, cnt.GetCommandContent()));
//RepType.add(new Fichier(cleanArchitectureStructure.CommandHandlerName, cnt));
//RepType.add(new Fichier(cleanArchitectureStructure.ValidatorName, cnt));

//RepDocumentationAPI.add(new Fichier(cleanArchitectureStructure.OneOfNameResponse, cnt));

//foreach (var resp in cleanArchitectureStructure.Repsonse.ExceptionResponse)
//{
//    RepKO.add(new Fichier(resp, cnt));
//}

//foreach (var resp in cleanArchitectureStructure.Repsonse.SuccesResponse)
//{
//    RepOK.add(new Fichier(resp, cnt));
//}
