
using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class DataBase : AuditableEntity
    {
        public DataBase()
        {
            Tables = new HashSet<Tables>();
        }

        public int IdDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string ConnectionString { get; set; }
        public string TypeDataBase { get; set; }

        public virtual ICollection<Tables> Tables { get; set; }
    }
}
