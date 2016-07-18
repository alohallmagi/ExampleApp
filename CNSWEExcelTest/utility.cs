using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CNSWEExcelTest { 
    public class utility
    {
        public static string ScheduleFileName;
        public static string DefaultScheduleName;
        public static string CommercialFileName;
        public static string dateTimeFormat = "dd.MM.yyyy";
        public static string ScheduleDay;
        public static string ExcelFileName;
        public static int ScheduleLine;
        public static string SavedFileName;
        public static string XMLDefaultFileLocation = @"\\CNSWE\SavedXML\xml.xml";
        public static string PredictedDuration;

        public static Excel.Application ExcelApp;
        public static Excel.Workbook ExcelWb;
        public static Excel.Worksheet ExcelWs;
        public static Excel.Range ExcelRange;

        public void CopyExcel()
        {
            string newPath = @"CNSWE\\CommercialSchedule\" + Path.GetFileName(ScheduleFileName);
            try
            {
                File.Copy(ScheduleFileName, newPath);
            }
            catch (Exception ex)
            {
                string initError = String.Format("Copyin Schedule error");
            }
        }
        public void CopyText()
        {
            string newPath = @"CNSWE\\DiscoveryID\DaySchedule\" + Path.GetFileName(ScheduleFileName);
            try
            {
                File.Copy(ScheduleFileName, newPath);
            }
            catch (Exception ex)
            {
                string initError = String.Format("Copyin Schedule error");
            }
        }
        public void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
      
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void OldExcel()
        {
            object misValue = System.Reflection.Missing.Value;
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        public void OpenExcelApplication(string excelname)
        {
            ExcelApp = new Excel.Application();
            ExcelWb = ExcelApp.Workbooks.Open(excelname);
        }
        public void OpenExcelRange(int sheetnr)
        {
            ExcelWs = (Excel.Worksheet)ExcelWb.Worksheets.get_Item(sheetnr);
            OldExcel();
            ExcelRange = ExcelWs.UsedRange;
        }
        public void CloseExcelItems()
        {
            try
            {

                ExcelApp.Quit();

                releaseObject(ExcelWs);
                releaseObject(ExcelWb);
                releaseObject(ExcelApp);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                ExcelApp = null;
            }
        }
        public void ExcelDisplayAlerts(bool IsTrue) 
        {
            ExcelApp.DisplayAlerts = IsTrue;
        }
        public void ExcelPasteSpecial() 
        {
           ExcelWs.PasteSpecial(ExcelRange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
        public void SaveExcelApp() 
        {
            ExcelDisplayAlerts(false);
            ExcelWb.Close(true, ExcelFileName, Type.Missing);
        }

        
     
      
        
    }
}
