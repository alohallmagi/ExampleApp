using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Models
{
   public class PredictedDuration
    {
        int predictedDuration;
        public PredictedDuration(int _predictedDuration)
        {
            predictedDuration = _predictedDuration;
        }
        public int getPredictedDuration()
        {
            return predictedDuration;
        }
    }
}
