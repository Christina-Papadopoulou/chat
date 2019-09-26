using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityChat.Models
{
    public class MessageModel
    {
        public MessageModel()
        {
        }
        public string messageText { get; set; }
        public String dateTime { get; set; }
        public string username { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}