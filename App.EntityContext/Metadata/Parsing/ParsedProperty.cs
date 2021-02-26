namespace EntityFrameworkCore.Generator.Metadata.Parsing
{
    public class ParsedProperty
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(ColumnName)
                && !string.IsNullOrEmpty(PropertyName);
        }
    }
}
