using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fynbus.Helper {
    class DatabaseFacade {
        string DBConnectionString = "Server=ealdb1.eal.local; User ID=ejl04_usr; Password=Baz1nga4; Database=EJL04_DB";
        public Model.CompanyType GetCompanyType(string id) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.CompanyType _CompanyType = new Model.CompanyType();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCompanyType", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _CompanyType = new Model.CompanyType(int.Parse(reader["ID"].ToString()), reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _CompanyType;
        }
        public Model.Permit GetPermit(string number) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.Permit _Permit = new Model.Permit();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetPermit", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@Number", number));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _Permit = new Model.Permit(reader["Number"].ToString(), reader["Permit_Type"].ToString(), DateTime.Parse(reader["Valid_Until"].ToString()));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _Permit;
        }
        public Model.TrafficCompany GetTrafficCompany(string id) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.TrafficCompany _TrafficCompany = new Model.TrafficCompany();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetTrafficCompany", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _TrafficCompany = new Model.TrafficCompany(int.Parse(reader["ID"].ToString()), reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _TrafficCompany;
        }
        public List<Model.Company> GetAllCompanies() {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            List<Model.Company> _Companies = new List<Model.Company>();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllCompanies", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _Companies.Add(new Model.Company(int.Parse(reader["CVR"].ToString()), reader["Name"].ToString(), int.Parse(reader["Offer_Number"].ToString()), reader["FK_Type"].ToString(), reader["FK_Traffic_Company"].ToString(), GetPermit(reader["FK_Permit"].ToString())));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _Companies;
        }
        public List<Model.Company> GetCompaniesFromTrafficCompanies(int fk_traffic_company) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            List<Model.Company> _Companies = new List<Model.Company>();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCompaniesFromTrafficCompanies", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@fk_traffic_Company", fk_traffic_company));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _Companies.Add(new Model.Company(int.Parse(reader["CVR"].ToString()), reader["Name"].ToString(), int.Parse(reader["Offer_Number"].ToString()), reader["FK_Type"].ToString(), reader["FK_Traffic_Company"].ToString(), GetPermit(reader["FK_Permit"].ToString())));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _Companies;
        }
        public List<Model.TrafficCompany> GetAllTrafficCompanies() {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            List<Model.TrafficCompany> _TrafficCompanies = new List<Model.TrafficCompany>();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllTrafficCompanies", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _TrafficCompanies.Add(new Model.TrafficCompany(int.Parse(reader["ID"].ToString()), reader["Name"].ToString()));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _TrafficCompanies;
        }
        public List<Model.Vehicle> GetVehicleFromCVR(int cvr) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            List<Model.Vehicle> _vehicles = new List<Model.Vehicle>();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetVehicleFromCVR", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@CVR", cvr));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _vehicles.Add(new Model.Vehicle(reader["Reg_Number"].ToString(), int.Parse(reader["Vehicle_Number"].ToString()), reader["FK_Company"].ToString(), reader["FK_Vehicle_Type"].ToString(), reader["Phone_Number"].ToString(), GetHomeFromId(int.Parse(reader["FK_Home"].ToString())), reader["Issuing_Authority"].ToString(), reader["Notice"].ToString(), int.Parse(reader["Warranty_Vehicle_Number"].ToString())));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _vehicles;
        }
        public Model.Company GetCompany(int cvr) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.Company _company = new Model.Company();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCompany", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@CVR", cvr));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _company = new Model.Company(int.Parse(reader["CVR"].ToString()), reader["Name"].ToString(), int.Parse(reader["Offer_Number"].ToString()), reader["FK_Type"].ToString(), reader["FK_Traffic_Company"].ToString(), GetPermit(reader["FK_Permit"].ToString()));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _company;
        }
        public Model.Home GetHomeFromId(int id) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.Home _home = new Model.Home();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetHomeFromId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _home = new Model.Home(int.Parse(reader["ID"].ToString()), reader["Street_Address"].ToString(), int.Parse(reader["Postcode"].ToString()), reader["Region"].ToString());
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return _home;
        }
    }
}
