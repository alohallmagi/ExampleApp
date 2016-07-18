using CNSWE.Models;
using OasysXML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Testing
{
    class Program
    {

       
        static void Main(string[] args)
        {
            var testing = new InterstitalEvent();

            XMLFillers xmlfillers = new XMLFillers();
            xmlfillers.Duration = 53;
            xmlfillers.FileName = "##_PR_PCN4685#01_01.mov";

            testing.XmlFillers.Add(xmlfillers);

            XMLFillers xmlfillers1 = new XMLFillers();
            xmlfillers1.Duration = 51;
            xmlfillers1.FileName = "##_PR_PCN4685#02_01.mov";

            testing.XmlFillers.Add(xmlfillers1);

            //XMLLogos xmllogo = new XMLLogos();
            //xmllogo.Duration = 32;
            //xmllogo.FileName = "TESTING";
            //testing.XmlLogos.Add(xmllogo);

            //var schedule = new Schedule();
            //ProgramGroup pGroup = new ProgramGroup();
            //ProgramGroup cGroup = new ProgramGroup();           
            //ProgramItem pItem = new ProgramItem();
            //VideoProgramEvent vEvent = new VideoProgramEvent();
            //ProgramEvent pEvent = new ProgramEvent();
            //pGroup.Title = "TEST1";
            //vEvent.FileName = "Test2";
            //vEvent.AspectRatio = AspectRatio.Item169;
            //vEvent.ConversionType = ConversionType.Crop;
            //vEvent.IsCommercial = true;
            //cGroup.Items.Add(vEvent);
            //pGroup.Items.Add(vEvent);
            //pGroup.Items.Add(cGroup);
            //schedule.Group = pGroup;
            //ProgramItemSubstream pItemSubstream = new ProgramItemSubstream();
            //pItemSubstream.AppearInLog = true;            
            //pItem.Title = "TEST1";
            var serializer = new XmlSerializer(typeof(InterstitalEvent), "TEST");
            using (TextWriter writer = new StreamWriter(@"C:\\Test.xml"))
            {
                serializer.Serialize(writer, testing);
                System.Console.Write(writer.ToString());
            }



        }
    }
}
