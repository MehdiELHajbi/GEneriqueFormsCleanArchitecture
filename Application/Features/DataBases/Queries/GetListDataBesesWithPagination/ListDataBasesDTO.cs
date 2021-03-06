﻿using Application.Common.Mappings;
using Domain.Entites;

namespace Application.Features.DataBases.Queries
{
    public class ListDataBasesDTO : IMapFrom<DataBase>
    {
        public int IdDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string TypeDataBase { get; set; }

    }
}
