using System;
using System.Collections.Generic;

namespace MiningMonitor
{
    public class RootObject
    {
        public string status { get; set; }
        public Data data { get; set; }
        public string address { get; set; }
        public double hashes { get; set; }
        public long valid_shares { get; set; }
        public int stale_shares { get; set; }
        public int invalid_shares { get; set; }
        public int blocks_found { get; set; }
        public string balance { get; set; }
        public string paid { get; set; }
        public int last_share_time { get; set; }
        public List<object> intervals { get; set; }
    }
}
