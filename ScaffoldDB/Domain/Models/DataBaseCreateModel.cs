using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Domain.Models
{
    public partial class DataBaseCreateModel
    {
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

    }
}
