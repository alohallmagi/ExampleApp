using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
        string OleDBDir;
        OleDbConnection conn = new OleDbConnection();
            
            string query = "SELECT * FROM " +Utility.DCIDCommercialPath+"test.txt";
            string duration;
            string filename;
            string filetitle;
            string starttime;

            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();

                OleDBDir = Path.GetDirectoryName(Utility.DCIDCommercialPath);
                conn = new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + OleDBDir + ";Extended Properties=\"Text;HDR=YES;FMT=Fixed\"");
                OleDbDataAdapter cmd = new OleDbDataAdapter(query, conn);
                cmd.Fill(dataSet, "Events");
                dt = dataSet.Tables["Events"];

                foreach (DataRow dr in dt.Rows)
                {
                starttime = dr["SpotTime"].ToString();
                duration = dr["SpotLength"].ToString();
                if (!String.IsNullOrEmpty(starttime))
                {
                    if (starttime.Length<6)
                    {
                        starttime = "0" + starttime;
                    }
                    starttime = starttime.Substring(0, 4);
                    int helper = int.Parse(starttime.Substring(3, 1));
                    if (helper<5)
                    {
                        helper = 0;
                    }
                    else
                    {
                        helper = 5;
                    }
                    starttime = starttime.Substring(0, 3) + helper.ToString();
                }
                
                filename = dr["HourseNumber"].ToString();
                filetitle = dr["ProductDescription"].ToString();
                Console.WriteLine("{0}, {1}, {2}, {3}", starttime, duration, filename, filetitle);
            }
            Console.ReadLine();
            
            }

    }
}