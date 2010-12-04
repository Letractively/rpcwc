using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpcwc.vo.Directory
{
    public class GuestRegistration
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public bool visited { get; set; }
        public DateTime visitDate { get; set; }
        public bool college { get; set; }
        public String howhear { get; set; }
        public bool contactme { get; set; }
        public bool faith { get; set; }
        public bool churchhome { get; set; }
        public bool worship { get; set; }
        public bool teaching { get; set; }
        public bool youth { get; set; }
        public bool service { get; set; }
        public bool love { get; set; }
        public bool evangelism { get; set; }
        public String othertext { get; set; }
        public String commentsprayer { get; set; }

        public bool newtoarea { get; set; }

        public DateTime createDate { get; set; }

        public string createUser { get; set; }

        public DateTime lastUpdateDate { get; set; }

        public string lastUpdateUser { get; set; }
    }
}