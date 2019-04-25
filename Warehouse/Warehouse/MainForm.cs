using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.DataAcces;
using Warehouse.Models;

namespace Warehouse
{
    public partial class MainForm : Form
    {
        private WarehouseContext warehouseDb;
        public MainForm()
        {
            InitializeComponent();
            warehouseDb = new WarehouseContext();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Product product = new Product();
            product.Name = form2.textBoxInfo.Text;

            warehouseDb.Products.Add(product);
            warehouseDb.SaveChanges();
            dataGridViewWarehouse.DataSource = warehouseDb.Products.ToList();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                int index = dataGridViewWarehouse.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridViewWarehouse[1, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = warehouseDb.Products.Find(id);

                Form2 form2 = new Form2();

                form2.textBoxInfo.Text = product.Name;

                DialogResult result = form2.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                product.Name = form2.textBoxInfo.Text;

                warehouseDb.SaveChanges();
                dataGridViewWarehouse.DataSource = warehouseDb.Products.ToList();

            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                int index = dataGridViewWarehouse.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridViewWarehouse[1, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = warehouseDb.Products.Find(id);
                warehouseDb.Products.Remove(product);
                warehouseDb.SaveChanges();
                dataGridViewWarehouse.DataSource = warehouseDb.Products.ToList();
            }
        }
    }
}
