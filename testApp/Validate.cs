using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Schema;

namespace testApp
{
   public class Validate
    {
       
        public static bool validateXML(MainWindow MW, string file)
        {
            MainWindow _MW;
            _MW = MW;
            Utility utility = new Utility();

            String schemaFileName = "ScheduleImporterImportList.xsd";

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("http://www.on-air-systems.com/playKast", schemaFileName);

            XDocument doc = XDocument.Load(file);
            string msg = "";
            int errorline = 0;
            doc.Validate(schemas, (o, e) =>
            {
                errorline++;
                if (!(msg.Contains(e.Message)))
                {
                    msg += e.Message + "Line: " + errorline.ToString() + Environment.NewLine;
                }
            });
            if (msg == "")
            {
               utility.populateLB(_MW, "Validation succeeded!");
                return true;
            }
                
            else
            {
                utility.populateLB(_MW,"Document invalid: " + msg);
                return false;
            }
        }
    }
}
