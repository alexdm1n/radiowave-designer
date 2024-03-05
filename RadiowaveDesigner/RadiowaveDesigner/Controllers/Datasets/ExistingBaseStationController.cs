using System.Data;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Services.BaseStations;
using RadiowaveDesigner.Services.BaseStations.Migrations;

namespace RadiowaveDesigner.Controllers.Datasets;

[Route("datasets/excel/base-stations")]
public class ExistingBaseStationController : ControllerBase
{
    private readonly IExistingBaseStationsService _existingBaseStationsService;

    public ExistingBaseStationController(IExistingBaseStationsService existingBaseStationsService)
    {
        _existingBaseStationsService = existingBaseStationsService;
    }

    [HttpPost]
    public async Task MigrateFromExcel(string path)
    {
        using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
        {
            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true,
                    }
                });
                var rows = new List<object[]>();
                foreach (var row in result.Tables[0].Rows)
                {
                    var dataRow = row as DataRow;
                    rows.Add(dataRow!.ItemArray!);
                }

                await _existingBaseStationsService.AddExistingBaseStations(rows);
            }
        }
        await Task.CompletedTask;
    }
}