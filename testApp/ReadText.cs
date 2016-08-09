using testApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public class ReadText
    {
        Utility utility = new Utility();
        private List<Trigger> triggers = new List<Trigger>();
        private List<Commercials> commercials = new List<Commercials>();
        public List<Commercials> GetCommercial()
        {
            return commercials;
        }
        public List<Trigger> GetList()
        {
            return triggers;
        }
        public static string SchedulePath;
        private string OleDBDir;
        private bool DBConnection = false;
        private OleDbConnection conn = new OleDbConnection();
        MainWindow _MW;

        public ReadText() { }

        private void CreateDBConnection()
        {
            try
            {                
                OleDBDir = Path.GetDirectoryName(Utility.CNSWEScheduledfile);
                conn = new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + OleDBDir + ";Extended Properties=\"Text;HDR=YES;FMT=Fixed\"");
                DBConnection = true;
            }
            catch
            {
                DBConnection = false;
            }
        }
        private void CloseDBConnection()
        {
            if (!DBConnection)
            {
                conn.Close();
            }
        }
        public void ReadDaySchedule(MainWindow MW)
        {
            SchedulePath= File.ReadLines(Utility.CNSWEScheduledfile).First();
            SchedulePath = SchedulePath.Substring(7, 8);

            this._MW = MW;
            List<string> test = new List<string>();
            string search = "'CN Nordic cue tone start'";
            string search1 = "'CN Nordic cue tone end'";
            string query = "SELECT ScheduledTime FROM " + Utility.CNSWEScheduledfile + " WHERE Description=" + search;
            string query1 = "SELECT ScheduledTime FROM " + Utility.CNSWEScheduledfile + " WHERE Description=" + search1;
            string triggerName;
            string timeHelper;
            string helper;
            int starttime;
            int endtime;
            int i = 0;
            int duration = 0;

            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            DataSet dataSet1 = new DataSet();
            DataTable dt1 = new DataTable();
            try
            {
                CreateDBConnection();
                OleDbDataAdapter cmd = new OleDbDataAdapter(query, conn);
                utility.populateLB(_MW, "OleDB Connection sucessful");
                cmd.Fill(dataSet, "Events");
                dt = dataSet.Tables["Events"];

                cmd.Fill(dataSet, "Start Time");
                dt = dataSet.Tables["Start Time"];

                cmd = new OleDbDataAdapter(query1, conn);
                cmd.Fill(dataSet1, "End Time");
                dt1 = dataSet1.Tables["End Time"];
                utility.populateLB(_MW, "Triggers: ");
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["ScheduledTime"].ToString().Substring(2, 1).Equals("0") && dt1.Rows[i]["ScheduledTime"].ToString().Substring(2, 1).Equals("0"))
                    {
                        helper = "6" + dr["ScheduledTime"].ToString().Substring(3);
                        starttime = int.Parse(helper);
                    }
                    else
                    {
                        starttime = int.Parse(dr["ScheduledTime"].ToString().Substring(2));
                    }


                    if (dt1.Rows[i]["ScheduledTime"].ToString().Substring(2, 1).Equals("0"))
                    {
                        helper = "6" + dt1.Rows[i]["ScheduledTime"].ToString().Substring(3);
                        endtime = int.Parse(helper);
                    }
                    else
                    {
                        endtime = int.Parse(dt1.Rows[i]["ScheduledTime"].ToString().Substring(2));
                    }

                    duration = endtime - starttime;
                    timeHelper = "000" + duration.ToString();

                    if (utility.TimeToSeconds(timeHelper) % 60 != 0)
                    {
                        int test2 = utility.TimeToSeconds(timeHelper) % 60;
                        timeHelper = "000" + duration.ToString().Substring(0, 1) + test2;
                        if (timeHelper.Length <= 6)
                        {
                            int lengthhelper = 8 - timeHelper.Length;
                            while (timeHelper.Length != 8)
                            {

                                timeHelper += "0";
                            }
                            utility.populateLB(_MW, "WARNING! Please DOUBLE CHECK Schedule list between starttime " + dr["ScheduledTime"].ToString() + " and endtime " + dt1.Rows[i]["ScheduledTime"].ToString());
                            utility.populateLB(_MW, "Break duration is " + utility.StringToPredictedTime(timeHelper));
                        }

                    }
                    else
                    {
                        timeHelper = "000" + duration.ToString();
                    }


                    triggerName = "CN Nordic cue tone start " +SchedulePath + dr["ScheduledTime"].ToString();
                    triggers.Add(new Trigger(triggerName, dr["ScheduledTime"].ToString(), utility.StringToPredictedTime(timeHelper), utility.TimeToSeconds(timeHelper)));
                    i++;
                }
                utility.populateLB(_MW, "Created!");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "ERROR: Failed getting information from daily schedule.\r\n OleDB failed! " + ex.Message);
                DBConnection = false;
                CloseDBConnection();
            }


        }
        public void ReadCommercials()
        {
            List<string> test = new List<string>();
            string query = "SELECT * FROM " + Utility.DCIDCommercialPath + "test.txt";
            string duration;
            string filename;
            string filetitle;
            string starttime;
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                CreateDBConnection();
                OleDbDataAdapter cmd = new OleDbDataAdapter(query, conn);
                cmd.Fill(dataSet, "Commercials");
                dt = dataSet.Tables["Commercials"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (!String.IsNullOrEmpty(dr["SpotTime"].ToString()))
                    {

                        starttime = dr["SpotTime"].ToString();
                        duration = dr["SpotLength"].ToString();
                        if (!String.IsNullOrEmpty(starttime))
                        {
                            if (starttime.Length < 6)
                            {
                                starttime = "0" + starttime;
                            }
                            starttime = starttime.Substring(0, 4);
                            int helper = int.Parse(starttime.Substring(3, 1));
                            if (helper < 5)
                            {
                                helper = 0;
                            }
                            else
                            {
                                helper = 5;
                            }
                            starttime = starttime.Substring(0, 3) + helper.ToString();
                        }
                        if (Properties.Settings.Default.useFindReplace)
                        {
                            filename = dr["HourseNumber"].ToString().Replace(Properties.Settings.Default.dcidFindWord,Properties.Settings.Default.dcidReplaceWord);
                        }
                        else
                        {
                            filename = dr["HourseNumber"].ToString();
                        }
                        filetitle = dr["ProductDescription"].ToString();
                        commercials.Add(new Commercials(starttime, filename, int.Parse(duration), filetitle));
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch
            {
                DBConnection = false;
                CloseDBConnection();
            }

        }
        public void ReadCommercials(MainWindow MW)
        {
            this._MW = MW;
            List<string> test = new List<string>();
            string query = "SELECT * FROM " + Utility.DCIDCommercialPath + "test.txt";
            string duration;
            string filename;
            string filetitle;
            string starttime;
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                CreateDBConnection();
                OleDbDataAdapter cmd = new OleDbDataAdapter(query, conn);
                utility.populateLB(_MW, "OleDB Connection sucessful");
                cmd.Fill(dataSet, "Commercials");
                dt = dataSet.Tables["Commercials"];
                utility.populateLB(_MW, "Commercials: ");
                foreach (DataRow dr in dt.Rows)
                {
                    if (!String.IsNullOrEmpty(dr["SpotTime"].ToString()))
                    {

                        starttime = dr["SpotTime"].ToString();
                        duration = dr["SpotLength"].ToString();
                        if (!String.IsNullOrEmpty(starttime))
                        {
                            if (starttime.Length < 6)
                            {
                                starttime = "0" + starttime;
                            }
                            starttime = starttime.Substring(0, 4);
                            int helper = int.Parse(starttime.Substring(3, 1));
                            if (helper < 5)
                            {
                                helper = 0;
                            }
                            else
                            {
                                helper = 5;
                            }
                            starttime = starttime.Substring(0, 3) + helper.ToString();
                        }
                        if (Properties.Settings.Default.useFindReplace)
                        {
                            filename = dr["HourseNumber"].ToString().Replace(Properties.Settings.Default.dcidFindWord, Properties.Settings.Default.dcidReplaceWord);
                        }
                        else
                        {
                            filename = dr["HourseNumber"].ToString();
                        }
                        filetitle = dr["ProductDescription"].ToString();
                        commercials.Add(new Commercials(starttime, filename, int.Parse(duration), filetitle));
                    }
                    else
                    {
                        continue;
                    }
                }

                utility.populateLB(_MW, "Created!");
            }
            catch (Exception ex)
            {
                utility.populateLB(_MW, "ERROR: Failed getting information from commercial schedule.\r\n OleDB failed! " + ex.Message);
                DBConnection = false;
                CloseDBConnection();
            }

        }
    }
}
