using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shahab.Offline.BL;
using Shahab.Offline.Logging;
using Shahab.Offline.Model;

namespace Shahab.Offline.WinUI
{
    public partial class frmPersonel : Form
    {

        public bool Submit()
        {
            try
            {
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                radioButton3.ForeColor = Color.Black;
                err.Clear();
                if (B_PublicFunctions.CheckTextBox(panelEx1, err) == false)
                {
                    radioButton1.ForeColor = Color.Red;
                    return false;
                }
                if (B_PublicFunctions.IsValidNationalCode(txtInserPersonelNationalCode.Text) == false)
                {
                    radioButton1.ForeColor = Color.Red;
                    err.SetError(txtInserPersonelNationalCode, "این مقدار صحیح نیست");
                    return false;
                }
                if (B_PublicFunctions.IsValidBirthDay(txtInserPersonelBirthDate.Text) == false)
                {
                    radioButton1.ForeColor = Color.Red;
                    err.SetError(txtInserPersonelBirthDate, "این مقدار صحیح نیست");
                    return false;
                }
                if (B_PublicFunctions.CheckTextBox(panelEx2, err) == false)
                {
                    radioButton2.ForeColor = Color.Red;
                    return false;
                }
                if (B_PublicFunctions.IsValidBirthDay(txtInserPersonelWorkStart.Text) == false)
                {
                    radioButton2.ForeColor = Color.Red;
                    err.SetError(txtInserPersonelWorkStart, "این مقدار صحیح نیست");
                    return false;
                }
                if (B_PublicFunctions.IsValidBirthDay(txtInserPersonelLastEduTime.Text) == false)
                {
                    radioButton2.ForeColor = Color.Red;
                    err.SetError(txtInserPersonelLastEduTime, "این مقدار صحیح نیست");
                    return false;
                }

                B_InsertDatas BI = new B_InsertDatas();

                M_Employee emp = new M_Employee();
                emp.CreateDate = DateTime.Today;
                emp.BirthDate = B_PublicFunctions.ConverShamsiToMiladi(txtInserPersonelBirthDate.Text);
                emp.FirstName = txtInserPersonelName.Text;
                emp.Gender = int.Parse(cmbInserPersonelGender.SelectedValue.ToString());
                emp.IsActive = true;
                emp.IsDeleted = false;
                emp.IsSent = false;
                emp.LastName = txtInserPersonelFamily.Text;
                emp.MaritalStatus = int.Parse(cmbInserPersonelMarital.SelectedValue.ToString());
                emp.NationalCode = txtInserPersonelNationalCode.Text;
                emp.OfficialCode = txtInserPersonelNezamNum.Text;
                emp.UserCode = txtInserPersonelEstekhdamNum.Text;
                emp.UserDescription = txtInserPersonelDescription.Text;
                System.IO.MemoryStream mStrim = new System.IO.MemoryStream();
                pictureBox1.Image.Save(mStrim, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] data = mStrim.ToArray();
                emp.Picture = data;

                M_EmployeeExprience empi = new M_EmployeeExprience();
                empi.AcceptableYears = int.Parse(txtInserPersonelSanavat.Text);
                empi.CreateDate = DateTime.Today;
                empi.Degree = int.Parse(cmbInserPersonelEducation.SelectedValue.ToString());
                empi.EmploymentType = int.Parse(cmbInserPersonelNoeEstekhdam.SelectedValue.ToString());
                empi.IsActive = true;
                empi.IsDeleted = false;
                empi.IsSent = true;
                empi.JobGrade = int.Parse(cmbInserPersonelReste.SelectedValue.ToString());
                empi.LastCertificateDate = B_PublicFunctions.ConverShamsiToMiladi(txtInserPersonelLastEduTime.Text);
                empi.OrganizationalPostTitle = int.Parse(cmbInserPersonelPostTitleSazmani.SelectedValue.ToString());
                empi.OrganizationalUnit = int.Parse(cmbInserPersonelVahed.SelectedValue.ToString());
                empi.Post = int.Parse(cmbInserPersonelSemat.SelectedValue.ToString());
                empi.Salary = long.Parse(txtInserPersonelSalary.Text);
                empi.ServicePostPlace = int.Parse(cmbInserPersonelPost.SelectedValue.ToString());
                empi.ServicePostPlace2 = int.Parse(cmbInserPersonelPost2.SelectedValue.ToString());
                empi.ServiceUnitPlace = int.Parse(cmbInserPersonelMahaleKhedmat.SelectedValue.ToString());
                empi.StartDate = B_PublicFunctions.ConverShamsiToMiladi(txtInserPersonelWorkStart.Text);

                M_EmployeeEducationalInformation empii = new M_EmployeeEducationalInformation();
                try { empii.CertificationTypeCode = int.Parse(cmbInserPersonelNoeGovahi.SelectedValue.ToString()); }
                catch { }
                try { empii.CourceDurationTime = int.Parse(txtInserPersonelDoreLen.Text.Replace("ساعت ", "")); }
                catch { }
                try
                {
                    if (B_PublicFunctions.IsValidBirthDay(txtInserPersonelDoreStart.Text) == true)
                        empii.CourseStartTime = B_PublicFunctions.ConverShamsiToMiladi(txtInserPersonelDoreStart.Text);
                }
                catch { };
                try { empii.EducationalInformationDescription = txtInserPersonelEduDescription.Text; }
                catch { };
                empii.CourseTitle = txtInserPersonelOnvaneDore.Text;
                empii.CreateDate = DateTime.Today;
                empii.IsActive = true;
                empii.IsDeleted = false;
                empii.IsSent = false;
                BI.InsertEmployee(emp, empi, empii);

                frmMessage msg = new frmMessage();
                msg.label1.Text = "عملیات با موفقیت انجارم شد";
                msg.ShowDialog();
                return true;
            }
            catch(Exception Ex)
            {
                L_ErrorLogs.Errors(Ex.Message);
                return false ;
            }
        }

