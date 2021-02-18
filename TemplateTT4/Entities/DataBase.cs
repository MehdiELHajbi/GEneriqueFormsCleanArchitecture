using System.Collections.Generic;

namespace TemplateTT4.Entities
{

    public partial class DataBase
    {


        public int IdDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string? ConnectionString { get; set; }
        public string TypeDataBase { get; set; }

        public virtual ICollection<Tables> Tables { get; set; }
        public virtual IList<Tables> dd { get; set; }


    }
    public partial class Tables
    {


        public int IdTable { get; set; }
        public string ObjName { get; set; }
        public string ObjFriendlyName { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAdd { get; set; }
        public int? FkDataBaseId { get; set; }

        public virtual DataBase FkDataBase { get; set; }
    }
}
