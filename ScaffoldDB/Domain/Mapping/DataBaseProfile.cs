using System;
using AutoMapper;
using CleanArchitectureDbTest1.Data.Entities;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Mapping
{
    public partial class DataBaseProfile
        : AutoMapper.Profile
    {
        public DataBaseProfile()
        {
            CreateMap<CleanArchitectureDbTest1.Data.Entities.DataBase, CleanArchitectureDbTest1.Domain.Models.DataBaseReadModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.DataBaseCreateModel, CleanArchitectureDbTest1.Data.Entities.DataBase>();

            CreateMap<CleanArchitectureDbTest1.Data.Entities.DataBase, CleanArchitectureDbTest1.Domain.Models.DataBaseUpdateModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.DataBaseUpdateModel, CleanArchitectureDbTest1.Data.Entities.DataBase>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.DataBaseReadModel, CleanArchitectureDbTest1.Domain.Models.DataBaseUpdateModel>();

        }

    }
}
