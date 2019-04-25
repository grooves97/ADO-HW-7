using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.DataAcces;

namespace Warehouse
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            var product = InitProduct();

            if (product == null)
            {
                return;
            }

            using (var context = new WarehouseContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            MessageBox.Show("Product successfully added");

            Close();
        }

        private Product InitProduct()
        {
            string productName;

            if (textBoxProduct.Text.Length == 0)
            {
                MessageBox.Show("Enter the name of the city");
                return null;
            }
            else if (IsHaveProduct(textBoxProduct.Text))
            {
                MessageBox.Show("Product already exists");
                return null;
            }
            else
            {
                productName = textBoxProduct.Text;
            }

            var product = new Product
            {
                Name = productName
            };

            return product;
        }


            private bool IsHaveProduct(string nameProduct)
        {
            using (var context = new WarehouseContext())
            {
                foreach (var product in context.Products)
                {
                    if (product.Name == nameProduct)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
