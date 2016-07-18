using testApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Data;

namespace testApp
{
    public partial class CNViewModel
    {

        public DateTime ListDate { get; set; }
        InterstitalEvent iEvent;
        TLCDCAudios rusAudios;
        private bool _isFiller;
        private bool _isInterstitalsOpened = true;
        private string _tlcSubStringText;
        private string _dcSubStringText;
        private readonly ICommand cnsweInterstitalCommand;
        private readonly ICommand tlcInterstitalCommand;
        private readonly ICommand dcInterstitalCommand;
        private readonly ICommand dcIDInterstitalCommand;
        private readonly ICommand applyAudiosCommand;
        private readonly ICommand applyOptionsCommand;
        private readonly ICommand dateCommand;
        private readonly ICommand listDateCommand;
        private readonly ICommand openOptionsCommand;
        private readonly ICommand openDefailtLocationCommand;
        private readonly ICommand saveDefaultLocationCommand;
        private readonly ICommand versionInfoCommand;
        private readonly ICommand openCnSWECommand;
        private readonly ICommand openTLCCommand;
        private readonly ICommand openDCCommand;
        private readonly ICommand openDCIDCommand;
        private readonly ICommand saveInterstitalsCommand;
        private readonly ICommand openFillersCommand;
        private readonly ICommand openLogosCommand;
        private readonly ICommand openInterstitalsCommand;
        private readonly ICommand openCommercialsCommand;
        private readonly ICommand openScheduleCommand;
        private readonly ICommand generateCommand;
        private readonly ICommand commercialReader;
        private readonly ICommand openCommercialReader;
        private readonly ICommand applyDCIDCommand;
        ReadExcel excelfile = new ReadExcel();
        ReadText textfile = new ReadText();
        Utility utility = new Utility();
        XML xml = new XML();
        private MainWindow _MW;
        private OptionsView _OV;
        private CommercialReader _CR;

