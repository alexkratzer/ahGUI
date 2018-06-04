using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    class aktuator_jalousie
    {
        public int interface_nr;
        public int current_position;
        public int current_angle;
        public int new_position;
        public int new_angle;
        public bool driving_up;
        public bool driving_down;
        public int wind_speed_threshold;
        
        public aktuator_jalousie(Int16[] rawData) {
            interface_nr = rawData[0];
            current_position = rawData[1];
            current_angle = rawData[2];
            new_position = rawData[3];
            new_angle = rawData[4];
            driving_up = Convert.ToBoolean(rawData[5]);
            driving_down = Convert.ToBoolean(rawData[6]);
            wind_speed_threshold = rawData[7];
        }
    }
}
