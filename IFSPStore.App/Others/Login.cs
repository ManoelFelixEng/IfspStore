using ReaLTaiizor.Forms;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs;

namespace IFSPStore.App.Others
{
    public partial class Login : MaterialForm
    {
        private readonly IBaseService<User> _userService;
        public Login(IBaseService<User> userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            User user = GetUser(txtUser.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("User/Password invalid!", "IFSP Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!user.Active)
            {
                MessageBox.Show("Inactive User!", "IFSP Store",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                user.LoginDate = DateTime.Now;
                user = _userService.Update<User, User, UserValidator>(user);
                MainForm.User = user;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private User? GetUser(string login, string password)
        {
            VerifyRegistratedUserExistance();
            var user = _userService.Get<User>().Where(x => x.Login == login).FirstOrDefault();
            if (user == null)
                return null;
            return user.Password != password ? null : user;
        }
        private void VerifyRegistratedUserExistance()
        {
            var users = _userService.Get<User>().ToList();
            if (!users.Any())
            {
                var user = new User
                {
                    Login = "admin",
                    Password = "admin",
                    Name = "System Admin",
                    Active = true,
                    RegistrationDate = DateTime.Now,
                    Email = "admin@gmail.com"
                };
                _userService.Add<User, User, UserValidator>(user);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
