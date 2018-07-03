using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Utilidades
{
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public string id_token { get; set; }
        public string not_before_policy { get; set; }
        public string session_state { get; set; }
    }
}
