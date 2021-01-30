﻿using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class SaveDatabaseStep : IRule<Context>
    {
        private readonly CreateDataBesesCommand request;
        private readonly IDataBaseRepository dataBaseRepository;
        public IEnumerable<IRule<Context>> steps { get; set; }
        public string RuleDescrition { get; } = " DatabaseNotExisteStep permet permet d'enregistrer une dans la table  'DataBase' passer en parmetre existe deja dans la Bd";

        string IRule<Context>.ruleName => nameof(SaveDatabaseStep);

        public SaveDatabaseStep(CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this.dataBaseRepository = dataBaseRepository;
            this.steps = new List<IRule<Context>>
                                         {
                                                new ReturnResponseStep()
                                         };

        }

        public async Task<Context> Execute(Context ctx)
        {
            // Create Object To save
            var dataBase = new DataBase()
            {
                ConnetionName = this.request.ConnetionName,
                NameDataBase = this.request.NameDataBase,
                TypeDataBase = this.request.TypeDataBase
            };
            // save data in data Base
            dataBase = await this.dataBaseRepository.AddAsync(dataBase);

            // update context with reult
            ctx.DataBase_id = dataBase.IdDataBase;


            // Do Steps
            foreach (var step in this.steps)
            {
                if (ctx.Continue) // Ne pas faire tout les Steps
                {
                    ctx = await step.Execute(ctx);
                }
                else
                    return ctx;

            }
            return ctx;
        }
    }
}
