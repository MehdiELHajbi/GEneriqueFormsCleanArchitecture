using System.Collections.Generic;

namespace EntityFrameworkCore.Generator.Metadata.Parsing
{
    public class ParsedContext
    {
        public ParsedContext()
        {
            Properties = new List<ParsedEntitySet>();
        }

        public string ContextClass { get; set; }

        public List<ParsedEntitySet> Properties { get; }
    }
}
