using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;
        public SupplierBL()
        {
            supplierDL = new SupplierDL();
        }
        public ObservableCollection<Supplier> GetSuppliers()
        {
            try
            {
                return (supplierDL.GetSuppliers());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Add(TransferObject.Supplier supplier)
        {
            DataLayer.SupplierDL supplierDL = new SupplierDL();

            return supplierDL.Add(supplier);
        }

    }
}
