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

        public Model.CompanyType GetCompanyType(int id) {
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
        public Model.Permit GetPermit(int number) {
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
                    _Permit = new Model.Permit(int.Parse(reader["Number"].ToString()), reader["Permit_Type"].ToString(), Convert.ToDateTime(reader["Valid_Until"].ToString()));
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
        public Model.TrafficCompany GetTrafficCompany(int id) {
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
                    _Companies.Add(new Model.Company(int.Parse(reader["CVR"].ToString()), reader["Name"].ToString(), int.Parse(reader["Offer_Number"].ToString()), int.Parse(reader["FK_Type"].ToString()), int.Parse(reader["FK_Permit"].ToString()), int.Parse(reader["FK_Traffic_Company"].ToString())));
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
    }
}
