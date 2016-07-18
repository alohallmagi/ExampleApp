using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Models
{
   public class Commercials
    {
        string startTime;
        string fileName;
        string fileTitle;
        string programTitle;
        int duration;
        string rusAudio;
        string estAudio;
        public Commercials(string _starttime, string _filename, string _filetitle, string _programtitle, int _duration)
        {
            startTime = _starttime;
            fileName = _filename;
            fileTitle = _filetitle;
            programTitle = _programtitle;
            duration = _duration;
        }
        public Commercials(string _starttime, string _filename, string _filetitle, string _programtitle, int _duration, string _rusaudio, string _estaudio)
        {
            startTime = _starttime;
            fileName = _filename;
            fileTitle = _filetitle;
            programTitle = _programtitle;
            duration = _duration;
            rusAudio = _rusaudio;
            estAudio = _estaudio;
        }
        public Commercials(string _starttime, string _filename, int _duration, string _filetitle)
        {
            startTime = _starttime;
            fileName = _filename;
            duration = _duration;
            fileTitle = _filetitle;
        }
        public string getRusAudio()
        {
            return rusAudio;
        }
        public string getEstAudio()
        {
            return estAudio;
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
