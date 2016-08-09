using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Models
{
    public class Messages
    {
        protected string message;

        public Messages()
        {
            message = "Empty Message";
        }
        public Messages(string _message)
        {
            message = _message;
        }

        public string getMessages()
        {
            return message;
        }
    }  
}
