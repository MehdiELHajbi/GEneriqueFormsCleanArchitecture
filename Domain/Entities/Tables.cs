
using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Tables : AuditableEntity
    {
        public Tables()
        {
            Fields = new HashSet<Fields>();
        }

        public int IdTable { get; set; }
        public string ObjName { get; set; }
        public string ObjFriendlyName { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAdd { get; set; }
        public int? FkDataBaseId { get; set; }

        public virtual DataBase FkDataBase { get; set; }
        public virtual ICollection<Fields> Fields { get; set; }
    }
}
