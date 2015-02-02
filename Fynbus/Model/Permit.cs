using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class Permit {
        public string Number { get; set; }
        public string PermitType { get; set; }
        public DateTime ValidUntil { get; set; }
        public Permit(string number, string permitType, DateTime validuntil) {
            this.Number = number;
            this.PermitType = permitType;
            this.ValidUntil = validuntil;
        }
        public Permit() { }
    }
}
