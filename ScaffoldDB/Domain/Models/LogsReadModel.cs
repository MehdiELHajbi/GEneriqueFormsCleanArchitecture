using System;
using System.Collections.Generic;

namespace CleanArchitectureDbTest1.Domain.Models
{
    public partial class LogsReadModel
    {
        #region Generated Properties
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }

        #endregion

    }
}
