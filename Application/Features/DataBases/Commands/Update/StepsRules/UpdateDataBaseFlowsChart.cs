using Application.Contracts;
using Application.Features.Common.Pattern.ChartFlow;
using Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.StepsRules
{
    public class UpdateDataBaseFlowsChart : Flowchart<UpdateDataBesesCommand, UpdateDataBesesCommandResponse>
    {
        private readonly UpdateDataBesesCommand request;
        public readonly IDataBaseRepository _dataBaseRepository;

        public UpdateDataBaseFlowsChart chart { get; set; }
        public UpdateDataBaseFlowsChart(UpdateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this._dataBaseRepository = dataBaseRepository;
            this.chart = this;

            this.chart.AddStepFeature("CheckIdDataBaseExiste")
                    //.YieldsResult(new UpdateDataBesesCommandResponse
                    //{
                    //    Message = "Ajouter avec Succes"
                    //});
                    .WithArrowPointingTo("SaveData").AndRule(m => DataBaseExiste(m.idDataBase))
                .AddStepFeature("SaveData").YieldsResult(UpdateData());
            //.WithArrowPointingTo("BadMovie").AndRule(LengthIsTooLong)
            //        .Requires(m => m.Length)
            //        .WithArrowPointingTo("BadMovie").AndRule(LengthIsTooLong)
            //        .WithArrowPointingTo("GoodMovie").AndRule(LengthIsJustRight)
            //        .WithArrowPointingTo("CheckReleaseDate").AndRule(LengthExists)
            //    .AddStepFeature("CheckReleaseDate")
            //        .Requires(m => m.ReleaseDate)
            //        .WithArrowPointingTo("BadMovie").AndRule(TooOld)
            //        .WithArrowPointingTo("GoodMovie").AndRule(HasReleaseDate)

            //    chart.AddStepFeature("BadMovie").YieldsResult(1)
            //    .AddStepFeature("GoodMovie").YieldsResult(2);
        }


        #region Rules
        public bool DataBaseExiste(int idDataBase)
        {
            var entity = Task.FromResult(_dataBaseRepository.GetByIdAsync(idDataBase)).Result.Result;
            if (entity == null)
            {
                throw new Exception("Database n'existe pas");
            }
            return false;
        }

        public UpdateDataBesesCommandResponse UpdateData()
        {
            // Create Object To save
            var dataBase = new DataBase()
            {
                ConnetionName = request.ConnetionName,
                NameDataBase = request.NameDataBase,
                TypeDataBase = request.TypeDataBase
            };

            // Create Object To save
            Task.FromResult(this._dataBaseRepository.UpdateAsync(dataBase)).Wait();

            return new UpdateDataBesesCommandResponse
            {
                Message = "update OK pour l id"
            };

        }
        #endregion
    }
}
