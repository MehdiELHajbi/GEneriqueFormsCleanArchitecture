using Application.Contracts;
using Application.Contracts.Infrastructure;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Queries.ExportGetListDataBeses
{
    public class ExportGetListDataBesesQueryHandler : IRequestHandler<ExportGetListDataBesesQuery, ExportGetListDataBesesVM>
    {
        private readonly IAsyncRepository<DataBase> _dataBaseRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        public ExportGetListDataBesesQueryHandler(IMapper mapper, IAsyncRepository<DataBase> dataBaseRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
            _csvExporter = csvExporter;
        }

        public async Task<ExportGetListDataBesesVM> Handle(ExportGetListDataBesesQuery request, CancellationToken cancellationToken)
        {
            var allDabases = _mapper.Map<List<DataBaseFileRecordDto>>((await _dataBaseRepository.ListAllAsync()));

            var fileData = _csvExporter.ExportDataBaseToCsv(allDabases);

            var eventExportFileDto = new ExportGetListDataBesesVM() { ContentType = "text/csv", Content = fileData, FileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;

        }


    }
}
