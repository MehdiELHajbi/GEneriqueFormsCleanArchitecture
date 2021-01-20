using Application.Contracts.Infrastructure;
using Application.Features.DataBases.Queries.ExportGetListDataBeses;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace infra.FileExport
{
    public class CsvExporter : ICsvExporter
    {


        public byte[] ExportDataBaseToCsv(List<DataBaseFileRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                //csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }

}
