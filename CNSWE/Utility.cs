using CNSWE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Win32;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Threading;

namespace CNSWE
{
    public class Utility
    {
        public static DateTime listDate;
        public static string ListType;
        public static string InterstitalType;
        public static string initError;
        public static string scheduleName;
        public static string FillerName;
        public static int FillerDuration;
        public static string FillerError;
        public static string LogoError;
        public static string LogoName;
        public static int LogoDuration;
        public static string fillerspath;
        public static string logospath;
        public static string xmlfile;
        public static string SavedXmlName;
        public static bool IsCommercialsCorrect = true;
        public static bool IsListGenerated = false;
        public static bool IsListValidated = false;
        public static string dateTimeFormat = "dd.MM.yyyy";
        private static string timeFormat = "HH:mm:ss:ff";
        public static string CommercialFilePath;
        public static string ScheduleFilePath;
        public static string TLCFilePath = @"C:\\AutomatedLists\TLC\Workflow\";
        public static string DCFilePath = @"C:\\AutomatedLists\DC\Workflow\";
        public static string CNSWEFilePath = @"C:\\AutomatedLists\CNSWE\Workflow\";
        public static string CNSWEScheduledfile = @"C:\\AutomatedLists\CNSWE\Workflow\Schedule\test.txt";
        MainWindow _MW;
        public string FirstEventST()
        {
            DateTime dt = new DateTime();
            string date = scheduleName.Substring(2, 8);
            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);
            dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), 06, 00, 00, 00);
            string swetime = day + "/" + month + "/" + year + " "+Properties.Settings.Default.cnsweStartTime;
            string time = TimeZoneInfo.ConvertTimeToUtc(dt, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")).ToString("yyyy-MM-ddThh:mm:ss.ff", CultureInfo.InvariantCulture);
            return time;
        }
        public string ListTitle()
        {
            string filepath = scheduleName;
            string _listTitle = "CN SWE " + filepath.Substring(8, 2) + "." + filepath.Substring(6, 2) + "." + filepath.Substring(2, 4);
            return _listTitle;
        }
        public static void saveInterstitalEventToXML(InterstitalEvent iEvent, string fileName)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(InterstitalEvent), "CNSWE");
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, iEvent);
            }

        }
        public static InterstitalEvent readXML(string fileLocation)
        {

            XmlSerializer reader = new XmlSerializer(typeof(InterstitalEvent));
            StreamReader XMLfile = new StreamReader(fileLocation);
            InterstitalEvent overview;
            try
            {
                overview = (InterstitalEvent)reader.Deserialize(XMLfile);
            }
            catch (Exception)
            {
                return null;
                //how not to write code - ignore errors
            }
            finally
            {
                XMLfile.Close();
            }
            return overview;
        }
        public int TimeToSeconds(string time)
        {
            string timeHelper;
            timeHelper = time.Substring(3, 3);
            double _timeHelper;
            _timeHelper = double.Parse(timeHelper);
            _timeHelper = _timeHelper * 0.6;
            int _timehelper;
            _timehelper = Convert.ToInt32(_timeHelper);
            return _timehelper;
        }
        public void populateLB(MainWindow MW, string text)
        {
            this._MW = MW;
            _MW.lb_openedFiles.Items.Add(text);
        }
        public string DoubleToTime(double time)
        {
            DateTime dt = DateTime.FromOADate(time);
            return dt.ToString(timeFormat, CultureInfo.InvariantCulture);
        }
        public string IntToTime(int time)
        {
            DateTime dt = DateTime.FromOADate(time);
            return dt.ToString(timeFormat, CultureInfo.InvariantCulture);
        }
        public string IntToTimeSpan(int time)
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);
            return ts.ToString(@"hh\:mm\:ss\:ff");
        }
        public string StringToTime(string time)
        {
            string _hour = time.Substring(0, 2);
            string _minutes = time.Substring(2, 2);
            string _seconds = time.Substring(4, 2);
            string _frames = time.Substring(6, 2);

            string _time = _hour + ":" + _minutes + ":" + _seconds + "." + _frames;
            return _time;
        }
        public string StringToPredictedTime(string time)
        {
            string _hour = time.Substring(0, 2);
            string _minutes = time.Substring(2, 2);
            string _seconds = time.Substring(4, 2);
            string _frames = time.Substring(6, 2);

            if (String.IsNullOrEmpty(_frames))
            {
                _frames = "00";
            }

            string _time = _hour + ":" + _minutes + ":" + _seconds + ":" + _frames;
            return _time;
        }
        public void ClearListbox()
        {
            if (Utility.IsListGenerated)
            {
                _MW.lb_openedFiles.Items.Clear();
                Utility.IsListGenerated = false;
            }
        }
        public void CopyScheduleText(MainWindow MW)
        {
            string newPath = @"C:\\AutomatedLists\CNSWE\Workflow\Schedule\" + Path.GetFileName(ScheduleFilePath);
            try
            {
                File.Copy(ScheduleFilePath, newPath);
                populateLB(MW, "Copying " + Path.GetFileName(ScheduleFilePath) + " into workflow folder");
                File.Move(newPath, CNSWEScheduledfile);
            }
            catch
            {
                string initError = String.Format("Copyin dailyschedule error");
                populateLB(MW, initError);
            }
        }
        public void CopyScheduleExcel(MainWindow MW, string path , string defaultpath)
        {
            string newPath=path+ @"\Schedule\"+Path.GetFileName(ScheduleFilePath);
            defaultpath = newPath;
            try
            {
                File.Copy(ScheduleFilePath, newPath);
                populateLB(MW, "Copying " + Path.GetFileName(ScheduleFilePath) + " into workflow folder");
            }
            catch(Exception ex)
            {
                string initError = String.Format("Copyin dailyschedule error "+ex.Message);
                populateLB(MW, initError);
            }

        }
        public void SaveFileDialog(string filter)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = filter;
            savefiledialog.InitialDirectory = Properties.Settings.Default.defaultSaveLocation;
            savefiledialog.ShowDialog();
            SavedXmlName = savefiledialog.FileName;
        }
        public void CopyXML()
        {
            if (IsListValidated)
            {
                SaveFileDialog("XML files (*.xml)|*.xml|All files (*.*)|*.*");

                try
                {
                    File.Copy(xmlfile, SavedXmlName, true);
                    populateLB(_MW, "Saved XML into " + SavedXmlName);
                }
                catch (Exception ex)
                {
                    string initError = String.Format("Saving XML error: " + ex.ToString());//TODO: add column
                    populateLB(_MW, initError);
                }
            }
        }
        public void clearFolder(MainWindow MW, string FolderName)
        {
            FolderName+=@"Schedule\";
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(MW,di.FullName);
                    di.Delete();
                }
            }
            catch (Exception ex)
            {
                populateLB(MW, ex.Message);
            }
           
        }
        public void clearCNSWEScheduleFolder()
        {
            System.IO.File.Delete(@"C:\\AutomatedLists\CNSWE\Workflow\Schedule\" + Path.GetFileName(ScheduleFilePath));
            System.IO.File.Delete(CNSWEScheduledfile);
        }
        public string StringtoDateTime(string commercialfile, string time)
        {
            string datetime;
            string day;
            string month;
            string year;
            commercialfile = Path.GetFileName(commercialfile);
            day = commercialfile.Substring(3, 2);
            month = commercialfile.Substring(5, 2);
            year = "20" + commercialfile.Substring(7, 2);

            datetime = year + "-" + month + "-" + day + "T" + StringToTime(time);

            return datetime;
        }
        public void NotifyPropertyChanged(string propName, PropertyChangedEventHandler PropertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #region ExcelStuff
        public static Excel.Application ExcelApp;
        public static Excel.Workbook ExcelWb;
        public static Excel.Worksheet ExcelWs;
        public static Excel.Range ExcelRange;

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
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
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
        public void CloseExcelItems()
        {
            try
            {
                releaseObject(ExcelRange);
                releaseObject(ExcelWs);
                ExcelWb.Close(null, null, null);
                releaseObject(ExcelWb);
                ExcelApp.Quit();
                releaseObject(ExcelApp);
                ExcelApp = null;
            }
            catch
            {
                populateLB(_MW, "Failed to close Excel app");
            }
            finally
            {
                releaseObject(ExcelApp);
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

        #endregion
    }
}
