using ReaLTaiizor.Forms;
using IFSPStore.App.Register;
using IFSPStore.App.Infra;
using IFSPStore.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using IFSPStore.App.Others;

namespace IFSPStore.App
{
    public partial class MainForm : MaterialForm
    {
        public static User User { get; set; }
        public MainForm()
        {
            InitializeComponent();
            LoadLogin();
        }

        private void LoadLogin()
        {
            var login = ConfigureDI.serviceProvider!.GetService<Login>();
            if (login != null && !login.IsDisposed)
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                else
                {
                    lblUser.Text = $"User: {User.Name}";
                }
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<CategoryForm>();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<UserForm>();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<CustomerForm>();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<CityForm>();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowForm<TFormulario>() where TFormulario : Form
        {
            var cad = ConfigureDI.serviceProvider!.GetService<TFormulario>();
            if (cad != null && !cad.IsDisposed)
            {
                cad.MdiParent = this;
                cad.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
        }
    }
}
