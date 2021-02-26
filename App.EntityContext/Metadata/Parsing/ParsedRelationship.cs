using System.Collections.Generic;

namespace EntityFrameworkCore.Generator.Metadata.Parsing
{
    public class ParsedRelationship
    {
        public ParsedRelationship()
        {
            ThisProperties = new List<string>();
        }

        public string ThisPropertyName { get; set; }
        public List<string> ThisProperties { get; private set; }

        public string OtherPropertyName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(ThisPropertyName)
                && !string.IsNullOrEmpty(OtherPropertyName)
                && ThisProperties.Count > 0;
        }

    }
}
