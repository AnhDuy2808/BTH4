using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH4
{
    public partial class frmNewSupplier : Form
    {
        public frmNewSupplier()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id, name, address;
            id= txtId.Text;
            name = txtName.Text;
            address= txtAddress.Text.Trim();

            TransferObject.Supplier supplier= new TransferObject.Supplier(id, name, address);

            try
            {
                BusinessLayer.SupplierBL supplierBL = new BusinessLayer.SupplierBL();

                supplierBL.Add(supplier);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
