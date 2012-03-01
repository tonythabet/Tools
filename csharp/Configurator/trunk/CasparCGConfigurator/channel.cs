﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CasparCGConfigurator
{
    public class Channel : INotifyPropertyChanged
    {
        public Channel()
        {            
        }

        private string videoMode = "PAL";
        [XmlElement(ElementName = "video-mode")]
        public string VideoMode
        {
            get { return this.videoMode; }
            set { this.videoMode = value; NotifyChanged("videomode"); }
        }

        private BindingList<AbstractConsumer> consumers = new BindingList<AbstractConsumer>();
        [XmlArray("consumers")]
        [XmlArrayItem("decklink", Type = typeof(DecklinkConsumer))]
        [XmlArrayItem("screen", Type = typeof(ScreenConsumer))]
        [XmlArrayItem("system-audio", Type = typeof(SystemAudioConsumer))]
        [XmlArrayItem("bluefish", Type = typeof(BluefishConsumer))]
        public BindingList<AbstractConsumer> Consumers
        {
            get { return this.consumers; }
            set { this.consumers = value; NotifyChanged("consumers");}
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        private void NotifyChanged(String info)
        {        
            PropertyChanged(this, new PropertyChangedEventArgs(info));            
        }
    }
}
