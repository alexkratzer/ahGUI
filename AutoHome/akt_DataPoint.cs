using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    class akt_DataPoint
    {
        public aktor_type aktor_type = aktor_type.undef;
        public int datapointLength = 0;
        public Int16[] rawValue = new Int16[] { };
        public int aktuator_index = 0;

        public akt_DataPoint(aktor_type _aktor_type, int _datapointLength, int _aktuator_index, Int16[] _rawValue) {
            aktor_type = _aktor_type;
            datapointLength = _datapointLength;
            aktuator_index = _aktuator_index;
            rawValue = _rawValue;
        }
    }
}
