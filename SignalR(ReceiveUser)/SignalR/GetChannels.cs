using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR
{
    internal class GetChannels
    {
        public int? user_id { get; set; }
        public int? admin_id { get; set; }
        public string? channels { get; set; }  // Puede ser de otro tipo si no es List<string>, ajústalo según sea necesario
        public int? unread_channels { get; set; }
        public int? unread_messages { get; set; }
    }
}
