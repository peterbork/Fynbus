using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fynbus.Helper;

namespace Fynbus.Controller {
    class Controller {
        DatabaseFacade _DatabaseFacade = new DatabaseFacade();

        public List<Model.Company> ViewAllCompanies(){
            List<Model.Company> _companies = _DatabaseFacade.GetAllCompanies();
            foreach (Model.Company _company in _companies){
		    _company.FKTrafficCompany = _DatabaseFacade.GetTrafficCompany(_company.FKTrafficCompany).Name;
            _company.FKType = _DatabaseFacade.GetCompanyType(_company.FKType).Name;
            //_company.Permit = _DatabaseFacade.GetPermit(_company.FKPermit).Number;
	        }
            return _companies;
        }
        public List<Model.Company> ViewAllCompaniesFromTrafficCompany(int trafficcompany) {

            List<Model.Company> _companies = _DatabaseFacade.GetCompaniesFromTrafficCompanies(trafficcompany);
            foreach (Model.Company _company in _companies) {
                _company.FKTrafficCompany = _DatabaseFacade.GetTrafficCompany(_company.FKTrafficCompany).Name;
                _company.FKType = _DatabaseFacade.GetCompanyType(_company.FKType).Name;
                //_company.FKPermit = _DatabaseFacade.GetPermit(_company.FKPermit).Number;
            }
            return _companies;
        }
        public List<Model.TrafficCompany> ViewAllTrafficCompanies() { 
            List<Model.TrafficCompany> _TrafficCompanies = _DatabaseFacade.GetAllTrafficCompanies();
            return _TrafficCompanies;
        }
        public Model.Company newCompany() {
            Model.Company company = new Model.Company();
            return company;
        }
    }
}
