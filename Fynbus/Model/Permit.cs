using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class Permit {
        public int Number { get; set; }
        public string PermitType { get; set; }
        public DateTime ValidUntil { get; set; }
        public Permit(int number, string permitType, DateTime validuntil) {
            this.Number = number;
            this.PermitType = permitType;
            this.ValidUntil = validuntil;
        }
        public Permit() { }
    }
}
