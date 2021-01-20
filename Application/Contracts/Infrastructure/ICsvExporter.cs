using Application.Features.DataBases.Queries.ExportGetListDataBeses;
using System.Collections.Generic;

namespace Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportDataBaseToCsv(List<DataBaseFileRecordDto> DataBaseExportVM);
    }
}
