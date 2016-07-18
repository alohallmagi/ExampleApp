using testApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testApp
{
    public class XML
    {
        private bool useRusAudios;
        public static int breakDuration;
        private int CommercialIndex = 0;
        private string LiveEventTitle;
        private string LiveEventDuration = "00:00:10:00";
        private string StartDateTime;
        private string TimeHelper;
        private int CommercialDuration;
        private int CommercialCountHelper;
        private int FillerDuration;
        List<Commercials> firstBreak = new List<Commercials>();
        List<Commercials> secondBreak = new List<Commercials>();
        List<Commercials> thirdBreak = new List<Commercials>();
        List<Commercials> fourthBreak = new List<Commercials>();
        List<Commercials> fifthBreak = new List<Commercials>();
        List<Commercials> sixthBreak = new List<Commercials>();
        List<Commercials> seventhBreak = new List<Commercials>();
        List<Commercials> eigthBreak = new List<Commercials>();
        List<Commercials> ninthBreak = new List<Commercials>();
        List<Fillers> PromosInBreak = new List<Fillers>();
        List<Logos> IdentsInBreak = new List<Logos>();
        Utility utility = new Utility();
        Filler promos = new Filler();
        ReadExcel readCommercials = new ReadExcel();
        ReadExcel readSchedule = new ReadExcel();
        Logo logo = new Logo();

        MainWindow _MW;

        public void GenerateCNSWEXML(MainWindow MW)
        {

            this._MW = MW;
            ReadExcel readCommercials = new ReadExcel();

            ReadText readDailySchedule = new ReadText();

            logo.ReadLogo();

            promos.ReadFiller();

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
                        rGroup.Title = utility.CNSWEListTitle();

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
                        fEvent.Title = commercials[0].getProgramTitle() + " 1";
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
                                #region Fillers
                                if (FillerDuration > 32)
                                {
                                    CNSWEPromotions(trigger.getIntPredictedDuration().ToString(), CommercialDuration, logos[0].getDuration());
                                    foreach (Fillers _promos in PromosInBreak)
                                    {
                                        VideoProgramEvent vEvent = new VideoProgramEvent();
                                        AudioSubstream cAudio = new AudioSubstream();
                                        AudioSubstream cAudio2 = new AudioSubstream();
                                        AudioSubstream cAudio3 = new AudioSubstream();
                                        AudioSubstream cAudio4 = new AudioSubstream();
                                        AudioSubstreamEvent caEvent = new AudioSubstreamEvent();

                                        vEvent.FileName = _promos.getFileName();
                                        vEvent.TrimIn = "00:00:00:00";
                                        vEvent.TrimOut = utility.IntToTimeSpan(_promos.getDuration());

                                        caEvent.FileName = _promos.getFileName();

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
                                    }
                                    PromosInBreak.Clear();
                                    #endregion
                                }
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
                            lEvent.Title = LiveEventTitle + " 1";
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
                finally
                {
                    logo.ClearLogos();
                    promos.ClearFillers();
                }
            }
        }
        public void GenerateTLCXML(MainWindow MW)
        {
            useRusAudios = Properties.Settings.Default.tlcdcUseRusAudios;
            this._MW = MW;
            readCommercials.OpenTLCCommercialExcelFile(_MW);
            readSchedule.OpenTLCScheduleExcelFile(_MW);
            logo.ReadLogo();
            promos.ReadFiller();
            CommercialCountHelper = 0;
            if (Utility.IsCommercialsCorrect)
            {
                List<Commercials> commercials = readCommercials.GetCommercial();

                List<Logos> logos = logo.GetList();

                List<TLCDCSchedule> scheduled = readSchedule.GetSchedule();

                #region Oasys Commands
                var schedule = new Schedule();
                ProgramGroup rGroup = new ProgramGroup();
                rGroup.Title = utility.TLCDCListTitle();

                #endregion
                foreach (TLCDCSchedule scheduleEvents in scheduled)
                {
                    #region Commercials
                    foreach (Commercials commercialEvents in commercials)
                    {

                        if (scheduleEvents.getFirstBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            firstBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(),commercialEvents.getRusAudio(),commercialEvents.getEstAudio()));
                            CommercialIndex++;
                        }
                        if (scheduleEvents.getSecondBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            secondBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                            CommercialIndex++;
                        }
                        if (!String.IsNullOrEmpty(scheduleEvents.getThirdBreakTime()))
                        {
                            if (scheduleEvents.getThirdBreakTime().Contains(commercialEvents.getStartTime()))
                            {
                                thirdBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                CommercialIndex++;
                            }
                            if (!String.IsNullOrEmpty(scheduleEvents.getFourthBreakTime()))
                            {
                                if (scheduleEvents.getFourthBreakTime().Contains(commercialEvents.getStartTime()))
                                {
                                    fourthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                    CommercialIndex++;
                                }
                                if (!String.IsNullOrEmpty(scheduleEvents.getFifthBreakTime()))
                                {
                                    if (scheduleEvents.getFifthBreakTime().Contains(commercialEvents.getStartTime()))
                                    {
                                        fifthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                        CommercialIndex++;
                                    }
                                    if (!String.IsNullOrEmpty(scheduleEvents.getSixthBreakTime()))
                                    {
                                        if (scheduleEvents.getSixthBreakTime().Contains(commercialEvents.getStartTime()))
                                        {
                                            sixthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                            CommercialIndex++;
                                        }
                                        if (!String.IsNullOrEmpty(scheduleEvents.getSeventhBreakTime()))
                                        {
                                            if (scheduleEvents.getSeventhBreakTime().Contains(commercialEvents.getStartTime()))
                                            {
                                                seventhBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                CommercialIndex++;
                                            }
                                            if (!String.IsNullOrEmpty(scheduleEvents.getEigthBreakTime()))
                                            {
                                                if (scheduleEvents.getEigthBreakTime().Contains(commercialEvents.getStartTime()))
                                                {
                                                    eigthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                    CommercialIndex++;
                                                }
                                                if (!String.IsNullOrEmpty(scheduleEvents.getNinthBreakTime()))
                                                {
                                                    if (scheduleEvents.getNinthBreakTime().Contains(commercialEvents.getStartTime()))
                                                    {
                                                        ninthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                        CommercialIndex++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //if (firstBreak.Count != 0 || secondBreak.Count != 0 || thirdBreak.Count != 0 || fourthBreak.Count != 0 || fifthBreak.Count != 0 || sixthBreak.Count != 0 || seventhBreak.Count != 0 || eigthBreak.Count != 0 || ninthBreak.Count != 0)
                    //{
                    //    for (int i = 0; i <= CommercialIndex; i++)
                    //    {
                    //        if (commercials.Count !=0)
                    //        {
                    //            commercials.RemoveAt(i);
                    //        }
                    //    }
                    //    CommercialIndex = 0;
                    //}

                    #endregion
                    if (IsBreakDurationEmpty(scheduleEvents.getFirstBreakDuration().ToString(), scheduleEvents.getSecondBreakDuration().ToString(), scheduleEvents.getThirdBreakDuration().ToString(), scheduleEvents.getFourthBreakDuration().ToString()))
                    {
                        continue;
                    }

                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFirstBreakTime(), scheduleEvents.getFirstBreakDuration().ToString(), firstBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSecondBreakTime(), scheduleEvents.getSecondBreakDuration().ToString(), secondBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getThirdBreakTime(), scheduleEvents.getThirdBreakDuration().ToString(), thirdBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFourthBreakTime(), scheduleEvents.getFourthBreakDuration().ToString(), fourthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFifthBreakTime(), scheduleEvents.getFifthBreakDuration().ToString(), fifthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSixthBreakTime(), scheduleEvents.getSixthBreakDuration().ToString(), sixthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSeventhBreakTime(), scheduleEvents.getSeventhBreakDuration().ToString(), seventhBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getEigthBreakTime(), scheduleEvents.getEigthBreakDuration().ToString(), eigthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getNinthBreakTime(), scheduleEvents.getNinthBreakDuration().ToString(), ninthBreak);

                }

                schedule.Group = rGroup;
                var serializer = new XmlSerializer(typeof(Schedule), "TEST");
                using (TextWriter writer = new StreamWriter(Utility.xmlfile))
                {
                    serializer.Serialize(writer, schedule);
                    System.Console.Write(writer.ToString());
                }
                logo.ClearLogos();
                promos.ClearFillers();
                scheduled.Clear();
                commercials.Clear();
                utility.populateLB(_MW, "XML Generated!");
                Utility.IsListValidated = Validate.validateXML(_MW, Utility.xmlfile);

            }
        }
        public void GenerateDCXML(MainWindow MW)
        {
            useRusAudios = Properties.Settings.Default.tlcdcUseRusAudios;
            this._MW = MW;
            readCommercials.OpenDCCommercialExcelFile(_MW);
            readSchedule.OpenDCScheduleExcelFile(_MW);
            logo.ReadLogo();
            promos.ReadFiller();
            CommercialCountHelper = 0;
            if (Utility.IsCommercialsCorrect)
            {
                List<Commercials> commercials = readCommercials.GetCommercial();

                List<Logos> logos = logo.GetList();

                List<TLCDCSchedule> scheduled = readSchedule.GetSchedule();

                #region Oasys Commands
                var schedule = new Schedule();
                ProgramGroup rGroup = new ProgramGroup();
                rGroup.Title = utility.TLCDCListTitle();

                #endregion
                foreach (TLCDCSchedule scheduleEvents in scheduled)
                {
                    #region Commercials
                    foreach (Commercials commercialEvents in commercials)
                    {

                        if (scheduleEvents.getFirstBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            firstBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                            CommercialIndex++;
                        }
                        if (scheduleEvents.getSecondBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            secondBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                            CommercialIndex++;
                        }
                        if (!String.IsNullOrEmpty(scheduleEvents.getThirdBreakTime()))
                        {
                            if (scheduleEvents.getThirdBreakTime().Contains(commercialEvents.getStartTime()))
                            {
                                thirdBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                CommercialIndex++;
                            }
                            if (!String.IsNullOrEmpty(scheduleEvents.getFourthBreakTime()))
                            {
                                if (scheduleEvents.getFourthBreakTime().Contains(commercialEvents.getStartTime()))
                                {
                                    fourthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                    CommercialIndex++;
                                }
                                if (!String.IsNullOrEmpty(scheduleEvents.getFifthBreakTime()))
                                {
                                    if (scheduleEvents.getFifthBreakTime().Contains(commercialEvents.getStartTime()))
                                    {
                                        fifthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                        CommercialIndex++;
                                    }
                                    if (!String.IsNullOrEmpty(scheduleEvents.getSixthBreakTime()))
                                    {
                                        if (scheduleEvents.getSixthBreakTime().Contains(commercialEvents.getStartTime()))
                                        {
                                            sixthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                            CommercialIndex++;
                                        }
                                        if (!String.IsNullOrEmpty(scheduleEvents.getSeventhBreakTime()))
                                        {
                                            if (scheduleEvents.getSeventhBreakTime().Contains(commercialEvents.getStartTime()))
                                            {
                                                seventhBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                CommercialIndex++;
                                            }
                                            if (!String.IsNullOrEmpty(scheduleEvents.getEigthBreakTime()))
                                            {
                                                if (scheduleEvents.getEigthBreakTime().Contains(commercialEvents.getStartTime()))
                                                {
                                                    eigthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                    CommercialIndex++;
                                                }
                                                if (!String.IsNullOrEmpty(scheduleEvents.getNinthBreakTime()))
                                                {
                                                    if (scheduleEvents.getNinthBreakTime().Contains(commercialEvents.getStartTime()))
                                                    {
                                                        ninthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getFileTitle(), commercialEvents.getProgramTitle(), commercialEvents.getDuration(), commercialEvents.getRusAudio(), commercialEvents.getEstAudio()));
                                                        CommercialIndex++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //if (firstBreak.Count != 0 || secondBreak.Count != 0 || thirdBreak.Count != 0 || fourthBreak.Count != 0 || fifthBreak.Count != 0 || sixthBreak.Count != 0 || seventhBreak.Count != 0 || eigthBreak.Count != 0 || ninthBreak.Count != 0)
                    //{
                    //    for (int i = 0; i <= CommercialIndex; i++)
                    //    {
                    //        if (commercials.Count !=0)
                    //        {
                    //            commercials.RemoveAt(i);
                    //        }
                    //    }
                    //    CommercialIndex = 0;
                    //}

                    #endregion
                    if (IsBreakDurationEmpty(scheduleEvents.getFirstBreakDuration().ToString(), scheduleEvents.getSecondBreakDuration().ToString(), scheduleEvents.getThirdBreakDuration().ToString(), scheduleEvents.getFourthBreakDuration().ToString()))
                    {
                        continue;
                    }
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFirstBreakTime(), scheduleEvents.getFirstBreakDuration().ToString(), firstBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSecondBreakTime(), scheduleEvents.getSecondBreakDuration().ToString(), secondBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getThirdBreakTime(), scheduleEvents.getThirdBreakDuration().ToString(), thirdBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFourthBreakTime(), scheduleEvents.getFourthBreakDuration().ToString(), fourthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFifthBreakTime(), scheduleEvents.getFifthBreakDuration().ToString(), fifthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSixthBreakTime(), scheduleEvents.getSixthBreakDuration().ToString(), sixthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSeventhBreakTime(), scheduleEvents.getSeventhBreakDuration().ToString(), seventhBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getEigthBreakTime(), scheduleEvents.getEigthBreakDuration().ToString(), eigthBreak);
                    createGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getNinthBreakTime(), scheduleEvents.getNinthBreakDuration().ToString(), ninthBreak);

                }

                schedule.Group = rGroup;
                var serializer = new XmlSerializer(typeof(Schedule), "TEST");
                using (TextWriter writer = new StreamWriter(Utility.xmlfile))
                {
                    serializer.Serialize(writer, schedule);
                    System.Console.Write(writer.ToString());
                }
                logo.ClearLogos();
                promos.ClearFillers();
                scheduled.Clear();
                commercials.Clear();
                utility.populateLB(_MW, "XML Generated!");
                Utility.IsListValidated = Validate.validateXML(_MW, Utility.xmlfile);

            }
        }
        public void GenerateDCIDXML(MainWindow MW)
        {
            this._MW = MW;
            ReadText readCommercials = new ReadText();
            readCommercials.ReadCommercials(_MW);
            readSchedule.OpenDCIDScheduleExcelFile(_MW);
            logo.ReadLogo();
            promos.ReadFiller();
            CommercialCountHelper = 0;
            if (Utility.IsCommercialsCorrect)
            {
                List<Commercials> commercials = readCommercials.GetCommercial();

                List<Logos> logos = logo.GetList();

                List<TLCDCSchedule> scheduled = readSchedule.GetSchedule();

                #region Oasys Commands
                var schedule = new Schedule();
                ProgramGroup rGroup = new ProgramGroup();
                rGroup.Title = utility.TLCDCListTitle();

                #endregion
                foreach (TLCDCSchedule scheduleEvents in scheduled)
                {
                    #region Commercials
                    foreach (Commercials commercialEvents in commercials)
                    {

                        if (scheduleEvents.getFirstBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            firstBreak.Add(new Commercials(commercialEvents.getStartTime(),commercialEvents.getFileName(),commercialEvents.getDuration(),commercialEvents.getFileTitle()));
                            CommercialIndex++;
                        }
                        if (scheduleEvents.getSecondBreakTime().Contains(commercialEvents.getStartTime()))
                        {
                            secondBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                            CommercialIndex++;
                        }
                        if (!String.IsNullOrEmpty(scheduleEvents.getThirdBreakTime()))
                        {
                            if (scheduleEvents.getThirdBreakTime().Contains(commercialEvents.getStartTime()))
                            {
                                thirdBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                CommercialIndex++;
                            }
                            if (!String.IsNullOrEmpty(scheduleEvents.getFourthBreakTime()))
                            {
                                if (scheduleEvents.getFourthBreakTime().Contains(commercialEvents.getStartTime()))
                                {
                                    fourthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                    CommercialIndex++;
                                }
                                if (!String.IsNullOrEmpty(scheduleEvents.getFifthBreakTime()))
                                {
                                    if (scheduleEvents.getFifthBreakTime().Contains(commercialEvents.getStartTime()))
                                    {
                                        fifthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                        CommercialIndex++;
                                    }
                                    if (!String.IsNullOrEmpty(scheduleEvents.getSixthBreakTime()))
                                    {
                                        if (scheduleEvents.getSixthBreakTime().Contains(commercialEvents.getStartTime()))
                                        {
                                            sixthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                            CommercialIndex++;
                                        }
                                        if (!String.IsNullOrEmpty(scheduleEvents.getSeventhBreakTime()))
                                        {
                                            if (scheduleEvents.getSeventhBreakTime().Contains(commercialEvents.getStartTime()))
                                            {
                                                seventhBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                                CommercialIndex++;
                                            }
                                            if (!String.IsNullOrEmpty(scheduleEvents.getEigthBreakTime()))
                                            {
                                                if (scheduleEvents.getEigthBreakTime().Contains(commercialEvents.getStartTime()))
                                                {
                                                    eigthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                                    CommercialIndex++;
                                                }
                                                if (!String.IsNullOrEmpty(scheduleEvents.getNinthBreakTime()))
                                                {
                                                    if (scheduleEvents.getNinthBreakTime().Contains(commercialEvents.getStartTime()))
                                                    {
                                                        ninthBreak.Add(new Commercials(commercialEvents.getStartTime(), commercialEvents.getFileName(), commercialEvents.getDuration(), commercialEvents.getFileTitle()));
                                                        CommercialIndex++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    if (IsBreakDurationEmpty(scheduleEvents.getFirstBreakDuration().ToString(), scheduleEvents.getSecondBreakDuration().ToString(), scheduleEvents.getThirdBreakDuration().ToString(), scheduleEvents.getFourthBreakDuration().ToString()))
                    {
                        continue;
                    }
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFirstBreakTime(), scheduleEvents.getFirstBreakDuration().ToString(), firstBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSecondBreakTime(), scheduleEvents.getSecondBreakDuration().ToString(), secondBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getThirdBreakTime(), scheduleEvents.getThirdBreakDuration().ToString(), thirdBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFourthBreakTime(), scheduleEvents.getFourthBreakDuration().ToString(), fourthBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getFifthBreakTime(), scheduleEvents.getFifthBreakDuration().ToString(), fifthBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSixthBreakTime(), scheduleEvents.getSixthBreakDuration().ToString(), sixthBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getSeventhBreakTime(), scheduleEvents.getSeventhBreakDuration().ToString(), seventhBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getEigthBreakTime(), scheduleEvents.getEigthBreakDuration().ToString(), eigthBreak);
                    createDCIDGroupEvent(rGroup, scheduleEvents.getLiveName(), scheduleEvents.getNinthBreakTime(), scheduleEvents.getNinthBreakDuration().ToString(), ninthBreak);

                }

                schedule.Group = rGroup;
                var serializer = new XmlSerializer(typeof(Schedule), "TEST");
                using (TextWriter writer = new StreamWriter(Utility.xmlfile))
                {
                    serializer.Serialize(writer, schedule);
                    System.Console.Write(writer.ToString());
                }
                logo.ClearLogos();
                promos.ClearFillers();
                scheduled.Clear();
                commercials.Clear();
                utility.populateLB(_MW, "XML Generated!");
                Utility.IsListValidated = Validate.validateXML(_MW, Utility.xmlfile);

            }
        }

        private void CNSWEPromotions(string breakduration, int commercialdurations, int logoLength)
        {
            int length = PromosDuration(breakduration, commercialdurations);
            int EmptyDuration = PromosDuration(breakduration, commercialdurations);
            bool nameEqual = false;
            int count = 0;

            List<Fillers> _promos = promos.GetList();
            var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();


            if (length > logoLength)
            {
                while (length > logoLength)
                {

                    foreach (Fillers item in shufflepromos)
                    {
                        count++;
                        if (item.getDuration() < length)
                        {
                            foreach (Fillers brkpromos in PromosInBreak)
                            {
                                if (item.getFileName().Contains(brkpromos.getFileName()))
                                {
                                    nameEqual = true;
                                }
                            }
                            if (nameEqual == true)
                            {
                                nameEqual = false;
                                continue;
                            }
                            if (nameEqual == false)
                            {
                                PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
                                length -= item.getDuration();
                            }

                        }
                        if (length <= logoLength)
                        {
                            count = 0;
                            break;
                        }

                    }
                    if (count == shufflepromos.Count)
                    {
                        count = 0;
                        length = Promoloop(EmptyDuration, logoLength, count, nameEqual);
                    }
                }
            }
            FillerDuration = length;
        }
        private void TLCPromotions(string breakduration, int commercialdurations)
        {
            IdentsInBreak.Clear();
            PromosInBreak.Clear();
            Utility.IsBreakDurationFull = false;
            int length = PromosDuration(breakduration, commercialdurations);
            int lengthHelper = 0;
            int correctDuration = PromosDuration(breakduration, commercialdurations);
            int specificwordstartIndex = 0;
            int specificwordLength = 0;
            if (Utility.ListType.Equals("DC"))
            {
                specificwordstartIndex = Properties.Settings.Default.dcConditionStartIndex;
                specificwordLength = Properties.Settings.Default.dcConditionLength;
            }
            else
            {
                specificwordstartIndex = Properties.Settings.Default.tlcConditionStartIndex;
                specificwordLength = Properties.Settings.Default.tlcConditionLength;
            }
            string trimmedFileName;
            int identlength = 0;
            int maxIdentLength = 0;
            int minIdentLength = 0;
            int trimIn = 0;
            int trimedDuration = 0;
            int ArrayCount = 0;
            bool nameEqual = false;
            bool expandLegnth = true;
            int count = 0;

            List<Logos> idents = logo.GetList();
            var shuffleidents = idents.OrderByDescending(x => x.getDuration()).ToList();
            maxIdentLength = shuffleidents[0].getDuration();
            minIdentLength = shuffleidents[shuffleidents.Count - 1].getDuration();
            shuffleidents = idents.OrderBy(x => Guid.NewGuid()).ToList();
            identlength = shuffleidents[0].getDuration();
            IdentsInBreak.Add(new Logos(shuffleidents[0].getFileName(), shuffleidents[0].getDuration()));

            if (length >= minIdentLength)
            {
                List<Fillers> _promos = promos.GetList();
                var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();
                shufflepromos = shufflepromos.OrderByDescending(x => x.getDuration()).ToList();

                if (length > maxIdentLength && length < shufflepromos[shufflepromos.Count - 1].getDuration())
                {
                    identlength = minIdentLength;
                    length = shufflepromos[shufflepromos.Count - 1].getDuration();
                    correctDuration = length - correctDuration;
                    expandLegnth = false;
                }
                if (length > (shufflepromos[0].getDuration() - minIdentLength) && length < shufflepromos[0].getDuration())
                {
                    length = shufflepromos[0].getDuration();
                    correctDuration = length - correctDuration;
                    expandLegnth = false;
                }
                while (length > 0)
                {
                    foreach (Fillers item in shufflepromos)
                    {
                        count++;
                        if (item.getDuration() <= length)
                        {
                            foreach (Fillers brkpromos in PromosInBreak)
                            {
                                if (item.getFileName().Substring(specificwordstartIndex, specificwordLength).Contains(brkpromos.getFileName().Substring(specificwordstartIndex, specificwordLength)))
                                {
                                    nameEqual = true;
                                }
                                if (nameEqual == true)
                                {
                                    break;
                                }
                            }
                            if (nameEqual == true)
                            {
                                nameEqual = false;
                                continue;
                            }
                            if (nameEqual == false)
                            {
                                length -= item.getDuration();
                                if (length > maxIdentLength && length < shufflepromos[shufflepromos.Count - 1].getDuration())
                                {
                                    correctDuration = length;
                                    length = shufflepromos[shufflepromos.Count - 1].getDuration();
                                    correctDuration = length - correctDuration;
                                    lengthHelper = correctDuration;
                                }
                                PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
                            }
                            if (length < 0)
                            {
                                break;
                            }
                        }
                    }
                    if (length == 0)
                    {
                        IdentsInBreak.Clear();
                        ArrayCount = 0;
                        PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                        trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                        trimedDuration = PromosInBreak[ArrayCount].getDuration();
                        trimIn = PromosInBreak[ArrayCount].getDuration() - identlength;
                        PromosInBreak.RemoveAt(ArrayCount);
                        trimIn = trimedDuration - trimIn;
                        if (expandLegnth == false)
                        {
                            trimIn += correctDuration;
                        }
                        if (lengthHelper != 0)
                        {
                            trimIn += lengthHelper;
                        }
                        PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                        foreach (Logos item in shuffleidents)
                        {
                            if (item.getDuration() == identlength)
                            {
                                count = 0;
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                break;
                            }
                        }
                    }
                    if (count == shufflepromos.Count && PromosInBreak.Count != 0)
                    {
                        count = 0;
                        foreach (Logos item in shuffleidents)
                        {
                            count++;
                            if (item.getDuration() == length)
                            {

                                length -= item.getDuration();
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                IdentsInBreak.RemoveAt(0);
                                break;
                            }
                        }
                        if (count == shuffleidents.Count)
                        {
                            count = 0;
                            ArrayCount = 0;
                            PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                            trimedDuration = PromosInBreak[ArrayCount].getDuration();
                            trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                            while (PromosInBreak[ArrayCount].getDuration() - identlength == 0)
                            {
                                shuffleidents = idents.OrderBy(a => Guid.NewGuid()).ToList();
                                identlength = shuffleidents[0].getDuration();
                            }
                            trimIn = PromosInBreak[ArrayCount].getDuration() - identlength;
                            PromosInBreak.RemoveAt(ArrayCount);
                            trimIn = trimedDuration - trimIn;
                            length += trimIn;
                            PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                            PromosInBreak = PromosInBreak.OrderBy(x => Guid.NewGuid()).ToList();
                            foreach (Logos item in shuffleidents)
                            {
                                count++;
                                if (item.getDuration() == length)
                                {
                                    length -= item.getDuration();
                                    IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                    IdentsInBreak.RemoveAt(0);
                                    break;
                                }
                            }
                        }
                        if (length != 0 && length > 0)
                        {
                            ArrayCount = 0;
                            PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                            trimedDuration = PromosInBreak[ArrayCount].getDuration();
                            trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                            if (PromosInBreak[ArrayCount].getTrimout() != 0)
                            {
                                length += PromosInBreak[ArrayCount].getTrimout();
                                trimIn = length;
                                PromosInBreak.RemoveAt(ArrayCount);
                            }
                            else
                            {
                                trimIn = PromosInBreak[ArrayCount].getDuration() - length;
                                PromosInBreak.RemoveAt(ArrayCount);
                                trimIn = trimedDuration - trimIn;
                            }

                            PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                            PromosInBreak = PromosInBreak.OrderBy(x => Guid.NewGuid()).ToList();
                            length -= trimIn;
                        }
                    }
                    if (PromosInBreak.Count == 0)
                    {
                        count = 0;
                        shuffleidents = shuffleidents.OrderByDescending(x => x.getDuration()).ToList();
                        foreach (Logos item in shuffleidents)
                        {
                            if (item.getDuration() <= length)
                            {
                                length -= item.getDuration();
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                            }
                            if (length == 0)
                            {
                                IdentsInBreak.RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (length < 0)
                    {
                        PromosInBreak = PromosInBreak.OrderByDescending(x => x.getTrimout()).ToList();
                        trimedDuration = PromosInBreak[0].getDuration();
                        trimmedFileName = PromosInBreak[0].getFileName();
                        string _helper = length.ToString();
                        _helper = _helper.Substring(1);
                        trimIn += int.Parse(_helper);
                        PromosInBreak.RemoveAt(0);
                        PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                    }
                }
            }
            else
            {
                Utility.IsBreakDurationFull = true;
                IdentsInBreak.Clear();
            }
        }
        private void DCPromotions(string breakduration, int commercialdurations)
        {
            #region oldFunction
            //    PromosInBreak.Clear();
            //    IdentsInBreak.Clear();
            //    Utility.IsBreakDurationFull = false;
            //    int length = PromosDuration(breakduration, commercialdurations);
            //    int EmptyDuration = PromosDuration(breakduration, commercialdurations);
            //    int specificwordstartIndex = 0;
            //    int specificwordLength = 0;
            //    if (Utility.ListType.Equals("DC"))
            //    {
            //        specificwordstartIndex = Properties.Settings.Default.dcConditionStartIndex;
            //        specificwordLength = Properties.Settings.Default.dcConditionLength;
            //    }
            //    else
            //    {
            //        specificwordstartIndex = Properties.Settings.Default.tlcConditionStartIndex;
            //        specificwordLength = Properties.Settings.Default.tlcConditionLength;
            //    }
            //    string trimmedFileName;
            //    int identlength = 0;
            //    int trimIn = 0;
            //    int trimedDuration = 0;
            //    int ArrayCount = 0;
            //    bool nameEqual = false;
            //    int count = 0;

            //    List<Logos> idents = logo.GetList();
            //    var shuffleidents = idents.OrderBy(a => Guid.NewGuid()).ToList();

            //    List<Fillers> _promos = promos.GetList();
            //    var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();
            //    shufflepromos = shufflepromos.OrderByDescending(x => x.getDuration()).ToList();
            //    identlength = shuffleidents[0].getDuration();
            //    IdentsInBreak.Add(new Logos(shuffleidents[0].getFileName(), shuffleidents[0].getDuration()));

            //if (length >= minIdentLength)
            //{
            //    List<Fillers> _promos = promos.GetList();
            //    var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();
            //    shufflepromos = shufflepromos.OrderByDescending(x => x.getDuration()).ToList();

            //    if (length >= identlength)
            //    {
            //        while (length > identlength)
            //        {
            //            foreach (Fillers item in shufflepromos)
            //            {
            //                count++;
            //                if (item.getDuration() < length)
            //                {
            //                    foreach (Fillers brkpromos in PromosInBreak)
            //                    {
            //                        if (item.getFileName().Substring(specificwordstartIndex, specificwordLength).Contains(brkpromos.getFileName().Substring(specificwordstartIndex, specificwordLength)))
            //                        {
            //                            nameEqual = true;
            //                        }
            //                        if (nameEqual == true)
            //                        {
            //                            break;
            //                        }
            //                    }
            //                    if (nameEqual == true)
            //                    {
            //                        nameEqual = false;
            //                        continue;
            //                    }
            //                    if (nameEqual == false)
            //                    {
            //                        length -= item.getDuration();

            //                        PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
            //                    }
            //                }
            //            }
            //            if (length == 0)
            //            {
            //                ArrayCount = PromosInBreak.Count - 1;
            //                trimmedFileName = PromosInBreak[ArrayCount].getFileName();
            //                trimedDuration = PromosInBreak[ArrayCount].getDuration();
            //                trimIn = PromosInBreak[ArrayCount].getDuration() - identlength;
            //                PromosInBreak.RemoveAt(ArrayCount);
            //                trimIn = trimedDuration - trimIn;
            //                PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
            //                foreach (Logos item in shuffleidents)
            //                {
            //                    if (item.getDuration() == length)
            //                    {

            //                        length -= item.getDuration();
            //                        IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
            //                        break;
            //                    }
            //                }
            //            }
            //            if (count == shufflepromos.Count)
            //            {
            //                count = 0;
            //                IdentsInBreak.Clear();
            //                foreach (Logos item in shuffleidents)
            //                {
            //                    count++;
            //                    if (item.getDuration() == length)
            //                    {

            //                        length -= item.getDuration();
            //                        IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
            //                        break;
            //                    }
            //                }
            //                if (count == shuffleidents.Count)
            //                {
            //                    count = 0;
            //                    ArrayCount = PromosInBreak.Count - 1;
            //                    PromosInBreak = PromosInBreak.OrderBy(x => x.getDuration()).ToList();
            //                    trimedDuration = PromosInBreak[ArrayCount].getDuration();
            //                    trimmedFileName = PromosInBreak[ArrayCount].getFileName();
            //                    while (PromosInBreak[ArrayCount].getDuration() - identlength == 0)
            //                    {
            //                        shuffleidents = idents.OrderBy(a => Guid.NewGuid()).ToList();
            //                        identlength = shuffleidents[0].getDuration();
            //                    }
            //                    trimIn = PromosInBreak[ArrayCount].getDuration() - identlength;
            //                    PromosInBreak.RemoveAt(ArrayCount);
            //                    trimIn = trimedDuration - trimIn;
            //                    PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
            //                    PromosInBreak = PromosInBreak.OrderBy(x => Guid.NewGuid()).ToList();
            //                    foreach (Logos item in shuffleidents)
            //                    {
            //                        count++;
            //                        if (item.getDuration() == identlength)
            //                        {
            //                            length -= item.getDuration();
            //                            IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
            //                            break;
            //                        }
            //                    }
            //                }


            //            }
            //        }
            //    }
            //    else
            //    {
            //        Utility.IsBreakDurationFull = true;
            //        IdentsInBreak.Clear();
            //    }
            //}
            #endregion
            IdentsInBreak.Clear();
            PromosInBreak.Clear();
            Utility.IsBreakDurationFull = false;
            int length = PromosDuration(breakduration, commercialdurations);
            int lengthHelper = 0;
            int correctDuration = PromosDuration(breakduration, commercialdurations);
            int specificwordstartIndex = 0;
            int specificwordLength = 0;

                specificwordstartIndex = Properties.Settings.Default.dcConditionStartIndex;
                specificwordLength = Properties.Settings.Default.dcConditionLength;

            string trimmedFileName;
            int identlength = 0;
            int maxIdentLength = 0;
            int minIdentLength = 0;
            int trimIn = 0;
            int trimedDuration = 0;
            int ArrayCount = 0;
            bool nameEqual = false;
            bool expandLegnth = true;
            int count = 0;

            List<Logos> idents = logo.GetList();
            var shuffleidents = idents.OrderByDescending(x => x.getDuration()).ToList();
            maxIdentLength = shuffleidents[0].getDuration();
            minIdentLength = shuffleidents[shuffleidents.Count - 1].getDuration();
            shuffleidents = idents.OrderBy(x => Guid.NewGuid()).ToList();
            identlength = shuffleidents[0].getDuration();
            IdentsInBreak.Add(new Logos(shuffleidents[0].getFileName(), shuffleidents[0].getDuration()));

            if (length >= minIdentLength)
            {
                List<Fillers> _promos = promos.GetList();
                var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();
                shufflepromos = shufflepromos.OrderByDescending(x => x.getDuration()).ToList();

                if (length > maxIdentLength && length < shufflepromos[shufflepromos.Count - 1].getDuration())
                {
                    identlength = minIdentLength;
                    length = shufflepromos[shufflepromos.Count - 1].getDuration();
                    correctDuration = length - correctDuration;
                    expandLegnth = false;
                }
                if (length > (shufflepromos[0].getDuration() - minIdentLength) && length < shufflepromos[0].getDuration())
                {
                    length = shufflepromos[0].getDuration();
                    correctDuration = length - correctDuration;
                    expandLegnth = false;
                }
                while (length > 0)
                {
                    foreach (Fillers item in shufflepromos)
                    {
                        count++;
                        if (item.getDuration() <= length)
                        {
                            foreach (Fillers brkpromos in PromosInBreak)
                            {
                                if (item.getFileName().Substring(specificwordstartIndex, specificwordLength).Contains(brkpromos.getFileName().Substring(specificwordstartIndex, specificwordLength)))
                                {
                                    nameEqual = true;
                                }
                                if (nameEqual == true)
                                {
                                    break;
                                }
                            }
                            if (nameEqual == true)
                            {
                                nameEqual = false;
                                continue;
                            }
                            if (nameEqual == false)
                            {
                                length -= item.getDuration();
                                if (length > maxIdentLength && length < shufflepromos[shufflepromos.Count - 1].getDuration())
                                {
                                    correctDuration = length;
                                    length = shufflepromos[shufflepromos.Count - 1].getDuration();
                                    correctDuration = length - correctDuration;
                                    lengthHelper = correctDuration;
                                }
                                PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
                            }
                            if (length < 0)
                            {
                                break;
                            }
                        }
                    }
                    if (length == 0)
                    {
                        IdentsInBreak.Clear();
                        ArrayCount = 0;
                        PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                        trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                        trimedDuration = PromosInBreak[ArrayCount].getDuration();
                        trimIn = PromosInBreak[ArrayCount].getDuration() - minIdentLength;
                        PromosInBreak.RemoveAt(ArrayCount);
                        trimIn = trimedDuration - trimIn;
                        if (expandLegnth == false)
                        {
                            trimIn += correctDuration;
                        }
                        if (lengthHelper != 0)
                        {
                            trimIn += lengthHelper;
                        }
                        PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                        foreach (Logos item in shuffleidents)
                        {
                            if (item.getDuration() == minIdentLength)
                            {
                                count = 0;
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                break;
                            }
                        }
                    }
                    if (count == shufflepromos.Count && PromosInBreak.Count != 0)
                    {
                        count = 0;
                        foreach (Logos item in shuffleidents)
                        {
                            count++;
                            if (item.getDuration() == length)
                            {

                                length -= item.getDuration();
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                IdentsInBreak.RemoveAt(0);
                                break;
                            }
                        }
                        if (count == shuffleidents.Count)
                        {
                            count = 0;
                            ArrayCount = 0;
                            PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                            trimedDuration = PromosInBreak[ArrayCount].getDuration();
                            trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                            while (PromosInBreak[ArrayCount].getDuration() - identlength == 0)
                            {
                                shuffleidents = idents.OrderBy(a => Guid.NewGuid()).ToList();
                                identlength = shuffleidents[0].getDuration();
                            }
                            trimIn = PromosInBreak[ArrayCount].getDuration() - identlength;
                            PromosInBreak.RemoveAt(ArrayCount);
                            trimIn = trimedDuration - trimIn;
                            length += trimIn;
                            PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                            PromosInBreak = PromosInBreak.OrderBy(x => Guid.NewGuid()).ToList();
                            foreach (Logos item in shuffleidents)
                            {
                                count++;
                                if (item.getDuration() == length)
                                {
                                    length -= item.getDuration();
                                    IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                                    IdentsInBreak.RemoveAt(0);
                                    break;
                                }
                            }
                        }
                        if (length != 0 && length > 0)
                        {
                            ArrayCount = 0;
                            PromosInBreak = PromosInBreak.OrderByDescending(x => x.getDuration()).ToList();
                            trimedDuration = PromosInBreak[ArrayCount].getDuration();
                            trimmedFileName = PromosInBreak[ArrayCount].getFileName();
                            if (PromosInBreak[ArrayCount].getTrimout() != 0)
                            {
                                length += PromosInBreak[ArrayCount].getTrimout();
                                trimIn = length;
                                PromosInBreak.RemoveAt(ArrayCount);
                            }
                            else
                            {
                                trimIn = PromosInBreak[ArrayCount].getDuration() - length;
                                PromosInBreak.RemoveAt(ArrayCount);
                                trimIn = trimedDuration - trimIn;
                            }

                            PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                            PromosInBreak = PromosInBreak.OrderBy(x => Guid.NewGuid()).ToList();
                            length -= trimIn;
                        }
                    }
                    if (PromosInBreak.Count == 0)
                    {
                        count = 0;
                        shuffleidents = shuffleidents.OrderByDescending(x => x.getDuration()).ToList();
                        foreach (Logos item in shuffleidents)
                        {
                            if (item.getDuration() <= length)
                            {
                                length -= item.getDuration();
                                IdentsInBreak.Add(new Logos(item.getFileName(), item.getDuration()));
                            }
                            if (length == 0)
                            {
                                IdentsInBreak.RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (length < 0)
                    {
                        PromosInBreak = PromosInBreak.OrderByDescending(x => x.getTrimout()).ToList();
                        trimedDuration = PromosInBreak[0].getDuration();
                        trimmedFileName = PromosInBreak[0].getFileName();
                        string _helper = length.ToString();
                        _helper = _helper.Substring(1);
                        trimIn += int.Parse(_helper);
                        PromosInBreak.RemoveAt(0);
                        PromosInBreak.Add(new Fillers(trimmedFileName, trimedDuration, trimIn));
                    }
                }
            }
            else
            {
                Utility.IsBreakDurationFull = true;
                IdentsInBreak.Clear();
            }
        }
        private void DCIDPromotions(string breakduration, int commercialdurations)
        {
            PromosInBreak.Clear();
            int length = PromosDuration(breakduration, commercialdurations);
            int EmptyDuration = PromosDuration(breakduration, commercialdurations);
            int identlength = 5;
            bool nameEqual = false;
            int count = 0;

            List<Fillers> _promos = promos.GetList();
            var shufflepromos = _promos.OrderBy(x => Guid.NewGuid()).ToList();


            if (length > 10)
            {
                while (length - identlength > 10)
                {

                    foreach (Fillers item in shufflepromos)
                    {
                        count++;
                        if (item.getDuration() < length - identlength)
                        {
                            foreach (Fillers brkpromos in PromosInBreak)
                            {
                                if (item.getFileName().Substring(23, 8).Contains(brkpromos.getFileName().Substring(23, 8)))
                                {
                                    nameEqual = true;
                                }
                            }
                            if (nameEqual == true)
                            {
                                nameEqual = false;
                                continue;
                            }
                            if (nameEqual == false)
                            {
                                PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
                                length -= item.getDuration();
                            }

                        }
                        if (length==0)
                        {
                            length = PromosInBreak[PromosInBreak.Count - 1].getDuration();
                            PromosInBreak.RemoveAt(PromosInBreak.Count - 1);
                        }
                        if (length - identlength <= 10)
                        {
                            count = 0;
                            break;
                        }

                    }
                    if (count == shufflepromos.Count)
                    {
                        count = 0;
                        length = Promoloop(EmptyDuration, identlength, count, nameEqual);
                    }
                }
            }
            breakDuration = length;
        }
        private int Promoloop(int length, int identlength, int count, bool nameEqual)
        {
            int curLength = 0;
            PromosInBreak.Clear();

            List<Fillers> _promos = promos.GetList();

            var shufflepromos = _promos.OrderByDescending(a => a.getDuration()).ToList();

            while (length > identlength)
            {

                foreach (Fillers item in shufflepromos)
                {
                    count++;
                    if (item.getDuration() < length - identlength)
                    {
                        foreach (Fillers brkpromos in PromosInBreak)
                        {
                            if (item.getFileName().Contains(brkpromos.getFileName()))
                            {
                                nameEqual = true;
                            }
                        }
                        if (nameEqual == true)
                        {
                            nameEqual = false;
                            continue;
                        }
                        if (nameEqual == false)
                        {
                            PromosInBreak.Add(new Fillers(item.getFileName(), item.getDuration(), 0));
                            length -= item.getDuration();
                        }

                    }
                    if (length <= identlength)
                    {
                        count = 0;
                        curLength = length;
                        break;
                    }

                }
                if (count == shufflepromos.Count)
                {
                    //AddingPromosFailed = true;
                    break;
                }
            }
            return curLength;
        }
        private int PromosDuration(string breakduration, int commercialsdurations)
        {
            int brkdur = int.Parse(breakduration);
            int amount = 0;
            amount = brkdur - commercialsdurations;
            return amount;
        }
        private bool IsBreakDurationEmpty(string fst, string snd, string trd, string frt)
        {

            if (fst == "0" && snd == "0")
            {
                if (trd == "0" && frt == "0")
                {
                    return true;
                }
                if (fst == "0" && snd == "0" && String.IsNullOrWhiteSpace(trd) && String.IsNullOrWhiteSpace(frt))
                {
                    return true;
                }
            }
            return false;
        }
        private void createGroupEvent(ProgramGroup rGroup, string liveName, string brkStartTime, string brkDuration, List<Commercials> brk)
        {            
            if (brk.Count != 0)
            {
                foreach (Commercials commercial in brk)
                {
                    breakDuration += commercial.getDuration();
                }
                if (breakDuration != 0)
                {
                    FillGroup(rGroup, brkDuration, breakDuration, brk);
                }
                brk.Clear();
                breakDuration = 0;
            }
            if (!String.IsNullOrWhiteSpace(brkStartTime) && brkDuration != "0")
            {
                #region Live event
                LiveProgramEvent fEvent = new LiveProgramEvent();
                AudioSubstream fAudio = new AudioSubstream();
                AudioSubstream fAudio2 = new AudioSubstream();
                AudioSubstream fAudio3 = new AudioSubstream();
                AudioSubstream fAudio4 = new AudioSubstream();
                AudioSubstreamEvent fAudioEvent = new AudioSubstreamEvent();

                fEvent.Duration = LiveEventDuration;
                fEvent.Title = liveName;
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
            }
        }
        private void createDCIDGroupEvent(ProgramGroup rGroup, string liveName, string brkStartTime, string brkDuration, List<Commercials> brk)
        {
            if (!String.IsNullOrWhiteSpace(brkStartTime) && brkDuration != "0")
            {
                #region Live event
                LiveProgramEvent fEvent = new LiveProgramEvent();
                AudioSubstream fAudio = new AudioSubstream();
                AudioSubstream fAudio2 = new AudioSubstream();
                AudioSubstream fAudio3 = new AudioSubstream();
                AudioSubstream fAudio4 = new AudioSubstream();
                AudioSubstreamEvent fAudioEvent = new AudioSubstreamEvent();

                fEvent.Duration = LiveEventDuration;
                fEvent.Title = liveName;
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
            }
            if (brk.Count != 0)
            {
                foreach (Commercials commercial in brk)
                {
                    breakDuration += commercial.getDuration();
                }
                if (breakDuration != 0)
                {
                    FillDCIDGroup(rGroup, brkDuration, breakDuration, brk);
                }
                brk.Clear();
                breakDuration = 0;
            }
          
        }
        private void FillGroup(ProgramGroup rGroup, string breakduration, int commercialsdurations, List<Commercials> brk)
        {
            ProgramGroup cGroup = new ProgramGroup();
            string cGroupTitle = "";
            if (Utility.ListType.Equals("DC"))
            {
                DCPromotions(breakduration, commercialsdurations);
            }
            else
            {
                TLCPromotions(breakduration, commercialsdurations);
            }

            string timehelper = utility.StringToTimeFormat(breakduration);
            cGroup.PredictedDuration = timehelper;
            cGroup.ExtendToPredictedDuration = true;
            foreach (Commercials commercial in brk)
            {
                cGroupTitle = commercial.getStartTime();
                VideoProgramEvent vEvent = new VideoProgramEvent();
                AudioSubstream cAudio = new AudioSubstream();
                AudioSubstream cAudio2 = new AudioSubstream();
                AudioSubstreamEvent caEvent = new AudioSubstreamEvent();
                AudioSubstreamEvent caEvent2 = new AudioSubstreamEvent();
                vEvent.FileName = commercial.getFileName();
                vEvent.IsCommercial = true;
                caEvent.FileName = commercial.getEstAudio();
                caEvent2.FileName = commercial.getRusAudio();
                cAudio.Name = AudioSubstreamName.Track1;
                cAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                cAudio.Default = true;
                cAudio.Event.Add(caEvent);
                vEvent.Substreams.Add(cAudio);
                cAudio2.Name = AudioSubstreamName.Track1;
                cAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                cAudio2.Default = true;
                cAudio2.Event.Add(caEvent2);
                vEvent.Substreams.Add(cAudio2);
                cGroup.Items.Add(vEvent);
            }
            if (!Utility.IsBreakDurationFull)
            {
                VideoProgramEvent ivEvent = new VideoProgramEvent();
                AudioSubstream iAudio = new AudioSubstream();
                AudioSubstream iAudio2 = new AudioSubstream();
                AudioSubstream iAudio3 = new AudioSubstream();
                AudioSubstream iAudio4 = new AudioSubstream();
                AudioSubstreamEvent iaEvent = new AudioSubstreamEvent();
                ivEvent.FileName = IdentsInBreak[0].getFileName();
                iaEvent.FileName = IdentsInBreak[0].getFileName();
                iAudio.Name = AudioSubstreamName.Track1;
                iAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
                iAudio.Default = true;
                iAudio.Event.Add(iaEvent);
                ivEvent.Substreams.Add(iAudio);
                iAudio2.Name = AudioSubstreamName.Track1;
                iAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
                iAudio2.Default = true;
                iAudio2.Event.Add(iaEvent);
                ivEvent.Substreams.Add(iAudio2);
                cGroup.Items.Add(ivEvent);
            }
            else
            {
                cGroup.BackColor = "ff0000";
            }

            foreach (Fillers promos in PromosInBreak)
            {
                VideoProgramEvent vEvent = new VideoProgramEvent();
                AudioSubstream cAudio = new AudioSubstream();
                AudioSubstream cAudio2 = new AudioSubstream();
                AudioSubstream cAudio3 = new AudioSubstream();
                AudioSubstream cAudio4 = new AudioSubstream();
                AudioSubstreamEvent caEvent = new AudioSubstreamEvent();

                vEvent.FileName = promos.getFileName();
                if (promos.getTrimout() != 0)
                {
                    if (Properties.Settings.Default.useTransistion)
                    {
                        Transition vTransition = new Transition();
                        TransitionType transistionType = (TransitionType)Enum.Parse(typeof(TransitionType), Properties.Settings.Default.transistionType);
                        vTransition.Type = transistionType;
                        vTransition.Duration = Properties.Settings.Default.transistionDuration;
                        vEvent.VideoTransition = vTransition;
                    }

                    double trimIn = promos.getTrimout() - 0.85;
                    vEvent.TrimIn = utility.IntToTimeSpan(trimIn);
                    //vEvent.TrimOut = utility.IntToTimeSpan(promos.getDuration());
                }
                else
                {
                    vEvent.TrimIn = "00:00:00:00";
                    //vEvent.TrimOut = utility.IntToTimeSpan(promos.getDuration());
                }

                caEvent.FileName = promos.getFileName();
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
                cGroup.Items.Add(vEvent);
            }
            cGroup.Title = cGroupTitle;
            rGroup.Items.Add(cGroup);
        }
        private void FillDCIDGroup(ProgramGroup rGroup,string breakduration, int commercialsdurations, List<Commercials> brk)
        {
            ProgramGroup cGroup = new ProgramGroup();
            string cGroupTitle = "";
            
            DCIDPromotions(breakduration, commercialsdurations);
            Idents();
            for (int i = 0; i < IdentsInBreak.Count; i++)
            {
                if (i == 0)
                {
                    IdentEvent(cGroup, i);
                }
            }
            string timehelper = utility.StringToTimeFormat(breakduration);
            cGroup.PredictedDuration = timehelper;
            cGroup.ExtendToPredictedDuration = true;
            foreach (Commercials commercial in brk)
            {
                cGroupTitle = commercial.getStartTime();
                VideoProgramEvent vEvent = new VideoProgramEvent();
                AudioSubstream cAudio = new AudioSubstream();
                AudioSubstream cAudio2 = new AudioSubstream();
                AudioSubstreamEvent caEvent = new AudioSubstreamEvent();
                vEvent.FileName = commercial.getFileName();
                vEvent.IsCommercial = true;
                if (Properties.Settings.Default.dcIDUseAudioExtension)
                {
                    string extension = Properties.Settings.Default.dcIDAudioExtension;
                    caEvent.FileName = commercial.getFileName()+extension;

                }
                else
                {
                    caEvent.FileName = commercial.getFileName();
                }
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
                cGroup.Items.Add(vEvent);
            }
            for (int i = 0; i < IdentsInBreak.Count; i++)
            {
                if (i == 1)
                {
                    IdentEvent(cGroup, i);
                }
            }
            foreach (Fillers promos in PromosInBreak)
            {
                VideoProgramEvent vEvent = new VideoProgramEvent();
                AudioSubstream cAudio = new AudioSubstream();
                AudioSubstream cAudio2 = new AudioSubstream();
                AudioSubstream cAudio3 = new AudioSubstream();
                AudioSubstream cAudio4 = new AudioSubstream();
                AudioSubstreamEvent caEvent = new AudioSubstreamEvent();

                vEvent.FileName = promos.getFileName();               
                caEvent.FileName = promos.getFileName();

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
                cGroup.Items.Add(vEvent);
            }
            cGroup.Title = cGroupTitle;
            rGroup.Items.Add(cGroup);
        }
        private void Idents()
        {
            IdentsInBreak.Clear();
            double FstIdentDuration = breakDuration / 2;
            double SndIdentDuration = breakDuration - FstIdentDuration;

            SndIdentDuration = Math.Floor(SndIdentDuration);
            FstIdentDuration = Math.Floor(FstIdentDuration);
            List<Logos> idents = logo.GetList();
            var shuffleidents = idents.OrderBy(a => Guid.NewGuid());
            for (int i = 0; i < idents.Count; i++)
            {
                if (i == 0)
                {
                    if ((int)FstIdentDuration >= 3 && (int)FstIdentDuration < 5)
                    {
                        IdentsInBreak.Add(new Logos(idents[i].getFileName(), (int)FstIdentDuration));
                    }
                    if ((int)FstIdentDuration >= 5)
                    {
                        IdentsInBreak.Add(new Logos(idents[i + 1].getFileName(), (int)FstIdentDuration));
                    }

                }
                if (i == 1)
                {
                    if ((int)SndIdentDuration >= 3 && (int)SndIdentDuration < 5)
                    {
                        IdentsInBreak.Add(new Logos(idents[i - 1].getFileName(), (int)SndIdentDuration));
                    }
                    if ((int)SndIdentDuration >= 5)
                    {
                        IdentsInBreak.Add(new Logos(idents[i].getFileName(), (int)SndIdentDuration));
                    }

                }
            }
        }
        private void IdentEvent(ProgramGroup cGroup, int nrOfIdent)
        {
            VideoProgramEvent ivEvent = new VideoProgramEvent();
            AudioSubstream iAudio = new AudioSubstream();
            AudioSubstream iAudio2 = new AudioSubstream();
            AudioSubstream iAudio3 = new AudioSubstream();
            AudioSubstream iAudio4 = new AudioSubstream();
            AudioSubstreamEvent iaEvent = new AudioSubstreamEvent();
            ivEvent.TrimOut = utility.IntToTimeSpan(IdentsInBreak[nrOfIdent].getDuration());
            ivEvent.FileName = IdentsInBreak[nrOfIdent].getFileName();
            iaEvent.FileName = IdentsInBreak[nrOfIdent].getFileName();
            iAudio.Name = AudioSubstreamName.Track1;
            iAudio.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel1;
            iAudio.Default = true;
            iAudio.Event.Add(iaEvent);
            ivEvent.Substreams.Add(iAudio);
            iAudio2.Name = AudioSubstreamName.Track1;
            iAudio2.AudioChannel = AudioSubstreamAudioChannel.RecordableAudioChannel2;
            iAudio2.Default = true;
            iAudio2.Event.Add(iaEvent);
            ivEvent.Substreams.Add(iAudio2);
            cGroup.Items.Add(ivEvent);
        }
    }
}


