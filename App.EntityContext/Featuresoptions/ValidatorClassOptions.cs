namespace App.EntityContext.Featuresoptions
{
    class ValidatorClassOptions
    {
        public ValidatorClassOptions(string ModelName)
        {
            BaseClass = "AbstractValidator<" + ModelName + "> ";
            Name = ModelName + "Validator";
        }

        public string BaseClass { get; set; }
        public string Name { get; set; }
    }
}
