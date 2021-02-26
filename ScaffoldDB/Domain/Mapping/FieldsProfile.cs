using System;
using AutoMapper;
using CleanArchitectureDbTest1.Data.Entities;
using CleanArchitectureDbTest1.Domain.Models;

namespace CleanArchitectureDbTest1.Domain.Mapping
{
    public partial class FieldsProfile
        : AutoMapper.Profile
    {
        public FieldsProfile()
        {
            CreateMap<CleanArchitectureDbTest1.Data.Entities.Fields, CleanArchitectureDbTest1.Domain.Models.FieldsReadModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.FieldsCreateModel, CleanArchitectureDbTest1.Data.Entities.Fields>();

            CreateMap<CleanArchitectureDbTest1.Data.Entities.Fields, CleanArchitectureDbTest1.Domain.Models.FieldsUpdateModel>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.FieldsUpdateModel, CleanArchitectureDbTest1.Data.Entities.Fields>();

            CreateMap<CleanArchitectureDbTest1.Domain.Models.FieldsReadModel, CleanArchitectureDbTest1.Domain.Models.FieldsUpdateModel>();

        }

    }
}
