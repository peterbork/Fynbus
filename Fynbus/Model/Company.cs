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
        public string FKType { get; set; }
        public string FKPermit { get; set; }
        public string FKTrafficCompany { get; set; }

        public Company(int cvr, string name, int offernumber, string fktype, string fkpermit, string fktrafficcompany) {
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
