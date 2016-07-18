using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CNSWEExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            utility utility = new utility();
            Excel.Range ScheduleRange;
            try
            {
                utility.ExcelFileName = @"\\DaySchedule\" + utility.DefaultScheduleName;
                utility.OpenExcelApplication(utility.ExcelFileName);
                utility.OpenExcelRange(1);
                ScheduleRange = utility.ExcelRange;
            }
            catch (Exception)
            {
                utility.CloseExcelItems();
            }
        }
    }
}
