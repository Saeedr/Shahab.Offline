using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Shahab.Offline.BL;
using Shahab.Offline.Logging;
using Shahab.Offline.Model;

namespace Shahab.Offline.WinUI
{
    public partial class frmEventTavalod : Form
    {
        public frmEventTavalod()
        {
            InitializeComponent();
        }

        M_Families FM;

        private void buttonX14_Click(object sender, EventArgs e)
        {
        }

        private void buttonX14_Click_1(object sender, EventArgs e)
        {
            try
            {
                M_Families fm = new M_Families();
                B_GetDatas BG = new B_GetDatas();
                fm = BG.GetFamily(int.Parse(txtActionFirstFamilySearch.Text)).Single();
                label28.Text = "نوع مالکیت خانوار : " + B_ReportPublicCategori.GetPublitCategoriByID(fm.OwnrshipCode).PC_Title + " .:|:. نوع خانوار : " + B_ReportPublicCategori.GetPublitCategoriByID(fm.FamilyTypeCode).PC_Title + " .:|:. شماره خانوار : " + txtActionFirstFamilySearch.Text;
                List<M_FamilyMembers> fmm = new List<M_FamilyMembers>();
                fmm = BG.GetFamilyMember(fm.ID).Where(c => c.MaritalStatus == 31).ToList();
                foreach (M_FamilyMembers fmmm in fmm)
                {
                    fmmm.NameAndFamily = fmmm.FirstName + " " + fmmm.LastName;
                }
                FM = fm;
                comboBoxEx1.DataSource = fmm.Where(c => c.Gender == 11).ToList<M_FamilyMembers>();
                comboBoxEx1.ValueMember = "ID";
                comboBoxEx1.DisplayMember = "NameAndFamily";
                comboBoxEx5.DataSource = fmm.Where(c => c.Gender == 12).ToList<M_FamilyMembers>();
                comboBoxEx5.ValueMember = "ID";
                comboBoxEx5.DisplayMember = "NameAndFamily";
                panelEx2.Enabled = true;
                panelEx3.Enabled = true;
                pnlStep1.Enabled = false;
            }
            catch { label28.Text = "خانواری یافت نشد"; }
        }

        public void Submit()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = @"insert into temp_Tavalod([SaderKonandeName],[SaderKonandeFamily],[SaderKonandePost],[SaderKonandeMahal],
                                [SaderKonandeAddress],[FatherID],[MotherID],[MartabeHamelegi],[TedadGholha],[MartabeGhol],[ghad],[Vazn],[MahalZayeman],[NoZayeman])
                                values('" + textBoxX4.Text + "','" + textBoxX5.Text + "','" + comboBoxEx2.SelectedValue + "','" + textBoxX6.Text + "','" + textBoxX7.Text +
                                "'," + comboBoxEx1.SelectedValue + "," + comboBoxEx5.SelectedValue + ",'" + textBoxX8.Text + "','" + textBoxX9.Text + "','" + textBoxX10.Text +
                                "'," + textBoxX2.Text + "," + textBoxX1.Text + ",'" + comboBoxEx3.SelectedValue + "','" + comboBoxEx4.SelectedValue + "')";
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            string ID = "0";
            cm.CommandText = @"select top 1 ID from temp_Tavalod order by ID Desc";
            cn.Open();
            ID = cm.ExecuteScalar().ToString();
            cn.Close();
            string[] date1 = maskedTextBoxAdv1.Text.Split('/');
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
            string Date = dt1.Year + "-" + dt1.Month + "-" + dt1.Day;
            cm.CommandText = @"insert into temp_Events([FirstName],[LastName],[NationalCode],[BirthDate],[Nationality],[Gender],[FirstInsurance],[SecondInsurance],[Education],
                                [Relationship],[Activity],[Job],[MaritalStatus],[ResidentStatus],[MobileNumber],[FamilyID],[CreateDate],[EventTypeID],[EventDate],[EventID],EventUID)
                                Values('" + txtParvandeAddName.Text + "','" + txtParvandeAddFamily.Text + "','" + txtParvandeAddNationalCode.Text + "','" + Date + "'," + cmbParvandeAddNasionality.SelectedValue +
                                "," + cmbParvandeAddGender.SelectedValue + "," + cmbParvandeAddBime1.SelectedValue + "," + cmbParvandeAddBime2.SelectedValue + ",61," + cmbParvandeAddNesbat.SelectedValue +
                                ",124,123,34," + cmbParvandeAddEghamat.SelectedValue + ",'09'," + FM.ID + ",'" + DateTime.Today + "',126,'" + DateTime.Today + "'," + ID + ",'" + Guid.NewGuid() + "')";
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.CommandText = @"insert into FamilyMembers([FirstName],[LastName],[NationalCode],[BirthDate],[Nationality],[Gender],[FirstInsurance],[SecondInsurance],[Education],
                                [Relationship],[Activity],[Job],[MaritalStatus],[ResidentStatus] ,[MobileNumber],[FamilyID] ,[CreateDate],[FamilyMembersUID])
                                Values('" + txtParvandeAddName.Text + "','" + txtParvandeAddFamily.Text + "','" + txtParvandeAddNationalCode.Text + "','" + Date + "'," + cmbParvandeAddNasionality.SelectedValue +
                                "," + cmbParvandeAddGender.SelectedValue + "," + cmbParvandeAddBime1.SelectedValue + "," + cmbParvandeAddBime2.SelectedValue + ",61," + cmbParvandeAddNesbat.SelectedValue +
                                ",124,123,34," + cmbParvandeAddEghamat.SelectedValue + ",'09'," + FM.ID + ",'" + DateTime.Today + "','" + Guid.NewGuid() + "')";
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void frmEventTavalod_Load(object sender, EventArgs e)
        {
            B_PublicFunctions.AddToCombo(142, comboBoxEx2);
            B_PublicFunctions.AddToCombo(131, comboBoxEx3);
            B_PublicFunctions.AddToCombo(138, comboBoxEx4);
            B_PublicFunctions.AddToCombo(7, cmbParvandeAddNasionality);
            B_PublicFunctions.AddToCombo(10, cmbParvandeAddGender);
            B_PublicFunctions.AddToCombo(35, cmbParvandeAddBime1);
            B_PublicFunctions.AddToCombo(43, cmbParvandeAddBime2);
            B_PublicFunctions.AddToCombo(62, cmbParvandeAddNesbat);
            B_PublicFunctions.AddToCombo(109, cmbParvandeAddEghamat);
        }
    }
}
