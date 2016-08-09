using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testApp.Models
{
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "")]
    public partial class AppAudios
    {
        private ObservableCollection<RusAudios> rusAudios;
        private Utility utility = new Utility();
        public AppAudios()
        {
            this.rusAudios = new ObservableCollection<RusAudios>();
        }
        [XmlArrayItem("AppAudios")]
        public ObservableCollection<RusAudios> russianAudios
        {
            get
            {
                return this.rusAudios;
            }
            set
            {
                this.rusAudios = value;
            }
        }      
    }
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class RusAudios : INotifyPropertyChanged
    {
        private string fileName;
        public event PropertyChangedEventHandler PropertyChanged;
        private Utility utility = new Utility();

        [XmlAttribute()]
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    utility.NotifyPropertyChanged("FileName", PropertyChanged);
                }

            }
        }
    }
    public class RussianAudios
    {
        string fileName;
        public RussianAudios(string _fileName)
        {
            fileName = _fileName;
        }
        public string getFileName()
        {
            return fileName;
        }
    }
}
