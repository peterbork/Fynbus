using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class TrafficCompany {
        public int ID { get; set; }
        public string Name { get; set; }
         public TrafficCompany(int id, string name) {
            this.ID = id;
            this.Name = name;
        }
         public TrafficCompany() { }
    }
}
