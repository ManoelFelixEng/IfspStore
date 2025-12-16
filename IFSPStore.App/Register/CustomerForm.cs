using IFSPStore.App.Base;
using IFSPStore.App.ViewModel;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlX.XDevAPI;

namespace IFSPStore.App.Register
{
    public partial class CustomerForm : BaseForm
    {
        private IBaseService<Customer> _customerService;
        private IBaseService<City> _cityService;

        private List<CustomerViewModel>? customers;
        public CustomerForm(IBaseService<Customer> customerService, IBaseService<City> cityService)
        {
            _customerService = customerService;
            _cityService = cityService;
            InitializeComponent();
            LoadCombo();
        }

        private void FormToObject(Customer customer)
        {
            customer.Name = txtName.Text;
            customer.Address = txtAddress.Text;
            customer.District = txtDistrict.Text;
            customer.DocumentId = txtDocumentId.Text;

            if (int.TryParse(cboCity.SelectedValue.ToString(), out var idGroup))
            {
                var city = _cityService.GetById<City>(idGroup);
                customer.City = city;
            }
        }

        private void LoadCombo()
        {
            cboCity.ValueMember = "Id";
            cboCity.DisplayMember = "StateName";
            cboCity.DataSource = _cityService.Get<CityViewModel>().ToList();
        }

        protected override void Save()
        {
            try
            {
                if (isEditMode)
                {
                    int.TryParse(txtId.Text, out var id);
                    var customer = _customerService.GetById<Customer>(id);
                    FormToObject(customer);
                    customer = _customerService.Update<Customer, Customer, CustomerValidator>(customer);
                }
                else
                {
                    var customer = new Customer();
                    FormToObject(customer);
                    customer = _customerService.Add<Customer, Customer, CustomerValidator>(customer);
                }
                tabControlRegister.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void PopulateGrid()
        {
            customers = _customerService.Get<CustomerViewModel>(new[] { "Cidade" }).ToList();
            dataGridViewList.DataSource = customers;
            dataGridViewList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewList.Columns["IdCidade"]!.Visible = false;
        }

        protected override void GridToForm(DataGridViewRow? record)
        {
            txtId.Text = record?.Cells["Id"].Value.ToString();
            txtName.Text = record?.Cells["Name"].Value.ToString();
            txtAddress.Text = record?.Cells["Address"].Value.ToString();
            txtDistrict.Text = record?.Cells["District"].Value.ToString();
            cboCity.SelectedValue = record?.Cells["CityId"].Value;
            txtDocumentId.Text = record?.Cells["DocumentId"].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControlRegister.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
