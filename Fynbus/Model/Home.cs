using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class Home {
        public int ID { get; set; }
        public string StreetAddress { get; set; }
        public int Postcode { get; set; }
        public string Region { get; set; }
        public Home(int id, string streetaddress, int postcode, string region) {
            this.ID = id;
            this.StreetAddress = streetaddress;
            this.Postcode = postcode;
            this.Region = region;
        }
        public Home() { }
    }
}
