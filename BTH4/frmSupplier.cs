using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace BTH4
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            List<String> columns = new List<String> {"ID", "Name", "Address" };

            dgvSupplier = CustomDataGridView(dgvSupplier, columns);

            dgvSupplier.DataSource = new SupplierBL().GetSuppliers();
        }

        private DataGridView CustomDataGridView(DataGridView dataGridView, List<String> columns)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Rows.Clear();

            foreach(string colum in columns)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.HeaderText = colum;
                dataGridView.Columns.Add(dataGridViewTextBoxColumn);

            }

            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
            dataGridViewImageColumn.Image = Image.FromFile(AppContext.BaseDirectory + "..\\..\\Resources\\red-trash-can-icon.png");
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView.Columns.Add(dataGridViewImageColumn);

            return dataGridView;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewSupplier frmNewSupplier = new frmNewSupplier();
            DialogResult result = frmNewSupplier.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgvSupplier.DataSource = new SupplierBL().GetSuppliers();

            }
        }
    }
}
