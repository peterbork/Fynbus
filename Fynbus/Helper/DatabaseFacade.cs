using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fynbus.Helper {
    class DatabaseFacade {
        static SqlConnection Conn;
        static string DBConnectionString = "Server=ealdb1.eal.local; User ID=ejl04_usr; Password=Baz1nga4; Database=EJL04_DB";

        public Model.CompanyType GetSensorFromCPRNR(int id) {
            SqlConnection conn = new SqlConnection(DBConnectionString);
            Model.CompanyType _CompanyType;

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCompanyType", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    _CompanyType = new Model.CompanyType(reader["ID"], reader["Name"]);
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
            return s;
        }

    }
}
