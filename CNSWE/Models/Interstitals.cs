using CNSWE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CNSWE.Models
{
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "")]
    public partial class InterstitalEvent
    {
        private ObservableCollection<XMLLogos> xmllogos;
        private ObservableCollection<XMLFillers> xmlfillers;
        private Utility utility = new Utility();
        public InterstitalEvent()
        {
            this.xmllogos = new ObservableCollection<XMLLogos>();
            this.xmlfillers = new ObservableCollection<XMLFillers>();
        }
        [XmlArrayItem("Logos")]
        public ObservableCollection<XMLLogos> XmlLogos
        {
            get
            {
                return this.xmllogos;
            }
            set
            {
                this.xmllogos = value;
            }
        }
        [XmlArrayItem("Fillers")]
        public ObservableCollection<XMLFillers> XmlFillers
        {
            get
            {
                return this.xmlfillers;
            }
            set
            {
                this.xmlfillers = value;
            }
        }
    }
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class XMLLogos : INotifyPropertyChanged
    {
        private int duration;
        private string fileName;
        public event PropertyChangedEventHandler PropertyChanged;
        private Utility utility = new Utility();
        [XmlAttribute()]
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (this.duration != value)
                {
                    this.duration = value;
                    utility.NotifyPropertyChanged("Duration", PropertyChanged);
                }

            }
        }
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
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class XMLFillers : INotifyPropertyChanged
    {
        private int duration;
        private string fileName;
        public event PropertyChangedEventHandler PropertyChanged;
        private Utility utility = new Utility();
        [XmlAttribute()]
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (this.duration != value)
                {
                    this.duration = value;
                    utility.NotifyPropertyChanged("Duration", PropertyChanged);
                }

            }
        }
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
    public class Logos
    {
        string fileName;
        int duration;
        public Logos(string _fileName, int _duration)
        {
            fileName = _fileName;
            duration = _duration;
        }
        public int getDuration()
        {
            return duration;
        }
        public string getFileName()
        {
            return fileName;
        }
    }
    public class Fillers
    {
        string fileName;
        int duration;
        public Fillers(string _fileName, int _duration)
        {
            fileName = _fileName;
            duration = _duration;
        }
        public int getDuration()
        {
            return duration;
        }
        public string getFileName()
        {
            return fileName;
        }
    }

}
