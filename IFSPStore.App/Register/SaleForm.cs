using IFSPStore.App.Base;
using IFSPStore.App.ViewModel; // Certifique-se que seus ViewModels estão aqui
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs; // Notei que no seu projeto está Validatorrs com 2 'r'
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace IFSPStore.App.Register
{
    public partial class SaleForm : BaseForm
    {
        
        private readonly IBaseService<Sale> _saleService;
        private readonly IBaseService<Product> _productService;
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<Customer> _customerService;

        
        private List<ProductViewModel>? _products;
        private List<UserViewModel>? _users;
        private List<CustomerViewModel>? _customers;

        
        private List<SaleItem> _saleItems;

        public SaleForm(IBaseService<Sale> saleService,
                        IBaseService<Product> productService,
                        IBaseService<User> userService,
                        IBaseService<Customer> customerService)
        {
            _saleService = saleService;
            _productService = productService;
            _userService = userService;
            _customerService = customerService;
            _saleItems = new List<SaleItem>();

            InitializeComponent();
            LoadCombos();
            CriarColunasGrid();
        }

        private void LoadCombos()
        {
            
            _customers = _customerService.Get<CustomerViewModel>().ToList();
            cboCliente.ValueMember = "Id";
            cboCliente.DisplayMember = "Name";
            cboCliente.DataSource = _customers;

            
            _users = _userService.Get<UserViewModel>().ToList();
            cboUsuario.ValueMember = "Id";
            cboUsuario.DisplayMember = "Name";
            cboUsuario.DataSource = _users;

            
            _products = _productService.Get<ProductViewModel>().ToList(); 
            cboProduto.ValueMember = "Id";
            cboProduto.DisplayMember = "Name"; 
            cboProduto.DataSource = _products;
        }

        private void CriarColunasGrid()
        {
            dataGridViewItens.Columns.Add("IdProduto", "Id");
            dataGridViewItens.Columns.Add("Produto", "Produto");
            dataGridViewItens.Columns.Add("VlUnitario", "Vl. Unit.");
            dataGridViewItens.Columns.Add("Quantidade", "Qtd");
            dataGridViewItens.Columns.Add("VlTotal", "Total");
        }

        private void AtualizarTotalVenda()
        {
            decimal total = _saleItems.Sum(x => x.TotalPrice);
            lblValor.Text = $"Valor Total: {total:C2}";
            lblQtdItens.Text = $"Qtd. Produtos: {_saleItems.Count}";
        }

        private void CalcularTotalItem()
        {
            if (decimal.TryParse(txtQuantidade.Text, out decimal qtd) &&
                decimal.TryParse(txtVlUnitario.Text, out decimal vlUnit))
            {
                txtVlTotal.Text = (qtd * vlUnit).ToString("F2");
            }
        }

        #region Eventos dos Controles

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CalcularTotalItem();
        }

        private void txtVlUnitario_Leave(object sender, EventArgs e)
        {
            CalcularTotalItem();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cboProduto.SelectedValue == null) return;

            
            var produtoId = (int)cboProduto.SelectedValue;
            var produtoNome = cboProduto.Text;

            if (!decimal.TryParse(txtQuantidade.Text, out var qtd)) return;
            if (!decimal.TryParse(txtVlUnitario.Text, out var vlUnit)) return;

            
            var item = new SaleItem
            {
                
                Quatity = qtd,
                UnitPrice = vlUnit,
                TotalPrice = qtd * vlUnit
            };

            
            _saleItems.Add(item);
            dataGridViewItens.Rows.Add(produtoId, produtoNome, vlUnit, qtd, item.TotalPrice);

            AtualizarTotalVenda();

           
            txtQuantidade.Clear();
            txtVlTotal.Clear();
            txtVlUnitario.Clear();
            cboProduto.SelectedIndex = -1;
            cboProduto.Focus();
        }

        #endregion

        #region Overrides do BaseForm

        protected override void Save()
        {
            try
            {
                if (isEditMode)
                {
                    
                }
                else
                {
                    
                    var sale = new Sale();
                    sale.Date = DateTime.Parse(txtDataVenda.Text);
                    sale.TotalAmount = _saleItems.Sum(i => i.TotalPrice);

                    if (int.TryParse(cboUsuario.SelectedValue?.ToString(), out int userId))
                        sale.Salesman = _userService.GetById<User>(userId);

                    if (int.TryParse(cboCliente.SelectedValue?.ToString(), out int customerId))
                        sale.Customer = _customerService.GetById<Customer>(customerId);

                    sale.SaleItens = _saleItems;

                    _saleService.Add<Sale, Sale, SaleValidator>(sale);
                }

                MessageBox.Show("Venda salva com sucesso!", "IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _saleService.Delete(id);
                MessageBox.Show("Venda excluída!", "IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void PopulateGrid()
        {
            
            var sales = _saleService.Get<SaleViewModel>(new[] { "Customer", "Salesman" }).ToList();
            dataGridViewList.DataSource = sales;
            dataGridViewList.Columns["TotalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override void New()
        {
            base.New();
            _saleItems.Clear();
            dataGridViewItens.Rows.Clear();
            txtDataVenda.Text = DateTime.Now.ToString("dd/MM/yyyy");
            AtualizarTotalVenda();
        }

        protected override void GridToForm(DataGridViewRow? record)
        {
   
        }

        #endregion
    }
}