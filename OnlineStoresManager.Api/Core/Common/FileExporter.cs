
using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.API
{
    public class FileExporter
    {
        //public Task<FileBytes> Export<TEntity>(IEnumerable<TEntity> entities, FileExportConfiguration<TEntity> configuration)
        //{
        //    IWorkbookFormatProvider workbookProvider = CreateWorkbookFormatProvider(configuration);
        //    Workbook workbook = CreateWorkbook(entities, configuration);

        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //        workbookProvider.Export(workbook, memory);

        //        string fileName = $"{DateTime.Now:yyyyMMddHHmmss}.{configuration.FileType.ToString().ToLower()}";
        //        byte[] fileBytes = memory.ToArray();
        //        FileBytes file = new FileBytes(fileName, fileBytes);

        //        return Task.FromResult(file);
        //    }
        //}

        //private static Workbook CreateWorkbook<TEntity>(IEnumerable<TEntity> entities, FileExportConfiguration<TEntity> configuration)
        //{
        //    Workbook workbook = new Workbook();
        //    workbook.Sheets.Add(SheetType.Worksheet);

        //    Worksheet worksheet = workbook.ActiveWorksheet;

        //    // Headers
        //    for (int colIndex = 0; colIndex < configuration.Properties.Count; colIndex++)
        //    {
        //        FileExportProperty<TEntity> property = configuration.Properties[colIndex];
        //        worksheet.Cells[0, colIndex].SetValue(property.Title);
        //    }

        //    // Rows
        //    for (int rowIndex = 0; rowIndex < entities.Count(); rowIndex++)
        //    {
        //        TEntity entity = entities.ElementAt(rowIndex);

        //        for (int colIndex = 0; colIndex < configuration.Properties.Count; colIndex++)
        //        {
        //            FileExportProperty<TEntity> property = configuration.Properties[colIndex];
        //            string propertyValue = property.Template.Compile()(entity);
        //            worksheet.Cells[rowIndex + 1, colIndex].SetValue(propertyValue);
        //        }
        //    }

        //    // Auto width
        //    for (int colIndex = 0; colIndex < worksheet.UsedCellRange.ColumnCount; colIndex++)
        //    {
        //        worksheet.Columns[colIndex].AutoFitWidth();
        //    }

        //    return workbook;
        //}

        //private static IWorkbookFormatProvider CreateWorkbookFormatProvider<TEntity>(FileExportConfiguration<TEntity> configuration1)
        //{
        //    IWorkbookFormatProvider formatProvider;

        //    switch (configuration1.FileType)
        //    {
        //        case FileType.Csv:
        //            formatProvider = new CsvFormatProvider();
        //            ((CsvFormatProvider)formatProvider).Settings.HasHeaderRow = true;
        //            break;
        //        case FileType.Pdf:
        //            formatProvider = new PdfFormatProvider();
        //            break;
        //        case FileType.Txt:
        //            formatProvider = new TxtFormatProvider();
        //            break;
        //        case FileType.Xlsx:
        //            formatProvider = new XlsxFormatProvider();
        //            break;
        //        default:
        //            throw new ArgumentException(string.Format("Not supported file type '{0}'", configuration1.FileType));
        //    }

        //    return formatProvider;
        //}
    }
}
