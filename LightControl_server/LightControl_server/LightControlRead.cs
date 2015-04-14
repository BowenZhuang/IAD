using System;
using System.Collections.Generic;
using System.Text;

namespace LightControl_server
{
    [Serializable()]
    class LightControlRead
    {
        public DateTime dateTime;
        public int sensorRead;
        public int ledRead;

        public LightControlRead(DateTime dateTime, int sensorRead, int ledRead)
        {
            // TODO: Complete member initialization
            this.dateTime = dateTime;
            this.sensorRead = sensorRead;
            this.ledRead = ledRead;
        }
    }
}
