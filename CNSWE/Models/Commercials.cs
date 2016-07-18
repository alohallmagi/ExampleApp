using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSWE.Models
{
   public class Commercials
    {
        string startTime;
        string fileName;
        string fileTitle;
        string programTitle;
        int duration;
        public Commercials(string _starttime, string _filename, string _filetitle, string _programtitle, int _duration)
        {
            startTime = _starttime;
            fileName = _filename;
            fileTitle = _filetitle;
            programTitle = _programtitle;
            duration = _duration;
        }
        public string getStartTime()
        {
            return startTime;
        }
        public string getFileName()
        {
            return fileName;
        }
        public string getFileTitle()
        {
            return fileTitle;
        }
        public string getProgramTitle()
        {
            return programTitle;
        }
        public int getDuration()
        {
            return duration;
        }
    }
}
