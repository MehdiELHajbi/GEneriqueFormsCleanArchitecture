using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Data.Entities
{
    public partial class DataBase
    {
        public DataBase()
        {
            #region Generated Constructor
            FkTables = new HashSet<Tables>();
            #endregion
        }

        #region Generated Properties
        public int IdDataBase { get; set; }

        public string NameDataBase { get; set; }

        public string ConnetionName { get; set; }

        public string ConnectionString { get; set; }

        public string TypeDataBase { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Tables> FkTables { get; set; }

        #endregion

    }
}
