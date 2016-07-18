using CNSWE.Models;
using OasysXML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNSWE
{
    public class XML
    {
        private string LiveEventTitle;
        private string LiveEventDuration = "00:00:10:00";
        private string StartDateTime;
        private string TimeHelper;
        private int CommercialDuration;
        private int CommercialCountHelper;
        private int FillerDuration;

        Utility utility = new Utility();
        MainWindow _MW;

        public void GenerateCNSWEXML(MainWindow MW)
        {

            this._MW = MW;
            ReadExcel readCommercials = new ReadExcel();

            ReadText readDailySchedule = new ReadText();

            Logo logo = new Logo();

            logo.ReadLogo();

            readDailySchedule.ReadDaySchedule(_MW);

            readCommercials.OpenCNSWEExcelFile(_MW);


            if (Utility.IsCommercialsCorrect)
            {
                List<Commercials> commercials = readCommercials.GetCommercial();

                List<Logos> logos = logo.GetList();

                List<Trigger> triggers = readDailySchedule.GetList();

                try
                {
                    if (String.IsNullOrEmpty(Utility.initError))
                    {

                        TimeHelper = commercials[0].getStartTime();

                        CommercialCountHelper = 0;
                        #region Oasys Commands
                        var schedule = new Schedule();
                        ProgramGroup rGroup = new ProgramGroup();
                        rGroup.Title = utility.ListTitle();

                        #region first live event

                        LiveProgramEvent fEvent = new LiveProgramEvent();
                        AudioSubstream fAudio = new AudioSubstream();
                        AudioSubstream fAudio2 = new AudioSubstream();
                        AudioSubstream fAudio3 = new AudioSubstream();
                        AudioSubstream fAudio4 = new AudioSubstream();
                        AudioSubstreamEvent fAudioEvent = new AudioSubstreamEvent();

                        fEvent.Duration = LiveEventDuration;
                        fEvent.StartDateTimeSpecified = true;
                        fEvent.StartDateTime = utility.FirstEventST();
                        fEvent.Title = commercials[0].getProgramTitle();
                        fEvent.StopModeSpecified = true;
                        fEvent.StopMode = StopModeRestricted.ExtendMode;
                        fAudioEvent.Live = true;
                        fAudio.Default = true;
                        fAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                        fAudio.Name = AudioSubstreamName.Track1;
                        fAudio.Event.Add(fAudioEvent);
                        fEvent.Substreams.Add(fAudio);
                        fAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                        fAudio2.Name = AudioSubstreamName.Track1;
                        fAudio2.Default = true;
                        fAudio2.Event.Add(fAudioEvent);
                        fEvent.Substreams.Add(fAudio2);
                        fAudio3.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel3;
                        fAudio3.Name = AudioSubstreamName.Track1;
                        fAudio3.Default = true;
                        fAudio3.Event.Add(fAudioEvent);
                        fEvent.Substreams.Add(fAudio3);
                        fAudio4.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel4;
                        fAudio4.Name = AudioSubstreamName.Track1;
                        fAudio4.Default = true;
                        fAudio4.Event.Add(fAudioEvent);
                        fEvent.Substreams.Add(fAudio4);
                        rGroup.Items.Add(fEvent);
                        #endregion
                        #endregion
                        foreach (Trigger trigger in triggers)
                        {

                            StartDateTime = utility.StringtoDateTime(Utility.CommercialFilePath, trigger.getStarTime());
                            //Commercial group
                            ProgramGroup cGroup = new ProgramGroup();

                            LiveProgramEvent lEvent = new LiveProgramEvent();
                            AudioSubstream Audio = new AudioSubstream();
                            AudioSubstream Audio2 = new AudioSubstream();
                            AudioSubstream Audio3 = new AudioSubstream();
                            AudioSubstream Audio4 = new AudioSubstream();
                            AudioSubstreamEvent aEvent = new AudioSubstreamEvent();
                            WSSSubstream wssStream = new WSSSubstream();
                            WSSSubstreamEvent wssEvent = new WSSSubstreamEvent();
                            wssEvent.Operation = WSSSubstreamEventOperation.Insert;
                            wssEvent.Insert = new WSSEntry();
                            wssEvent.Insert.AspectRatio = WSSAspectRatio.FullFormat169Anamorphic;
                            wssEvent.Insert.Subtitles = new WSSSubtitles();
                            wssEvent.Insert.Subtitles.Type = WSSSubtitlesType.NoOpenSubtitles;
                            wssStream.Default = true;

                            wssStream.Event.Add(wssEvent);
                            #region Commercials           
                            for (int i = CommercialCountHelper; i <= commercials.Count - 1; i++)
                            {

                                CommercialDuration += commercials[i].getDuration();
                                VideoProgramEvent vEvent = new VideoProgramEvent();
                                AudioSubstream cAudio = new AudioSubstream();
                                AudioSubstream cAudio2 = new AudioSubstream();
                                AudioSubstream cAudio3 = new AudioSubstream();
                                AudioSubstream cAudio4 = new AudioSubstream();
                                AudioSubstreamEvent caEvent = new AudioSubstreamEvent();

                                if (i == CommercialCountHelper)
                                {
                                    cGroup.StartDateTimeSpecified = true;
                                    cGroup.StartDateTime = StartDateTime;
                                }
                                vEvent.FileName = commercials[i].getFileName();
                                vEvent.IsCommercial = true;

                                caEvent.FileName = commercials[i].getFileName();

                                cAudio.Name = AudioSubstreamName.Track1;
                                cAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                                cAudio.Default = true;
                                cAudio.Event.Add(caEvent);
                                vEvent.Substreams.Add(cAudio);
                                cAudio2.Name = AudioSubstreamName.Track1;
                                cAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                                cAudio2.Default = true;
                                cAudio2.Event.Add(caEvent);
                                vEvent.Substreams.Add(cAudio2);
                                cAudio3.Name = AudioSubstreamName.Track1;
                                cAudio3.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel3;
                                cAudio3.Default = true;
                                cAudio3.Event.Add(caEvent);
                                vEvent.Substreams.Add(cAudio3);
                                cAudio4.Name = AudioSubstreamName.Track1;
                                cAudio4.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel4;
                                cAudio4.Default = true;
                                cAudio4.Event.Add(caEvent);
                                vEvent.Substreams.Add(cAudio4);
                                cGroup.Title = commercials[i].getStartTime();
                                if (i + 1 < commercials.Count)
                                {

                                    if (TimeHelper != commercials[i + 1].getStartTime())
                                    {
                                        if (commercials[i].getProgramTitle() != null)
                                        {
                                            LiveEventTitle = commercials[i].getProgramTitle();
                                        }
                                        cGroup.Items.Add(vEvent);
                                        CommercialCountHelper = i + 1;
                                        TimeHelper = commercials[i + 1].getStartTime();
                                        break;
                                    }
                                }
                                cGroup.Items.Add(vEvent);

                            }
                            #endregion
                            #region Predicted Duration

                            FillerDuration = trigger.getIntPredictedDuration() - CommercialDuration;

                            cGroup.PredictedDuration = trigger.getPredictedDuration();
                            cGroup.ExtendToPredictedDuration = true;
                            cGroup.Substreams.Add(wssStream);
                            #endregion
                            if (FillerDuration != 0)
                            {
                                if (FillerDuration < 32)
                                {
                                    #region LogoFiller
                                    VideoProgramEvent vEvent = new VideoProgramEvent();
                                    AudioSubstream cAudio = new AudioSubstream();
                                    AudioSubstream cAudio2 = new AudioSubstream();
                                    AudioSubstream cAudio3 = new AudioSubstream();
                                    AudioSubstream cAudio4 = new AudioSubstream();
                                    AudioSubstreamEvent caEvent = new AudioSubstreamEvent();

                                    vEvent.FileName = logos[0].getFileName();
                                    vEvent.TrimIn = "00:00:00:00";
                                    vEvent.TrimOut = utility.IntToTimeSpan(FillerDuration);
                                    vEvent.Title = "LOGO LOOP";

                                    caEvent.FileName = logos[0].getFileName();

                                    cAudio.Name = AudioSubstreamName.Track1;
                                    cAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                                    cAudio.Default = true;
                                    cAudio.Event.Add(caEvent);
                                    vEvent.Substreams.Add(cAudio);
                                    cAudio2.Name = AudioSubstreamName.Track1;
                                    cAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                                    cAudio2.Default = true;
                                    cAudio2.Event.Add(caEvent);
                                    vEvent.Substreams.Add(cAudio2);
                                    cAudio3.Name = AudioSubstreamName.Track1;
                                    cAudio3.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel3;
                                    cAudio3.Default = true;
                                    cAudio3.Event.Add(caEvent);
                                    vEvent.Substreams.Add(cAudio3);
                                    cAudio4.Name = AudioSubstreamName.Track1;
                                    cAudio4.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel4;
                                    cAudio4.Default = true;
                                    cAudio4.Event.Add(caEvent);
                                    vEvent.Substreams.Add(cAudio4);
                                    cGroup.Items.Add(vEvent);
                                    #endregion
                                }
                            }


                            #region Live Event
                            lEvent.Duration = LiveEventDuration;
                            lEvent.Title = LiveEventTitle;
                            lEvent.StopModeSpecified = true;
                            lEvent.StopMode = StopModeRestricted.ExtendMode;
                            aEvent.Live = true;
                            Audio.Default = true;
                            Audio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                            Audio.Name = AudioSubstreamName.Track1;
                            Audio.Event.Add(aEvent);
                            lEvent.Substreams.Add(Audio);
                            Audio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                            Audio2.Name = AudioSubstreamName.Track1;
                            Audio2.Default = true;
                            Audio2.Event.Add(aEvent);
                            lEvent.Substreams.Add(Audio2);
                            Audio3.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel3;
                            Audio3.Name = AudioSubstreamName.Track1;
                            Audio3.Default = true;
                            Audio3.Event.Add(aEvent);
                            lEvent.Substreams.Add(Audio3);
                            Audio4.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel4;
                            Audio4.Name = AudioSubstreamName.Track1;
                            Audio4.Default = true;
                            Audio4.Event.Add(aEvent);
                            lEvent.Substreams.Add(Audio4);
                            #endregion
                            cGroup.AdInsertion.Enabled = true;
                            cGroup.AdInsertion.ID = trigger.getTrigger();
                            rGroup.Items.Add(cGroup);
                            rGroup.Items.Add(lEvent);

                            CommercialDuration = 0;
                        }
                        schedule.Group = rGroup;
                        var serializer = new XmlSerializer(typeof(Schedule), "TEST");
                        using (TextWriter writer = new StreamWriter(Utility.xmlfile))
                        {
                            serializer.Serialize(writer, schedule);
                            System.Console.Write(writer.ToString());
                        }

                        utility.populateLB(_MW, "XML Generated!");
                        Utility.IsListValidated = Validate.validateXML(_MW, Utility.xmlfile);

                    }

                }
                catch (Exception ex)
                {
                    utility.populateLB(_MW, "ERROR: Failed to Generate XML! Missing essential material (Commercials, triggers, schedule events). " + ex.Message);
                }
            }
        }
        public void GenerateTLCXML(MainWindow MW)
        {

        }
        public void GenerateDCXML(MainWindow MW)
        {

        }

    }
}


