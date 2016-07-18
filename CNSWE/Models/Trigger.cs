using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSWE.Models
{
   public class Trigger
    {
        string starttime;
        string trigger;
        string predictedDuration;
        int pDuration;
        public Trigger(string _trigger, string _starttime, string _predictedDuration, int _pDuration)
        {
            trigger = _trigger;
            starttime= _starttime;
            predictedDuration = _predictedDuration;
            pDuration = _pDuration;
        }
        public string getTrigger()
        {
            return trigger;
        }
        public string getStarTime()
        {
            return starttime;
        }
        public string getPredictedDuration()
        {
            return predictedDuration;
        }
        public int getIntPredictedDuration()
        {
            return pDuration;
        }
    }
}
