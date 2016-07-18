using CNSWE.Models;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CNSWE
{
    public class ReadExcel
    {
        private List<Commercials> commercials = new List<Commercials>();
        private List<TLCDCSchedule> schedule = new List<TLCDCSchedule>();
        public static TimeSpan ts;
        private string _helper;
        private double dhelper;
        private int commercialamount;
        private static int errorline;
        private static int errorcolumn;
        private string startTime;
        private string liveName;
        private string fstBreakTime;
        private string fstBreakDuration;
        private string sndBreakTime;
        private string sndBreakDuration;
        private string trdBreakTime;
        private string trdBreakDuration;
        private string frtBreakTime;
        private string frtBreakDuration;
        private string fitBreakTime;
        private string fitBreakDuration;
        private string sxtBreakTime;
        private string sxtBreakDuration;
        private string sntBreakTime;
        private string sntBreakDuration;
        private string egtBreakTime;
        private string egtBreakDuration;
        private string nitBreakTime;
        private string nitBreakDuration;
        private string fileName;
        private string fileTitle;
        private string programTitle;
        private int duration;
        private string[] firstCNSWERow = new string[] { "Spot Sales Area Code", null, "Scheduled Date", "Scheduled Time", "Seq. In Break", "Industry Code", "House Number", "Product", "Length", "Programme/Category" };
        private string[] firstTLCComRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\TLC\Workflow\cfg\commercialfirstrow.txt");
        private string[] firstDCComRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\DC\Workflow\cfg\commercialfirstrow.txt");
        private string[] firstTLCScheduleRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\TLC\Workflow\cfg\schedulefirstrow.txt");
        private string[] firstDCScheduleRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\DC\Workflow\cfg\schedulefirstrow.txt");
        private MainWindow _MW;
        Utility utility = new Utility();
        Excel.Range ScheduleRange;
        public List<Commercials> GetCommercial()
        {
            return commercials;
        }
        public List<TLCDCSchedule> GetSchedule()
        {
            return schedule;
        }
        public void OpenCNSWEExcelFile(MainWindow MW)
        {
            this._MW = MW;
            try
            {
                utility.OpenExcelApplication(Utility.CommercialFilePath);
                utility.OpenExcelRange(1);
                ScheduleRange = Utility.ExcelRange;
                utility.populateLB(_MW, "Reading Commercial Excel file");

            }
            catch
            {
                utility.CloseExcelItems();
                utility.populateLB(_MW, "ERROR: Failed to open Commercial Excel");
            }

            commercialamount = 0;
            readFirstRow(firstCNSWERow, Properties.Settings.Default.cnsweComStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {


                    for (int i = 4; i <= ScheduleRange.Rows.Count; i++)
                    {

                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 7] as Excel.Range).Value2))
                        {
                            commercialamount++;
                            errorcolumn = 4;
                            dhelper = (double)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            startTime = utility.DoubleToTime(dhelper);
                            errorcolumn = 6;
                            fileTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 7;
                            fileName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 9;
                            duration = (int)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 10;
                            programTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;

                            commercials.Add(new Commercials(startTime, fileName, fileTitle, programTitle, duration));

                        }


                    }
                    utility.populateLB(_MW, "Commercials readed. Total amount " + commercialamount.ToString() + " commercials");
                }
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("Commercials - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                utility.populateLB(_MW, Utility.initError);
            }
            finally { utility.CloseExcelItems(); }



        }
        public void OpenTLCCommercialExcelFile(MainWindow MW)
        {
            this._MW = MW;
            OpenExcelApp(_MW, Utility.CommercialFilePath);
            commercialamount = 0;
            readFirstRow(firstTLCComRow, Properties.Settings.Default.tlcComStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    for (int i = 6; i <= ScheduleRange.Rows.Count; i++)
                    {

                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 5] as Excel.Range).Value2))
                        {
                            commercialamount++;
                            errorcolumn = 4;
                            dhelper = (double)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            startTime = utility.DoubleToTime(dhelper);
                            errorcolumn = 8;
                            fileTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 8;
                            fileName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 9;
                            duration = (int)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 5;
                            programTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;

                            commercials.Add(new Commercials(startTime, fileName, fileTitle, programTitle, duration));

                        }
                    }
                    utility.populateLB(_MW, "Commercials readed. Total amount " + commercialamount.ToString() + " commercials");
                }
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("Commercials - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                utility.populateLB(_MW, Utility.initError);
            }
            finally { utility.CloseExcelItems(); }
        }
        public void OpenDCCommercialExcelFile(MainWindow MW)
        {
            this._MW = MW;
            OpenExcelApp(_MW, Utility.CommercialFilePath);
            commercialamount = 0;
            readFirstRow(firstDCComRow, Properties.Settings.Default.dcComStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    for (int i = 6; i <= ScheduleRange.Rows.Count; i++)
                    {

                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 5] as Excel.Range).Value2))
                        {
                            commercialamount++;
                            errorcolumn = 4;
                            dhelper = (double)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            startTime = utility.DoubleToTime(dhelper);
                            errorcolumn = 8;
                            fileTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 8;
                            fileName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 9;
                            duration = (int)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 5;
                            programTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;

                            commercials.Add(new Commercials(startTime, fileName, fileTitle, programTitle, duration));

                        }
                    }
                    utility.populateLB(_MW, "Commercials readed. Total amount " + commercialamount.ToString() + " commercials");
                }
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("Commercials - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                utility.populateLB(_MW, Utility.initError);
            }
            finally { utility.CloseExcelItems(); }
        }
        public void OpenTLCScheduleExcelFile(MainWindow MW)
        {
            this._MW = MW;
            OpenExcelApp(_MW, Utility.ScheduleFilePath);
            readFirstRow(firstTLCScheduleRow, Properties.Settings.Default.tlcScheduleStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    for (int i = 6; i <= ScheduleRange.Rows.Count; i++)
                    {

                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 5] as Excel.Range).Value2))
                        {
                            string day = (string)(ScheduleRange.Cells[i, 1] as Excel.Range).Value2;
                            int _day = int.Parse(day);
                            if (_day == Utility.listDate.Day)
                            {
                                errorcolumn = 4;                             
                                _helper  = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                startTime = _helper.Substring(0, 2) + ":" + _helper.Substring(2);
                                errorcolumn = 5;
                                liveName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 7;
                                fstBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 8;
                                fstBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 9;
                                sndBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 10;
                                sndBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 11;
                                trdBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 12;
                                trdBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 13;
                                frtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 14;
                                frtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 15;
                                fitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 16;
                                fitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 17;
                                sxtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 18;
                                sxtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 19;
                                sntBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 20;
                                sntBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 21;
                                egtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 22;
                                egtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 23;
                                nitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 24;
                                nitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                schedule.Add(new TLCDCSchedule(startTime, liveName, fstBreakTime, sndBreakTime, trdBreakTime, frtBreakTime, fitBreakTime, sxtBreakTime, sntBreakTime, egtBreakTime, nitBreakTime, fstBreakDuration, sndBreakDuration, trdBreakDuration, frtBreakDuration, fitBreakDuration, sxtBreakDuration, sntBreakDuration, egtBreakDuration, nitBreakDuration));
                            }
                        }
                    }
                    utility.populateLB(_MW, "TLC Schedule readed.");
                }
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("Schedule - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                utility.populateLB(_MW, Utility.initError);
            }
            finally { utility.CloseExcelItems(); }
        }
        public void OpenDCScheduleExcelFile(MainWindow MW)
        {
            this._MW = MW;
            OpenExcelApp(_MW, Utility.ScheduleFilePath);
            readFirstRow(firstDCScheduleRow, Properties.Settings.Default.dcScheduleStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    for (int i = 6; i <= ScheduleRange.Rows.Count; i++)
                    {

                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 5] as Excel.Range).Value2))
                        {
                            string day = (string)(ScheduleRange.Cells[i, 1] as Excel.Range).Value2;
                            int _day = int.Parse(day);
                            if (_day == Utility.listDate.Day)
                            {
                                errorcolumn = 4;
                                _helper = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                startTime = _helper.Substring(0, 2) + ":" + _helper.Substring(2);
                                errorcolumn = 5;
                                liveName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 7;
                                fstBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 8;
                                fstBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 9;
                                sndBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 10;
                                sndBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 11;
                                trdBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 12;
                                trdBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 13;
                                frtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 14;
                                frtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 15;
                                fitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 16;
                                fitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 17;
                                sxtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 18;
                                sxtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 19;
                                sntBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 20;
                                sntBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 21;
                                egtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 22;
                                egtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 23;
                                nitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 24;
                                nitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                schedule.Add(new TLCDCSchedule(startTime, liveName, fstBreakTime, sndBreakTime, trdBreakTime, frtBreakTime, fitBreakTime, sxtBreakTime, sntBreakTime, egtBreakTime, nitBreakTime, fstBreakDuration, sndBreakDuration, trdBreakDuration, frtBreakDuration, fitBreakDuration, sxtBreakDuration, sntBreakDuration, egtBreakDuration, nitBreakDuration));
                            }
                        }
                    }
                    utility.populateLB(_MW, "TLC Schedule readed.");
                }
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("Schedule - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                utility.populateLB(_MW, Utility.initError);
            }
            finally { utility.CloseExcelItems(); }
        }
        private void OpenExcelApp(MainWindow MW, string path)
        {
            this._MW = MW;
            try
            {
                utility.OpenExcelApplication(path);
                utility.OpenExcelRange(1);
                ScheduleRange = Utility.ExcelRange;
                utility.populateLB(_MW, "Reading Commercial Excel file");

            }
            catch
            {
                utility.CloseExcelItems();
                utility.populateLB(_MW, "ERROR: Failed to open Commercial Excel");
            }
        }
        private void readFirstRow(string[] firstRow, int startingrow)
        {
            try
            {
                for (int i = 1; i <= firstRow.Length; i++)
                {
                    if ((string)(ScheduleRange.Cells[startingrow, i] as Excel.Range).Value2 != null)
                    {
                        var cellValue = (string)(ScheduleRange.Cells[startingrow, i] as Excel.Range).Value2;
                        if (!(cellValue.ToString()).Equals(firstRow[i - 1]))
                        {
                            Utility.initError += String.Format("Column {0} contains {1}, expected: {2} \r\n", i, cellValue.ToString(), firstRow[i - 1]);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Utility.initError += ex.Message;
            }
            finally
            {
                if (Utility.initError != "" || !String.IsNullOrEmpty(Utility.initError))
                    utility.populateLB(_MW, Utility.initError);
            }

        }

        private static readonly Regex sWhitespace = new Regex(@"\s+");

    }
}
