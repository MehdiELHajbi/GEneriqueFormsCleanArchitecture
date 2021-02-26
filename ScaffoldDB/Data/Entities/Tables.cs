using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Data.Entities
{
    public partial class Tables
    {
        public Tables()
        {
            #region Generated Constructor
            FkFields = new HashSet<Fields>();
            #endregion
        }

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

        #region Generated Relationships
        public virtual DataBase FkDataBase { get; set; }

        public virtual ICollection<Fields> FkFields { get; set; }

        #endregion

    }
}
