using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp;
using testApp.Models;

namespace ModuleTest
{
    public class MessageModule
    {

        private List<Messages> messages = new List<Messages>();
        public void TestMessage()
        {
            ReadExcel readCommercials = new ReadExcel();
            messages.Add(new Messages(readCommercials.TNTCommercialExcel()));
        }
       
    }
}
