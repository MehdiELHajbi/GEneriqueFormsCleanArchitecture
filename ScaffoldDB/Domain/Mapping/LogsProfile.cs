using System;
using AutoMapper;
using CleanArchitectureDbTest1.Data.Entities;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Mapping
{
    public partial class LogsProfile
        : AutoMapper.Profile
    {
        public LogsProfile()
        {
            CreateMap<CleanArchitectureDbTest1.Data.Entities.Logs, CleanArchitectureDbTest1.Domain.Models.LogsReadModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.LogsCreateModel, CleanArchitectureDbTest1.Data.Entities.Logs>();

            CreateMap<CleanArchitectureDbTest1.Data.Entities.Logs, CleanArchitectureDbTest1.Domain.Models.LogsUpdateModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.LogsUpdateModel, CleanArchitectureDbTest1.Data.Entities.Logs>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.LogsReadModel, CleanArchitectureDbTest1.Domain.Models.LogsUpdateModel>();

        }

    }
}
