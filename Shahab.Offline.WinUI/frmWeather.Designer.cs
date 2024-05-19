namespace Shahab.Offline.WinUI
{
    partial class frmWeather
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
            this.boCityName = new System.Windows.Forms.ComboBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTemp = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblLowTemp = new System.Windows.Forms.Label();
            this.lblHighTemp = new System.Windows.Forms.Label();
            this.lblCurrentConditions = new System.Windows.Forms.Label();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.س = new DevComponents.DotNetBar.PanelEx();
            this.pictureBoxWeatherForecast = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.س.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeatherForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // boCityName
            // 
            this.boCityName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boCityName.FormattingEnabled = true;
            this.boCityName.Items.AddRange(new object[] {
            "Tehran",
            "Shiraz",
            "Tabriz",
            "Esfehan",
            "Rasht",
            "Qazvin",
            "Lahijan",
            "Mazandaran",
            "Slamshahr",
            "Sanandaj",
            "Mashhad"});
            this.boCityName.Location = new System.Drawing.Point(183, 297);
            this.boCityName.Name = "boCityName";
            this.boCityName.Size = new System.Drawing.Size(162, 22);
            this.boCityName.TabIndex = 26;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("B Yekan", 9F);
            this.buttonX1.Image = global::Shahab.Offline.WinUI.Properties.Resources.cross_mark_304374_1280;
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(15, 15);
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX1.Location = new System.Drawing.Point(353, 4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.buttonX1.Size = new System.Drawing.Size(28, 28);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 25;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Location = new System.Drawing.Point(40, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 2);
            this.panel1.TabIndex = 24;
            // 
            // lblCurrentTemp
            // 
            this.lblCurrentTemp.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblCurrentTemp.Location = new System.Drawing.Point(53, 228);
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            this.lblCurrentTemp.Size = new System.Drawing.Size(85, 29);
            this.lblCurrentTemp.TabIndex = 23;
            this.lblCurrentTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHumidity
            // 
            this.lblHumidity.Location = new System.Drawing.Point(183, 237);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(93, 19);
            this.lblHumidity.TabIndex = 22;
            // 
            // lblLowTemp
            // 
            this.lblLowTemp.Location = new System.Drawing.Point(183, 207);
            this.lblLowTemp.Name = "lblLowTemp";
            this.lblLowTemp.Size = new System.Drawing.Size(93, 19);
            this.lblLowTemp.TabIndex = 21;
            // 
            // lblHighTemp
            // 
            this.lblHighTemp.Location = new System.Drawing.Point(183, 176);
            this.lblHighTemp.Name = "lblHighTemp";
            this.lblHighTemp.Size = new System.Drawing.Size(93, 19);
            this.lblHighTemp.TabIndex = 20;
            // 
            // lblCurrentConditions
            // 
            this.lblCurrentConditions.Location = new System.Drawing.Point(183, 146);
            this.lblCurrentConditions.Name = "lblCurrentConditions";
            this.lblCurrentConditions.Size = new System.Drawing.Size(93, 19);
            this.lblCurrentConditions.TabIndex = 19;
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.Class = "";
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Font = new System.Drawing.Font("B Yekan", 20F);
            this.reflectionLabel1.Location = new System.Drawing.Point(10, 39);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reflectionLabel1.Size = new System.Drawing.Size(175, 70);
            this.reflectionLabel1.TabIndex = 18;
            this.reflectionLabel1.Text = "وضعیت آب و هوا";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(285, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "میزان رطوبت :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(285, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "کمینه دمای امروز :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(267, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "بیشینه دمای امروز :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(285, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "آب و هوای فعلی :";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.Font = new System.Drawing.Font("B Yekan", 9F);
            this.buttonX3.ImageFixedSize = new System.Drawing.Size(30, 20);
            this.buttonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX3.Location = new System.Drawing.Point(42, 287);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(115, 43);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 10;
            this.buttonX3.Text = "نمایش";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // س
            // 
            this.س.CanvasColor = System.Drawing.SystemColors.Control;
            this.س.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.س.Controls.Add(this.pictureBoxWeatherForecast);
            this.س.Controls.Add(this.boCityName);
            this.س.Controls.Add(this.buttonX1);
            this.س.Controls.Add(this.panel1);
            this.س.Controls.Add(this.lblCurrentTemp);
            this.س.Controls.Add(this.lblHumidity);
            this.س.Controls.Add(this.lblLowTemp);
            this.س.Controls.Add(this.lblHighTemp);
            this.س.Controls.Add(this.lblCurrentConditions);
            this.س.Controls.Add(this.reflectionLabel1);
            this.س.Controls.Add(this.pictureBox2);
            this.س.Controls.Add(this.label3);
            this.س.Controls.Add(this.label4);
            this.س.Controls.Add(this.label2);
            this.س.Controls.Add(this.label1);
            this.س.Controls.Add(this.buttonX3);
            this.س.Dock = System.Windows.Forms.DockStyle.Fill;
            this.س.Location = new System.Drawing.Point(0, 0);
            this.س.Name = "س";
            this.س.Size = new System.Drawing.Size(384, 351);
            this.س.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.س.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.س.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.س.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.س.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.س.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.س.Style.GradientAngle = 90;
            this.س.TabIndex = 13;
            // 
            // pictureBoxWeatherForecast
            // 
            this.pictureBoxWeatherForecast.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWeatherForecast.Location = new System.Drawing.Point(63, 161);
            this.pictureBoxWeatherForecast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxWeatherForecast.Name = "pictureBoxWeatherForecast";
            this.pictureBoxWeatherForecast.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxWeatherForecast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWeatherForecast.TabIndex = 27;
            this.pictureBoxWeatherForecast.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Shahab.Offline.WinUI.Properties.Resources.Weather;
            this.pictureBox2.Location = new System.Drawing.Point(191, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // frmWeather
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 351);
            this.Controls.Add(this.س);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWeather";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWeather";
            this.Load += new System.EventHandler(this.frmWeather_Load);
            this.س.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeatherForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWeatherForecast;
        private System.Windows.Forms.ComboBox boCityName;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTemp;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblLowTemp;
        private System.Windows.Forms.Label lblHighTemp;
        private System.Windows.Forms.Label lblCurrentConditions;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.PanelEx س;
    }
}