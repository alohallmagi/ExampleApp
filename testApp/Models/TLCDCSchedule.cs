using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Models
{
    public class TLCDCSchedule
    {
        string _startTime;
        string _liveName;
        string _fstBreakTime;
        string _sndBreakTime;
        string _trdBreakTime;
        string _frtBreakTime;
        string _fitBreakTime;
        string _sxtBreakTime;
        string _sntBreakTime;
        string _egtBreakTime;
        string _nitBreakTime;
        int _fstBreakDuration;
        int _sndBreakDuration;
        int _trdBreakDuration;
        int _frtBreakDuration;
        int _fitBreakDuration;
        int _sxtBreakDuration;
        int _sntBreakDuration;
        int _egtBreakDuration;
        int _nitBreakDuration;

        public TLCDCSchedule(string startTime,string liveName,string fstBreakTime,string sndBreakTime,string trdBreakTime,string frtBreakTime,string fitBreakTime,string sxtBreakTime, string sntBreakTime,string egtBreakTime,string nitBreakTime,int fstBreakDuration,int sndBreakDuration,int trdBreakDuration,int frtBreakDuration,int fitBreakDuration,int sxtBreakDuration,int sntBreakDuration,int egtBreakDuration,int nitBreakDuration)
        {
            _startTime = startTime;
            _liveName = liveName;
            _fstBreakTime = fstBreakTime;
            _fstBreakDuration = fstBreakDuration;
            _sndBreakTime = sndBreakTime;
            _sndBreakDuration = sndBreakDuration;
            _trdBreakTime = trdBreakTime;
            _trdBreakDuration = trdBreakDuration;
            _frtBreakTime = frtBreakTime;
            _frtBreakDuration = frtBreakDuration;
            _fitBreakTime = fitBreakTime;
            _fitBreakDuration = fitBreakDuration;
            _sxtBreakTime = sxtBreakTime;
            _sxtBreakDuration = sxtBreakDuration;
            _sntBreakTime = sntBreakTime;
            _sntBreakDuration = sntBreakDuration;
            _egtBreakTime = egtBreakTime;
            _egtBreakDuration = egtBreakDuration;
            _nitBreakTime = nitBreakTime;
            _nitBreakDuration = nitBreakDuration;
        }
        public string getStartTime()
        {
            return _startTime;
        }
        public string getLiveName()
        {
            return _liveName;
        }
        public string getFirstBreakTime()
        {
            return _fstBreakTime;
        }
        public string getSecondBreakTime()
        {
            return _sndBreakTime;
        }
        public string getThirdBreakTime()
        {
            return _trdBreakTime;
        }
        public string getFourthBreakTime()
        {
            return _frtBreakTime;
        }
        public string getFifthBreakTime()
        {
            return _fitBreakTime;
        }
        public string getSixthBreakTime()
        {
            return _sxtBreakTime;
        }
        public string getSeventhBreakTime()
        {
            return _sntBreakTime;
        }
        public string getEigthBreakTime()
        {
            return _egtBreakTime;
        }
        public string getNinthBreakTime()
        {
            return _nitBreakTime;
        }
        public int getFirstBreakDuration()
        {
            return _fstBreakDuration;
        }
        public int getSecondBreakDuration()
        {
            return _sndBreakDuration;
        }
        public int getThirdBreakDuration()
        {
            return _trdBreakDuration;
        }
        public int getFourthBreakDuration()
        {
            return _frtBreakDuration;
        }
        public int getFifthBreakDuration()
        {
            return _fitBreakDuration;
        }
        public int getSixthBreakDuration()
        {
            return _sxtBreakDuration;
        }
        public int getSeventhBreakDuration()
        {
            return _sntBreakDuration;
        }
        public int getEigthBreakDuration()
        {
            return _egtBreakDuration;
        }
        public int getNinthBreakDuration()
        {
            return _nitBreakDuration;
        }

    }
}
