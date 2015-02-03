using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fynbus.Model {
    class Vehicle {
        public string RegNumber { get; set; }
        public int VehicleNumber { get; set; }
        public string FKCompany { get; set; }
        public string FKVehicleType { get; set; }
        public string PhoneNumber { get; set; }
        public int FKHome { get; set; }
        public string IssuingAuthority { get; set; }
        public string Notice { get; set; }
        public int WarrantyVehicleNumber { get; set; }

        public Vehicle(string regnumber, int vehiclenumber, string fkcompany, string fkvehicletype, string phonenumber, int fkhome, string issuingauthority, string notice, int warrantyvehiclenumber) {
            this.RegNumber = regnumber;
            this.VehicleNumber = vehiclenumber;
            this.FKCompany = fkcompany;
            this.FKVehicleType = fkvehicletype;
            this.PhoneNumber = phonenumber;
            this.FKHome = fkhome;
            this.IssuingAuthority = issuingauthority;
            this.Notice = notice;
            this.WarrantyVehicleNumber = warrantyvehiclenumber;
        }
        public Vehicle() { }
    }
}
