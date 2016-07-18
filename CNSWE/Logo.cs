using CNSWE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNSWE
{
    public class Logo
    {
        private List<Logos> logos = new List<Logos>();
        public List<Logos> GetList()
        {
            return logos;
        }

        public void ReadLogo()
        {
            XmlSerializer reader = new XmlSerializer(typeof(InterstitalEvent));

            StreamReader file= new StreamReader(Utility.logospath);;
            try
            {
                
                InterstitalEvent overview = (InterstitalEvent)reader.Deserialize(file);
                foreach (XMLLogos item in overview.XmlLogos)
                {
                    logos.Add(new Logos(item.FileName, item.Duration));
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
    }
}
