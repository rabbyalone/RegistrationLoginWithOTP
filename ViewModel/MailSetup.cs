using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithOTP.ViewModel
{
    public class MailSetup
    {
        public int Port { get; set; }
        public string FromMail { get; set; }
        public string Server { get; set; }
        public string FromMailPassword { get; set; }
        public bool EnableSSL { get; set; }

    }
}
