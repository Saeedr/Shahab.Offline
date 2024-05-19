namespace Shahab.Offline.WinUI
{
    partial class frmEventTalagh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            AnimatorNS.Animation animation3 = new AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventTalagh));
            this.pnlParvandeSearch = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.pnlStep2 = new DevComponents.DotNetBar.PanelEx();
            this.rdoNewFamily = new System.Windows.Forms.RadioButton();
            this.rdoSearchFamily = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStep2_2 = new DevComponents.DotNetBar.PanelEx();
            this.pnlStep2_1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtActionFamilySecondSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlStep1 = new DevComponents.DotNetBar.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX14 = new DevComponents.DotNetBar.ButtonX();
            this.txtActionFirstFamilySearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label46 = new System.Windows.Forms.Label();
            this.dgvActionTalagh = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.animator1 = new AnimatorNS.Animator(this.components);
            this.cmbParvandeAddNesbat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLastFamilyFamilyType = new System.Windows.Forms.Label();
            this.lblLastFamilyOwner = new System.Windows.Forms.Label();
            this.lblLastFamilyHeaderName = new System.Windows.Forms.Label();
            this.lblLastFamilyTell = new System.Windows.Forms.Label();
            this.cmbParvandeAddFamilyType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtParvandeAddTell2 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label10 = new System.Windows.Forms.Label();
            this.txtParvandeAddTell1 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtParvandeAddPostalCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtParvandeAddFamilyNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.schParvandeAddPstalCode = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.cmbParvandeAddCityOrVillage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.cmbParvandeAddMalekiat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtParvandeAddShomareSakhteman = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtParvandeAddAdress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlParvandeSearch.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.pnlStep2_2.SuspendLayout();
            this.pnlStep2_1.SuspendLayout();
            this.pnlStep1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionTalagh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParvandeSearch
            // 
            this.pnlParvandeSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlParvandeSearch.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlParvandeSearch.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlParvandeSearch.Controls.Add(this.lblStatus);
            this.pnlParvandeSearch.Controls.Add(this.buttonX3);
            this.pnlParvandeSearch.Controls.Add(this.pnlStep2);
            this.pnlParvandeSearch.Controls.Add(this.pnlStep1);
            this.animator1.SetDecoration(this.pnlParvandeSearch, AnimatorNS.DecorationType.None);
            this.pnlParvandeSearch.Location = new System.Drawing.Point(17, 11);
            this.pnlParvandeSearch.Name = "pnlParvandeSearch";
            this.pnlParvandeSearch.Size = new System.Drawing.Size(975, 480);
            // 
            // 
            // 
            this.pnlParvandeSearch.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlParvandeSearch.Style.BackColorGradientAngle = 90;
            this.pnlParvandeSearch.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlParvandeSearch.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlParvandeSearch.Style.BorderBottomWidth = 1;
            this.pnlParvandeSearch.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlParvandeSearch.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlParvandeSearch.Style.BorderLeftWidth = 1;
            this.pnlParvandeSearch.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlParvandeSearch.Style.BorderRightWidth = 1;
            this.pnlParvandeSearch.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlParvandeSearch.Style.BorderTopWidth = 1;
            this.pnlParvandeSearch.Style.Class = "";
            this.pnlParvandeSearch.Style.CornerDiameter = 4;
            this.pnlParvandeSearch.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlParvandeSearch.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlParvandeSearch.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlParvandeSearch.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlParvandeSearch.StyleMouseDown.Class = "";
            this.pnlParvandeSearch.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlParvandeSearch.StyleMouseOver.Class = "";
            this.pnlParvandeSearch.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlParvandeSearch.TabIndex = 3;
            this.pnlParvandeSearch.Text = "انجام طـــلاق";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.lblStatus, AnimatorNS.DecorationType.None);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStatus.Location = new System.Drawing.Point(11, 418);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(827, 36);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.animator1.SetDecoration(this.buttonX3, AnimatorNS.DecorationType.None);
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonX3.Image = ((System.Drawing.Image)(resources.GetObject("buttonX3.Image")));
            this.buttonX3.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX3.Location = new System.Drawing.Point(844, 418);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(116, 36);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 20;
            this.buttonX3.Tag = "1";
            this.buttonX3.Text = "مرحله بعدی";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // pnlStep2
            // 
            this.pnlStep2.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlStep2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlStep2.Controls.Add(this.rdoNewFamily);
            this.pnlStep2.Controls.Add(this.rdoSearchFamily);
            this.pnlStep2.Controls.Add(this.label2);
            this.pnlStep2.Controls.Add(this.pnlStep2_2);
            this.pnlStep2.Controls.Add(this.pnlStep2_1);
            this.animator1.SetDecoration(this.pnlStep2, AnimatorNS.DecorationType.None);
            this.pnlStep2.Location = new System.Drawing.Point(11, 36);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(949, 346);
            this.pnlStep2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlStep2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlStep2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlStep2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlStep2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlStep2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlStep2.Style.GradientAngle = 90;
            this.pnlStep2.TabIndex = 24;
            this.pnlStep2.Visible = false;
            // 
            // rdoNewFamily
            // 
            this.rdoNewFamily.AutoSize = true;
            this.animator1.SetDecoration(this.rdoNewFamily, AnimatorNS.DecorationType.None);
            this.rdoNewFamily.Location = new System.Drawing.Point(440, 56);
            this.rdoNewFamily.Name = "rdoNewFamily";
            this.rdoNewFamily.Size = new System.Drawing.Size(81, 18);
            this.rdoNewFamily.TabIndex = 26;
            this.rdoNewFamily.Text = "خانوار جدید";
            this.rdoNewFamily.UseVisualStyleBackColor = true;
            // 
            // rdoSearchFamily
            // 
            this.rdoSearchFamily.AutoSize = true;
            this.rdoSearchFamily.Checked = true;
            this.animator1.SetDecoration(this.rdoSearchFamily, AnimatorNS.DecorationType.None);
            this.rdoSearchFamily.Location = new System.Drawing.Point(830, 54);
            this.rdoSearchFamily.Name = "rdoSearchFamily";
            this.rdoSearchFamily.Size = new System.Drawing.Size(104, 18);
            this.rdoSearchFamily.TabIndex = 26;
            this.rdoSearchFamily.TabStop = true;
            this.rdoSearchFamily.Text = "جستجوی خانوار";
            this.rdoSearchFamily.UseVisualStyleBackColor = true;
            this.rdoSearchFamily.CheckedChanged += new System.EventHandler(this.rdoSearchFamily_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label2, AnimatorNS.DecorationType.None);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(377, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(560, 30);
            this.label2.TabIndex = 23;
            this.label2.Text = "مرحله 3 : خانواری که مطلقه در آن عضو خواهد شد را انتخاب نمایید";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep2_2
            // 
            this.pnlStep2_2.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlStep2_2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlStep2_2.Controls.Add(this.label19);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddAdress);
            this.pnlStep2_2.Controls.Add(this.label18);
            this.pnlStep2_2.Controls.Add(this.cmbParvandeAddCityOrVillage);
            this.pnlStep2_2.Controls.Add(this.cmbParvandeAddMalekiat);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddShomareSakhteman);
            this.pnlStep2_2.Controls.Add(this.label15);
            this.pnlStep2_2.Controls.Add(this.label16);
            this.pnlStep2_2.Controls.Add(this.label17);
            this.pnlStep2_2.Controls.Add(this.label13);
            this.pnlStep2_2.Controls.Add(this.schParvandeAddPstalCode);
            this.pnlStep2_2.Controls.Add(this.cmbParvandeAddFamilyType);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddTell2);
            this.pnlStep2_2.Controls.Add(this.label10);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddTell1);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddPostalCode);
            this.pnlStep2_2.Controls.Add(this.label8);
            this.pnlStep2_2.Controls.Add(this.label9);
            this.pnlStep2_2.Controls.Add(this.label11);
            this.pnlStep2_2.Controls.Add(this.txtParvandeAddFamilyNumber);
            this.pnlStep2_2.Controls.Add(this.label12);
            this.animator1.SetDecoration(this.pnlStep2_2, AnimatorNS.DecorationType.None);
            this.pnlStep2_2.Enabled = false;
            this.pnlStep2_2.Location = new System.Drawing.Point(11, 80);
            this.pnlStep2_2.Name = "pnlStep2_2";
            this.pnlStep2_2.Size = new System.Drawing.Size(510, 255);
            this.pnlStep2_2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlStep2_2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlStep2_2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlStep2_2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlStep2_2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlStep2_2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlStep2_2.Style.GradientAngle = 90;
            this.pnlStep2_2.TabIndex = 27;
            // 
            // pnlStep2_1
            // 
            this.pnlStep2_1.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlStep2_1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlStep2_1.Controls.Add(this.lblLastFamilyTell);
            this.pnlStep2_1.Controls.Add(this.lblLastFamilyHeaderName);
            this.pnlStep2_1.Controls.Add(this.label7);
            this.pnlStep2_1.Controls.Add(this.lblLastFamilyOwner);
            this.pnlStep2_1.Controls.Add(this.label6);
            this.pnlStep2_1.Controls.Add(this.lblLastFamilyFamilyType);
            this.pnlStep2_1.Controls.Add(this.label5);
            this.pnlStep2_1.Controls.Add(this.label4);
            this.pnlStep2_1.Controls.Add(this.cmbParvandeAddNesbat);
            this.pnlStep2_1.Controls.Add(this.label14);
            this.pnlStep2_1.Controls.Add(this.buttonX1);
            this.pnlStep2_1.Controls.Add(this.label3);
            this.pnlStep2_1.Controls.Add(this.txtActionFamilySecondSearch);
            this.animator1.SetDecoration(this.pnlStep2_1, AnimatorNS.DecorationType.None);
            this.pnlStep2_1.Location = new System.Drawing.Point(529, 78);
            this.pnlStep2_1.Name = "pnlStep2_1";
            this.pnlStep2_1.Size = new System.Drawing.Size(410, 257);
            this.pnlStep2_1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlStep2_1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlStep2_1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlStep2_1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlStep2_1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlStep2_1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlStep2_1.Style.GradientAngle = 90;
            this.pnlStep2_1.TabIndex = 25;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.animator1.SetDecoration(this.buttonX1, AnimatorNS.DecorationType.None);
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.buttonX1.Image = global::Shahab.Offline.WinUI.Properties.Resources.search_70;
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX1.Location = new System.Drawing.Point(50, 15);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(82, 27);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 19;
            this.buttonX1.Text = "جستجو";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label3, AnimatorNS.DecorationType.None);
            this.label3.Location = new System.Drawing.Point(313, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "شماره پرونده :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtActionFamilySecondSearch
            // 
            // 
            // 
            // 
            this.txtActionFamilySecondSearch.Border.Class = "TextBoxBorder";
            this.txtActionFamilySecondSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtActionFamilySecondSearch, AnimatorNS.DecorationType.None);
            this.txtActionFamilySecondSearch.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtActionFamilySecondSearch, true);
            this.txtActionFamilySecondSearch.Location = new System.Drawing.Point(138, 16);
            this.txtActionFamilySecondSearch.MaxLength = 7;
            this.txtActionFamilySecondSearch.Name = "txtActionFamilySecondSearch";
            this.txtActionFamilySecondSearch.Size = new System.Drawing.Size(169, 22);
            this.txtActionFamilySecondSearch.TabIndex = 17;
            this.txtActionFamilySecondSearch.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtActionFamilySecondSearch.WatermarkText = "مثال : 235";
            // 
            // pnlStep1
            // 
            this.pnlStep1.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlStep1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlStep1.Controls.Add(this.label1);
            this.pnlStep1.Controls.Add(this.buttonX14);
            this.pnlStep1.Controls.Add(this.txtActionFirstFamilySearch);
            this.pnlStep1.Controls.Add(this.label46);
            this.pnlStep1.Controls.Add(this.dgvActionTalagh);
            this.animator1.SetDecoration(this.pnlStep1, AnimatorNS.DecorationType.None);
            this.pnlStep1.Location = new System.Drawing.Point(11, 3);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(949, 412);
            this.pnlStep1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlStep1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlStep1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlStep1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlStep1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlStep1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlStep1.Style.GradientAngle = 90;
            this.pnlStep1.TabIndex = 23;
            this.pnlStep1.Text = "panelEx1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label1, AnimatorNS.DecorationType.None);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(377, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 36);
            this.label1.TabIndex = 23;
            this.label1.Text = "مرحله 1 : لطفا شخصی که مطلقه است را انتخاب نمایید (شخصی که میخواد از خانواده برود" +
    ")";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonX14
            // 
            this.buttonX14.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX14.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.animator1.SetDecoration(this.buttonX14, AnimatorNS.DecorationType.None);
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
            // txtActionFirstFamilySearch
            // 
            // 
            // 
            // 
            this.txtActionFirstFamilySearch.Border.Class = "TextBoxBorder";
            this.txtActionFirstFamilySearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtActionFirstFamilySearch, AnimatorNS.DecorationType.None);
            this.txtActionFirstFamilySearch.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtActionFirstFamilySearch, true);
            this.txtActionFirstFamilySearch.Location = new System.Drawing.Point(118, 15);
            this.txtActionFirstFamilySearch.MaxLength = 7;
            this.txtActionFirstFamilySearch.Name = "txtActionFirstFamilySearch";
            this.txtActionFirstFamilySearch.Size = new System.Drawing.Size(169, 22);
            this.txtActionFirstFamilySearch.TabIndex = 17;
            this.txtActionFirstFamilySearch.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtActionFirstFamilySearch.WatermarkText = "مثال : 235";
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label46, AnimatorNS.DecorationType.None);
            this.label46.Location = new System.Drawing.Point(293, 15);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 20);
            this.label46.TabIndex = 0;
            this.label46.Text = "شماره پرونده :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvActionTalagh
            // 
            this.dgvActionTalagh.AllowUserToAddRows = false;
            this.dgvActionTalagh.AllowUserToDeleteRows = false;
            this.dgvActionTalagh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActionTalagh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvActionTalagh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActionTalagh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.NationalCode,
            this.BirthDate,
            this.MobileNumber,
            this.MemberID});
            this.animator1.SetDecoration(this.dgvActionTalagh, AnimatorNS.DecorationType.None);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActionTalagh.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvActionTalagh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvActionTalagh.HighlightSelectedColumnHeaders = false;
            this.dgvActionTalagh.Location = new System.Drawing.Point(8, 49);
            this.dgvActionTalagh.MultiSelect = false;
            this.dgvActionTalagh.Name = "dgvActionTalagh";
            this.dgvActionTalagh.ReadOnly = true;
            this.dgvActionTalagh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActionTalagh.Size = new System.Drawing.Size(934, 354);
            this.dgvActionTalagh.TabIndex = 10;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "نام";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "نام خانوادگی";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // NationalCode
            // 
            this.NationalCode.HeaderText = "کد ملی";
            this.NationalCode.Name = "NationalCode";
            this.NationalCode.ReadOnly = true;
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "سن";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // MobileNumber
            // 
            this.MobileNumber.HeaderText = "تلفن همراه";
            this.MobileNumber.Name = "MobileNumber";
            this.MobileNumber.ReadOnly = true;
            // 
            // MemberID
            // 
            this.MemberID.HeaderText = "کد شخص";
            this.MemberID.Name = "MemberID";
            this.MemberID.ReadOnly = true;
            this.MemberID.Visible = false;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // animator1
            // 
            this.animator1.AnimationType = AnimatorNS.AnimationType.HorizSlide;
            this.animator1.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.animator1.DefaultAnimation = animation3;
            this.animator1.Interval = 3;
            // 
            // cmbParvandeAddNesbat
            // 
            this.cmbParvandeAddNesbat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.animator1.SetDecoration(this.cmbParvandeAddNesbat, AnimatorNS.DecorationType.None);
            this.cmbParvandeAddNesbat.DisplayMember = "Text";
            this.cmbParvandeAddNesbat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParvandeAddNesbat.Enabled = false;
            this.cmbParvandeAddNesbat.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbParvandeAddNesbat, true);
            this.cmbParvandeAddNesbat.ItemHeight = 16;
            this.cmbParvandeAddNesbat.Location = new System.Drawing.Point(10, 215);
            this.cmbParvandeAddNesbat.Name = "cmbParvandeAddNesbat";
            this.cmbParvandeAddNesbat.Size = new System.Drawing.Size(268, 22);
            this.cmbParvandeAddNesbat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParvandeAddNesbat.TabIndex = 73;
            this.cmbParvandeAddNesbat.Tag = "Valid";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label14, AnimatorNS.DecorationType.None);
            this.label14.Location = new System.Drawing.Point(284, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 22);
            this.label14.TabIndex = 72;
            this.label14.Text = "نسبت با سرپرست :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label4, AnimatorNS.DecorationType.None);
            this.label4.Location = new System.Drawing.Point(232, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 22);
            this.label4.TabIndex = 74;
            this.label4.Text = "نوع خانوار :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label5, AnimatorNS.DecorationType.None);
            this.label5.Location = new System.Drawing.Point(232, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 22);
            this.label5.TabIndex = 74;
            this.label5.Text = "نوع مالکیت : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label6, AnimatorNS.DecorationType.None);
            this.label6.Location = new System.Drawing.Point(232, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 22);
            this.label6.TabIndex = 74;
            this.label6.Text = "نام و نام خانوادگی سرپرست : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label7, AnimatorNS.DecorationType.None);
            this.label7.Location = new System.Drawing.Point(232, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 22);
            this.label7.TabIndex = 74;
            this.label7.Text = "همراه سرپرست : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastFamilyFamilyType
            // 
            this.lblLastFamilyFamilyType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLastFamilyFamilyType.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.lblLastFamilyFamilyType, AnimatorNS.DecorationType.None);
            this.lblLastFamilyFamilyType.Location = new System.Drawing.Point(10, 53);
            this.lblLastFamilyFamilyType.Name = "lblLastFamilyFamilyType";
            this.lblLastFamilyFamilyType.Size = new System.Drawing.Size(214, 22);
            this.lblLastFamilyFamilyType.TabIndex = 74;
            this.lblLastFamilyFamilyType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastFamilyOwner
            // 
            this.lblLastFamilyOwner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLastFamilyOwner.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.lblLastFamilyOwner, AnimatorNS.DecorationType.None);
            this.lblLastFamilyOwner.Location = new System.Drawing.Point(10, 92);
            this.lblLastFamilyOwner.Name = "lblLastFamilyOwner";
            this.lblLastFamilyOwner.Size = new System.Drawing.Size(214, 22);
            this.lblLastFamilyOwner.TabIndex = 74;
            this.lblLastFamilyOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastFamilyHeaderName
            // 
            this.lblLastFamilyHeaderName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLastFamilyHeaderName.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.lblLastFamilyHeaderName, AnimatorNS.DecorationType.None);
            this.lblLastFamilyHeaderName.Location = new System.Drawing.Point(10, 133);
            this.lblLastFamilyHeaderName.Name = "lblLastFamilyHeaderName";
            this.lblLastFamilyHeaderName.Size = new System.Drawing.Size(214, 22);
            this.lblLastFamilyHeaderName.TabIndex = 74;
            this.lblLastFamilyHeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastFamilyTell
            // 
            this.lblLastFamilyTell.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLastFamilyTell.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.lblLastFamilyTell, AnimatorNS.DecorationType.None);
            this.lblLastFamilyTell.Location = new System.Drawing.Point(10, 171);
            this.lblLastFamilyTell.Name = "lblLastFamilyTell";
            this.lblLastFamilyTell.Size = new System.Drawing.Size(214, 22);
            this.lblLastFamilyTell.TabIndex = 74;
            this.lblLastFamilyTell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbParvandeAddFamilyType
            // 
            this.animator1.SetDecoration(this.cmbParvandeAddFamilyType, AnimatorNS.DecorationType.None);
            this.cmbParvandeAddFamilyType.DisplayMember = "Text";
            this.cmbParvandeAddFamilyType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParvandeAddFamilyType.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbParvandeAddFamilyType, true);
            this.cmbParvandeAddFamilyType.ItemHeight = 16;
            this.cmbParvandeAddFamilyType.Location = new System.Drawing.Point(270, 150);
            this.cmbParvandeAddFamilyType.Name = "cmbParvandeAddFamilyType";
            this.cmbParvandeAddFamilyType.Size = new System.Drawing.Size(145, 22);
            this.cmbParvandeAddFamilyType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParvandeAddFamilyType.TabIndex = 82;
            // 
            // txtParvandeAddTell2
            // 
            // 
            // 
            // 
            this.txtParvandeAddTell2.BackgroundStyle.Class = "TextBoxBorder";
            this.txtParvandeAddTell2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParvandeAddTell2.ButtonClear.Visible = true;
            this.animator1.SetDecoration(this.txtParvandeAddTell2, AnimatorNS.DecorationType.None);
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddTell2, true);
            this.txtParvandeAddTell2.Location = new System.Drawing.Point(270, 115);
            this.txtParvandeAddTell2.Mask = "\\000-00000000";
            this.txtParvandeAddTell2.Name = "txtParvandeAddTell2";
            this.txtParvandeAddTell2.PromptChar = ' ';
            this.txtParvandeAddTell2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtParvandeAddTell2.Size = new System.Drawing.Size(146, 26);
            this.txtParvandeAddTell2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtParvandeAddTell2.TabIndex = 78;
            this.txtParvandeAddTell2.Tag = "Valid";
            this.txtParvandeAddTell2.Text = "";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label10, AnimatorNS.DecorationType.None);
            this.label10.Location = new System.Drawing.Point(427, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 81;
            this.label10.Text = "تلفن ثابت :";
            // 
            // txtParvandeAddTell1
            // 
            // 
            // 
            // 
            this.txtParvandeAddTell1.BackgroundStyle.Class = "TextBoxBorder";
            this.txtParvandeAddTell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParvandeAddTell1.ButtonClear.Visible = true;
            this.animator1.SetDecoration(this.txtParvandeAddTell1, AnimatorNS.DecorationType.None);
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddTell1, true);
            this.txtParvandeAddTell1.Location = new System.Drawing.Point(20, 115);
            this.txtParvandeAddTell1.Mask = "\\0\\900-0000000";
            this.txtParvandeAddTell1.Name = "txtParvandeAddTell1";
            this.txtParvandeAddTell1.PromptChar = ' ';
            this.txtParvandeAddTell1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtParvandeAddTell1.Size = new System.Drawing.Size(135, 26);
            this.txtParvandeAddTell1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtParvandeAddTell1.TabIndex = 77;
            this.txtParvandeAddTell1.Tag = "Valid";
            this.txtParvandeAddTell1.Text = "";
            // 
            // txtParvandeAddPostalCode
            // 
            // 
            // 
            // 
            this.txtParvandeAddPostalCode.Border.Class = "TextBoxBorder";
            this.txtParvandeAddPostalCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtParvandeAddPostalCode, AnimatorNS.DecorationType.None);
            this.txtParvandeAddPostalCode.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddPostalCode, true);
            this.txtParvandeAddPostalCode.Location = new System.Drawing.Point(20, 81);
            this.txtParvandeAddPostalCode.MaxLength = 10;
            this.txtParvandeAddPostalCode.Name = "txtParvandeAddPostalCode";
            this.txtParvandeAddPostalCode.Size = new System.Drawing.Size(135, 22);
            this.txtParvandeAddPostalCode.TabIndex = 75;
            this.txtParvandeAddPostalCode.Tag = "Valid";
            this.txtParvandeAddPostalCode.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtParvandeAddPostalCode.WatermarkText = "مثال : 3568745214";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label8, AnimatorNS.DecorationType.None);
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.Location = new System.Drawing.Point(176, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "کد پستی : ";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label9, AnimatorNS.DecorationType.None);
            this.label9.Location = new System.Drawing.Point(161, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 79;
            this.label9.Text = "همراه سرپرست :";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label11, AnimatorNS.DecorationType.None);
            this.label11.Location = new System.Drawing.Point(418, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 20);
            this.label11.TabIndex = 76;
            this.label11.Text = "نوع خانوار :";
            // 
            // txtParvandeAddFamilyNumber
            // 
            // 
            // 
            // 
            this.txtParvandeAddFamilyNumber.Border.Class = "TextBoxBorder";
            this.txtParvandeAddFamilyNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtParvandeAddFamilyNumber, AnimatorNS.DecorationType.None);
            this.txtParvandeAddFamilyNumber.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddFamilyNumber, true);
            this.txtParvandeAddFamilyNumber.Location = new System.Drawing.Point(20, 15);
            this.txtParvandeAddFamilyNumber.MaxLength = 5;
            this.txtParvandeAddFamilyNumber.Name = "txtParvandeAddFamilyNumber";
            this.txtParvandeAddFamilyNumber.Size = new System.Drawing.Size(135, 22);
            this.txtParvandeAddFamilyNumber.TabIndex = 73;
            this.txtParvandeAddFamilyNumber.Tag = "Valid";
            this.txtParvandeAddFamilyNumber.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtParvandeAddFamilyNumber.WatermarkText = "مثال : 235";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label12, AnimatorNS.DecorationType.None);
            this.label12.Location = new System.Drawing.Point(167, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 20);
            this.label12.TabIndex = 74;
            this.label12.Text = "شماره خانوار :";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label13, AnimatorNS.DecorationType.None);
            this.label13.Location = new System.Drawing.Point(176, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 20);
            this.label13.TabIndex = 84;
            this.label13.Text = "کد پستی : ";
            // 
            // schParvandeAddPstalCode
            // 
            // 
            // 
            // 
            this.schParvandeAddPstalCode.BackgroundStyle.Class = "";
            this.schParvandeAddPstalCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.schParvandeAddPstalCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animator1.SetDecoration(this.schParvandeAddPstalCode, AnimatorNS.DecorationType.None);
            this.schParvandeAddPstalCode.FocusCuesEnabled = false;
            this.schParvandeAddPstalCode.Font = new System.Drawing.Font("Tahoma", 8F);
            this.schParvandeAddPstalCode.Location = new System.Drawing.Point(20, 47);
            this.schParvandeAddPstalCode.Name = "schParvandeAddPstalCode";
            this.schParvandeAddPstalCode.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.schParvandeAddPstalCode.OffText = "ندارد";
            this.schParvandeAddPstalCode.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.schParvandeAddPstalCode.OnText = "دارد";
            this.schParvandeAddPstalCode.Size = new System.Drawing.Size(135, 22);
            this.schParvandeAddPstalCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.schParvandeAddPstalCode.TabIndex = 83;
            this.schParvandeAddPstalCode.TabStop = false;
            this.schParvandeAddPstalCode.Value = true;
            this.schParvandeAddPstalCode.ValueChanged += new System.EventHandler(this.schParvandeAddPstalCode_ValueChanged);
            // 
            // cmbParvandeAddCityOrVillage
            // 
            this.animator1.SetDecoration(this.cmbParvandeAddCityOrVillage, AnimatorNS.DecorationType.None);
            this.cmbParvandeAddCityOrVillage.DisplayMember = "Text";
            this.cmbParvandeAddCityOrVillage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParvandeAddCityOrVillage.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbParvandeAddCityOrVillage, true);
            this.cmbParvandeAddCityOrVillage.IntegralHeight = false;
            this.cmbParvandeAddCityOrVillage.ItemHeight = 16;
            this.cmbParvandeAddCityOrVillage.Items.AddRange(new object[] {
            this.comboItem1});
            this.cmbParvandeAddCityOrVillage.Location = new System.Drawing.Point(270, 20);
            this.cmbParvandeAddCityOrVillage.Name = "cmbParvandeAddCityOrVillage";
            this.cmbParvandeAddCityOrVillage.Size = new System.Drawing.Size(146, 22);
            this.cmbParvandeAddCityOrVillage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParvandeAddCityOrVillage.TabIndex = 90;
            this.cmbParvandeAddCityOrVillage.WatermarkText = "انتخاب کنید";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Test";
            // 
            // cmbParvandeAddMalekiat
            // 
            this.animator1.SetDecoration(this.cmbParvandeAddMalekiat, AnimatorNS.DecorationType.None);
            this.cmbParvandeAddMalekiat.DisplayMember = "Text";
            this.cmbParvandeAddMalekiat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParvandeAddMalekiat.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbParvandeAddMalekiat, true);
            this.cmbParvandeAddMalekiat.ItemHeight = 16;
            this.cmbParvandeAddMalekiat.Location = new System.Drawing.Point(270, 53);
            this.cmbParvandeAddMalekiat.Name = "cmbParvandeAddMalekiat";
            this.cmbParvandeAddMalekiat.Size = new System.Drawing.Size(146, 22);
            this.cmbParvandeAddMalekiat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParvandeAddMalekiat.TabIndex = 89;
            this.cmbParvandeAddMalekiat.WatermarkText = "انتخاب کنید";
            // 
            // txtParvandeAddShomareSakhteman
            // 
            // 
            // 
            // 
            this.txtParvandeAddShomareSakhteman.Border.Class = "TextBoxBorder";
            this.txtParvandeAddShomareSakhteman.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtParvandeAddShomareSakhteman, AnimatorNS.DecorationType.None);
            this.txtParvandeAddShomareSakhteman.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddShomareSakhteman, true);
            this.txtParvandeAddShomareSakhteman.Location = new System.Drawing.Point(270, 82);
            this.txtParvandeAddShomareSakhteman.MaxLength = 5;
            this.txtParvandeAddShomareSakhteman.Name = "txtParvandeAddShomareSakhteman";
            this.txtParvandeAddShomareSakhteman.Size = new System.Drawing.Size(120, 22);
            this.txtParvandeAddShomareSakhteman.TabIndex = 86;
            this.txtParvandeAddShomareSakhteman.Tag = "Valid";
            this.txtParvandeAddShomareSakhteman.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtParvandeAddShomareSakhteman.WatermarkText = "مثال : 235";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label15, AnimatorNS.DecorationType.None);
            this.label15.Location = new System.Drawing.Point(417, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 20);
            this.label15.TabIndex = 88;
            this.label15.Text = "نوع مالکیت :";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label16, AnimatorNS.DecorationType.None);
            this.label16.Location = new System.Drawing.Point(388, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 87;
            this.label16.Text = "شماره ساختمان : ";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label17, AnimatorNS.DecorationType.None);
            this.label17.Location = new System.Drawing.Point(404, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 20);
            this.label17.TabIndex = 85;
            this.label17.Text = "شهر یا روستا :";
            // 
            // txtParvandeAddAdress
            // 
            // 
            // 
            // 
            this.txtParvandeAddAdress.Border.Class = "TextBoxBorder";
            this.txtParvandeAddAdress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.animator1.SetDecoration(this.txtParvandeAddAdress, AnimatorNS.DecorationType.None);
            this.txtParvandeAddAdress.HideSelection = false;
            this.highlighter1.SetHighlightOnFocus(this.txtParvandeAddAdress, true);
            this.txtParvandeAddAdress.Location = new System.Drawing.Point(20, 184);
            this.txtParvandeAddAdress.Name = "txtParvandeAddAdress";
            this.txtParvandeAddAdress.Size = new System.Drawing.Size(385, 22);
            this.txtParvandeAddAdress.TabIndex = 91;
            this.txtParvandeAddAdress.Tag = "Valid";
            this.txtParvandeAddAdress.WatermarkColor = System.Drawing.SystemColors.ControlDark;
            this.txtParvandeAddAdress.WatermarkText = "مثال : تهران , شهرک غرب , هرمزان , پیروزان جنوبی , کوچه 8 , پلاک 4";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label18, AnimatorNS.DecorationType.None);
            this.label18.Location = new System.Drawing.Point(399, 186);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 20);
            this.label18.TabIndex = 92;
            this.label18.Text = "نشانی خانوار :";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.animator1.SetDecoration(this.label19, AnimatorNS.DecorationType.None);
            this.label19.ForeColor = System.Drawing.Color.Maroon;
            this.label19.Location = new System.Drawing.Point(20, 213);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(475, 22);
            this.label19.TabIndex = 93;
            this.label19.Text = "در صورت موسسه ای نبودن خانوار شخص مورد نظر سرپرست خانوار محصوب میشود";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            this.err.Icon = ((System.Drawing.Icon)(resources.GetObject("err.Icon")));
            // 
            // frmEventTalagh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 510);
            this.Controls.Add(this.pnlParvandeSearch);
            this.animator1.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEventTalagh";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmEventMarriage";
            this.Load += new System.EventHandler(this.frmEventTalagh_Load);
            this.pnlParvandeSearch.ResumeLayout(false);
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.pnlStep2_2.ResumeLayout(false);
            this.pnlStep2_1.ResumeLayout(false);
            this.pnlStep1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionTalagh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlParvandeSearch;
        private DevComponents.DotNetBar.ButtonX buttonX14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtActionFirstFamilySearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvActionTalagh;
        private System.Windows.Forms.Label label46;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private AnimatorNS.Animator animator1;
        private System.Windows.Forms.Label lblStatus;
        private DevComponents.DotNetBar.PanelEx pnlStep1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private DevComponents.DotNetBar.PanelEx pnlStep2;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtActionFamilySecondSearch;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.PanelEx pnlStep2_1;
        private System.Windows.Forms.RadioButton rdoNewFamily;
        private System.Windows.Forms.RadioButton rdoSearchFamily;
        private DevComponents.DotNetBar.PanelEx pnlStep2_2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbParvandeAddNesbat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLastFamilyTell;
        private System.Windows.Forms.Label lblLastFamilyHeaderName;
        private System.Windows.Forms.Label lblLastFamilyOwner;
        private System.Windows.Forms.Label lblLastFamilyFamilyType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbParvandeAddFamilyType;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtParvandeAddTell2;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtParvandeAddTell1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtParvandeAddPostalCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        public DevComponents.DotNetBar.Controls.TextBoxX txtParvandeAddFamilyNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.SwitchButton schParvandeAddPstalCode;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbParvandeAddCityOrVillage;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbParvandeAddMalekiat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtParvandeAddShomareSakhteman;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtParvandeAddAdress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider err;
    }
}