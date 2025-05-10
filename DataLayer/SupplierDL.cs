using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Collections.ObjectModel;

namespace DataLayer
{
    public class SupplierDL:DataProvider
    {

        public ObservableCollection<Supplier> GetSuppliers()
        {
            string sql = "SELECT * FROM Supplier";

            string id, name, address;
            ObservableCollection<Supplier> suppliers = new ObservableCollection<Supplier>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader["name"].ToString();
                    address = reader[2].ToString();
                    Supplier supplier = new Supplier(id, name, address);
                    suppliers.Add(supplier);
                }
                reader.Close();
                return suppliers;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public int Add(Supplier supplier)
        {
            string sql = "uspAddSupplier";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@id", supplier.Id));
            sqlParameters.Add(new SqlParameter("@name", supplier.Name));
            sqlParameters.Add(new SqlParameter("@address", supplier.Address));
            try
            {
                Connect();

                Console.WriteLine(supplier.Id);

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, sqlParameters);

            } 
            catch (SqlException ex)
            {
                throw ex;
            } finally
            {
                DisConnect();
            }
        }
    }
}
