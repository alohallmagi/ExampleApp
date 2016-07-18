using testApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testApp
{
    public class Filler
    {
        
        private List<Fillers> filler = new List<Fillers>();
        public List<Fillers> GetList()
        {
            return filler;
        }

        public void ReadFiller()
        {
            XmlSerializer reader = new XmlSerializer(typeof(InterstitalEvent));

            StreamReader file = new StreamReader(Utility.fillerspath);
            try
            {
                InterstitalEvent overview = (InterstitalEvent)reader.Deserialize(file);
                foreach (XMLFillers item in overview.XmlFillers)
                {
                    filler.Add(new Fillers(item.FileName, item.Duration,0));
                }
                
            }
            catch (Exception ex)
            {
                Utility.FillerError = "Unabled to open the filler database. " + ex.Message;
            }
            finally
            {
                file.Close();
            }
        }     
        public void ClearFillers()
        {
            filler.Clear();
        }
    }
}
