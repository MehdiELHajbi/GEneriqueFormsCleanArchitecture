
using Domain.Common;

namespace Domain.Entites
{
    public partial class Fields : AuditableEntity
    {
        public int IdFiled { get; set; }
        public string FieldFriendlyName { get; set; }
        public string FieldName { get; set; }
        public string Type { get; set; }
        public int MaxLength { get; set; }
        public bool IsId { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUpdatable { get; set; }
        public bool IsListable { get; set; }
        public bool IsViewtable { get; set; }
        public bool? IsInsertable { get; set; }
        public int? FkTablesId { get; set; }
        public int? RelationId { get; set; }
        public string RelationValue { get; set; }

        public virtual Tables FkTables { get; set; }
    }
}
