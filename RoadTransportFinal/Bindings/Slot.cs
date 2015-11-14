using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTransportFinal.Bindings
{
    public class Slot : INotifyPropertyChanged
    {
        public Slot() { }
        public string Id { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public Slot(string id, string time,string status)
        {
            Id = id;
            Time = time;
            Status = status;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
