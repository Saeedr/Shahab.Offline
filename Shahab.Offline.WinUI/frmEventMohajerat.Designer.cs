namespace Shahab.Offline.WinUI
{
    partial class frmEventMohajerat
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventMohajerat));
            this.buttonX14 = new DevComponents.DotNetBar.ButtonX();
            this.MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActionFirstFamilySearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvActionMohajerat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label46 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParvandeAddBirthDay = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlStep1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxAdv1 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.cmbCityOrVillage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbTownship = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbCounty = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbProvince = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label13 = new System.Windows.Forms.Label();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionMohajerat)).BeginInit();
            this.pnlStep1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX14
            // 
            this.buttonX14.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX14.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX14.FocusCuesEnabled = false;
            this.buttonX14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonX14.Image = global::Shahab.Offline.WinUI.Properties.Resources.search_70;
            this.buttonX14.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonX14.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX14.Location = new System.Drawing.Point(8, 6);
            this.buttonX14.Name = "buttonX14";
            this.buttonX14.Size = new System.Drawing.Size(104, 38);
            this.buttonX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX14.TabIndex = 19;
            this.buttonX14.Text = "جستجو";
            this.buttonX14.Click += new System.EventHandler(this.buttonX14_Click);
            // 
            // MobileNumber
            // 
            this.MobileNumber.HeaderText = "تلفن همراه";
            this.MobileNumber.Name = "MobileNumber";
            this.MobileNumber.ReadOnly = true;
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "سن";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // NationalCode
            // 
            this.NationalCode.HeaderText = "کد ملی";
            this.NationalCode.Name = "NationalCode";
            this.NationalCode.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "نام خانوادگی";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "نام";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(558, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 36);
            this.label1.TabIndex = 23;
            this.label1.Text = "انتخاب شخص مهاجر";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtActionFirstFamilySearch
            // 
            // 
            // 
            // 
            this.txtActionFirstFamilySearch.Border.Class = "TextBoxBorder";
            this.txtActionFirstFamilySearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtActionFirstFamilySearch.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtActionFirstFamilySearch, true);
            this.txtActionFirstFamilySearch.Location = new System.Drawing.Point(118, 15);
            this.txtActionFirstFamilySearch.MaxLength = 7;
            this.txtActionFirstFamilySearch.Name = "txtActionFirstFamilySearch";
            this.txtActionFirstFamilySearch.Size = new System.Drawing.Size(114, 22);
            this.txtActionFirstFamilySearch.TabIndex = 17;
            this.txtActionFirstFamilySearch.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtActionFirstFamilySearch.WatermarkText = "مثال : 235";
            // 
            // dgvActionMohajerat
            // 
            this.dgvActionMohajerat.AllowUserToAddRows = false;
            this.dgvActionMohajerat.AllowUserToDeleteRows = false;
            this.dgvActionMohajerat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActionMohajerat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActionMohajerat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActionMohajerat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActionMohajerat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.NationalCode,
            this.BirthDate,
            this.MobileNumber,
            this.MemberID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActionMohajerat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActionMohajerat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvActionMohajerat.HighlightSelectedColumnHeaders = false;
            this.dgvActionMohajerat.Location = new System.Drawing.Point(8, 49);
            this.dgvActionMohajerat.MultiSelect = false;
            this.dgvActionMohajerat.Name = "dgvActionMohajerat";
            this.dgvActionMohajerat.ReadOnly = true;
            this.dgvActionMohajerat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActionMohajerat.Size = new System.Drawing.Size(671, 163);
            this.dgvActionMohajerat.TabIndex = 10;
            // 
            // MemberID
            // 
            this.MemberID.HeaderText = "کد شخص";
            this.MemberID.Name = "MemberID";
            this.MemberID.ReadOnly = true;
            this.MemberID.Visible = false;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Location = new System.Drawing.Point(238, 17);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 20);
            this.label46.TabIndex = 0;
            this.label46.Text = "شماره پرونده :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "مقصد مهاجرت ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParvandeAddBirthDay
            // 
            this.txtParvandeAddBirthDay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.txtParvandeAddBirthDay.BackgroundStyle.Class = "TextBoxBorder";
            this.txtParvandeAddBirthDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParvandeAddBirthDay.ButtonClear.Visible = true;
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddBirthDay, true);
            this.txtParvandeAddBirthDay.Location = new System.Drawing.Point(589, 306);
            this.txtParvandeAddBirthDay.Mask = "1000/00/00";
            this.txtParvandeAddBirthDay.Name = "txtParvandeAddBirthDay";
            this.txtParvandeAddBirthDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtParvandeAddBirthDay.Size = new System.Drawing.Size(90, 26);
            this.txtParvandeAddBirthDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtParvandeAddBirthDay.TabIndex = 27;
            this.txtParvandeAddBirthDay.Tag = "Valid";
            this.txtParvandeAddBirthDay.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(581, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "تاریخ مهاجرت شخص";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep1
            // 
            this.pnlStep1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStep1.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlStep1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlStep1.Controls.Add(this.textBoxX1);
            this.pnlStep1.Controls.Add(this.label7);
            this.pnlStep1.Controls.Add(this.label1);
            this.pnlStep1.Controls.Add(this.buttonX14);
            this.pnlStep1.Controls.Add(this.txtActionFirstFamilySearch);
            this.pnlStep1.Controls.Add(this.dgvActionMohajerat);
            this.pnlStep1.Controls.Add(this.label46);
            this.pnlStep1.Location = new System.Drawing.Point(8, 10);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(690, 223);
            this.pnlStep1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlStep1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlStep1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlStep1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlStep1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlStep1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlStep1.Style.GradientAngle = 90;
            this.pnlStep1.TabIndex = 24;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX2);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.checkBoxX1);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.maskedTextBoxAdv1);
            this.groupPanel1.Controls.Add(this.comboBoxEx2);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtParvandeAddBirthDay);
            this.groupPanel1.Controls.Add(this.panelEx2);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.pnlStep1);
            this.groupPanel1.Location = new System.Drawing.Point(15, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(719, 370);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "مهـــــاجرت";
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.Class = "";
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.FocusCuesEnabled = false;
            this.checkBoxX1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxX1.Location = new System.Drawing.Point(476, 275);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(90, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 52;
            this.checkBoxX1.Text = "مهاجرت دائمی";
            this.checkBoxX1.TextColor = System.Drawing.Color.Black;
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(566, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "تا";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(685, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "از";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maskedTextBoxAdv1
            // 
            this.maskedTextBoxAdv1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.maskedTextBoxAdv1.BackgroundStyle.Class = "TextBoxBorder";
            this.maskedTextBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.maskedTextBoxAdv1.ButtonClear.Visible = true;
            this.highlighter1.SetHighlightOnFocus(this.maskedTextBoxAdv1, true);
            this.maskedTextBoxAdv1.Location = new System.Drawing.Point(475, 306);
            this.maskedTextBoxAdv1.Mask = "1000/00/00";
            this.maskedTextBoxAdv1.Name = "maskedTextBoxAdv1";
            this.maskedTextBoxAdv1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBoxAdv1.Size = new System.Drawing.Size(93, 26);
            this.maskedTextBoxAdv1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.maskedTextBoxAdv1.TabIndex = 50;
            this.maskedTextBoxAdv1.Tag = "Valid";
            this.maskedTextBoxAdv1.Text = "";
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.comboBoxEx2, true);
            this.comboBoxEx2.ItemHeight = 16;
            this.comboBoxEx2.Location = new System.Drawing.Point(473, 244);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(125, 22);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 31;
            this.comboBoxEx2.Tag = "Valid";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(604, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "علت مهاجرت :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.cmbCityOrVillage);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.label17);
            this.panelEx2.Controls.Add(this.cmbTownship);
            this.panelEx2.Controls.Add(this.label15);
            this.panelEx2.Controls.Add(this.cmbCounty);
            this.panelEx2.Controls.Add(this.label16);
            this.panelEx2.Controls.Add(this.cmbCountry);
            this.panelEx2.Controls.Add(this.label14);
            this.panelEx2.Controls.Add(this.cmbProvince);
            this.panelEx2.Controls.Add(this.label13);
            this.panelEx2.Location = new System.Drawing.Point(8, 244);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(459, 95);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 49;
            // 
            // cmbCityOrVillage
            // 
            this.cmbCityOrVillage.DisplayMember = "Text";
            this.cmbCityOrVillage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCityOrVillage.Enabled = false;
            this.cmbCityOrVillage.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbCityOrVillage, true);
            this.cmbCityOrVillage.ItemHeight = 16;
            this.cmbCityOrVillage.Location = new System.Drawing.Point(11, 64);
            this.cmbCityOrVillage.Name = "cmbCityOrVillage";
            this.cmbCityOrVillage.Size = new System.Drawing.Size(120, 22);
            this.cmbCityOrVillage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCityOrVillage.TabIndex = 54;
            this.cmbCityOrVillage.Tag = "Valid";
            this.cmbCityOrVillage.Text = "انتخاب کنید";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(140, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 20);
            this.label17.TabIndex = 53;
            this.label17.Text = "شهر | روستا :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTownship
            // 
            this.cmbTownship.DisplayMember = "Text";
            this.cmbTownship.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTownship.Enabled = false;
            this.cmbTownship.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbTownship, true);
            this.cmbTownship.ItemHeight = 16;
            this.cmbTownship.Location = new System.Drawing.Point(11, 37);
            this.cmbTownship.Name = "cmbTownship";
            this.cmbTownship.Size = new System.Drawing.Size(120, 22);
            this.cmbTownship.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTownship.TabIndex = 52;
            this.cmbTownship.Tag = "Valid";
            this.cmbTownship.Text = "انتخاب کنید";
            this.cmbTownship.SelectedIndexChanged += new System.EventHandler(this.cmbTownship_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(140, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 20);
            this.label15.TabIndex = 51;
            this.label15.Text = "شهرستان : ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCounty
            // 
            this.cmbCounty.DisplayMember = "Text";
            this.cmbCounty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCounty.Enabled = false;
            this.cmbCounty.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbCounty, true);
            this.cmbCounty.ItemHeight = 16;
            this.cmbCounty.Location = new System.Drawing.Point(230, 64);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(132, 22);
            this.cmbCounty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCounty.TabIndex = 50;
            this.cmbCounty.Tag = "NotValid";
            this.cmbCounty.Text = "انتخاب کنید";
            this.cmbCounty.SelectedIndexChanged += new System.EventHandler(this.cmbCounty_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(369, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 20);
            this.label16.TabIndex = 49;
            this.label16.Text = "بخش : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCountry
            // 
            this.cmbCountry.DisplayMember = "Text";
            this.cmbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCountry.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbCountry, true);
            this.cmbCountry.ItemHeight = 16;
            this.cmbCountry.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbCountry.Location = new System.Drawing.Point(230, 10);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(132, 22);
            this.cmbCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCountry.TabIndex = 48;
            this.cmbCountry.Tag = "Valid";
            this.cmbCountry.Text = "انتخاب کنید";
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "ایران";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "خارج از ایران";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(368, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 20);
            this.label14.TabIndex = 37;
            this.label14.Text = "کشور : ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProvince
            // 
            this.cmbProvince.DisplayMember = "Text";
            this.cmbProvince.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProvince.Enabled = false;
            this.cmbProvince.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbProvince, true);
            this.cmbProvince.ItemHeight = 16;
            this.cmbProvince.Location = new System.Drawing.Point(230, 37);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(132, 22);
            this.cmbProvince.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbProvince.TabIndex = 31;
            this.cmbProvince.Tag = "Valid";
            this.cmbProvince.Text = "انتخاب کنید";
            this.cmbProvince.SelectedIndexChanged += new System.EventHandler(this.cmbProvince_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(373, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "استان : ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            this.err.Icon = ((System.Drawing.Icon)(resources.GetObject("err.Icon")));
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.textBoxX1, true);
            this.textBoxX1.Location = new System.Drawing.Point(322, 15);
            this.textBoxX1.MaxLength = 10;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(114, 22);
            this.textBoxX1.TabIndex = 25;
            this.textBoxX1.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxX1.WatermarkText = "مثال : 2354567892";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(442, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "کد ملی :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonX1.Image = global::Shahab.Offline.WinUI.Properties.Resources.checkmark;
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX1.Location = new System.Drawing.Point(16, 16);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(49, 38);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 26;
            this.buttonX1.Visible = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonX2.Image = global::Shahab.Offline.WinUI.Properties.Resources.cross_mark_304374_1280;
            this.buttonX2.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX2.Location = new System.Drawing.Point(71, 16);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(49, 38);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 53;
            this.buttonX2.Visible = false;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // frmEventMohajerat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(747, 398);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEventMohajerat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmEventMohajerat";
            this.Load += new System.EventHandler(this.frmEventMohajerat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionMohajerat)).EndInit();
            this.pnlStep1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX14;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtActionFirstFamilySearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvActionMohajerat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtParvandeAddBirthDay;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.PanelEx pnlStep1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCityOrVillage;
        private System.Windows.Forms.Label label17;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTownship;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCounty;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCountry;
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbProvince;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv maskedTextBoxAdv1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private System.Windows.Forms.ErrorProvider err;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}