        public CNViewModel(MainWindow MW)
        {
            Utility.ListType = "CNSWE";
            this._MW = MW;
            this.saveInterstitalsCommand = new RelayCommand(this.SaveInterstitals);
            this.openCommercialsCommand = new RelayCommand(this.OpenCommercials);
            this.openScheduleCommand = new RelayCommand(this.OpenSchedule);
            this.generateCommand = new RelayCommand(this.Generate);
            this.openInterstitalsCommand = new RelayCommand(this.OpenInterstitals);
            this.openLogosCommand = new RelayCommand(this.OpenLogos);
            this.openFillersCommand = new RelayCommand(this.OpenFillers);
            this.openCnSWECommand = new RelayCommand(this.OpenCNSWE);
            this.openDCCommand = new RelayCommand(this.OpenDC);
            this.openTLCCommand = new RelayCommand(this.OpenTLC);
            this.openDCIDCommand = new RelayCommand(this.OpenDCID);
            this.versionInfoCommand = new RelayCommand(this.VersionInfo);
            this.openOptionsCommand = new RelayCommand(this.OpenOptions);
            this.listDateCommand = new RelayCommand(this.ListDatePicker);
            this.dateCommand = new RelayCommand(this.OpenDatePicker);
            this.cnsweInterstitalCommand = new RelayCommand(this.CNsweInterstitals);
            this.tlcInterstitalCommand = new RelayCommand(this.TLCInterstitals);
            this.dcInterstitalCommand = new RelayCommand(this.DCInterstitals);
            this.dcIDInterstitalCommand = new RelayCommand(this.DCIDInterstitals);
            this.openCommercialReader = new RelayCommand(this.OpenCommercialReader);

            ListType(Utility.ListType);
        }
        public CNViewModel(OptionsView OV)
        {
            this._OV = OV;
            this.openDefailtLocationCommand = new RelayCommand(this.OpenDefaultLocation);
            this.saveDefaultLocationCommand = new RelayCommand(this.SaveDefaultLocation);
            this.applyOptionsCommand = new RelayCommand(this.ApplyOptions);
            this.applyAudiosCommand = new RelayCommand(this.ApplyAudios);
            this.applyDCIDCommand = new RelayCommand(this.ApplyDCIDChanges);
            FillRusAudioDGV();
            _OV.tb_rusAudio.Text = Properties.Settings.Default.tlcdcRusAudioExtension;
            _OV.tb_estAudio.Text = Properties.Settings.Default.tlcdcEstAudioExtension;
            _OV.tb_cnsweComStartRow.Text = Properties.Settings.Default.cnsweComStartRow.ToString();
            _OV.tb_cnsweStartTime.Text = Properties.Settings.Default.cnsweStartTime;
            _OV.tb_dcComStartRow.Text = Properties.Settings.Default.dcComStartRow.ToString();
            _OV.tb_dcScheduleStartRow.Text = Properties.Settings.Default.dcScheduleStartRow.ToString();
            _OV.tb_openLocation.Text = Properties.Settings.Default.defaultOpenLocation;
            _OV.tb_saveLocation.Text = Properties.Settings.Default.defaultSaveLocation;
            _OV.tb_tlcComStartRow.Text = Properties.Settings.Default.tlcComStartRow.ToString();
            _OV.tb_tlcScheduleStartRow.Text = Properties.Settings.Default.tlcScheduleStartRow.ToString();
            _OV.tb_dcConditionStartIndex.Text = Properties.Settings.Default.dcConditionStartIndex.ToString();
            _OV.tb_dcConfitionLength.Text = Properties.Settings.Default.dcConditionLength.ToString();
            _OV.tb_tlcConditionStartIndex.Text = Properties.Settings.Default.tlcConditionStartIndex.ToString();
            _OV.tb_tlcConfitionLength.Text = Properties.Settings.Default.tlcConditionLength.ToString();
            UseTransistion = Properties.Settings.Default.useTransistion;
            UseFindReplace = Properties.Settings.Default.useFindReplace;
            UseRusAudios = Properties.Settings.Default.tlcdcUseRusAudios;
            UseDCIDAudioExtension = Properties.Settings.Default.dcIDUseAudioExtension;
            _OV.tb_eventTransistionDuration.Text = Properties.Settings.Default.transistionDuration;
            _OV.tb_findWord.Text = Properties.Settings.Default.dcidFindWord;
            _OV.tb_replaceWord.Text = Properties.Settings.Default.dcidReplaceWord;
            _OV.cb_useFindReplace.IsChecked = UseFindReplace;
            _OV.tb_dcIDAudioExtension.Text = Properties.Settings.Default.dcIDAudioExtension;
            if (!String.IsNullOrEmpty(Properties.Settings.Default.transistionType))
            {
                TransitionType transistionType = (TransitionType)Enum.Parse(typeof(TransitionType), Properties.Settings.Default.transistionType);
                _OV.cmb_eventTransistion.SelectedItem = transistionType;
            }
            _OV.cb_useTransistion.IsChecked = Properties.Settings.Default.useTransistion;
        }
        public CNViewModel(CommercialReader CR)
        {
            this._CR = CR;
            this.commercialReader = new RelayCommand(this.CommercialReaderDCID);
        }
        public ICommand CommercialReaderCommand
        {
            get { return this.openCommercialReader; }
        }
        public ICommand DCIDCommercialReader
        {
            get { return this.commercialReader; }
        }
        public ICommand CnSWEInterstitalCommand
        {
            get { return this.cnsweInterstitalCommand; }
        }
        public ICommand TLCInterstitalCommand
        {
            get { return this.tlcInterstitalCommand; }
        }
        public ICommand DCInterstitalCommand
        {
            get { return this.dcInterstitalCommand; }
        }
        public ICommand DCIDInterstitalCommand
        {
            get { return this.dcIDInterstitalCommand; }
        }
        public ICommand ApplyAudiosCommand
        {
            get { return this.applyAudiosCommand; }
        }
        public ICommand ApplyOptionsCommand
        {
            get { return this.applyOptionsCommand; }
        }
        public ICommand ApplyDCIDCommand
        {
            get { return applyDCIDCommand; }
        }
        public ICommand DateCommand
        {
            get { return this.dateCommand; }
        }
        public ICommand DatePickerCommand
        {
            get { return this.listDateCommand; }
        }
        public ICommand SaveDefaultLocationCommand
        {
            get { return this.saveDefaultLocationCommand; }
        }
        public ICommand OpenDefaultLocationCommand
        {
            get { return this.openDefailtLocationCommand; }
        }
        public ICommand OpenOptionsCommand
        {
            get { return this.openOptionsCommand; }
        }
        public ICommand VersionInfoCommand
        {
            get { return this.versionInfoCommand; }
        }
        public ICommand SaveInterstitalsCommand
        {
            get { return this.saveInterstitalsCommand; }
        }
        public ICommand OpenFillersCommand
        {
            get { return this.openFillersCommand; }
        }
        public ICommand OpenLogosCommand
        {
            get { return this.openLogosCommand; }
        }
        public ICommand OpenCommercialsCommand
        {
            get { return this.openCommercialsCommand; }
        }
        public ICommand OpenScheduleCommand
        {
            get { return this.openScheduleCommand; }
        }
        public ICommand GenerateCommand
        {
            get { return this.generateCommand; }
        }
        public ICommand OpenInterstitalsCommand
        {
            get { return this.openInterstitalsCommand; }
        }
        public ICommand OpenCNSWECommand
        {
            get { return this.openCnSWECommand; }
        }
        public ICommand OpenTLCCommand
        {
            get { return this.openTLCCommand; }
        }
        public ICommand OpenDCIDCommand
        {
            get { return this.openDCIDCommand; }
        }
        public ICommand OpenDCCommand
        {
            get { return this.openDCCommand; }
        }

