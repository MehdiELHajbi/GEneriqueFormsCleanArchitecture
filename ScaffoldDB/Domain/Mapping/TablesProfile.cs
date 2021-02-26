using System;
using AutoMapper;
using CleanArchitectureDbTest1.Data.Entities;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Mapping
{
    public partial class TablesProfile
        : AutoMapper.Profile
    {
        public TablesProfile()
        {
            CreateMap<CleanArchitectureDbTest1.Data.Entities.Tables, CleanArchitectureDbTest1.Domain.Models.TablesReadModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.TablesCreateModel, CleanArchitectureDbTest1.Data.Entities.Tables>();

            CreateMap<CleanArchitectureDbTest1.Data.Entities.Tables, CleanArchitectureDbTest1.Domain.Models.TablesUpdateModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.TablesUpdateModel, CleanArchitectureDbTest1.Data.Entities.Tables>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.TablesReadModel, CleanArchitectureDbTest1.Domain.Models.TablesUpdateModel>();

        }

    }
}
