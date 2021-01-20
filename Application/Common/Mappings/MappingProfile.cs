using Application.Features.DataBases.Commands.Create;
using Application.Features.DataBases.Queries;
using Application.Features.DataBases.Queries.ExportGetListDataBeses;
using AutoMapper;
using Domain.Entites;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Query
            CreateMap<DataBase, ListDataBasesVM>().ReverseMap();
            CreateMap<DataBase, DataBaseFileRecordDto>().ReverseMap();
            CreateMap<DataBase, ListDataBasesDTO>().ReverseMap();

            // Command
            CreateMap<DataBase, CreateDataBesesCommand>().ReverseMap();
            CreateMap<DataBase, CreateDataBaseDto>().ReverseMap();

        }
    }
}
