using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Domain.Models
{
    public partial class FieldsCreateModel
    {
        #region Generated Properties
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

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion

    }
}