        public bool UseTransistion { get; set; }
        public bool UseRusAudios { get; set; }
        public bool UseFindReplace { get; set; }
        public bool UseDCIDAudioExtension { get; set; }
        public string DCConditionStartIndex
        {
            get
            {
                return Properties.Settings.Default.dcConditionStartIndex.ToString();
            }
            set
            {
                Properties.Settings.Default.dcConditionStartIndex = int.Parse(value);
                OnPropertyChanged("DCConditionStartIndex");
            }
        }
        public string DCConditionLength
        {
            get
            {
                return Properties.Settings.Default.dcConditionLength.ToString();
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Properties.Settings.Default.dcConditionLength = int.Parse(value);
                }

                OnPropertyChanged("DCConditionLength");
            }
        }
        public string TLConditionStartIndex
        {
            get
            {
                return Properties.Settings.Default.tlcConditionStartIndex.ToString();
            }
            set
            {
                Properties.Settings.Default.tlcConditionStartIndex = int.Parse(value);
                OnPropertyChanged("TLConditionStartIndex");
            }
        }
        public string TLCConditionLength
        {
            get
            {
                return Properties.Settings.Default.tlcConditionLength.ToString();
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Properties.Settings.Default.tlcConditionLength = int.Parse(value);
                }

                OnPropertyChanged("TLCConditionLength");
            }
        }
        public string TLCSubStringText
        {
            get
            {
                return this._tlcSubStringText;
            }
            set
            {
                if (value.Length >= Properties.Settings.Default.tlcConditionStartIndex)
                {
                    this._tlcSubStringText = value.Substring(Properties.Settings.Default.tlcConditionStartIndex, Properties.Settings.Default.tlcConditionLength);
                    OnPropertyChanged("TLCSubStringText");
                }
                else
                {
                    System.Windows.MessageBox.Show(value + "Length of the word text is shorter then " + Properties.Settings.Default.tlcConditionStartIndex.ToString());
                }
            }
        }
        public string DCSubStringText
        {
            get
            {
                return this._dcSubStringText;
            }
            set
            {
                if (value.Length >= Properties.Settings.Default.dcConditionStartIndex)
                {
                    this._dcSubStringText = value.Substring(Properties.Settings.Default.dcConditionStartIndex, Properties.Settings.Default.dcConditionLength);
                    OnPropertyChanged("DCSubStringText");
                }


            }
        }
        private void CNsweInterstitals(object state)
        {
            Utility.InterstitalType = "CNSWE";
            OpenInterstital(Utility.InterstitalType);
        }
        private void DCInterstitals(object state)
        {
            Utility.InterstitalType = "DC";
            OpenInterstital(Utility.InterstitalType);
        }
        private void TLCInterstitals(object state)
        {
            Utility.InterstitalType = "TLC";
            OpenInterstital(Utility.InterstitalType);
        }
        private void DCIDInterstitals(object state)
        {
            Utility.InterstitalType = "DCID";
            OpenInterstital(Utility.InterstitalType);
        }
        private void ApplyOptions(object state)
        {
            if (System.Windows.MessageBox.Show("Options has been saved!", "Confirm", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                if (!String.IsNullOrEmpty(_OV.tb_cnsweStartTime.Text))
                {
                    Properties.Settings.Default.cnsweStartTime = _OV.tb_cnsweStartTime.Text;
                }
                if (!String.IsNullOrEmpty(_OV.tb_cnsweComStartRow.Text))
                {
                    Properties.Settings.Default.cnsweComStartRow = int.Parse(_OV.tb_cnsweComStartRow.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_tlcComStartRow.Text))
                {
                    Properties.Settings.Default.tlcComStartRow = int.Parse(_OV.tb_tlcComStartRow.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_tlcScheduleStartRow.Text))
                {
                    Properties.Settings.Default.tlcScheduleStartRow = int.Parse(_OV.tb_tlcScheduleStartRow.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_dcComStartRow.Text))
                {
                    Properties.Settings.Default.dcComStartRow = int.Parse(_OV.tb_dcComStartRow.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_dcScheduleStartRow.Text))
                {
                    Properties.Settings.Default.dcScheduleStartRow = int.Parse(_OV.tb_dcScheduleStartRow.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_dcConditionStartIndex.Text))
                {
                    Properties.Settings.Default.dcConditionStartIndex = int.Parse(_OV.tb_dcConditionStartIndex.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_dcConfitionLength.Text))
                {
                    Properties.Settings.Default.dcConditionLength = int.Parse(_OV.tb_dcConfitionLength.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_tlcConditionStartIndex.Text))
                {
                    Properties.Settings.Default.tlcConditionStartIndex = int.Parse(_OV.tb_tlcConditionStartIndex.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_tlcConfitionLength.Text))
                {
                    Properties.Settings.Default.tlcConditionLength = int.Parse(_OV.tb_tlcConfitionLength.Text);
                }
                if (!String.IsNullOrEmpty(_OV.tb_eventTransistionDuration.Text))
                {
                    Properties.Settings.Default.transistionDuration = _OV.tb_eventTransistionDuration.Text;
                }
                if (_OV.cmb_eventTransistion.SelectedItem != null)
                {
                    Properties.Settings.Default.transistionType = _OV.cmb_eventTransistion.SelectedItem.ToString();
                }
                Properties.Settings.Default.useTransistion = UseTransistion;
                Properties.Settings.Default.Save();
                _OV.Close();
            }
        }
        private void ApplyAudios(object state)
        {
            if (System.Windows.MessageBox.Show("Audios has been saved!", "Confirm", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                if (!String.IsNullOrEmpty(_OV.tb_rusAudio.Text))
                {
                    Properties.Settings.Default.tlcdcRusAudioExtension = _OV.tb_rusAudio.Text;
                }
                if (!String.IsNullOrEmpty(_OV.tb_estAudio.Text))
                {
                    Properties.Settings.Default.tlcdcEstAudioExtension = _OV.tb_estAudio.Text;
                }
            }
            SaveRusAudios();
            Properties.Settings.Default.tlcdcUseRusAudios = UseRusAudios;
            Properties.Settings.Default.Save();
        }
        private void ApplyDCIDChanges(object state)
        {
            if (System.Windows.MessageBox.Show("Changes has been saved!", "Confirm", MessageBoxButton.OK) == MessageBoxResult.OK)
            {

                Properties.Settings.Default.dcidFindWord = _OV.tb_findWord.Text;
                Properties.Settings.Default.dcidReplaceWord = _OV.tb_replaceWord.Text;
                Properties.Settings.Default.dcIDAudioExtension = _OV.tb_dcIDAudioExtension.Text;

            }
            Properties.Settings.Default.dcIDUseAudioExtension = UseDCIDAudioExtension;
            Properties.Settings.Default.useFindReplace = UseFindReplace;
            Properties.Settings.Default.Save();
        }
        private void OpenDatePicker(object state)
        {
            _MW.listDate.SelectedDate = DateTime.Now.Date;
            _MW.CalendarPopup.IsOpen = !_MW.CalendarPopup.IsOpen;
        }
        private void ListDatePicker(object state)
        {
            if (!String.IsNullOrEmpty(ListDate.ToString()))
            {
                Utility.listDate = ListDate;
                _MW.CalendarPopup.IsOpen = false;
                utility.populateLB(_MW, ListDate.Day.ToString() + "." + ListDate.Month.ToString() + "." + ListDate.Year.ToString() + " selected.");
                _MW.btn_generate.IsEnabled = true;
            }
        }
        private void OpenOptions(object state)
        {
            OptionsView options = new OptionsView();
            options.Show();
        }
        private void OpenCommercialReader(object state)
        {
            CommercialReader cr = new CommercialReader();
            cr.Show();
        }
        private void VersionInfo(object state)
        {
            System.Windows.Forms.MessageBox.Show(Properties.Settings.Default.verInfo);
        }
        private void OpenCNSWE(object state)
        {
            Utility.ListType = "CNSWE";
            ListType(Utility.ListType);
        }
        private void OpenDCID(object state)
        {
            Utility.ListType = "DCID";
            ListType(Utility.ListType);
        }
        private void OpenTLC(object state)
        {
            Utility.ListType = "TLC";
            ListType(Utility.ListType);
        }
        private void OpenDC(object state)
        {
            Utility.ListType = "DC";
            ListType(Utility.ListType);
        }
        private void CommercialReaderDCID(object state)
        {
            OpenCommercialReaderDialog();
            utility.AddCommercialsLB(_CR.lbCommercialReader);
        }
        private void OpenDefaultLocation(object state)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Properties.Settings.Default.defaultOpenLocation;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.defaultOpenLocation = fbd.SelectedPath;
                _OV.tb_openLocation.Text = Properties.Settings.Default.defaultOpenLocation;
            }
        }
        private void SaveDefaultLocation(object state)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Properties.Settings.Default.defaultSaveLocation;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.defaultSaveLocation = fbd.SelectedPath;
                _OV.tb_saveLocation.Text = Properties.Settings.Default.defaultSaveLocation;
            }
        }
        private void ListType(string listtype)
        {
            switch (listtype)
            {
                case "TLC":
                    _MW.btn_generate.IsEnabled = false;
                    utility.CheckForSchedule(Utility.TLCFilePath, _MW);
                    utility.populateLB(_MW, "Opened schedule: " + Path.GetFileName(Utility.ScheduleFilePath));
                    _MW.lbl_formTitle.Content = "Playlist Form: TLC";
                    _MW.btn_date.Visibility = Visibility.Visible;
                    Utility.xmlfile = @"C:\\AutomatedLists\TLC\Workflow\XML\Done.xml";
                    Utility.fillerspath = @"C:\\AutomatedLists\TLC\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\TLC\Workflow\Logo\logo.xml";
                    break;
                case "DC":
                    _MW.btn_generate.IsEnabled = false;
                    utility.CheckForSchedule(Utility.DCFilePath, _MW);
                    utility.populateLB(_MW, "Opened schedule: " + Path.GetFileName(Utility.ScheduleFilePath));
                    _MW.lbl_formTitle.Content = "Playlist Form: DC";
                    _MW.btn_date.Visibility = Visibility.Visible;
                    Utility.xmlfile = @"C:\\AutomatedLists\DC\Workflow\XML\Done.xml";
                    Utility.fillerspath = @"C:\\AutomatedLists\DC\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\DC\Workflow\Logo\logo.xml";
                    break;
                case "CNSWE":
                    _MW.btn_generate.IsEnabled = true;
                    _MW.lbl_formTitle.Content = "Playlist Form: CN SWE";
                    _MW.btn_date.Visibility = Visibility.Collapsed;
                    Utility.xmlfile = @"C:\\AutomatedLists\CNSWE\Workflow\XML\Done.xml";
                    Utility.fillerspath = @"C:\\AutomatedLists\CNSWE\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\CNSWE\Workflow\Logo\logo.xml";
                    break;
                case "DCID":
                    _MW.btn_generate.IsEnabled = false;
                    utility.CheckForSchedule(Utility.DCIDFilePath, _MW);
                    utility.populateLB(_MW, "Opened schedule: " + Path.GetFileName(Utility.ScheduleFilePath));
                    _MW.lbl_formTitle.Content = "Playlist Form: DC IDx";
                    _MW.btn_date.Visibility = Visibility.Visible;
                    Utility.xmlfile = @"C:\\AutomatedLists\DCID\Workflow\XML\Done.xml";
                    Utility.fillerspath = @"C:\\AutomatedLists\DCID\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\DCID\Workflow\Logo\logo.xml";
                    break;
            }
        }
        private void SaveInterstitals(object state)
        {
            if (_isFiller)
            {
                Utility.saveInterstitalEventToXML(iEvent, Utility.fillerspath);
                System.Windows.Forms.MessageBox.Show("Fillers has been saved!");
            }
            if (!_isFiller)
            {
                Utility.saveInterstitalEventToXML(iEvent, Utility.logospath);
                System.Windows.Forms.MessageBox.Show("Logos has been saved!");
            }
        }
        private void SaveRusAudios()
        {
            Utility.saveTLCDCRusAudiosToXML(Utility.TLCDCRusAudioPath, rusAudios);
        }
        private void OpenFillers(object state)
        {
            iEvent = Utility.readInterstitalsXML(Utility.fillerspath);
            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
            _isFiller = true;
        }
        private void OpenLogos(object state)
        {
            iEvent = Utility.readInterstitalsXML(Utility.logospath);
            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
            _isFiller = false;
        }
        private void OpenCommercials(object state)
        {

            DefaultVisibility();
            utility.ClearListbox();
            OpenCommercialDialog(Utility.ListType);

        }
        private void OpenInterstitals(object state)
        {
            fieldVisibilty();
            utility.ClearListbox();

        }
        private void OpenSchedule(object state)
        {
            DefaultVisibility();
            utility.ClearListbox();
            OpenScheduleDialog(Utility.ListType);
        }
        private void OpenCommercialDialog(string listtype)
        {
            Microsoft.Win32.OpenFileDialog opf = new Microsoft.Win32.OpenFileDialog();
            opf.Title = "Open Commercials";
            switch (listtype)
            {
                case "TLC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    break;
                case "DC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    break;
                case "DCID":
                    opf.Filter = "IDBU Files (.idbu, .txt)|*.idbu;*.txt";
                    break;
                case "CNSWE":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    break;
            }
            opf.InitialDirectory = Properties.Settings.Default.defaultOpenLocation;
            opf.ShowDialog();
            string filePath = opf.FileName;
            if (!String.IsNullOrEmpty(filePath) && !String.IsNullOrWhiteSpace(filePath))
            {
                Utility.IsCommercialsCorrect = true;
                Utility.CommercialFilePath = filePath;
                string text = "Opened: " + Path.GetFileName(filePath);
                utility.populateLB(_MW, text);
            }
            if (listtype == "DCID")
            {
                utility.CopyCommercialText(_MW, Utility.DCIDCommercialPath, Utility.CommercialFilePath, "test.txt");
            }
        }
        private void OpenCommercialReaderDialog()
        {
            Microsoft.Win32.OpenFileDialog opf = new Microsoft.Win32.OpenFileDialog();
            opf.Title = "Open Commercials";
            opf.Filter = "IDBU Files (.idbu, .txt)|*.idbu;*.txt";
            opf.InitialDirectory = Properties.Settings.Default.defaultOpenLocation;
            opf.ShowDialog();
            string filePath = opf.FileName;
            if (!String.IsNullOrEmpty(filePath) && !String.IsNullOrWhiteSpace(filePath))
            {
                Utility.IsCommercialsCorrect = true;
                Utility.CommercialFilePath = filePath;
                utility.CopyCommercialText(Utility.DCIDCommercialPath, Utility.CommercialFilePath, "test.txt");
            }
        }
        private void OpenScheduleDialog(string listtype)
        {
            bool copyexcel = false;
            Microsoft.Win32.OpenFileDialog opf = new Microsoft.Win32.OpenFileDialog();
            opf.Title = "Open Schedule";
            switch (listtype)
            {
                case "TLC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    copyexcel = true;
                    break;
                case "DC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    copyexcel = true;
                    break;
                case "DCID":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    copyexcel = true;
                    break;
                case "CNSWE":
                    opf.Filter = "Text Files (.txt)|*.txt";
                    break;
            }
            opf.InitialDirectory = Properties.Settings.Default.defaultOpenLocation;
            opf.ShowDialog();
            string filePath = opf.FileName;
            if (!String.IsNullOrEmpty(filePath) && !String.IsNullOrWhiteSpace(filePath))
            {
                Utility.ScheduleFilePath = filePath;
                Utility.scheduleName = Path.GetFileName(filePath);
                if (copyexcel)
                {
                    switch (listtype)
                    {
                        case "TLC":
                            utility.clearFolder(_MW, Utility.TLCFilePath);
                            utility.CopyExcel(_MW, Utility.TLCFilePath, Utility.ScheduleFilePath);
                            break;
                        case "DC":
                            utility.clearFolder(_MW, Utility.DCFilePath);
                            utility.CopyExcel(_MW, Utility.DCFilePath, Utility.ScheduleFilePath);
                            break;
                        case "DCID":
                            utility.clearFolder(_MW, Utility.DCIDFilePath);
                            utility.CopyExcel(_MW, Utility.DCIDFilePath, Utility.ScheduleFilePath);
                            break;
                    }
                }
                string text = "Opened: " + Path.GetFileName(filePath);
                utility.populateLB(_MW, text);
            }
        }
        private void OpenInterstital(string interstitaltype)
        {
            switch (interstitaltype)
            {
                case "TLC":
                    Utility.fillerspath = @"C:\\AutomatedLists\TLC\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\TLC\Workflow\Logo\logo.xml";
                    _MW.btn_Fillers.IsEnabled = true;
                    _MW.btn_Logos.IsEnabled = true;
                    _MW.btn_Save.IsEnabled = true;
                    _MW.cb_cnSwe.IsChecked = false;
                    _MW.cb_dc.IsChecked = false;
                    _MW.cb_dcID.IsChecked = false;
                    if (_isFiller)
                    {
                        if (Utility.readInterstitalsXML(Utility.fillerspath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.fillerspath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " fillers xml!");
                        }
                    }
                    else
                    {
                        if (Utility.readInterstitalsXML(Utility.logospath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.logospath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " logos xml!");
                        }
                    }
                    break;
                case "DC":
                    Utility.fillerspath = @"C:\\AutomatedLists\DC\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\DC\Workflow\Logo\logo.xml";
                    _MW.btn_Fillers.IsEnabled = true;
                    _MW.btn_Logos.IsEnabled = true;
                    _MW.btn_Save.IsEnabled = true;
                    _MW.cb_cnSwe.IsChecked = false;
                    _MW.cb_tlc.IsChecked = false;
                    _MW.cb_dcID.IsChecked = false;
                    if (_isFiller)
                    {
                        if (Utility.readInterstitalsXML(Utility.fillerspath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.fillerspath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " fillers xml!");
                        }
                    }
                    else
                    {
                        if (Utility.readInterstitalsXML(Utility.logospath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.logospath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " logos xml!");
                        }
                    }
                    break;
                case "DCID":
                    Utility.fillerspath = @"C:\\AutomatedLists\DCID\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\DCID\Workflow\Logo\logo.xml";
                    _MW.btn_Fillers.IsEnabled = true;
                    _MW.btn_Logos.IsEnabled = true;
                    _MW.btn_Save.IsEnabled = true;
                    _MW.cb_dc.IsChecked = false;
                    _MW.cb_cnSwe.IsChecked = false;
                    _MW.cb_tlc.IsChecked = false;
                    if (_isFiller)
                    {
                        if (Utility.readInterstitalsXML(Utility.fillerspath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.fillerspath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " fillers xml!");
                        }
                    }
                    else
                    {
                        if (Utility.readInterstitalsXML(Utility.logospath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.logospath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " logos xml!");
                        }
                    }
                    break;
                case "CNSWE":
                    Utility.fillerspath = @"C:\\AutomatedLists\CNSWE\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\CNSWE\Workflow\Logo\logo.xml";
                    _MW.btn_Fillers.IsEnabled = true;
                    _MW.btn_Logos.IsEnabled = true;
                    _MW.btn_Save.IsEnabled = true;
                    _MW.cb_dc.IsChecked = false;
                    _MW.cb_tlc.IsChecked = false;
                    _MW.cb_dcID.IsChecked = false;
                    if (_isFiller)
                    {
                        if (Utility.readInterstitalsXML(Utility.fillerspath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.fillerspath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " fillers xml!");
                        }
                    }
                    else
                    {
                        if (Utility.readInterstitalsXML(Utility.logospath) != null)
                        {
                            iEvent = Utility.readInterstitalsXML(Utility.logospath);
                            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                        }
                        else
                        {
                            utility.populateLB(_MW, "Error reading " + interstitaltype + " logos xml!");
                        }
                    }
                    break;
            }
        }
        private void copySchedules()
        {
            switch (Utility.ListType)
            {
                case "CNSWE":
                    utility.CopyScheduleText(_MW);

                    break;
                case "TLC":
                    utility.clearFolder(_MW, Utility.TLCFilePath);
                    if (!String.IsNullOrEmpty(Utility.ScheduleFilePath))
                    {
                        utility.CopyScheduleExcel(_MW, Utility.TLCFilePath, Properties.Settings.Default.tlcSchedulePath);
                    }
                    break;
                case "DC":
                    utility.clearFolder(_MW, Utility.DCFilePath);
                    if (!String.IsNullOrEmpty(Utility.ScheduleFilePath))
                    {
                        utility.CopyScheduleExcel(_MW, Utility.DCFilePath, Properties.Settings.Default.dcSchedulePath);
                    }
                    break;
                case "DCID":
                    utility.clearFolder(_MW, Utility.DCIDFilePath);
                    if (!String.IsNullOrEmpty(Utility.ScheduleFilePath))
                    {
                        utility.CopyScheduleExcel(_MW, Utility.DCIDFilePath, Properties.Settings.Default.dcIDSchedulePath);
                    }
                    break;
            }
        }
        private void fieldVisibilty()
        {

            if (_isInterstitalsOpened)
            {
                _MW.dgvStackPanel.Visibility = Visibility.Visible;
                _MW.dgvButtons.Visibility = Visibility.Visible;
                _MW.cbInterstitals.Visibility = Visibility.Visible;
                _MW.lbStackPanel.Visibility = Visibility.Collapsed;
                _MW.btn_Save.IsEnabled = false;
                _MW.btn_Fillers.IsEnabled = false;
                _MW.btn_Logos.IsEnabled = false;
                _isInterstitalsOpened = false;
            }
            else
            {
                DefaultVisibility();
            }
        }
        private void DefaultVisibility()
        {
            _MW.dgvButtons.Visibility = Visibility.Collapsed;
            _MW.dgvStackPanel.Visibility = Visibility.Collapsed;
            _MW.cbInterstitals.Visibility = Visibility.Collapsed;
            _MW.lbStackPanel.Visibility = Visibility.Visible;
            _isInterstitalsOpened = true;
        }
        private void Generate(object state)
        {
            GenerateLists();
        }
        private void GenerateLists()
        {
            switch (Utility.ListType)
            {
                case "CNSWE":
                    if (!String.IsNullOrEmpty(Utility.CommercialFilePath) && !String.IsNullOrEmpty(Utility.ScheduleFilePath))
                    {
                        copySchedules();
                        xml.GenerateCNSWEXML(_MW);
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            Utility.IsListGenerated = true;

                        }
                        else
                        {
                            Utility.initError = string.Empty;
                        }
                        utility.clearCNSWEScheduleFolder();
                    }
                    else
                    {
                        utility.populateLB(_MW, "Missing essential info!");
                    }
                    break;
                case "TLC":
                    if (!String.IsNullOrEmpty(Utility.CommercialFilePath))
                    {
                        xml.GenerateTLCXML(_MW);
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            Utility.IsListGenerated = true;
                            _MW.btn_generate.IsEnabled = false;
                        }
                        else
                        {
                            Utility.initError = string.Empty;
                        }
                    }
                    else
                    {
                        utility.populateLB(_MW, "Missing essential info!");
                    }
                    break;
                case "DC":
                    if (!String.IsNullOrEmpty(Utility.CommercialFilePath))
                    {
                        xml.GenerateDCXML(_MW);
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            Utility.IsListGenerated = true;
                            _MW.btn_generate.IsEnabled = false;
                        }
                        else
                        {
                            Utility.initError = string.Empty;
                        }
                    }
                    else
                    {
                        utility.populateLB(_MW, "Missing essential info!");
                    }
                    break;
                case "DCID":
                    if (!String.IsNullOrEmpty(Utility.CommercialFilePath))
                    {
                        xml.GenerateDCIDXML(_MW);
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            Utility.IsListGenerated = true;
                        }
                        else
                        {
                            Utility.initError = string.Empty;
                        }
                        utility.clearDCIDCommercialFolder();
                    }
                    else
                    {
                        utility.populateLB(_MW, "Missing essential info!");
                    }
                    break;
            }
        }
        private void FillRusAudioDGV()
        {
            rusAudios = Utility.readRusAudiosXML(Utility.TLCDCRusAudioPath);
            _OV.dgv_openAudios.ItemsSource = rusAudios.russianAudios;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        public class RelayCommand : ICommand
        {
            #region Fields

            readonly Action<object> _execute;
            readonly Predicate<object> _canExecute;

            #endregion // Fields

            #region Constructors

            /// <summary>
            /// Creates a new command that can always execute.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            public RelayCommand(Action<object> execute)
                : this(execute, null)
            {
            }

            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }

            #endregion // Constructors

            #region ICommand Members

            [DebuggerStepThrough]
            public bool CanExecute(object parameters)
            {
                return _canExecute == null ? true : _canExecute(parameters);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameters)
            {
                _execute(parameters);
            }

            #endregion // ICommand Members
        }
    }

}
