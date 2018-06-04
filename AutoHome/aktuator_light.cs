using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    class aktuator_light
    {
        public int interface_nr;
        bool button_state; //hardware switch signal of button
        int currentLux; //lux TODO: evtl redundant zu sensor values....
        public bool switch_signal; //current state of output signal to light (on/off)
        public bool enable_autoOffTime; //enable timer to automatic switch off light 
        public bool enable_autoOffLux;
        public TimeSpan autoOffTime;
        public int autoOffAtLux;
        TimeSpan TautooffluxET;
        public TimeSpan remaining_light_on_time;



        public aktuator_light(Int16[] rawData) {
            interface_nr = rawData[0];
            button_state = Convert.ToBoolean(rawData[1]);
            currentLux = rawData[2];
            switch_signal = Convert.ToBoolean(rawData[3]);
            enable_autoOffTime = Convert.ToBoolean(rawData[4]);
            enable_autoOffLux = Convert.ToBoolean(rawData[5]);
            autoOffTime = new TimeSpan(rawData[6]);
            autoOffAtLux = rawData[7];
            TautooffluxET = new TimeSpan(rawData[8]);
            remaining_light_on_time = new TimeSpan(rawData[9]);
        }
    }
}
