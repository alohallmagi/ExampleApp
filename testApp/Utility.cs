using testApp.Models;
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
using System.Windows.Controls;

namespace testApp
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
        public static bool IsScheduleFirstRowCorrect = true;
        public static bool IsBreakDurationFull = false;
        public static bool IsCommercialsCorrect = true;
        public static bool IsListGenerated = false;
        public static bool IsListValidated = false;
        public static string dateTimeFormat = "dd.MM.yyyy";
        private static string timeFormat = "HH:mm:ss:ff";
        public static string CommercialFilePath;
        public static string ScheduleFilePath;
        public static string TLCDCRusAudioPath = @"C:\\AutomatedLists\Utility\TLCDC\rusaudios.xml";
        public static string TLCFilePath = @"C:\\AutomatedLists\TLC\Workflow\";
        public static string DCFilePath = @"C:\\AutomatedLists\DC\Workflow\";
        public static string DCIDFilePath= @"C:\\AutomatedLists\DCID\Workflow\";
        public static string CNSWEFilePath = @"C:\\AutomatedLists\CNSWE\Workflow\";
        public static string CNSWEScheduledfile = @"C:\\AutomatedLists\CNSWE\Workflow\Schedule\test.txt";
        public static string DCIDCommercialPath = @"C:\\AutomatedLists\DCID\Workflow\Commercial\";
        MainWindow _MW;
        public void CheckForSchedule(string FolderName, MainWindow _MW)
        {
            ScheduleFilePath = "";
            FolderName += @"Schedule\";
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (!String.IsNullOrEmpty(fi.FullName))
                    {
                        Utility.ScheduleFilePath = fi.FullName;
                    }
                    foreach (DirectoryInfo di in dir.GetDirectories())
                    {
                        Utility.ScheduleFilePath = di.FullName;
                    }
                }

            }
            catch (Exception ex)
            {
                populateLB(_MW, "Error finding schedule " + ex.Message);
            }
        }
        public void CopyExcel(MainWindow _MW, string path, string ScheduleFileName)
        {
            string newPath = path+@"\Schedule\" + Path.GetFileName(ScheduleFileName);
            try
            {
                File.Copy(ScheduleFileName,newPath, true);
            }
            catch (Exception ex)
            {
                string initError = String.Format("Copyin Schedule error");//TODO: add column
                populateLB(_MW, initError + " " + ex.Message);
            }
        }
        public string TLCDCTimeZone(string _time)
        {
            string time;
            int hourhelper;
            string hours = _time.Substring(0, 2);
            hourhelper = int.Parse(hours) + 1;
            if (hourhelper >24)
            {
                hourhelper = hourhelper - 24;
                hours = hourhelper.ToString();
            }
            if (hourhelper == 24)
            {
                hours = "00";
            }
            else
            {
                hours = hourhelper.ToString();
            }
            if (hours.Length == 1)
            {
                hours = "0" + hours;
            }
            string minutes = _time.Substring(2, 2);
            time = hours + "" + minutes;
            return time;
        }      
        public string FirstEventST()
        {
            DateTime dt = new DateTime();
            string date = scheduleName.Substring(2, 8);
            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);
            string hours = Properties.Settings.Default.cnsweStartTime.Substring(0, 2);
            string minutes = Properties.Settings.Default.cnsweStartTime.Substring(3, 2);
            string seconds = Properties.Settings.Default.cnsweStartTime.Substring(6, 2);
            string frames = Properties.Settings.Default.cnsweStartTime.Substring(9, 2);
            dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hours), int.Parse(minutes), int.Parse(seconds), int.Parse(frames));
            string swetime = day + "/" + month + "/" + year + " " + Properties.Settings.Default.cnsweStartTime;
            string time = TimeZoneInfo.ConvertTimeToUtc(dt, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")).ToString("yyyy-MM-ddThh:mm:ss.ff", CultureInfo.InvariantCulture);
            return time;
        }
        public string TLCDCListTitle()
        {
            string _listTitle = listDate.Day.ToString() + "." + listDate.Month.ToString() + "." + listDate.Year.ToString() + " " + ListType;
            return _listTitle;
        }
        public string CNSWEListTitle()
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
        public static void saveTLCDCRusAudiosToXML(string fileName, TLCDCAudios audios)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TLCDCAudios), "TLCDC");
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, audios);
            }
        }
        public static InterstitalEvent readInterstitalsXML(string fileLocation)
        {
            if (!String.IsNullOrEmpty(fileLocation))
            {

                XmlSerializer reader = new XmlSerializer(typeof(InterstitalEvent));
                StreamReader XMLfile = new StreamReader(fileLocation);
                InterstitalEvent overview;
                try
                {
                    overview = (InterstitalEvent)reader.Deserialize(XMLfile);
                    return overview;
                }
                catch 
                {
                    return null;
                }
                finally
                {
                    XMLfile.Close();
                }
            }
            else
            {
                return null;
            }
        }
        public static TLCDCAudios readRusAudiosXML(string fileLocation)
        {
            if (!String.IsNullOrEmpty(fileLocation))
            {

                XmlSerializer reader = new XmlSerializer(typeof(TLCDCAudios));
                StreamReader XMLfile = new StreamReader(fileLocation);
                TLCDCAudios overview;
                try
                {
                    overview = (TLCDCAudios)reader.Deserialize(XMLfile);
                    return overview;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    XMLfile.Close();
                }
            }
            else
            {
                return null;
            }
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
        public string IntToTimeSpan(double time)
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
        public string StringToTimeFormat(string seconds)
        {
            double secs = double.Parse(seconds);
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            answer = answer.Substring(0, 11);
            return answer;
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
        public void CopyCommercialText(MainWindow MW, string path,string schedulefilepath,string commercialpathname)
        {
            string newPath = path + Path.GetFileName(schedulefilepath);
            try
            {
                File.Copy(schedulefilepath, newPath);
                populateLB(MW, "Copying " + Path.GetFileName(schedulefilepath) + " into workflow folder");
                File.Move(newPath, path+commercialpathname);
            }
            catch(Exception ex)
            {
                string initError = String.Format("Copyin commercialschedule error. "+ex.Message);
                populateLB(MW, initError);
            }
        }
        public void CopyCommercialText(string path, string schedulefilepath, string commercialpathname)
        {
            string newPath = path + Path.GetFileName(schedulefilepath);
            try
            {
                File.Copy(schedulefilepath, newPath);
                File.Move(newPath, path + commercialpathname);
            }
            catch (Exception ex)
            {
                string initError = String.Format("Copyin commercialschedule error. " + ex.Message);
            }
        }
        public void AddCommercialsLB(ListBox lb)
        {
            ReadText readCommercials = new ReadText();
            readCommercials.ReadCommercials();
            List<Commercials> commercials = readCommercials.GetCommercial();
            lb.Items.Clear();
            commercials.ForEach(item => lb.Items.Add("StartTime: "+item.getStartTime()+" FileName: "+item.getFileName()+" Duration: "+item.getDuration()));
            clearDCIDCommercialFolder();
            commercials.Clear();
        }
        public void CopyScheduleExcel(MainWindow MW, string path, string defaultpath)
        {
            string newPath = path + @"\Schedule\" + Path.GetFileName(ScheduleFilePath);
            defaultpath = newPath;
            try
            {
                File.Copy(ScheduleFilePath, newPath);
                populateLB(MW, "Copying " + Path.GetFileName(ScheduleFilePath) + " into workflow folder");
            }
            catch (Exception ex)
            {
                string initError = String.Format("Copyin dailyschedule error " + ex.Message);
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
            FolderName += @"Schedule\";
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(MW, di.FullName);
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
        public void clearDCIDCommercialFolder()
        {
            System.IO.File.Delete(DCIDCommercialPath + Path.GetFileName(CommercialFilePath));
            System.IO.File.Delete(DCIDCommercialPath+"test.txt");
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