        public frmPersonel()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panelEx1.Visible = true;
                panelEx2.Visible = false;
                panelEx3.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panelEx2.Visible = true;
                panelEx1.Visible = false;
                panelEx3.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                panelEx3.Visible = true;
                panelEx2.Visible = false;
                panelEx1.Visible = false;
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files|*.jpg|PNG Files|*.png|Gif Files|*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            B_PublicFunctions.AddToCombo(10, cmbInserPersonelGender, new int[] { });
            B_PublicFunctions.AddToCombo(29, cmbInserPersonelMarital, new int[] { 34 });
            B_PublicFunctions.AddToCombo(51, cmbInserPersonelEducation, new int[] { 61 });
            B_PublicFunctions.AddToCombo(146, cmbInserPersonelReste, new int[] { });
            B_PublicFunctions.AddToCombo(162, cmbInserPersonelVahed, new int[] { });
            B_PublicFunctions.AddToCombo(162, cmbInserPersonelMahaleKhedmat, new int[] { });
            B_PublicFunctions.AddToCombo(173, cmbInserPersonelPost, new int[] { 205, 206 });
            B_PublicFunctions.AddToCombo(173, cmbInserPersonelPost2, new int[] { 174, 175 });
            B_PublicFunctions.AddToCombo(146, cmbInserPersonelPostTitleSazmani, new int[] { });
            B_PublicFunctions.AddToCombo(176, cmbInserPersonelSemat, new int[] { });
            B_PublicFunctions.AddToCombo(192, cmbInserPersonelNoeEstekhdam, new int[] { });
            B_PublicFunctions.AddToCombo(207, cmbInserPersonelNoeGovahi, new int[] { });
            dgvParvandeAddPerson1.Rows.Clear();
            B_GetDatas BG = new B_GetDatas();
            List<M_Employee> em = BG.GetEmployee();
            foreach(M_Employee li in em)
            {
                dgvParvandeAddPerson1.Rows.Add(li.FirstName, li.LastName, li.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(li.Gender).PC_Title);
            }
        }

        private void txtInserPersonelEstekhdamNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
