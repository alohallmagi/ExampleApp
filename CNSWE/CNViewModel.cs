using CNSWE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace CNSWE
{
    public partial class CNViewModel
    {

        public DateTime ListDate { get; set; }
        InterstitalEvent iEvent;
        private bool _isFiller;
        private bool _isInterstitalsOpened = true;
        private readonly ICommand cnsweInterstitalCommand;
        private readonly ICommand tlcInterstitalCommand;
        private readonly ICommand dcInterstitalCommand;
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
        private readonly ICommand saveInterstitalsCommand;
        private readonly ICommand openFillersCommand;
        private readonly ICommand openLogosCommand;
        private readonly ICommand openInterstitalsCommand;
        private readonly ICommand openCommercialsCommand;
        private readonly ICommand openScheduleCommand;
        private readonly ICommand generateCommand;
        ReadExcel excelfile = new ReadExcel();
        ReadText textfile = new ReadText();
        Utility utility = new Utility();
        XML xml = new XML();
        private MainWindow _MW;
        private OptionsView _OV;

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
            this.versionInfoCommand = new RelayCommand(this.VersionInfo);
            this.openOptionsCommand = new RelayCommand(this.OpenOptions);
            this.listDateCommand = new RelayCommand(this.ListDatePicker);
            this.dateCommand = new RelayCommand(this.OpenDatePicker);
            this.cnsweInterstitalCommand = new RelayCommand(this.CNsweInterstitals);
            this.tlcInterstitalCommand = new RelayCommand(this.TLCInterstitals);
            this.dcInterstitalCommand = new RelayCommand(this.DCInterstitals);
            ListType(Utility.ListType);
        }
        public CNViewModel(OptionsView OV)
        {
            this._OV = OV;
            this.openDefailtLocationCommand = new RelayCommand(this.OpenDefaultLocation);
            this.saveDefaultLocationCommand = new RelayCommand(this.SaveDefaultLocation);
            this.applyOptionsCommand = new RelayCommand(this.ApplyOptions);
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
        public ICommand ApplyOptionsCommand
        {
            get { return this.applyOptionsCommand; }
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
        public ICommand OpenDCCommand
        {
            get { return this.openDCCommand; }
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
        private void ApplyOptions(object state)
        {
            if (System.Windows.MessageBox.Show("Options has been saved!", "Confirm", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                Properties.Settings.Default.cnsweStartTime = _OV.tb_cnsweStartTime.Text;
                Properties.Settings.Default.cnsweComStartRow = int.Parse(_OV.tb_cnsweComStartRow.Text);
                Properties.Settings.Default.tlcComStartRow = int.Parse(_OV.tb_tlcComStartRow.Text);
                Properties.Settings.Default.tlcScheduleStartRow = int.Parse(_OV.tb_tlcScheduleStartRow.Text);
                Properties.Settings.Default.dcComStartRow = int.Parse(_OV.tb_dcComStartRow.Text);
                Properties.Settings.Default.dcScheduleStartRow = int.Parse(_OV.tb_dcScheduleStartRow.Text);
                Properties.Settings.Default.Save();
                _OV.Close();
            }
        }
        private void OpenDatePicker(object state)
        {
            _MW.listDate.DisplayDate = DateTime.Now.Date;
            _MW.CalendarPopup.IsOpen = !_MW.CalendarPopup.IsOpen;
        }
        private void ListDatePicker(object state)
        {
            if (!String.IsNullOrEmpty(ListDate.ToString()))
            {
                Utility.listDate = ListDate;
                _MW.CalendarPopup.IsOpen = false;
                utility.populateLB(_MW, "Searching for " + ListDate.ToShortDateString().ToString() + " schedule");
            }
        }
        private void OpenOptions(object state)
        {
            OptionsView options = new OptionsView();
            options.Show();
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
                    _MW.Title = "TLC";
                    _MW.btn_date.Visibility = Visibility.Visible;
                    Utility.xmlfile = @"C:\\AutomatedLists\TLC\Workflow\XML\Done.xml";
                    
                    break;
                case "DC":
                    _MW.Title = "DC";
                    _MW.btn_date.Visibility = Visibility.Visible;
                    Utility.xmlfile = @"C:\\AutomatedLists\DC\Workflow\XML\Done.xml";
                    break;
                case "CNSWE":
                    _MW.Title = "CN SWE";
                    _MW.btn_date.Visibility = Visibility.Collapsed;
                    Utility.xmlfile = @"C:\\AutomatedLists\CNSWE\Workflow\XML\Done.xml";
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
        private void OpenFillers(object state)
        {
            iEvent = Utility.readXML(Utility.fillerspath);
            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
            _isFiller = true;
        }
        private void OpenLogos(object state)
        {
            iEvent = Utility.readXML(Utility.logospath);
            _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
            _isFiller = false;
        }
        private void OpenCommercials(object state)
        {

            DefaultVisibility();
            utility.ClearListbox();
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Open Commercials";
            opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
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
        private void OpenScheduleDialog(string listtype)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Open Schedule";
            switch (listtype)
            {
                case "TLC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
                    break;
                case "DC":
                    opf.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx";
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
                    _MW.cb_cnSwe.IsChecked = false;
                    _MW.cb_dc.IsChecked = false;
                    if (_isFiller)
                    {
                        iEvent = Utility.readXML(Utility.fillerspath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                    }
                    else
                    {
                        iEvent = Utility.readXML(Utility.logospath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                    }
                    break;
                case "DC":
                    Utility.fillerspath = @"C:\\AutomatedLists\DC\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\DC\Workflow\Logo\logo.xml";
                    _MW.cb_cnSwe.IsChecked = false;
                    _MW.cb_tlc.IsChecked = false;
                    if (_isFiller)
                    {
                        iEvent = Utility.readXML(Utility.fillerspath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                    }
                    else
                    {
                        iEvent = Utility.readXML(Utility.logospath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
                    }
                    break;
                case "CNSWE":
                    Utility.fillerspath = @"C:\\AutomatedLists\CNSWE\Workflow\Fillers\fillers.xml";
                    Utility.logospath = @"C:\\AutomatedLists\CNSWE\Workflow\Logo\logo.xml";
                    _MW.cb_dc.IsChecked = false;
                    _MW.cb_tlc.IsChecked = false;
                    if (_isFiller)
                    {
                        iEvent = Utility.readXML(Utility.fillerspath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlFillers;
                    }
                    else
                    {
                        iEvent = Utility.readXML(Utility.logospath);
                        _MW.dgv_openedFiles.ItemsSource = iEvent.XmlLogos;
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
                        utility.CopyScheduleExcel(_MW, Utility.TLCFilePath,Properties.Settings.Default.tlcSchedulePath);
                    }
                    break;
                case "DC":
                    utility.clearFolder(_MW, Utility.DCFilePath);
                    if (!String.IsNullOrEmpty(Utility.ScheduleFilePath))
                    {
                        utility.CopyScheduleExcel(_MW, Utility.DCFilePath, Properties.Settings.Default.dcSchedulePath);
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
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            Utility.IsListGenerated = true;
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
                        if (String.IsNullOrEmpty(Utility.initError))
                        {
                            utility.CopyXML();
                            ReadExcel exl = new ReadExcel();
                            exl.OpenDCCommercialExcelFile(_MW);
                            Utility.IsListGenerated = true;
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
            }
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
