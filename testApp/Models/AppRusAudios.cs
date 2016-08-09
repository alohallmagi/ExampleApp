using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using testApp.Models;

namespace testApp
{
   public class AppRusAudios
    {
        private List<RussianAudios> audios = new List<RussianAudios>();
        public List<RussianAudios> GetList()
        {
            return audios;
        }

        public void ReadAudios()
        {
            XmlSerializer reader = new XmlSerializer(typeof(AppAudios));

            StreamReader file = new StreamReader(Utility.TLCDCRusAudioPath); ;
            try
            {

                AppAudios overview = (AppAudios)reader.Deserialize(file);
                foreach (RusAudios item in overview.russianAudios)
                {
                    audios.Add(new RussianAudios(item.FileName));
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
        public void ClearAudios()
        {
            audios.Clear();
        }
    }
}
