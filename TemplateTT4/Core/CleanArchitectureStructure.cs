using System.Collections.Generic;

namespace TemplateTT4.Core
{
    public enum TypeCqrs
    {
        Command,
        Query
    };



    public class CleanArchitectureStructure
    {
        #region ctor
        public CleanArchitectureStructure(string path, string Feature, string FeatureType, string FeatureCommande)
        {
            this.path = path;
            this.Feature = Feature;
            this.FeatureType = FeatureType;
            this.FeatureCommande = FeatureCommande;
            this.Repsonse = new Response();
        }
        #endregion


        #region Directory

        public string path { get; set; }
        public string Feature { get; set; }
        public string FeatureType { get; set; }
        public string FeatureCommande { get; set; }
        #endregion


        #region Constant
        public string Name { get { return FeatureCommande + Feature; } set { this.Name = value; } }
        #endregion


        #region Files
        public string commandName { get { return Name + "Command"; } set { this.commandName = value; } }
        public string CommandHandlerName { get { return Name + "CommandHandler"; } set { this.CommandHandlerName = value; } }
        public string ValidatorName { get { return Name + "Validator"; } set { this.ValidatorName = value; } }
        public string OneOfNameResponseName { get { return "OneOf" + Name + "Response"; } set { this.OneOfNameResponseName = value; } }

        public Response Repsonse { get; set; }

        #endregion


        public void AddExceptionResponse(string NameException)
        {
            this.Repsonse.ExceptionResponse.Add("Exception" + NameException + Name + "Response");
        }

        public void AddSuccesResponse(string NameResponse)
        {
            if (string.IsNullOrEmpty(NameResponse))
                this.Repsonse.SuccesResponse.Add(Name + "Response");

            this.Repsonse.SuccesResponse.Add(NameResponse + "Response");
        }




    }


    public class Response
    {
        public Response()
        {
            ExceptionResponse = new List<string>();
            SuccesResponse = new List<string>();
        }
        public List<string> ExceptionResponse { get; set; }
        public List<string> SuccesResponse { get; set; }

    }


}
