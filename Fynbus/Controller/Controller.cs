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
            return _companies;
        }
    }
}
