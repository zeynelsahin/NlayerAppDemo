using System;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concreate;
using Northwind.Business.DependecyResolvers.Ninject;
using Northwind.DataAccess.Concreate.EntityFramework;
using NorthwinEntities.Concreate;

namespace Northwin.WebFormsUI
{
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService = InstanceFactory.GetIntance<ICategoryService>();
        private readonly IProductService _productService = InstanceFactory.GetIntance<IProductService>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryId.DataSource = _categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";

            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource =
                    _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {
            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            var name = tbxProductName.Text;
            if (string.IsNullOrEmpty(name))
                LoadProducts();
            else
                dgwProduct.DataSource = _productService.GetProductsByName(tbxProductName.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    ProductName = tbxProductName2.Text,
                    QuantityPerUnit = tbxQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxStock.Text)
                });
                MessageBox.Show("Ekledi");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product()
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                ProductName = tbxUpdateProductName.Text,
                UnitsInStock = Convert.ToInt16(tbxUnitInStockUpdate.Text),
                QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
            });
            MessageBox.Show("Ürün Güncellendi");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateProductName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxUnitInStockUpdate.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();
                    tbxUnitPriceUpdate.Text =dgwProduct.CurrentRow.Cells[3].Value.ToString();
                cbxCategoryIdUpdate.SelectedValue = dgwProduct.CurrentRow.Cells[2].Value;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Delete(new Product() { ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) });
                MessageBox.Show("Deleted");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        
        }
    }
}