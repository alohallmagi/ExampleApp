using testApp.Models;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace testApp
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
        private string rusAudio;
        private string estAudio;
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
        private string[] firstRow;
        private string[] firstCNSWERow, firstTNTRow, TurnerRow;
        private string[] firstTLCComRow;
        private string[] firstDCComRow;
        private string[] firstTLCScheduleRow;
        private string[] firstDCScheduleRow;
        private MainWindow _MW;

        public ReadExcel() { }

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
                firstCNSWERow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\CNSWE\Workflow\cfg\commercialfirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading CNSWE commercial.cfg " + ex.Message);
            }
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
            validateFirstRow(firstCNSWERow, Properties.Settings.Default.cnsweComStartRow);
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
                            startTime = StartTime(i);
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
            AppRusAudios tlcdcRusAudios = new AppRusAudios();
            tlcdcRusAudios.ReadAudios();
            List<RussianAudios> rusAudios = tlcdcRusAudios.GetList();

            this._MW = MW;
            try
            {
                firstTLCComRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\TLC\Workflow\cfg\commercialfirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading TLC commercial.cfg " + ex.Message);
            }
            OpenExcelApp(_MW, Utility.CommercialFilePath);
            commercialamount = 0;
            validateFirstRow(firstTLCComRow, Properties.Settings.Default.tlcComStartRow);
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
                            startTime = startTime.Substring(0, 2) + "" + startTime.Substring(3, 2);
                            errorcolumn = 8;
                            fileTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 8;
                            fileName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            estAudio = fileName + Properties.Settings.Default.tlcdcEstAudioExtension;
                            rusAudio = fileName + Properties.Settings.Default.tlcdcEstAudioExtension;
                            RusAudios(rusAudios);
                            errorcolumn = 9;
                            duration = (int)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 5;
                            programTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;

                            commercials.Add(new Commercials(startTime, fileName, fileTitle, programTitle, duration,rusAudio,estAudio));

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
            finally {
                utility.CloseExcelItems();
                tlcdcRusAudios.ClearAudios();
            }
        }
        public void OpenDCCommercialExcelFile(MainWindow MW)
        {
            AppRusAudios tlcdcRusAudios = new AppRusAudios();
            tlcdcRusAudios.ReadAudios();
            List<RussianAudios> rusAudios = tlcdcRusAudios.GetList();
            this._MW = MW;
            try
            {
                firstDCComRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\DC\Workflow\cfg\commercialfirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading DC commercial.cfg " + ex.Message);
            }
            OpenExcelApp(_MW, Utility.CommercialFilePath);
            commercialamount = 0;
            validateFirstRow(firstDCComRow, Properties.Settings.Default.dcComStartRow);
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
                            startTime = startTime.Substring(0, 2) + "" + startTime.Substring(3, 2);
                            errorcolumn = 8;
                            fileTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 8;
                            fileName = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            estAudio = fileName + Properties.Settings.Default.tlcdcEstAudioExtension;
                            rusAudio = fileName + Properties.Settings.Default.tlcdcEstAudioExtension;
                            RusAudios(rusAudios);
                            errorcolumn = 9;
                            duration = (int)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                            errorcolumn = 5;
                            programTitle = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;

                            commercials.Add(new Commercials(startTime, fileName, fileTitle, programTitle, duration,rusAudio,estAudio));

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
            finally {
                utility.CloseExcelItems();
                tlcdcRusAudios.ClearAudios();
            }
        }
        public void OpenTLCScheduleExcelFile(MainWindow MW)
        {
            this._MW = MW;
            try
            {
                firstTLCScheduleRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\TLC\Workflow\cfg\schedulefirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading TLC schedule.cfg "+ex.Message);
                Utility.IsScheduleFirstRowCorrect = false;
            }
            if (Utility.IsScheduleFirstRowCorrect)
            {

            OpenExcelApp(_MW, Utility.ScheduleFilePath);
            validateFirstRow(firstTLCScheduleRow, Properties.Settings.Default.tlcScheduleStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    utility.populateLB(_MW, "Searching for " + Utility.listDate.Day.ToString() + "." + Utility.listDate.Month.ToString() + "." + Utility.listDate.Year.ToString() + " from schedule.");
                    for (int i = Properties.Settings.Default.tlcScheduleStartRow + 1; i <= ScheduleRange.Rows.Count; i++)
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
                                fstBreakTime = utility.TLCDCTimeZone(fstBreakTime);
                                errorcolumn = 8;
                                fstBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 9;
                                sndBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                sndBreakTime = utility.TLCDCTimeZone(sndBreakTime);
                                errorcolumn = 10;
                                sndBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 11;
                                if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                {
                                    trdBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                    trdBreakTime = utility.TLCDCTimeZone(trdBreakTime);
                                    errorcolumn = 12;
                                    trdBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                    errorcolumn = 13;
                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                    {
                                        frtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        frtBreakTime = utility.TLCDCTimeZone(frtBreakTime);
                                        errorcolumn = 14;
                                        frtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        errorcolumn = 15;
                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                        {
                                            fitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            fitBreakTime = utility.TLCDCTimeZone(fitBreakTime);
                                            errorcolumn = 16;
                                            fitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            errorcolumn = 17;
                                            if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                            {
                                                sxtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                sxtBreakTime = utility.TLCDCTimeZone(sxtBreakTime);
                                                errorcolumn = 18;
                                                sxtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                errorcolumn = 19;
                                                if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                {
                                                    sntBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    sntBreakTime = utility.TLCDCTimeZone(sntBreakTime);
                                                    errorcolumn = 20;
                                                    sntBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    errorcolumn = 21;
                                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                    {
                                                        egtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        egtBreakTime = utility.TLCDCTimeZone(egtBreakTime);
                                                        errorcolumn = 22;
                                                        egtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        errorcolumn = 23;
                                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                        {

                                                            nitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                            nitBreakTime = utility.TLCDCTimeZone(nitBreakTime);
                                                            errorcolumn = 24;
                                                            nitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        }
                                                        else
                                                        {
                                                            nitBreakTime = "";
                                                            nitBreakDuration = "0";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        egtBreakTime = "";
                                                        egtBreakDuration = "0";
                                                        nitBreakTime = "";
                                                        nitBreakDuration = "0";
                                                    }
                                                }
                                                else
                                                {
                                                    sntBreakTime = "";
                                                    sntBreakDuration = "0";
                                                    egtBreakTime = "";
                                                    egtBreakDuration = "0";
                                                    nitBreakTime = "";
                                                    nitBreakDuration = "0";
                                                }
                                            }
                                            else
                                            {
                                                sxtBreakTime = "";
                                                sxtBreakDuration = "0";
                                                sntBreakTime = "";
                                                sntBreakDuration = "0";
                                                egtBreakTime = "";
                                                egtBreakDuration = "0";
                                                nitBreakTime = "";
                                                nitBreakDuration = "0";
                                            }
                                        }
                                        else
                                        {
                                            fitBreakTime = "";
                                            fitBreakDuration = "0";
                                            sxtBreakTime = "";
                                            sxtBreakDuration = "0";
                                            sntBreakTime = "";
                                            sntBreakDuration = "0";
                                            egtBreakTime = "";
                                            egtBreakDuration = "0";
                                            nitBreakTime = "";
                                            nitBreakDuration = "0";
                                        }
                                    }
                                    else
                                    {
                                        frtBreakTime = "";
                                        frtBreakDuration = "0";
                                        fitBreakTime = "";
                                        fitBreakDuration = "0";
                                        sxtBreakTime = "";
                                        sxtBreakDuration = "0";
                                        sntBreakTime = "";
                                        sntBreakDuration = "0";
                                        egtBreakTime = "";
                                        egtBreakDuration = "0";
                                        nitBreakTime = "";
                                        nitBreakDuration = "0";
                                    }
                                }
                                else
                                {
                                    trdBreakTime = "";
                                    trdBreakDuration = "0";
                                    frtBreakTime = "";
                                    frtBreakDuration = "0";
                                    fitBreakTime = "";
                                    fitBreakDuration = "0";
                                    sxtBreakTime = "";
                                    sxtBreakDuration = "0";
                                    sntBreakTime = "";
                                    sntBreakDuration = "0";
                                    egtBreakTime = "";
                                    egtBreakDuration = "0";
                                    nitBreakTime = "";
                                    nitBreakDuration = "0";
                                }
                                schedule.Add(new TLCDCSchedule(startTime, liveName, fstBreakTime, sndBreakTime, trdBreakTime, frtBreakTime, fitBreakTime, sxtBreakTime, sntBreakTime, egtBreakTime, nitBreakTime, int.Parse(fstBreakDuration), int.Parse(sndBreakDuration), int.Parse(trdBreakDuration), int.Parse(frtBreakDuration), int.Parse(fitBreakDuration), int.Parse(sxtBreakDuration), int.Parse(sntBreakDuration), int.Parse(egtBreakDuration), int.Parse(nitBreakDuration)));
                            }
                        }
                    }
                    utility.populateLB(_MW, "TLC " + Utility.listDate.Day.ToString() + "." + Utility.listDate.Month.ToString() + "." + Utility.listDate.Year.ToString() + " Schedule readed.");
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
        }
        public void OpenDCScheduleExcelFile(MainWindow MW)
        {
            this._MW = MW;
            try
            {
                firstDCScheduleRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\DC\Workflow\cfg\schedulefirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading DC schedule.cfg " + ex.Message);
                Utility.IsScheduleFirstRowCorrect = false;
            }
            if (Utility.IsScheduleFirstRowCorrect)
            {
            OpenExcelApp(_MW, Utility.ScheduleFilePath);
            validateFirstRow(firstDCScheduleRow, Properties.Settings.Default.dcScheduleStartRow);
            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    utility.populateLB(_MW, "Searching for "+Utility.listDate.Day.ToString()+"."+Utility.listDate.Month.ToString()+"."+Utility.listDate.Year.ToString()+" from schedule.");
                    for (int i = Properties.Settings.Default.dcScheduleStartRow + 1; i <= ScheduleRange.Rows.Count; i++)
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
                                fstBreakTime = utility.TLCDCTimeZone(fstBreakTime);
                                errorcolumn = 8;
                                fstBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 9;
                                sndBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                sndBreakTime = utility.TLCDCTimeZone(sndBreakTime);
                                errorcolumn = 10;
                                sndBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                errorcolumn = 11;
                                if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                {
                                    trdBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                    trdBreakTime = utility.TLCDCTimeZone(trdBreakTime);
                                    errorcolumn = 12;
                                    trdBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                    errorcolumn = 13;
                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                    {
                                        frtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        frtBreakTime = utility.TLCDCTimeZone(frtBreakTime);
                                        errorcolumn = 14;
                                        frtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        errorcolumn = 15;
                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                        {
                                            fitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            fitBreakTime = utility.TLCDCTimeZone(fitBreakTime);
                                            errorcolumn = 16;
                                            fitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            errorcolumn = 17;
                                            if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                            {
                                                sxtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                sxtBreakTime = utility.TLCDCTimeZone(sxtBreakTime);
                                                errorcolumn = 18;
                                                sxtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                errorcolumn = 19;
                                                if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                {
                                                    sntBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    sntBreakTime = utility.TLCDCTimeZone(sntBreakTime);
                                                    errorcolumn = 20;
                                                    sntBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    errorcolumn = 21;
                                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                    {
                                                        egtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        egtBreakTime = utility.TLCDCTimeZone(egtBreakTime);
                                                        errorcolumn = 22;
                                                        egtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        errorcolumn = 23;
                                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                        {

                                                            nitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                            nitBreakTime = utility.TLCDCTimeZone(nitBreakTime);
                                                            errorcolumn = 24;
                                                            nitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        }
                                                        else
                                                        {
                                                            nitBreakTime = "";
                                                            nitBreakDuration = "0";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        egtBreakTime = "";
                                                        egtBreakDuration = "0";
                                                        nitBreakTime = "";
                                                        nitBreakDuration = "0";
                                                    }
                                                }
                                                else
                                                {
                                                    sntBreakTime = "";
                                                    sntBreakDuration = "0";
                                                    egtBreakTime = "";
                                                    egtBreakDuration = "0";
                                                    nitBreakTime = "";
                                                    nitBreakDuration = "0";
                                                }
                                            }
                                            else
                                            {
                                                sxtBreakTime = "";
                                                sxtBreakDuration = "0";
                                                sntBreakTime = "";
                                                sntBreakDuration = "0";
                                                egtBreakTime = "";
                                                egtBreakDuration = "0";
                                                nitBreakTime = "";
                                                nitBreakDuration = "0";
                                            }
                                        }
                                        else
                                        {
                                            fitBreakTime = "";
                                            fitBreakDuration = "0";
                                            sxtBreakTime = "";
                                            sxtBreakDuration = "0";
                                            sntBreakTime = "";
                                            sntBreakDuration = "0";
                                            egtBreakTime = "";
                                            egtBreakDuration = "0";
                                            nitBreakTime = "";
                                            nitBreakDuration = "0";
                                        }
                                    }
                                    else
                                    {
                                        frtBreakTime = "";
                                        frtBreakDuration = "0";
                                        fitBreakTime = "";
                                        fitBreakDuration = "0";
                                        sxtBreakTime = "";
                                        sxtBreakDuration = "0";
                                        sntBreakTime = "";
                                        sntBreakDuration = "0";
                                        egtBreakTime = "";
                                        egtBreakDuration = "0";
                                        nitBreakTime = "";
                                        nitBreakDuration = "0";
                                    }
                                }
                                else
                                {
                                    trdBreakTime = "";
                                    trdBreakDuration = "0";
                                    frtBreakTime = "";
                                    frtBreakDuration = "0";
                                    fitBreakTime = "";
                                    fitBreakDuration = "0";
                                    sxtBreakTime = "";
                                    sxtBreakDuration = "0";
                                    sntBreakTime = "";
                                    sntBreakDuration = "0";
                                    egtBreakTime = "";
                                    egtBreakDuration = "0";
                                    nitBreakTime = "";
                                    nitBreakDuration = "0";
                                }
                                schedule.Add(new TLCDCSchedule(startTime, liveName, fstBreakTime, sndBreakTime, trdBreakTime, frtBreakTime, fitBreakTime, sxtBreakTime, sntBreakTime, egtBreakTime, nitBreakTime, int.Parse(fstBreakDuration), int.Parse(sndBreakDuration), int.Parse(trdBreakDuration), int.Parse(frtBreakDuration), int.Parse(fitBreakDuration), int.Parse(sxtBreakDuration), int.Parse(sntBreakDuration), int.Parse(egtBreakDuration), int.Parse(nitBreakDuration)));
                            }
                        }
                    }
                    utility.populateLB(_MW, "DC " + Utility.listDate.Day.ToString() + "." + Utility.listDate.Month.ToString() + "."+Utility.listDate.Year.ToString()+" Schedule readed.");
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
        }
        public void OpenDCIDScheduleExcelFile(MainWindow MW)
        {
            this._MW = MW;
            try
            {
                firstDCScheduleRow = System.IO.File.ReadAllLines(@"C:\AutomatedLists\DCID\Workflow\cfg\schedulefirstrow.txt");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "Error reading DCID schedule.cfg " + ex.Message);
                Utility.IsScheduleFirstRowCorrect = false;
            }
            if (Utility.IsScheduleFirstRowCorrect)
            {
                OpenExcelApp(_MW, Utility.ScheduleFilePath);
                validateFirstRow(firstDCScheduleRow, Properties.Settings.Default.dcScheduleStartRow);
                try
                {
                    if (String.IsNullOrEmpty(Utility.initError))
                    {
                        utility.populateLB(_MW, "Searching for " + Utility.listDate.Day.ToString() + "." + Utility.listDate.Month.ToString() + "." + Utility.listDate.Year.ToString() + " from schedule.");
                        for (int i = Properties.Settings.Default.dcScheduleStartRow + 1; i <= ScheduleRange.Rows.Count; i++)
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
                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                    {
                                        trdBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        errorcolumn = 12;
                                        trdBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                        errorcolumn = 13;
                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                        {
                                            frtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            errorcolumn = 14;
                                            frtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                            errorcolumn = 15;
                                            if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                            {
                                                fitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                errorcolumn = 16;
                                                fitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                errorcolumn = 17;
                                                if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                {
                                                    sxtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    errorcolumn = 18;
                                                    sxtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                    errorcolumn = 19;
                                                    if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                    {
                                                        sntBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        errorcolumn = 20;
                                                        sntBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                        errorcolumn = 21;
                                                        if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                        {
                                                            egtBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                            errorcolumn = 22;
                                                            egtBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                            errorcolumn = 23;
                                                            if (!String.IsNullOrEmpty((string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2))
                                                            {

                                                                nitBreakTime = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                                errorcolumn = 24;
                                                                nitBreakDuration = (string)(ScheduleRange.Cells[i, errorcolumn] as Excel.Range).Value2;
                                                            }
                                                            else
                                                            {
                                                                nitBreakTime = "";
                                                                nitBreakDuration = "0";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            egtBreakTime = "";
                                                            egtBreakDuration = "0";
                                                            nitBreakTime = "";
                                                            nitBreakDuration = "0";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        sntBreakTime = "";
                                                        sntBreakDuration = "0";
                                                        egtBreakTime = "";
                                                        egtBreakDuration = "0";
                                                        nitBreakTime = "";
                                                        nitBreakDuration = "0";
                                                    }
                                                }
                                                else
                                                {
                                                    sxtBreakTime = "";
                                                    sxtBreakDuration = "0";
                                                    sntBreakTime = "";
                                                    sntBreakDuration = "0";
                                                    egtBreakTime = "";
                                                    egtBreakDuration = "0";
                                                    nitBreakTime = "";
                                                    nitBreakDuration = "0";
                                                }
                                            }
                                            else
                                            {
                                                fitBreakTime = "";
                                                fitBreakDuration = "0";
                                                sxtBreakTime = "";
                                                sxtBreakDuration = "0";
                                                sntBreakTime = "";
                                                sntBreakDuration = "0";
                                                egtBreakTime = "";
                                                egtBreakDuration = "0";
                                                nitBreakTime = "";
                                                nitBreakDuration = "0";
                                            }
                                        }
                                        else
                                        {
                                            frtBreakTime = "";
                                            frtBreakDuration = "0";
                                            fitBreakTime = "";
                                            fitBreakDuration = "0";
                                            sxtBreakTime = "";
                                            sxtBreakDuration = "0";
                                            sntBreakTime = "";
                                            sntBreakDuration = "0";
                                            egtBreakTime = "";
                                            egtBreakDuration = "0";
                                            nitBreakTime = "";
                                            nitBreakDuration = "0";
                                        }
                                    }
                                    else
                                    {
                                        trdBreakTime = "";
                                        trdBreakDuration = "0";
                                        frtBreakTime = "";
                                        frtBreakDuration = "0";
                                        fitBreakTime = "";
                                        fitBreakDuration = "0";
                                        sxtBreakTime = "";
                                        sxtBreakDuration = "0";
                                        sntBreakTime = "";
                                        sntBreakDuration = "0";
                                        egtBreakTime = "";
                                        egtBreakDuration = "0";
                                        nitBreakTime = "";
                                        nitBreakDuration = "0";
                                    }
                                    schedule.Add(new TLCDCSchedule(startTime, liveName, fstBreakTime, sndBreakTime, trdBreakTime, frtBreakTime, fitBreakTime, sxtBreakTime, sntBreakTime, egtBreakTime, nitBreakTime, int.Parse(fstBreakDuration), int.Parse(sndBreakDuration), int.Parse(trdBreakDuration), int.Parse(frtBreakDuration), int.Parse(fitBreakDuration), int.Parse(sxtBreakDuration), int.Parse(sntBreakDuration), int.Parse(egtBreakDuration), int.Parse(nitBreakDuration)));
                                }
                            }
                        }
                        utility.populateLB(_MW, "DC " + Utility.listDate.Day.ToString() + "." + Utility.listDate.Month.ToString() + "." + Utility.listDate.Year.ToString() + " Schedule readed.");
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
        }        

        public string TNTCommercialExcel()
        {
            string message="";
            firstTNTRow= System.IO.File.ReadAllLines(@"C:\AutomatedLists\TNT\Workflow\cfg\commercialfirstrow.txt");
            message = OpenTurnerExcel(Utility.CommercialFilePath);
            message += validateTNTFirstRow(firstTNTRow, Properties.Settings.Default.TNTComStartRow);

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
                            startTime = StartTime(i);
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
                    message += "\nCommercials has been readed!";
                }
                return message;
            }
            catch (Exception ex)
             {
                Utility.initError = String.Format("\nCommercials - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                message += Utility.initError;
                return message;
            }
            finally { utility.CloseExcelItems();
            }
        }

        public string CommercialExcel(string path, int rowindex)
        {
            string message = "";
            TurnerRow = System.IO.File.ReadAllLines(path);
            message = OpenTurnerExcel(Utility.CommercialFilePath);
            message += validateTNTFirstRow(TurnerRow, rowindex);

            try
            {
                if (String.IsNullOrEmpty(Utility.initError))
                {
                    for (int i = rowindex+2; i <= ScheduleRange.Rows.Count; i++)
                    {
                        errorline = i;
                        if (!String.IsNullOrWhiteSpace((string)(ScheduleRange.Cells[i, 7] as Excel.Range).Value2))
                        {
                            commercialamount++;
                            errorcolumn = 4;
                            startTime = StartTime(i);
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
                    message += "\nCommercials has been readed!";
                }
                return message;
            }
            catch (Exception ex)
            {
                Utility.initError = String.Format("\nCommercials - Error on {0} row {1} column. ErrorCode: {2}", errorline, errorcolumn, ex.Message);
                Utility.IsCommercialsCorrect = false;
                message += Utility.initError;
                return message;
            }
            finally
            {
                utility.CloseExcelItems();
            }
        }

        private void OpenExcelApp(MainWindow MW, string path)
        {
            this._MW = MW;
            try
            {
                utility.OpenExcelApplication(path);
                utility.OpenExcelRange(1);
                ScheduleRange = Utility.ExcelRange;
                utility.populateLB(_MW, "Reading " + Path.GetFileName(path));

            }
            catch
            {
                utility.CloseExcelItems();
                utility.populateLB(_MW, "ERROR: Failed to open " + Path.GetFileName(path));
            }
        }
        private string OpenTurnerExcel(string path)
        {
            string message;
            try
            {
                utility.OpenExcelApplication(path);
                utility.OpenExcelRange(1);
                ScheduleRange = Utility.ExcelRange;
                message = "\nReading " + Path.GetFileName(path);

            }
            catch
            {
                utility.CloseExcelItems();
                message = "\nError at reading " + Path.GetFileName(path);
            }
            return message;
        }

        private void readFirstRow(string firstrowPath)
        {
            try
            {
               firstRow = System.IO.File.ReadAllLines(firstrowPath);
            }
            catch
            {
                //TODO Error handling
            }
        }
        private void validateFirstRow(string[] firstRow, int startingrow)
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
                Utility.initError += "Failed getting first row: " + ex.Message;
            }
            finally
            {
                if (Utility.initError != "" || !String.IsNullOrEmpty(Utility.initError))
                    utility.populateLB(_MW, Utility.initError);
            }

        }
        private string validateTNTFirstRow(string[] firstRow, int startingrow)
        {
            string initError="";
            try
            {
                for (int i = 1; i <= firstRow.Length; i++)
                {
                    if ((string)(ScheduleRange.Cells[startingrow, i] as Excel.Range).Value2 != null)
                    {
                        var cellValue = (string)(ScheduleRange.Cells[startingrow, i] as Excel.Range).Value2;
                        if (!(cellValue.ToString()).Equals(firstRow[i - 1]))
                        {
                            initError = String.Format("Column {0} contains {1}, expected: {2} \r\n", i, cellValue.ToString(), firstRow[i - 1]);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                initError = "Failed getting first row: " + ex.Message;
            }
            return initError;

        }
        private void RusAudios(List<RussianAudios> rusAudios)
        {
            if (Properties.Settings.Default.tlcdcUseRusAudios)
            {
                foreach (RussianAudios item in rusAudios)
                {
                    if (!String.IsNullOrEmpty(item.getFileName()))
                    {
                        if (fileName.Contains(item.getFileName()))
                        {
                            rusAudio = fileName + Properties.Settings.Default.tlcdcRusAudioExtension;
                        }
                    }
                }
            }
        }

        private string StartTime(int rownr)
        {
            string time;
            try
            {
                dhelper = (double)(ScheduleRange.Cells[rownr, errorcolumn] as Excel.Range).Value2;
                return time = utility.DoubleToTime(dhelper);
            }
            catch
            {
                string shelper = (string)(ScheduleRange.Cells[rownr, errorcolumn] as Excel.Range).Value2;
                int ihelper = int.Parse(shelper.Substring(0, 2));
                if (ihelper > 23)
                {
                    ihelper = ihelper - 24;
                    shelper = "0" + ihelper + shelper.Substring(2) + ":00";
                }
                time = shelper;
                return time;
            }
        }
    }
}
