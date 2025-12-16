namespace IFSPStore.App.Register
{
    partial class CityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCity = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cboState = new ReaLTaiizor.Controls.MaterialComboBox();
            txtId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            tabControlRegister.SuspendLayout();
            tabPageRegister.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlRegister
            // 
            tabControlRegister.Size = new Size(500, 263);
            // 
            // tabPageRegister
            // 
            tabPageRegister.Controls.Add(txtId);
            tabPageRegister.Controls.Add(cboState);
            tabPageRegister.Controls.Add(txtCity);
            tabPageRegister.Size = new Size(492, 228);
            tabPageRegister.Controls.SetChildIndex(txtCity, 0);
            tabPageRegister.Controls.SetChildIndex(cboState, 0);
            tabPageRegister.Controls.SetChildIndex(txtId, 0);
            // 
            // txtCity
            // 
            txtCity.AnimateReadOnly = false;
            txtCity.AutoCompleteMode = AutoCompleteMode.None;
            txtCity.AutoCompleteSource = AutoCompleteSource.None;
            txtCity.BackgroundImageLayout = ImageLayout.None;
            txtCity.CharacterCasing = CharacterCasing.Normal;
            txtCity.Depth = 0;
            txtCity.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCity.HideSelection = true;
            txtCity.Hint = "City";
            txtCity.LeadingIcon = null;
            txtCity.Location = new Point(23, 34);
            txtCity.MaxLength = 32767;
            txtCity.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtCity.Name = "txtCity";
            txtCity.PasswordChar = '\0';
            txtCity.PrefixSuffixText = null;
            txtCity.ReadOnly = false;
            txtCity.RightToLeft = RightToLeft.No;
            txtCity.SelectedText = "";
            txtCity.SelectionLength = 0;
            txtCity.SelectionStart = 0;
            txtCity.ShortcutsEnabled = true;
            txtCity.Size = new Size(273, 48);
            txtCity.TabIndex = 3;
            txtCity.TabStop = false;
            txtCity.TextAlign = HorizontalAlignment.Left;
            txtCity.TrailingIcon = null;
            txtCity.UseSystemPasswordChar = false;
            // 
            // cboState
            // 
            cboState.AutoResize = false;
            cboState.BackColor = Color.FromArgb(255, 255, 255);
            cboState.Depth = 0;
            cboState.DrawMode = DrawMode.OwnerDrawVariable;
            cboState.DropDownHeight = 174;
            cboState.DropDownStyle = ComboBoxStyle.DropDownList;
            cboState.DropDownWidth = 121;
            cboState.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboState.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboState.FormattingEnabled = true;
            cboState.Hint = "State";
            cboState.IntegralHeight = false;
            cboState.ItemHeight = 43;
            cboState.Items.AddRange(new object[] { "Select", "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" });
            cboState.Location = new Point(23, 99);
            cboState.MaxDropDownItems = 4;
            cboState.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboState.Name = "cboState";
            cboState.Size = new Size(121, 49);
            cboState.StartIndex = 0;
            cboState.TabIndex = 4;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(370, 34);
            txtId.MaxLength = 32767;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = false;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(73, 48);
            txtId.TabIndex = 5;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            // 
            // CityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 330);
            Location = new Point(0, 0);
            Name = "CityForm";
            Text = "CityForm";
            tabControlRegister.ResumeLayout(false);
            tabPageRegister.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtCity;
        private ReaLTaiizor.Controls.MaterialComboBox cboState;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
    }
}