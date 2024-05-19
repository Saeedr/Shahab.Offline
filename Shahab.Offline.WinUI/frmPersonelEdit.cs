using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Shahab.Offline.BL;
using Shahab.Offline.Logging;
using Shahab.Offline.Model;
using System.Globalization;

namespace Shahab.Offline.WinUI
{
    public partial class frmPersonelEdit : Form
    {

        public bool Submit()
        {
            try
            {
                if (dgvParvandeAddPerson1.SelectedRows.Count != 0)
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

                    B_UpdateDatas BI = new B_UpdateDatas();

                    M_Employee emp = new M_Employee();
                    emp.BirthDate = B_PublicFunctions.ConverShamsiToMiladi(txtInserPersonelBirthDate.Text);
                    emp.FirstName = txtInserPersonelName.Text;
                    emp.Gender = int.Parse(cmbInserPersonelGender.SelectedValue.ToString());
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
                    empi.Degree = int.Parse(cmbInserPersonelEducation.SelectedValue.ToString());
                    empi.EmploymentType = int.Parse(cmbInserPersonelNoeEstekhdam.SelectedValue.ToString());
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

                    int ID = int.Parse(dgvParvandeAddPerson1.SelectedRows[0].Cells["ID"].Value.ToString());

                    BI.UpdateEmployee(emp, empi, empii, ID);

                    frmMessage msg = new frmMessage();
                    msg.label1.Text = "عملیات با موفقیت انجام شد";
                    msg.ShowDialog();
                    return true;
                }
                else
                {
                    frmMessage msg = new frmMessage();
                    msg.label1.Text = "فردی را انتخاب نمایید";
                    msg.ShowDialog();
                    return false;
                }
            }
            catch (Exception Ex)
            {
                L_ErrorLogs.Errors(Ex.Message);
                return false;
            }
        }

        private string DateFormat(DateTime Dt)
        {
            PersianCalendar pc = new PersianCalendar();
            string Come = pc.GetYear(Dt) + "/" + pc.GetMonth(Dt) + "/" + pc.GetDayOfMonth(Dt);
            string[] s = Come.Split('/');
            if (s[1].Length == 1)
                s[1] = "0" + s[1];
            if (s[2].Length == 1)
                s[2] = "0" + s[2];
            return s[0] + s[1] + s[2]; 
        }

        public frmPersonelEdit()
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtDeletePersonelSearch.Text != "")
            {
                dgvParvandeAddPerson1.Rows.Clear();
                B_GetDatas BG = new B_GetDatas();
                List<M_Employee> em = BG.GetEmployee().Where(c => c.UserCode.Trim() == txtDeletePersonelSearch.Text.Trim()).ToList();
                foreach (M_Employee li in em)
                {
                        dgvParvandeAddPerson1.Rows.Add(li.ID, li.FirstName, li.LastName, li.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(li.Gender).PC_Title);
                }
                dgvParvandeAddPerson1_Click(null, null);
            }
            else
            {
                frmPersonelEdit_Load(null, null);
            }
        }

        private void frmPersonelEdit_Load(object sender, EventArgs e)
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
            foreach (M_Employee li in em)
            {
                    dgvParvandeAddPerson1.Rows.Add(li.ID, li.FirstName, li.LastName, li.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(li.Gender).PC_Title);
            }
            dgvParvandeAddPerson1_Click(null, null);
        }

        private void dgvParvandeAddPerson1_Click(object sender, EventArgs e)
        {
            if (dgvParvandeAddPerson1.SelectedRows.Count == 1)
            {
                int id = int.Parse(dgvParvandeAddPerson1.SelectedRows[0].Cells["ID"].Value.ToString());
                B_GetDatas BG = new B_GetDatas();
                M_Employee em = BG.GetEmployee().Where(c => c.ID == id).Single();
                byte[] data = em.Picture;
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(data));
                txtInserPersonelBirthDate.Text = DateFormat(em.BirthDate);
                txtInserPersonelEstekhdamNum.Text = em.UserCode;
                txtInserPersonelFamily.Text = em.LastName;
                txtInserPersonelName.Text = em.FirstName;
                txtInserPersonelNationalCode.Text = em.NationalCode;
                txtInserPersonelNezamNum.Text = em.OfficialCode;
                cmbInserPersonelMarital.Text = B_ReportPublicCategori.GetPublitCategoriByID(em.MaritalStatus).PC_Title;
                cmbInserPersonelGender.Text = B_ReportPublicCategori.GetPublitCategoriByID(em.Gender).PC_Title;
                txtInserPersonelDescription.Text = em.UserDescription;

                M_EmployeeExprience eme = BG.GetEmployeeExprience().Where(c => c.EmployeeID == id).Single();
                cmbInserPersonelEducation.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.Degree).PC_Title;
                cmbInserPersonelMahaleKhedmat.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.ServiceUnitPlace).PC_Title;
                cmbInserPersonelNoeEstekhdam.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.EmploymentType).PC_Title;
                cmbInserPersonelPost.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.ServicePostPlace).PC_Title;
                cmbInserPersonelPost2.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.ServicePostPlace2).PC_Title;
                cmbInserPersonelPostTitleSazmani.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.OrganizationalPostTitle).PC_Title;
                cmbInserPersonelReste.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.JobGrade).PC_Title;
                cmbInserPersonelSemat.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.Post).PC_Title;
                cmbInserPersonelVahed.Text = B_ReportPublicCategori.GetPublitCategoriByID(eme.OrganizationalUnit).PC_Title;
                txtInserPersonelSalary.Text = eme.Salary.ToString();
                txtInserPersonelWorkStart.Text = DateFormat(eme.StartDate);
                if (eme.LastCertificateDate.HasValue)
                    txtInserPersonelLastEduTime.Text = DateFormat(eme.LastCertificateDate.Value);
                txtInserPersonelSanavat.Text = eme.AcceptableYears.ToString();
                try
                {
                    txtInserPersonelOnvaneDore.Text = "";
                    txtInserPersonelDoreStart.Text = "";
                    txtInserPersonelDoreLen.Text = "";
                    cmbInserPersonelNoeGovahi.Text = "";
                    txtInserPersonelEduDescription.Text = "";
                    M_EmployeeEducationalInformation emei = BG.GetEmployeeEducationalInformation().Where(c => c.EmployeeID == id).Single();
                    txtInserPersonelOnvaneDore.Text = emei.CourseTitle;
                    if (eme.LastCertificateDate.HasValue)
                    {
                        DateTime dt = emei.CourseStartTime.Value;
                        txtInserPersonelDoreStart.Text = DateFormat(dt);
                    }
                    txtInserPersonelDoreLen.Text = emei.CourceDurationTime.ToString();
                    if (emei.CertificationTypeCode.HasValue)
                        cmbInserPersonelNoeGovahi.Text = B_ReportPublicCategori.GetPublitCategoriByID(emei.CertificationTypeCode.Value).PC_Title;
                    txtInserPersonelEduDescription.Text = emei.EducationalInformationDescription;
                }
                catch { }
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
    }
}
