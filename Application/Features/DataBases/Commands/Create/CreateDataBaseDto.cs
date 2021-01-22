using Application.Common.Mappings;
using Domain.Entites;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBaseDto : IMapFrom<DataBase>
    {
        public int idDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string TypeDataBase { get; set; }


    }
}
