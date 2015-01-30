using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class Company {
        public int CVR { get; set; }
        public string Name { get; set; }
        public int OfferNumber { get; set; }
        public int FKType { get; set; }
        public int FKPermit { get; set; }
        public int FKTrafficCompany { get; set; }

        public Company(int cvr, string name, int offernumber, int fktype, int fkpermit, int fktrafficcompany) {
            this.CVR = cvr;
            this.Name = name;
            this.OfferNumber = offernumber;
            this.FKType = fktype;
            this.FKPermit = fkpermit;
            this.FKTrafficCompany = fktrafficcompany;
        }
        public Company() { }
    }
}
