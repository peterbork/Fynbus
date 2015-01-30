using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class CompanyType {
        public int ID { get; set; }
        public string Name { get; set; }
        CompanyType(int id, string name) {
            this.ID = id;
            this.Name = name;
        }
    }
}
