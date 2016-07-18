/*------------------------------------------------------------------------------
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
------------------------------------------------------------------------------*/

using System.Collections.ObjectModel;

namespace testApp

{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum StopMode
    {
        /// <remarks/>
        Loop,
        /// <remarks/>
        StopOnLastFrame,
        /// <remarks/>
        None,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class KeyFrame
    {
        private string timingField;
        private bool timeFromEndField;
        private int currentTrackField;
        private int otherTracksField;
        public KeyFrame()
        {
            this.timeFromEndField = false;
        }
        /// <remarks/>
        public string Timing
        {
            get
            {
                return this.timingField;
            }
            set
            {
                this.timingField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool TimeFromEnd
        {
            get
            {
                return this.timeFromEndField;
            }
            set
            {
                this.timeFromEndField = value;
            }
        }
        /// <remarks/>
        public int CurrentTrack
        {
            get
            {
                return this.currentTrackField;
            }
            set
            {
                this.currentTrackField = value;
            }
        }
        /// <remarks/>
        public int OtherTracks
        {
            get
            {
                return this.otherTracksField;
            }
            set
            {
                this.otherTracksField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class ArrayOfKeyFrames
    {
        private KeyFrame[] keyFrameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KeyFrame")]
        public KeyFrame[] KeyFrame
        {
            get
            {
                return this.keyFrameField;
            }
            set
            {
                this.keyFrameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class AdInsertion
    {
        private bool enabledField;
        private string idField;
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }
        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OverlayProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeDelayProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VTRProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AutoScheduleProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StaticProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LiveProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OapkeProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VideoProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramGroup))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramGroupFromFile))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class ProgramItem
    {
        private string titleField;
        private string startDateTimeField;
        private bool startDateTimeFieldSpecified;
        private string labelField;
        private string fontColorField;
        private string backColorField;
        private string uniqueIDGuidField;
        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        /// <remarks/>
        public string StartDateTime
        {
            get
            {
                return this.startDateTimeField;
            }
            set
            {
                this.startDateTimeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateTimeSpecified
        {
            get
            {
                return this.startDateTimeFieldSpecified;
            }
            set
            {
                this.startDateTimeFieldSpecified = value;
            }
        }
        /// <remarks/>
        public string Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
        /// <remarks/>
        public string FontColor
        {
            get
            {
                return this.fontColorField;
            }
            set
            {
                this.fontColorField = value;
            }
        }
        /// <remarks/>
        public string BackColor
        {
            get
            {
                return this.backColorField;
            }
            set
            {
                this.backColorField = value;
            }
        }
        /// <remarks/>
        public string UniqueIDGuid
        {
            get
            {
                return this.uniqueIDGuidField;
            }
            set
            {
                this.uniqueIDGuidField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramGroupFromFile))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class ProgramGroup : ProgramItem
    {
        private string predictedDurationField;
        private ObservableCollection<ProgramItem> itemsField;
        private bool extendToPredictedDurationField;
        private string notesField;
        private bool loopField;
        private ObservableCollection<ProgramItemSubstream> substreamsField;
        private ObservableCollection<ProgramItem> hotkeysField;
        private AdInsertion adInsertionField;
        private string groupGuidField;
        private string mergeIDField;
        public ProgramGroup()
        {
            this.extendToPredictedDurationField = false;
            this.loopField = false;
            this.groupGuidField = "{00000000-0000-0000-0000-000000000000}";
            this.Items = new ObservableCollection<ProgramItem>();
            this.substreamsField = new ObservableCollection<ProgramItemSubstream>();
            this.adInsertionField = new AdInsertion();
        }
        /// <remarks/>
        public string PredictedDuration
        {
            get
            {
                return this.predictedDurationField;
            }
            set
            {
                this.predictedDurationField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public ObservableCollection<ProgramItem> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ExtendToPredictedDuration
        {
            get
            {
                return this.extendToPredictedDurationField;
            }
            set
            {
                this.extendToPredictedDurationField = value;
            }
        }
        /// <remarks/>
        public string Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Loop
        {
            get
            {
                return this.loopField;
            }
            set
            {
                this.loopField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Substream", IsNullable = false)]
        public ObservableCollection<ProgramItemSubstream> Substreams
        {
            get
            {
                return this.substreamsField;
            }
            set
            {
                this.substreamsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public ObservableCollection<ProgramItem> Hotkeys
        {
            get
            {
                return this.hotkeysField;
            }
            set
            {
                this.hotkeysField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public AdInsertion AdInsertion
        {
            get
            {
                return this.adInsertionField;
            }
            set
            {
                this.adInsertionField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("{00000000-0000-0000-0000-000000000000}")]
        public string GroupGuid
        {
            get
            {
                return this.groupGuidField;
            }
            set
            {
                this.groupGuidField = value;
            }
        }
        /// <remarks/>
        public string MergeID
        {
            get
            {
                return this.mergeIDField;
            }
            set
            {
                this.mergeIDField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SubtitlesSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RouterSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SqueezeSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GPISubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WSSSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CaptureSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TriggerSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AudioSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AFDSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProfanityBlankingSubstream))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GraphicSubstream))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class ProgramItemSubstream
    {
        private bool defaultField;
        private bool appearInLogField;
        public ProgramItemSubstream()
        {
            this.defaultField = false;
            this.appearInLogField = false;
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Default
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AppearInLog
        {
            get
            {
                return this.appearInLogField;
            }
            set
            {
                this.appearInLogField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ProgramGroupFromFile : ProgramGroup
    {
        private string fileNameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OverlayProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeDelayProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VTRProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AutoScheduleProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StaticProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LiveProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OapkeProgramEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VideoProgramEvent))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ProgramEvent : ProgramItem
    {
        private Metadata metaDataField;
        private string notesField;
        private bool isCommercialField;
        private Transition videoTransitionField;
        private string scheduleIDField;
        private ObservableCollection<ProgramItemSubstream> substreamsField;
        private ProgramItem[] hotkeysField;
        private NamedTrigger namedTriggerField;
        private AspectRatio aspectRatioField;
        private ConversionType conversionTypeField;
        public ProgramEvent()
        {
            this.isCommercialField = false;
            this.aspectRatioField = AspectRatio.DefaultFrommetadata;
            this.conversionTypeField = ConversionType.DefaultFrommetadata;
            this.substreamsField = new ObservableCollection<ProgramItemSubstream>();
        }
        /// <remarks/>
        public Metadata MetaData
        {
            get
            {
                return this.metaDataField;
            }
            set
            {
                this.metaDataField = value;
            }
        }
        /// <remarks/>
        public string Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsCommercial
        {
            get
            {
                return this.isCommercialField;
            }
            set
            {
                this.isCommercialField = value;
            }
        }
        /// <remarks/>
        public Transition VideoTransition
        {
            get
            {
                return this.videoTransitionField;
            }
            set
            {
                this.videoTransitionField = value;
            }
        }
        /// <remarks/>
        public string ScheduleID
        {
            get
            {
                return this.scheduleIDField;
            }
            set
            {
                this.scheduleIDField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Substream", IsNullable = false)]
        public ObservableCollection<ProgramItemSubstream> Substreams
        {
            get
            {
                return this.substreamsField;
            }
            set
            {
                this.substreamsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public ProgramItem[] Hotkeys
        {
            get
            {
                return this.hotkeysField;
            }
            set
            {
                this.hotkeysField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public NamedTrigger NamedTrigger
        {
            get
            {
                return this.namedTriggerField;
            }
            set
            {
                this.namedTriggerField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(AspectRatio.DefaultFrommetadata)]
        public AspectRatio AspectRatio
        {
            get
            {
                return this.aspectRatioField;
            }
            set
            {
                this.aspectRatioField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(ConversionType.DefaultFrommetadata)]
        public ConversionType ConversionType
        {
            get
            {
                return this.conversionTypeField;
            }
            set
            {
                this.conversionTypeField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class Metadata
    {
        private MetadataPair[] metadataPairField;
        private ComingNextGroup[] includeInComingNextGroupsField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MetadataPair")]
        public MetadataPair[] MetadataPair
        {
            get
            {
                return this.metadataPairField;
            }
            set
            {
                this.metadataPairField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Group", IsNullable = false)]
        public ComingNextGroup[] IncludeInComingNextGroups
        {
            get
            {
                return this.includeInComingNextGroupsField;
            }
            set
            {
                this.includeInComingNextGroupsField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class MetadataPair
    {
        private string keyField;
        private string valueField;
        /// <remarks/>
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ComingNextGroup
    {
        private int numberField;
        /// <remarks/>
        public int Number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class Transition
    {
        private TransitionType typeField;
        private string durationField;
        private bool loopField;
        private int speedField;
        private bool leftToRightField;
        private bool topToBottomField;
        private TransitionKind kindField;
        private TransitionDirection directionField;
        private MatroxDSXData matroxDSXDataField;
        private GraphicsTransitionData graphicsTransitionDataField;
        private string inDurationField;
        private string outDurationField;
        public Transition()
        {
            this.typeField = TransitionType.ttCut;
            this.durationField = "00:00:00:00";
            this.loopField = false;
            this.speedField = 1;
            this.leftToRightField = false;
            this.topToBottomField = false;
            this.kindField = TransitionKind.tkWipe;
            this.directionField = TransitionDirection.tdLeft;
            this.inDurationField = "00:00:00:00";
            this.outDurationField = "00:00:00:00";
        }
        /// <remarks/>
        public TransitionType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Loop
        {
            get
            {
                return this.loopField;
            }
            set
            {
                this.loopField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int Speed
        {
            get
            {
                return this.speedField;
            }
            set
            {
                this.speedField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool LeftToRight
        {
            get
            {
                return this.leftToRightField;
            }
            set
            {
                this.leftToRightField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool TopToBottom
        {
            get
            {
                return this.topToBottomField;
            }
            set
            {
                this.topToBottomField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(TransitionKind.tkWipe)]
        public TransitionKind Kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(TransitionDirection.tdLeft)]
        public TransitionDirection Direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }
        /// <remarks/>
        public MatroxDSXData MatroxDSXData
        {
            get
            {
                return this.matroxDSXDataField;
            }
            set
            {
                this.matroxDSXDataField = value;
            }
        }
        /// <remarks/>
        public GraphicsTransitionData GraphicsTransitionData
        {
            get
            {
                return this.graphicsTransitionDataField;
            }
            set
            {
                this.graphicsTransitionDataField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string InDuration
        {
            get
            {
                return this.inDurationField;
            }
            set
            {
                this.inDurationField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string OutDuration
        {
            get
            {
                return this.outDurationField;
            }
            set
            {
                this.outDurationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum TransitionType
    {
        /// <remarks/>
        ttCut,
        /// <remarks/>
        ttDissolve,
        /// <remarks/>
        ttMatrox,
        /// <remarks/>
        ttGraphicsWipe,
        /// <remarks/>
        ttCrawl,
        /// <remarks/>
        ttRoll,
        /// <remarks/>
        ttDSX,
        /// <remarks/>
        ttWipe,
        /// <remarks/>
        ttSqueeze,
        /// <remarks/>
        ttVanish,
        /// <remarks/>
        ttHorizontalFlip,
        /// <remarks/>
        ttVerticalFlip,
        /// <remarks/>
        ttGraphics,
        /// <remarks/>
        ttCutFade,
        /// <remarks/>
        ttFadeCut,
        /// <remarks/>
        ttFade,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum TransitionKind
    {
        /// <remarks/>
        tkWipe,
        /// <remarks/>
        tkPush,
        /// <remarks/>
        tkPushOver,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum TransitionDirection
    {
        /// <remarks/>
        tdLeft,
        /// <remarks/>
        tdRight,
        /// <remarks/>
        tdUp,
        /// <remarks/>
        tdDown,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class MatroxDSXData
    {
        private MatroxDSXTransitionType nameField;
        private bool reversedField;
        private double borderWidthField;
        private bool borderWidthFieldSpecified;
        private double borderSoftnessField;
        private bool borderSoftnessFieldSpecified;
        private double borderSoftnessBalanceField;
        private bool borderSoftnessBalanceFieldSpecified;
        private bool borderSoftnessLinearField;
        private string borderColorField;
        public MatroxDSXData()
        {
            this.reversedField = false;
            this.borderSoftnessLinearField = false;
        }
        /// <remarks/>
        public MatroxDSXTransitionType Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Reversed
        {
            get
            {
                return this.reversedField;
            }
            set
            {
                this.reversedField = value;
            }
        }
        /// <remarks/>
        public double BorderWidth
        {
            get
            {
                return this.borderWidthField;
            }
            set
            {
                this.borderWidthField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BorderWidthSpecified
        {
            get
            {
                return this.borderWidthFieldSpecified;
            }
            set
            {
                this.borderWidthFieldSpecified = value;
            }
        }
        /// <remarks/>
        public double BorderSoftness
        {
            get
            {
                return this.borderSoftnessField;
            }
            set
            {
                this.borderSoftnessField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BorderSoftnessSpecified
        {
            get
            {
                return this.borderSoftnessFieldSpecified;
            }
            set
            {
                this.borderSoftnessFieldSpecified = value;
            }
        }
        /// <remarks/>
        public double BorderSoftnessBalance
        {
            get
            {
                return this.borderSoftnessBalanceField;
            }
            set
            {
                this.borderSoftnessBalanceField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BorderSoftnessBalanceSpecified
        {
            get
            {
                return this.borderSoftnessBalanceFieldSpecified;
            }
            set
            {
                this.borderSoftnessBalanceFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool BorderSoftnessLinear
        {
            get
            {
                return this.borderSoftnessLinearField;
            }
            set
            {
                this.borderSoftnessLinearField = value;
            }
        }
        /// <remarks/>
        public string BorderColor
        {
            get
            {
                return this.borderColorField;
            }
            set
            {
                this.borderColorField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum MatroxDSXTransitionType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 01")]
        SMPTESMPTE01,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 02")]
        SMPTESMPTE02,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 03")]
        SMPTESMPTE03,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 04")]
        SMPTESMPTE04,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 05")]
        SMPTESMPTE05,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 06")]
        SMPTESMPTE06,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 07")]
        SMPTESMPTE07,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 08")]
        SMPTESMPTE08,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 09")]
        SMPTESMPTE09,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 10")]
        SMPTESMPTE10,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 11")]
        SMPTESMPTE11,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 12")]
        SMPTESMPTE12,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 13")]
        SMPTESMPTE13,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 14")]
        SMPTESMPTE14,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 15")]
        SMPTESMPTE15,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 16")]
        SMPTESMPTE16,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 17")]
        SMPTESMPTE17,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 18")]
        SMPTESMPTE18,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 19")]
        SMPTESMPTE19,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 20")]
        SMPTESMPTE20,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 21")]
        SMPTESMPTE21,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 22")]
        SMPTESMPTE22,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 23")]
        SMPTESMPTE23,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 24")]
        SMPTESMPTE24,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 25")]
        SMPTESMPTE25,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 26")]
        SMPTESMPTE26,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 27")]
        SMPTESMPTE27,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 28")]
        SMPTESMPTE28,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 29")]
        SMPTESMPTE29,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 30")]
        SMPTESMPTE30,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SMPTE\\SMPTE 77")]
        SMPTESMPTE77,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Basket")]
        GradientsBasket,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Bend In Time")]
        GradientsBendInTime,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Cuts Linear")]
        GradientsCutsLinear,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Cuts Radial")]
        GradientsCutsRadial,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Diamond Bands 01")]
        GradientsDiamondBands01,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Diamond Bands 02")]
        GradientsDiamondBands02,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Diamond Bands 03")]
        GradientsDiamondBands03,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Fabric Of Time")]
        GradientsFabricOfTime,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Fossile")]
        GradientsFossile,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 01")]
        GradientsGradientPattern01,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 02")]
        GradientsGradientPattern02,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 03")]
        GradientsGradientPattern03,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 04")]
        GradientsGradientPattern04,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 05")]
        GradientsGradientPattern05,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Gradient Pattern 06")]
        GradientsGradientPattern06,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Horizontal Gradient Wave")]
        GradientsHorizontalGradientWave,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Horizontal Gradient")]
        GradientsHorizontalGradient,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Horizontal Vertical Gradient")]
        GradientsHorizontalVerticalGradient,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Sound Booth ")]
        GradientsSoundBooth,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Star Lines")]
        GradientsStarLines,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Vertical Gradient Wave")]
        GradientsVerticalGradientWave,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Vertical Gradient")]
        GradientsVerticalGradient,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Vertical Horizontal Gradient Wave")]
        GradientsVerticalHorizontalGradientWave,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gradients\\Vertical Horizontal Gradient")]
        GradientsVerticalHorizontalGradient,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Blocks")]
        ShapesBlocks,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Bubbles")]
        ShapesBubbles,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Butterflies Sharp")]
        ShapesButterfliesSharp,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Butterflies Soft")]
        ShapesButterfliesSoft,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Cell Radial")]
        ShapesCellRadial,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Curly Cues")]
        ShapesCurlyCues,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Dots Dots Dots")]
        ShapesDotsDotsDots,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 01 Noise")]
        ShapesGeometric01Noise,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 01")]
        ShapesGeometric01,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 02 Noise")]
        ShapesGeometric02Noise,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 02")]
        ShapesGeometric02,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 03 Noise")]
        ShapesGeometric03Noise,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 03")]
        ShapesGeometric03,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 04 Noise")]
        ShapesGeometric04Noise,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Geometric 04")]
        ShapesGeometric04,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Hearts")]
        ShapesHearts,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Ripple Alien")]
        ShapesRippleAlien,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Ripple Smooth")]
        ShapesRippleSmooth,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Ripple")]
        ShapesRipple,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Shapes\\Sponge")]
        ShapesSponge,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Abstract")]
        AbstractAbstract,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Birds Nest")]
        AbstractBirdsNest,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Clowns Amuk")]
        AbstractClownsAmuk,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Downfeathers 01")]
        AbstractDownfeathers01,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Downfeathers 02")]
        AbstractDownfeathers02,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Epi Cell")]
        AbstractEpiCell,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Floating Diamonds")]
        AbstractFloatingDiamonds,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Glasscubes")]
        AbstractGlasscubes,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Hypnotic Square Ripples")]
        AbstractHypnoticSquareRipples,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Lines Erode")]
        AbstractLinesErode,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Liquified Patches")]
        AbstractLiquifiedPatches,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Liquified Smooth")]
        AbstractLiquifiedSmooth,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Liquified")]
        AbstractLiquified,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Marble Tiles")]
        AbstractMarbleTiles,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Rain")]
        AbstractRain,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Wall")]
        AbstractWall,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Watermarks")]
        AbstractWatermarks,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Abstract\\Writing On The Wall")]
        AbstractWritingOnTheWall,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GraphicsTransitionData
    {
        private string offsetField;
        private string graphicsDurationField;
        private string filenameField;
        /// <remarks/>
        public string Offset
        {
            get
            {
                return this.offsetField;
            }
            set
            {
                this.offsetField = value;
            }
        }
        /// <remarks/>
        public string GraphicsDuration
        {
            get
            {
                return this.graphicsDurationField;
            }
            set
            {
                this.graphicsDurationField = value;
            }
        }
        /// <remarks/>
        public string Filename
        {
            get
            {
                return this.filenameField;
            }
            set
            {
                this.filenameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class NamedTrigger
    {
        private bool enabledField;
        private string nameField;
        private System.DateTime startDateTimeField;
        private bool startDateTimeFieldSpecified;
        private System.DateTime endDateTimeField;
        private bool endDateTimeFieldSpecified;
        public NamedTrigger()
        {
            this.enabledField = false;
            this.nameField = "";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        public System.DateTime StartDateTime
        {
            get
            {
                return this.startDateTimeField;
            }
            set
            {
                this.startDateTimeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateTimeSpecified
        {
            get
            {
                return this.startDateTimeFieldSpecified;
            }
            set
            {
                this.startDateTimeFieldSpecified = value;
            }
        }
        /// <remarks/>
        public System.DateTime EndDateTime
        {
            get
            {
                return this.endDateTimeField;
            }
            set
            {
                this.endDateTimeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateTimeSpecified
        {
            get
            {
                return this.endDateTimeFieldSpecified;
            }
            set
            {
                this.endDateTimeFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum AspectRatio
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4:3")]
        Item43,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16:9")]
        Item169,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Default/From metadata")]
        DefaultFrommetadata,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum ConversionType
    {
        /// <remarks/>
        Crop,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Add border")]
        Addborder,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Default/From metadata")]
        DefaultFrommetadata,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class VideoProgramEvent : ProgramEvent
    {
        private string trimInField;
        private string trimOutField;
        private System.Nullable<StopMode> stopModeField;
        private bool stopModeFieldSpecified;
        private int repeatCountField;
        private bool loopField;
        private bool loopFieldSpecified;
        private string predictedDurationField;
        private string fileNameField;
        public VideoProgramEvent()
        {
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
            this.repeatCountField = 1;
            this.predictedDurationField = "00:00:00:00";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public System.Nullable<StopMode> StopMode
        {
            get
            {
                return this.stopModeField;
            }
            set
            {
                this.stopModeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StopModeSpecified
        {
            get
            {
                return this.stopModeFieldSpecified;
            }
            set
            {
                this.stopModeFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int RepeatCount
        {
            get
            {
                return this.repeatCountField;
            }
            set
            {
                this.repeatCountField = value;
            }
        }
        /// <remarks/>
        public bool Loop
        {
            get
            {
                return this.loopField;
            }
            set
            {
                this.loopField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LoopSpecified
        {
            get
            {
                return this.loopFieldSpecified;
            }
            set
            {
                this.loopFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string PredictedDuration
        {
            get
            {
                return this.predictedDurationField;
            }
            set
            {
                this.predictedDurationField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class OapkeProgramEvent : ProgramEvent
    {
        private string fileNameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class LiveProgramEvent : ProgramEvent
    {
        private uint routerInputNumberField;
        private int routerPositionField;
        private System.Nullable<StopModeRestricted> stopModeField;
        private bool stopModeFieldSpecified;
        private string durationField;
        public LiveProgramEvent()
        {
            this.routerInputNumberField = ((uint)(1));
            this.routerPositionField = 1;
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "1")]
        public uint RouterInputNumber
        {
            get
            {
                return this.routerInputNumberField;
            }
            set
            {
                this.routerInputNumberField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int RouterPosition
        {
            get
            {
                return this.routerPositionField;
            }
            set
            {
                this.routerPositionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public System.Nullable<StopModeRestricted> StopMode
        {
            get
            {
                return this.stopModeField;
            }
            set
            {
                this.stopModeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StopModeSpecified
        {
            get
            {
                return this.stopModeFieldSpecified;
            }
            set
            {
                this.stopModeFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum StopModeRestricted
    {
        /// <remarks/>
        None,
        /// <remarks/>
        ExtendMode,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class StaticProgramEvent : ProgramEvent
    {
        private int repeatCountField;
        private System.Nullable<StopModeRestricted> stopModeField;
        private bool loopField;
        private string fileNameField;
        private string durationField;
        public StaticProgramEvent()
        {
            this.repeatCountField = 1;
            this.stopModeField = StopModeRestricted.None;
            this.loopField = false;
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int RepeatCount
        {
            get
            {
                return this.repeatCountField;
            }
            set
            {
                this.repeatCountField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        [System.ComponentModel.DefaultValueAttribute(StopModeRestricted.None)]
        public System.Nullable<StopModeRestricted> StopMode
        {
            get
            {
                return this.stopModeField;
            }
            set
            {
                this.stopModeField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Loop
        {
            get
            {
                return this.loopField;
            }
            set
            {
                this.loopField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class AutoScheduleProgramEvent : ProgramEvent
    {
        private string parameterField;
        private AutoScheduleProgramEventPlugIn plugInField;
        public AutoScheduleProgramEvent()
        {
            this.parameterField = "";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Parameter
        {
            get
            {
                return this.parameterField;
            }
            set
            {
                this.parameterField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AutoScheduleProgramEventPlugIn PlugIn
        {
            get
            {
                return this.plugInField;
            }
            set
            {
                this.plugInField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum AutoScheduleProgramEventPlugIn
    {
        /// <remarks/>
        Vote,
        /// <remarks/>
        InsertFileList,
        /// <remarks/>
        Clubland,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class VTRProgramEvent : ProgramEvent
    {
        private string trimInField;
        private string trimOutField;
        private int vTRNumberField;
        private int routerPositionField;
        private string tapeIDField;
        public VTRProgramEvent()
        {
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        public int VTRNumber
        {
            get
            {
                return this.vTRNumberField;
            }
            set
            {
                this.vTRNumberField = value;
            }
        }
        /// <remarks/>
        public int RouterPosition
        {
            get
            {
                return this.routerPositionField;
            }
            set
            {
                this.routerPositionField = value;
            }
        }
        /// <remarks/>
        public string TapeID
        {
            get
            {
                return this.tapeIDField;
            }
            set
            {
                this.tapeIDField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class TimeDelayProgramEvent : ProgramEvent
    {
        private int inputField;
        private System.DateTime timeField;
        private string durationField;
        public TimeDelayProgramEvent()
        {
            this.inputField = 1;
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int Input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class OverlayProgramEvent : ProgramEvent
    {
        private string durationField;
        public OverlayProgramEvent()
        {
            this.durationField = "00:00:00:00";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ArrayOfComingNextGroups
    {
        private ComingNextGroup[] groupField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Group")]
        public ComingNextGroup[] Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ArrayOfItems
    {
        private ProgramItem[] itemField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ProgramItem[] Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ArrayOfSubstreams
    {
        private ProgramItemSubstream[] substreamField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Substream")]
        public ProgramItemSubstream[] Substream
        {
            get
            {
                return this.substreamField;
            }
            set
            {
                this.substreamField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GraphicSubstream : ProgramItemSubstream
    {
        private string nameField;
        private GraphicPosition positionField;
        private GraphicSubstreamEvent[] eventField;
        private GraphicSubstreamGraphicStreamType graphicStreamTypeField;
        public GraphicSubstream()
        {
            this.nameField = "Default";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("Default")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        public GraphicPosition Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public GraphicSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public GraphicSubstreamGraphicStreamType GraphicStreamType
        {
            get
            {
                return this.graphicStreamTypeField;
            }
            set
            {
                this.graphicStreamTypeField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GraphicPosition
    {
        private int leftField;
        private int topField;
        private int layerField;
        private int heightField;
        private int widthField;
        public GraphicPosition()
        {
            this.leftField = 0;
            this.topField = 0;
            this.heightField = 576;
            this.widthField = 720;
        }
        /// <remarks/>
        public int Left
        {
            get
            {
                return this.leftField;
            }
            set
            {
                this.leftField = value;
            }
        }
        /// <remarks/>
        public int Top
        {
            get
            {
                return this.topField;
            }
            set
            {
                this.topField = value;
            }
        }
        /// <remarks/>
        public int Layer
        {
            get
            {
                return this.layerField;
            }
            set
            {
                this.layerField = value;
            }
        }
        /// <remarks/>
        public int Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// <remarks/>
        public int Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GraphicSubstreamEvent : SubstreamEvent
    {
        private Transitions transitionsField;
        private bool stopOnTheLastFrameField;
        private string trimInField;
        private string trimOutField;
        private string fileNameField;
        public GraphicSubstreamEvent()
        {
            this.stopOnTheLastFrameField = false;
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
        }
        /// <remarks/>
        public Transitions Transitions
        {
            get
            {
                return this.transitionsField;
            }
            set
            {
                this.transitionsField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool StopOnTheLastFrame
        {
            get
            {
                return this.stopOnTheLastFrameField;
            }
            set
            {
                this.stopOnTheLastFrameField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class Transitions
    {
        private Transition inTransitionField;
        private Transition clearTransitionField;
        private bool defineTransitionsFromVideoField;
        public Transitions()
        {
            this.defineTransitionsFromVideoField = false;
        }
        /// <remarks/>
        public Transition InTransition
        {
            get
            {
                return this.inTransitionField;
            }
            set
            {
                this.inTransitionField = value;
            }
        }
        /// <remarks/>
        public Transition ClearTransition
        {
            get
            {
                return this.clearTransitionField;
            }
            set
            {
                this.clearTransitionField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool DefineTransitionsFromVideo
        {
            get
            {
                return this.defineTransitionsFromVideoField;
            }
            set
            {
                this.defineTransitionsFromVideoField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SubtitlesSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RouterSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SqueezeSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GPISubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WSSSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CaptureSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TriggerSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AudioSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProfanityBlankingSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GraphicSubstreamEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AFDSubstreamEvent))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SubstreamEvent
    {
        private string startAtField;
        private bool startAtFromEndField;
        private string durationField;
        private string endAtField;
        private bool endAtFromEndField;
        private bool isCommercialField;
        private string eventIDField;
        private bool applyToAllEventsField;
        public SubstreamEvent()
        {
            this.startAtFromEndField = false;
            this.endAtFromEndField = true;
            this.isCommercialField = false;
            this.applyToAllEventsField = false;
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string StartAt
        {
            get
            {
                return this.startAtField;
            }
            set
            {
                this.startAtField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool StartAtFromEnd
        {
            get
            {
                return this.startAtFromEndField;
            }
            set
            {
                this.startAtFromEndField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string EndAt
        {
            get
            {
                return this.endAtField;
            }
            set
            {
                this.endAtField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool EndAtFromEnd
        {
            get
            {
                return this.endAtFromEndField;
            }
            set
            {
                this.endAtFromEndField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsCommercial
        {
            get
            {
                return this.isCommercialField;
            }
            set
            {
                this.isCommercialField = value;
            }
        }
        /// <remarks/>
        public string EventID
        {
            get
            {
                return this.eventIDField;
            }
            set
            {
                this.eventIDField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ApplyToAllEvents
        {
            get
            {
                return this.applyToAllEventsField;
            }
            set
            {
                this.applyToAllEventsField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum GraphicSubstreamGraphicStreamType
    {
        /// <remarks/>
        GraphicStream1,
        /// <remarks/>
        GraphicStream2,
        /// <remarks/>
        GraphicStream3,
        /// <remarks/>
        GraphicStream4,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ProfanityBlankingSubstream : ProgramItemSubstream
    {
        private ProfanityBlankingSubstreamEvent eventField;
        /// <remarks/>
        public ProfanityBlankingSubstreamEvent Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class ProfanityBlankingSubstreamEvent : SubstreamEvent
    {
        private ProfanityBlankingType blankElementsField;
        private string blankingFileField;
        private string trimInField;
        private string trimOutField;
        public ProfanityBlankingSubstreamEvent()
        {
            this.blankElementsField = ProfanityBlankingType.None;
            this.blankingFileField = "";
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
        }
        /// <remarks/>
        public ProfanityBlankingType BlankElements
        {
            get
            {
                return this.blankElementsField;
            }
            set
            {
                this.blankElementsField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string BlankingFile
        {
            get
            {
                return this.blankingFileField;
            }
            set
            {
                this.blankingFileField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum ProfanityBlankingType
    {
        /// <remarks/>
        None,
        /// <remarks/>
        Video,
        /// <remarks/>
        Audio,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Video and audio")]
        Videoandaudio,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class AFDSubstream : ProgramItemSubstream
    {
        private AFDSubstreamEvent[] eventField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public AFDSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class AFDSubstreamEvent : SubstreamEvent
    {
        private string trimInField;
        private string trimOutField;
        private string aFDStringField;
        public AFDSubstreamEvent()
        {
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AFDString
        {
            get
            {
                return this.aFDStringField;
            }
            set
            {
                this.aFDStringField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class AudioSubstream : ProgramItemSubstream
    {
        private AudioSubstreamName nameField;
        private ObservableCollection<AudioSubstreamEvent> eventField;
        private AudioSubstreamAudioChannel audioChannelField;
        public AudioSubstream()
        {
            this.nameField = AudioSubstreamName.Track1;
            this.eventField = new ObservableCollection<AudioSubstreamEvent>();

        }
        /// <remarks/>
        public AudioSubstreamName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public ObservableCollection<AudioSubstreamEvent> Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AudioSubstreamAudioChannel AudioChannel
        {
            get
            {
                return this.audioChannelField;
            }
            set
            {
                this.audioChannelField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum AudioSubstreamName
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Track #1")]
        Track1,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Track #2")]
        Track2,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Track #3")]
        Track3,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Track #4")]
        Track4,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class AudioSubstreamEvent : SubstreamEvent
    {
        private Transitions transitionsField;
        private bool liveField;
        private string trimInField;
        private string trimOutField;
        private KeyFrame[] keyFramesField;
        private uint routerInputNumberField;
        private uint streamIndexField;
        private string fileNameField;
        public AudioSubstreamEvent()
        {
            this.liveField = false;
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
            this.routerInputNumberField = ((uint)(0));
            this.streamIndexField = ((uint)(0));
        }
        /// <remarks/>
        public Transitions Transitions
        {
            get
            {
                return this.transitionsField;
            }
            set
            {
                this.transitionsField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Live
        {
            get
            {
                return this.liveField;
            }
            set
            {
                this.liveField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public KeyFrame[] KeyFrames
        {
            get
            {
                return this.keyFramesField;
            }
            set
            {
                this.keyFramesField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
        public uint RouterInputNumber
        {
            get
            {
                return this.routerInputNumberField;
            }
            set
            {
                this.routerInputNumberField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
        public uint StreamIndex
        {
            get
            {
                return this.streamIndexField;
            }
            set
            {
                this.streamIndexField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum AudioSubstreamAudioChannel
    {
        /// <remarks/>
        RecordableAudioChannel1,
        /// <remarks/>
        RecordableAudioChannel2,
        /// <remarks/>
        RecordableAudioChannel3,
        /// <remarks/>
        RecordableAudioChannel4,
        /// <remarks/>
        RecordableAudioChannel5,
        /// <remarks/>
        RecordableAudioChannel6,
        /// <remarks/>
        RecordableAudioChannel7,
        /// <remarks/>
        RecordableAudioChannel8,
        /// <remarks/>
        NonRecordableAudioChannel1,
        /// <remarks/>
        NonRecordableAudioChannel2,
        /// <remarks/>
        NonRecordableAudioChannel3,
        /// <remarks/>
        NonRecordableAudioChannel4,
        /// <remarks/>
        NonRecordableAudioChannel5,
        /// <remarks/>
        NonRecordableAudioChannel6,
        /// <remarks/>
        NonRecordableAudioChannel7,
        /// <remarks/>
        NonRecordableAudioChannel8,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class TriggerSubstream : ProgramItemSubstream
    {
        private TriggerSubstreamEvent[] eventField;
        private int streamIndexField;
        public TriggerSubstream()
        {
            this.streamIndexField = 0;
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public TriggerSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        public int StreamIndex
        {
            get
            {
                return this.streamIndexField;
            }
            set
            {
                this.streamIndexField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class TriggerSubstreamEvent : SubstreamEvent
    {
        private TriggerSubstreamEventTriggerMessage triggerMessageField;
        /// <remarks/>
        public TriggerSubstreamEventTriggerMessage TriggerMessage
        {
            get
            {
                return this.triggerMessageField;
            }
            set
            {
                this.triggerMessageField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public partial class TriggerSubstreamEventTriggerMessage
    {
        private string startMessageField;
        private string endMessageField;
        /// <remarks/>
        public string StartMessage
        {
            get
            {
                return this.startMessageField;
            }
            set
            {
                this.startMessageField = value;
            }
        }
        /// <remarks/>
        public string EndMessage
        {
            get
            {
                return this.endMessageField;
            }
            set
            {
                this.endMessageField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class CaptureSubstream : ProgramItemSubstream
    {
        private CaptureSubstreamEvent[] eventField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public CaptureSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class CaptureSubstreamEvent : SubstreamEvent
    {
        private string fileNameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSSubstream : ProgramItemSubstream
    {
        private ObservableCollection<WSSSubstreamEvent> eventField;

        public WSSSubstream()
        {
            this.eventField = new ObservableCollection<WSSSubstreamEvent>();

        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public ObservableCollection<WSSSubstreamEvent> Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSSubstreamEvent : SubstreamEvent
    {
        private WSSEntry insertField;
        private WSSEntry modifyField;
        private WSSSubstreamEventOperation operationField;
       
        /// <remarks/>
        public WSSEntry Insert
        {
            get
            {
                return this.insertField;
            }
            set
            {
                this.insertField = value;
            }
        }
        /// <remarks/>
        public WSSEntry Modify
        {
            get
            {
                return this.modifyField;
            }
            set
            {
                this.modifyField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public WSSSubstreamEventOperation Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSEntry
    {
        private WSSOthers othersField;
        private WSSEnhancedServices enhancedServicesField;
        private WSSSubtitles subtitlesField;
        private WSSAspectRatio aspectRatioField;
        /// <remarks/>
        public WSSOthers Others
        {
            get
            {
                return this.othersField;
            }
            set
            {
                this.othersField = value;
            }
        }
        /// <remarks/>
        public WSSEnhancedServices EnhancedServices
        {
            get
            {
                return this.enhancedServicesField;
            }
            set
            {
                this.enhancedServicesField = value;
            }
        }
        /// <remarks/>
        public WSSSubtitles Subtitles
        {
            get
            {
                return this.subtitlesField;
            }
            set
            {
                this.subtitlesField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public WSSAspectRatio AspectRatio
        {
            get
            {
                return this.aspectRatioField;
            }
            set
            {
                this.aspectRatioField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSOthers
    {
        private System.Nullable<bool> surroundSoundModeField;
        private bool surroundSoundModeFieldSpecified;
        private System.Nullable<bool> copyRightAssertedField;
        private bool copyRightAssertedFieldSpecified;
        private System.Nullable<bool> copyingRestrictedField;
        private bool copyingRestrictedFieldSpecified;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> SurroundSoundMode
        {
            get
            {
                return this.surroundSoundModeField;
            }
            set
            {
                this.surroundSoundModeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SurroundSoundModeSpecified
        {
            get
            {
                return this.surroundSoundModeFieldSpecified;
            }
            set
            {
                this.surroundSoundModeFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> CopyRightAsserted
        {
            get
            {
                return this.copyRightAssertedField;
            }
            set
            {
                this.copyRightAssertedField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CopyRightAssertedSpecified
        {
            get
            {
                return this.copyRightAssertedFieldSpecified;
            }
            set
            {
                this.copyRightAssertedFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> CopyingRestricted
        {
            get
            {
                return this.copyingRestrictedField;
            }
            set
            {
                this.copyingRestrictedField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CopyingRestrictedSpecified
        {
            get
            {
                return this.copyingRestrictedFieldSpecified;
            }
            set
            {
                this.copyingRestrictedFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSEnhancedServices
    {
        private System.Nullable<bool> filmModeField;
        private bool filmModeFieldSpecified;
        private System.Nullable<bool> motionAdaptiveColourPlusField;
        private bool motionAdaptiveColourPlusFieldSpecified;
        private System.Nullable<bool> modulatedHelperField;
        private bool modulatedHelperFieldSpecified;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> FilmMode
        {
            get
            {
                return this.filmModeField;
            }
            set
            {
                this.filmModeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FilmModeSpecified
        {
            get
            {
                return this.filmModeFieldSpecified;
            }
            set
            {
                this.filmModeFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> MotionAdaptiveColourPlus
        {
            get
            {
                return this.motionAdaptiveColourPlusField;
            }
            set
            {
                this.motionAdaptiveColourPlusField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MotionAdaptiveColourPlusSpecified
        {
            get
            {
                return this.motionAdaptiveColourPlusFieldSpecified;
            }
            set
            {
                this.motionAdaptiveColourPlusFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> ModulatedHelper
        {
            get
            {
                return this.modulatedHelperField;
            }
            set
            {
                this.modulatedHelperField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ModulatedHelperSpecified
        {
            get
            {
                return this.modulatedHelperFieldSpecified;
            }
            set
            {
                this.modulatedHelperFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class WSSSubtitles
    {
        private System.Nullable<bool> subtitleswithinTeletextField;
        private bool subtitleswithinTeletextFieldSpecified;
        private WSSSubtitlesType typeField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> SubtitleswithinTeletext
        {
            get
            {
                return this.subtitleswithinTeletextField;
            }
            set
            {
                this.subtitleswithinTeletextField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubtitleswithinTeletextSpecified
        {
            get
            {
                return this.subtitleswithinTeletextFieldSpecified;
            }
            set
            {
                this.subtitleswithinTeletextFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public WSSSubtitlesType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum WSSSubtitlesType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("No Open Subtitles")]
        NoOpenSubtitles,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Subtitles in Active Image Area")]
        SubtitlesinActiveImageArea,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Subtitles out of Active Image Area")]
        SubtitlesoutofActiveImageArea,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("No Change")]
        NoChange,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum WSSAspectRatio
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Full Format 4:3")]
        FullFormat43,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Box 14:9 Centre")]
        Box149Centre,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Box 14:9 Top")]
        Box149Top,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Box 16:9 Centre")]
        Box169Centre,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Box 16:9 Top")]
        Box169Top,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Box > 16:9 Centre")]
        Box169Centre1,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Full Format 4:3 (Shoot and protect 14:9 Centre)")]
        FullFormat43Shootandprotect149Centre,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Full Format 16:9 (Anamorphic)")]
        FullFormat169Anamorphic,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("No Change")]
        NoChange,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("From playlist")]
        Fromplaylist,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum WSSSubstreamEventOperation
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("No change")]
        Nochange,
        /// <remarks/>
        Blank,
        /// <remarks/>
        Insert,
        /// <remarks/>
        Modify,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GPISubstream : ProgramItemSubstream
    {
        private GPISubstreamName nameField;
        private GPISubstreamEvent[] eventField;
        private int gPIDeviceField;
        public GPISubstream()
        {
            this.nameField = GPISubstreamName.GPI0;
        }
        /// <remarks/>
        public GPISubstreamName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public GPISubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        public int GPIDevice
        {
            get
            {
                return this.gPIDeviceField;
            }
            set
            {
                this.gPIDeviceField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum GPISubstreamName
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #0")]
        GPI0,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #1")]
        GPI1,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #2")]
        GPI2,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #3")]
        GPI3,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #4")]
        GPI4,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #5")]
        GPI5,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #6")]
        GPI6,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #7")]
        GPI7,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #8")]
        GPI8,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #9")]
        GPI9,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #10")]
        GPI10,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #11")]
        GPI11,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #12")]
        GPI12,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #13")]
        GPI13,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #14")]
        GPI14,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #15")]
        GPI15,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #16")]
        GPI16,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #17")]
        GPI17,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #18")]
        GPI18,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #19")]
        GPI19,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #20")]
        GPI20,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #21")]
        GPI21,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #22")]
        GPI22,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #23")]
        GPI23,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #24")]
        GPI24,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #25")]
        GPI25,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #26")]
        GPI26,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #27")]
        GPI27,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #28")]
        GPI28,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #29")]
        GPI29,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #30")]
        GPI30,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #31")]
        GPI31,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GPI #32")]
        GPI32,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class GPISubstreamEvent : SubstreamEvent
    {
        private GPISubstreamEventGPIState gPIStateField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public GPISubstreamEventGPIState GPIState
        {
            get
            {
                return this.gPIStateField;
            }
            set
            {
                this.gPIStateField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum GPISubstreamEventGPIState
    {
        /// <remarks/>
        GPIUp,
        /// <remarks/>
        GPIDown,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SqueezeSubstream : ProgramItemSubstream
    {
        private SqueezeSubstreamEvent eventField;
        private SqueezeSubstreamPosition positionField;
        private SqueezeSubstreamSqueezeStreamType squeezeStreamTypeField;
        /// <remarks/>
        public SqueezeSubstreamEvent Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        public SqueezeSubstreamPosition Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SqueezeSubstreamSqueezeStreamType SqueezeStreamType
        {
            get
            {
                return this.squeezeStreamTypeField;
            }
            set
            {
                this.squeezeStreamTypeField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SqueezeSubstreamEvent : SubstreamEvent
    {
        private string trimInField;
        private string trimOutField;
        private SqueezeTransition inTransitionField;
        private SqueezeTransition clearTransitionField;
        private bool liveField;
        private int routerPositionField;
        private bool eventToWindowField;
        private bool eventToWindowFieldSpecified;
        private string fileNameField;
        public SqueezeSubstreamEvent()
        {
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
            this.liveField = false;
            this.routerPositionField = 1;
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
        /// <remarks/>
        public SqueezeTransition InTransition
        {
            get
            {
                return this.inTransitionField;
            }
            set
            {
                this.inTransitionField = value;
            }
        }
        /// <remarks/>
        public SqueezeTransition ClearTransition
        {
            get
            {
                return this.clearTransitionField;
            }
            set
            {
                this.clearTransitionField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Live
        {
            get
            {
                return this.liveField;
            }
            set
            {
                this.liveField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(1)]
        public int RouterPosition
        {
            get
            {
                return this.routerPositionField;
            }
            set
            {
                this.routerPositionField = value;
            }
        }
        /// <remarks/>
        public bool EventToWindow
        {
            get
            {
                return this.eventToWindowField;
            }
            set
            {
                this.eventToWindowField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventToWindowSpecified
        {
            get
            {
                return this.eventToWindowFieldSpecified;
            }
            set
            {
                this.eventToWindowFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SqueezeTransition
    {
        private SqueezeSubstreamPosition startPositionField;
        private SqueezeSubstreamPosition endPositionField;
        private string transitionDurationField;
        private int startAlphaField;
        private int endAlphaField;
        public SqueezeTransition()
        {
            this.startAlphaField = 255;
            this.endAlphaField = 255;
        }
        /// <remarks/>
        public SqueezeSubstreamPosition StartPosition
        {
            get
            {
                return this.startPositionField;
            }
            set
            {
                this.startPositionField = value;
            }
        }
        /// <remarks/>
        public SqueezeSubstreamPosition EndPosition
        {
            get
            {
                return this.endPositionField;
            }
            set
            {
                this.endPositionField = value;
            }
        }
        /// <remarks/>
        public string TransitionDuration
        {
            get
            {
                return this.transitionDurationField;
            }
            set
            {
                this.transitionDurationField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(255)]
        public int StartAlpha
        {
            get
            {
                return this.startAlphaField;
            }
            set
            {
                this.startAlphaField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(255)]
        public int EndAlpha
        {
            get
            {
                return this.endAlphaField;
            }
            set
            {
                this.endAlphaField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SqueezeSubstreamPosition
    {
        private int leftField;
        private int topField;
        private int heightField;
        private int widthField;
        public SqueezeSubstreamPosition()
        {
            this.leftField = 0;
            this.topField = 0;
            this.heightField = 576;
            this.widthField = 720;
        }
        /// <remarks/>
        public int Left
        {
            get
            {
                return this.leftField;
            }
            set
            {
                this.leftField = value;
            }
        }
        /// <remarks/>
        public int Top
        {
            get
            {
                return this.topField;
            }
            set
            {
                this.topField = value;
            }
        }
        /// <remarks/>
        public int Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        /// <remarks/>
        public int Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    public enum SqueezeSubstreamSqueezeStreamType
    {
        /// <remarks/>
        SqueezeStream1,
        /// <remarks/>
        SqueezeStream2,
        /// <remarks/>
        SqueezeStream3,
        /// <remarks/>
        SqueezeStream4,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class RouterSubstream : ProgramItemSubstream
    {
        private RouterSubstreamEvent[] eventField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public RouterSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class RouterSubstreamEvent : SubstreamEvent
    {
        private string commandField;
        /// <remarks/>
        public string Command
        {
            get
            {
                return this.commandField;
            }
            set
            {
                this.commandField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public enum FrameFormat
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4:3")]
        Item43,
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16:9")]
        Item169,
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SubtitlesSubstream : ProgramItemSubstream
    {
        private SubtitlesSubstreamEvent[] eventField;
        private int streamIndexField;
        private bool streamIndexFieldSpecified;
        private int substreamIndexField;
        public SubtitlesSubstream()
        {
            this.substreamIndexField = 0;
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event")]
        public SubtitlesSubstreamEvent[] Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
        /// <remarks/>
        public int StreamIndex
        {
            get
            {
                return this.streamIndexField;
            }
            set
            {
                this.streamIndexField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StreamIndexSpecified
        {
            get
            {
                return this.streamIndexFieldSpecified;
            }
            set
            {
                this.streamIndexFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int SubstreamIndex
        {
            get
            {
                return this.substreamIndexField;
            }
            set
            {
                this.substreamIndexField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = true)]
    public partial class SubtitlesSubstreamEvent : SubstreamEvent
    {
        private string fileNameField;
        private string trimInField;
        private string trimOutField;
        public SubtitlesSubstreamEvent()
        {
            this.trimInField = "00:00:00:00";
            this.trimOutField = "00:00:00:00";
        }
        /// <remarks/>
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimIn
        {
            get
            {
                return this.trimInField;
            }
            set
            {
                this.trimInField = value;
            }
        }
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("00:00:00:00")]
        public string TrimOut
        {
            get
            {
                return this.trimOutField;
            }
            set
            {
                this.trimOutField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.on-air-systems.com/playKast")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.on-air-systems.com/playKast", IsNullable = false)]
    public partial class Schedule
    {
        private ProgramGroup groupField;
        private bool doNotCreateTopLevelGroupField;
        private bool doNotCreateTopLevelGroupFieldSpecified;
        private string scheduleIDField;
        /// <remarks/>
        public ProgramGroup Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }
        /// <remarks/>
        public bool DoNotCreateTopLevelGroup
        {
            get
            {
                return this.doNotCreateTopLevelGroupField;
            }
            set
            {
                this.doNotCreateTopLevelGroupField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DoNotCreateTopLevelGroupSpecified
        {
            get
            {
                return this.doNotCreateTopLevelGroupFieldSpecified;
            }
            set
            {
                this.doNotCreateTopLevelGroupFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ScheduleID
        {
            get
            {
                return this.scheduleIDField;
            }
            set
            {
                this.scheduleIDField = value;
            }
        }
    }
}
