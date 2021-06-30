using HWMS.Application.ViewModels;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWMS.Application.Services
{
    public static class FileService
    {
        public static async Task<DataTable> ExecuteReadExcelForStream(Stream stream)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            stream.Position = 0;
            HSSFWorkbook xssWorkbook = new HSSFWorkbook(stream);
            sheet = xssWorkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                {
                    dtTable.Columns.Add(cell.ToString());
                }
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                        {
                            rowList.Add(row.GetCell(j).ToString());
                        }
                    }
                }
                if (rowList.Count > 0)
                    dtTable.Rows.Add(rowList.ToArray());
                rowList.Clear();
            }
            return dtTable;
        }

        public static List<T> TranT<T>(this DataTable dataTable)
        {
            List<T> returnData = new List<T>();
            try
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var model = Activator.CreateInstance<T>();
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        foreach (var item in typeof(T).GetProperties())
                        {
                            var genericCloumnName = (DisplayNameAttribute)item.GetCustomAttributes(true).FirstOrDefault(x => x is DisplayNameAttribute);
                            if (genericCloumnName!=null&& genericCloumnName.DisplayName.Equals(dataTable.Columns[j].ColumnName))
                            {
                                var getValue = dataTable.Rows[i][dataTable.Columns[j].ColumnName];
                                Console.WriteLine(getValue);
                                if (item.PropertyType == typeof(int))
                                {
                                    item.SetValue(model, Convert.ToInt16(getValue));
                                }
                                break;
                            }
                        }
                    }
                    returnData.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnData;
        }
    }
}
