using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo.Api.ViewModels
{
    public class MessageModel
    {
        public int Error { get; set; }
        public Object Data { get; set; }
        public string Msg { get; set; }
    }
}
