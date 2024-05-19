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
using System.Data.SqlClient;

namespace Shahab.Offline.WinUI
{
    public partial class frmEventMotherDeath : Form
    {

        public M_FamilyMembers Person;

        public frmEventMotherDeath()
        {
            InitializeComponent();
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            panelEx1.Enabled = false;
            if(txtActionFirstFamilySearch.Text!="")
            {
                B_GetDatas BG = new B_GetDatas();
                List<M_FamilyMembers> FMem = new List<M_FamilyMembers>();
                List<M_Families> Fm = BG.GetFamily(int.Parse(txtActionFirstFamilySearch.Text));
                if (Fm.Count > 1)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "بیش از یک خانوار با این شماره پرونده وجود دارد , لطفا شماره خانوار را تصحیح و مجددا سعی نمایید";
                    msg.ShowDialog();
                    return;
                }
                if (Fm.Count == 0)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "خانواری با این شماره پرونده یافت نشد";
                    msg.ShowDialog();
                    return;
                }

                B_GetDatas bg = new B_GetDatas();
                M_Families fm2 = bg.GetFamily().Where(c => c.ID == Fm.Single().ID).Single<M_Families>();
                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fm2.ID);
                frm.Tag = "Edit";
                frm.FamilyCode = Fm.Single().ID;
                frm.ThisFamily = fm2;
                frm.Width = 0;
                frm.Height = 0;
                frm.Show();
                int Counter = 0;
                foreach (DataGridViewRow rw in frm.dgvParvandeAddPerson.Rows)
                {
                    if (rw.DefaultCellStyle.BackColor == Color.LightPink)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "اطلاعات اعضای خانوار شما مشکل دارد , لطفا آنهارا تصحیح و مجددا سعی نمایید";
                        frm.Close();
                        msg.ShowDialog();
                        return;
                    }
                    if (fm2.FamilyTypeCode == 84 && rw.Cells["NesbatID"].Value.ToString() != "")
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "این خانوار موسسه ای است و نسبت با سرپرست دارد , لطفا مورد را تصحیح و مجددا سعی نمایید";
                        frm.Close();
                        msg.ShowDialog();
                        return;
                    }
                    if (rw.Cells["NesbatID"].Value.ToString() == "63")
                        Counter++;
                }
                frm.Close();
                if (Counter > 1)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "این خانوار بیش از یک سرپرست دارد , لطفا به مورد رسیدگی و مجددا سعی نمایید";
                    msg.ShowDialog();
                    return;
                }
                FMem = BG.GetFamilyMember(Fm.Single().ID);
                dgvActionDead.Rows.Clear();
                foreach (M_FamilyMembers fm in FMem)
                {
                    dgvActionDead.Rows.Add(fm.FirstName, fm.LastName, fm.NationalCode, Math.Round(((DateTime.Today - fm.BirthDate).TotalDays / 365)) + " سال", fm.MobileNumber, fm.ID);
                }
            }
            else if (txtActionTalaghNationalCodeSearch.Text != "")
            {
                B_GetDatas bg = new B_GetDatas();
                M_FamilyMembers fmm = bg.GetFamilyMember(txtActionTalaghNationalCodeSearch.Text);
                dgvActionDead.Rows.Clear();
                if (fmm != null)
                {
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string Date = pc.GetYear(fmm.BirthDate).ToString() + "/" + pc.GetMonth(fmm.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm.BirthDate).ToString();
                    dgvActionDead.Rows.Add(fmm.FirstName, fmm.LastName, fmm.NationalCode, Date, fmm.MobileNumber, fmm.ID);
                }
            }
        }

        private void txtActionTalaghNationalCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dgvActionDead_DoubleClick(object sender, EventArgs e)
        {
            if (dgvActionDead.SelectedRows.Count == 1)
            {
                B_GetDatas bg = new B_GetDatas();
                Person = bg.GetFamilyMember(int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString()), "None");
                if (Person != null)
                {
                    panelEx1.Enabled = true;
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string Date = pc.GetYear(Person.BirthDate).ToString() + "/" + pc.GetMonth(Person.BirthDate).ToString() + "/" + pc.GetDayOfMonth(Person.BirthDate).ToString();
                    label2.Text = "نام و نام خانوادگی : " + Person.FirstName + " " + Person.LastName + " .::. تاریخ تولد : " + Date + " .::. جنسیت : " + B_ReportPublicCategori.GetPublitCategoriByID(Person.Gender).PC_Title + " .::. نسبت با سرپرست : " + B_ReportPublicCategori.GetPublitCategoriByID(Person.Relationship).PC_Title;
                }
            }
        }

        private void rdoActionDeadOld_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActionDeadOld.Checked == true)
            {
                pnlStep1.Visible = true;
                panelEx4.Visible = false;
            }
            else
            {
                pnlStep1.Visible = false;
                panelEx4.Visible = true;
            }
        }

        public void Submit()
        {
            if (rdoActionDeadOld.Checked == true)
            {
                M_FamilyMembers fm = new M_FamilyMembers();
                B_GetDatas BG = new B_GetDatas();
                B_DeleteDatas BD = new B_DeleteDatas();
                fm = BG.GetFamilyMember(int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString()), "None");
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;

                string[] date1 = txtParvandeAddBirthDay.Text.Split('/');
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                string Date = dt1.Year + "-" + dt1.Month + "-" + dt1.Day;
                date1 = maskedTextBoxAdv1.Text.Split('/');
                dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                string Date2 = dt1.Year + "-" + dt1.Month + "-" + dt1.Day;

                string D = "";
                //if (comboBoxEx15.Text != "")
                //    D = comboBoxEx15.Text;
                //else
                //    D = comboBoxEx1.Text;

                cm.CommandText = @"insert into temp_Dead([DeadDate],[ShomareShenasname],[MahaleSodor],[FatherName],[ShomareParvaneGheirIrani],[VaziateShenasname],[Mother]
                                  ,[MakaneFot],[VaziateBardari],[Discription1],[DiscriptionID1],[Discription2],[DiscriptionID2],[Discription3],[DiscriptionID3]
                                  ,[Discription4],[DiscriptionID4],[Discription5],[DiscriptionID5],[Discription6],[DiscriptionID6],[SaderKonande],[NameMosese]
                                  ,[ShomareNezamPezeshki],[TarikhSodor],[NoeMarg],[ElateMarg])
                                    Values('" + Date + "','" + textBoxX4.Text + "','" + textBoxX2.Text + "','" + textBoxX3.Text + "','" + textBoxX5.Text + "','" + comboBoxEx2.Text + "','" + comboBoxEx3.Text
                                    + "','" + comboBoxEx4.Text + "','" + comboBoxEx10.Text + "','" + textBoxX9.Text + "','" + textBoxX13.Text + "','" + textBoxX10.Text + "','" + textBoxX14.Text + "','" + textBoxX11.Text
                                    + "','" + textBoxX15.Text + "','" + textBoxX12.Text + "','" + textBoxX16.Text + "','" + textBoxX20.Text + "','" + textBoxX18.Text + "','" + textBoxX19.Text + "','" + textBoxX17.Text +
                                    "','" + textBoxX6.Text + "','" + textBoxX8.Text + "','" + textBoxX7.Text + "','" + Date2 + "',1,'" + D + "')";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                string ID = "0";
                cm.CommandText = @"select top 1 ID from temp_Dead order by ID Desc";
                cn.Open();
                ID = cm.ExecuteScalar().ToString();
                cn.Close();
                cm.CommandText = @"insert into temp_Events([FirstName],[LastName],[NationalCode],[BirthDate],[Nationality],[Gender],[FirstInsurance],[SecondInsurance],[Education],
                                [Relationship],[Activity],[Job],[MaritalStatus],[ResidentStatus],[MobileNumber],[FamilyID],[CreateDate],[EventTypeID],[EventDate],[EventID],EventUID)
                                Values('" + fm.FirstName + "','" + fm.LastName + "','" + fm.NationalCode + "','" + fm.BirthDate + "'," + fm.Nationality + "," + fm.Gender + "," + fm.FirstInsurance + "," + fm.SecondInsurance +
                                "," + fm.Education + "," + fm.Relationship + "," + fm.Activity + "," + fm.Job + "," + fm.MaritalStatus + "," + fm.Relationship + ",'" + fm.MobileNumber + "'," + fm.FamilyID +
                                ",'" + Date + "',129,'" + DateTime.Today + "'," + ID + ",'" + Guid.NewGuid() + "')";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                BD.DeleteFamilyMember(fm);
            }
            else
            {
                B_GetDatas BG = new B_GetDatas();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;

                string[] date1 = maskedTextBoxAdv2.Text.Split('/');
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                string Date = dt1.Year + "-" + dt1.Month + "-" + dt1.Day;

                date1 = maskedTextBoxAdv4.Text.Split('/');
                dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                string Date2 = dt1.Year + "-" + dt1.Month + "-" + dt1.Day;

                cm.CommandText = @"insert into temp_Dead([DeadDate],[ShomareShenasname],[Mother],[Discription1],[DiscriptionID1],[Discription2],[DiscriptionID2],
                                    [Discription3],[DiscriptionID3],[Discription4],[DiscriptionID4],[Discription5],[DiscriptionID5],[SaderKonande],[NameMosese],[ShomareNezamPezeshki]
                                    ,[TarikhSodor],[NoeMarg],[TedadGholha],[MartabeGholha],[NoeZayeman],[AmelZayeman],[MakaneZayeman])
                                    Values('" + Date + "','" + textBoxX21.Text + "','" + comboBoxEx14.SelectedValue + "','" + textBoxX35.Text + "','" + textBoxX31.Text + "','" + textBoxX34.Text
                                    + "','" + textBoxX30.Text + "','" + textBoxX33.Text + "','" + textBoxX29.Text + "','" + textBoxX32.Text + "','" + textBoxX28.Text + "','" + textBoxX27.Text
                                    + "','" + textBoxX25.Text + "','" + textBoxX38.Text + "','" + textBoxX37.Text + "','" + textBoxX36.Text + "','" + Date2 + "',2" + ",'" + textBoxX22.Text
                                    + "','" + textBoxX23.Text + "',0," + comboBoxEx12.SelectedValue + "," + comboBoxEx13.SelectedValue + ")";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                string ID = "0";
                cm.CommandText = @"select top 1 ID from temp_Dead order by ID Desc";
                cn.Open();
                ID = cm.ExecuteScalar().ToString();
                cn.Close();
                //cm.CommandText = @"insert into temp_Events(Gender,FamilyID,[CreateDate],[EventTypeID],[EventDate],[EventID],EventUID)
                //                Values(" + comboBoxEx11.SelectedValue + "," + FM.ID + ",'" + DateTime.Today + "',129,'" + DateTime.Today + "'," + ID + ",'" + Guid.NewGuid() + "')";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
