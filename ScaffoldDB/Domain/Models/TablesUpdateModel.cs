using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Domain.Models
{
    public partial class TablesUpdateModel
    {
        #region Generated Properties
        public int IdTable { get; set; }

        public string ObjName { get; set; }

        public string ObjFriendlyName { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanAdd { get; set; }

        public int? FkDataBaseId { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion

    }
}
