using IFSPStore.App.Base;
using IFSPStore.App.ViewModel;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs;

namespace IFSPStore.App.Register
{
    public partial class UserForm: BaseForm
    {
        private IBaseService<User> _userService;
        private List<UserViewModel>? users;
        public UserForm(IBaseService<User> userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void FormToObject(User user)
        {
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Text;
            user.Active = activeChk.Checked;
        }

        protected override void Save()
        {
            try
            {
                if (isEditMode)
                {
                    int.TryParse(txtId.Text, out var id);
                    var user = _userService.GetById<User>(id);
                    FormToObject(user);
                    user = _userService.Update<User, User, UserValidator>(user);
                }
                else
                {
                    var user = new User();
                    FormToObject(user);
                    user = _userService.Add<User, User, UserValidator>(user);
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
                _userService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void PopulateGrid()
        {
            users = _userService.Get<UserViewModel>().ToList();
            dataGridViewList.DataSource = users;
            dataGridViewList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override void GridToForm(DataGridViewRow? record)
        {
            txtId.Text = record?.Cells["Id"].Value.ToString();
            txtName.Text = record?.Cells["Name"].Value.ToString();
            txtEmail.Text = record?.Cells["Email"].Value.ToString();
            txtLogin.Text = record?.Cells["Login"].Value.ToString();
            txtPassword.Text = record?.Cells["Password"].Value.ToString();
            activeChk.Checked = (bool)(record?.Cells["Active"].Value ?? false);

            txtRegistrationDate.Text = DateTime.TryParse(record?.Cells["RegistrationDate"].Value.ToString(), out var dataC)
                ? dataC.ToString("g")
                : "";

            txtLoginDate.Text = DateTime.TryParse(record?.Cells["LoginDate"].Value.ToString(), out var dataL)
                ? dataL.ToString("g")
                : "";
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

