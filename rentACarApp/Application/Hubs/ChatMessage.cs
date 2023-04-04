using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hubs
{
    public class ChatMessage
    {
        public string SenderId { get; set; }
        public string SenderFullName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
