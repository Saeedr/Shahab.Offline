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
using System.Reflection;

namespace Shahab.Offline.WinUI
{
    public partial class frmEventEzdevaj : Form
    {

        public M_FamilyMembers Person1 = null;
        public M_FamilyMembers Person2 = null;
        public M_Families Family1 = null;
        public M_Families Family2 = null;
        public M_Families NewFamily = null;
        public M_Address NewAddress = null;
        public M_EventMigrations Migration = null;
        int Steps = 0;
        bool FinishSteps = false;

        public bool Submit()
        {
            B_GetDatas BG = new B_GetDatas();
            if (FinishSteps == true)
            {
                if (rdoVillageFalse.Checked == true)
                {
                    if (radioButton4.Checked == true)
                    {
                        if (Person1 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص اول را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (Person2 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (NewFamily == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "خانوار جدید را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        submit1(Person1, Person2, NewFamily, NewAddress);
                        frmMessage msg2 = new frmMessage();
                        msg2.label1.Text = "عملیات با موفقیت انجام شد";
                        msg2.ShowDialog();
                        return true;
                    }
                    if (radioButton3.Checked == true)
                    {
                        if (Person1 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص اول را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (Person2 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (Family1 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "خانوار فرد اول را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        submit2(Person1, Person2, Family1);
                        frmMessage msg2 = new frmMessage();
                        msg2.label1.Text = "عملیات با موفقیت انجام شد";
                        msg2.ShowDialog();
                        return true;
                    }
                    if (radioButton1.Checked == true)
                    {
                        if (dgvActionDead.SelectedRows.Count != 0)
                        {
                            int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                            Person1 = BG.GetFamilyMember(id, "Refrense");
                            if (Person1 == null)
                            {
                                frmMessage msg = new frmMessage();
                                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                msg.label1.Text = "شخص اول را نهایی نکرده اید";
                                msg.ShowDialog();
                                return false;
                            }
                            M_EventMigrations EV = new M_EventMigrations();
                            frmEventMohajerat Mig = new frmEventMohajerat(new List<M_FamilyMembers>() { Person1 }, new int[] { 220, 221, 222, 223 }, false);
                            Mig.WindowState = FormWindowState.Maximized;
                            Mig.StartPosition = FormStartPosition.CenterParent;
                            Mig.ShowDialog();
                            if (Mig.M_EM != null)
                            {
                                EV = Mig.M_EM;
                                List<int> M_DelF = Mig.DeleteFamily;
                                submit3(Person1,EV, M_DelF);
                                frmMessage msg2 = new frmMessage();
                                msg2.label1.Text = "عملیات با موفقیت انجام شد";
                                msg2.ShowDialog();
                                return true;
                            }
                            else
                            {
                                frmMessage msg = new frmMessage();
                                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                msg.label1.Text = "اطلاعات مهاجرت را مشخص نکرده اید , اطاعات ثبت نشد";
                                msg.ShowDialog();
                                return false;
                            }
                        }
                        else
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخصی را انتخاب نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                    }
                }
                else if (rdoVillageTrue.Checked == true)
                {
                    if (rdoWhichFamily1.Checked == true)
                    {
                        if (Person1 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص اول را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (Person2 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (NewFamily == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "خانوار جدید را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        submit1(Person1, Person2, NewFamily, NewAddress);
                        frmMessage msg2 = new frmMessage();
                        msg2.label1.Text = "عملیات با موفقیت انجام شد";
                        msg2.ShowDialog();
                        return true;
                    }
                }
                if (rdoWhichFamily2.Checked == true)
                {
                    int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                    Person1 = BG.GetFamilyMember(id, "Refrense");
                    int id2 = int.Parse(dataGridViewX1.SelectedRows[0].Cells["MemberID2"].Value.ToString());
                    Person2 = BG.GetFamilyMember(id2, "Refrense");
                    if (Person1 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخص اول را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    if (Person2 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    if (Family1 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "خانوار فرد اول را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    submit2(Person1, Person2, Family1);
                    frmMessage msg2 = new frmMessage();
                    msg2.label1.Text = "عملیات با موفقیت انجام شد";
                    msg2.ShowDialog();
                    return true;
                }
                if (rdoWhichFamily3.Checked == true)
                {
                    int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                    Person1 = BG.GetFamilyMember(id, "Refrense");
                    int id2 = int.Parse(dataGridViewX1.SelectedRows[0].Cells["MemberID2"].Value.ToString());
                    Person2 = BG.GetFamilyMember(id2, "Refrense");
                    if (Person1 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخص اول را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    if (Person2 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    if (Family2 == null)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "خانوار فرد اول را نهایی نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                    submit2(Person1, Person2, Family2);
                    frmMessage msg2 = new frmMessage();
                    msg2.label1.Text = "عملیات با موفقیت انجام شد";
                    msg2.ShowDialog();
                    return true;
                }
                if (rdoWhichFamily4.Checked == true)
                {
                    if (dgvActionDead.SelectedRows.Count != 0)
                    {
                        int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                        Person1 = BG.GetFamilyMember(id, "Refrense");
                        int id2 = int.Parse(dataGridViewX1.SelectedRows[0].Cells["MemberID2"].Value.ToString());
                        Person2 = BG.GetFamilyMember(id2, "Refrense");
                        if (Person1 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص اول را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        if (Person2 == null)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "شخص دوم را نهایی نکرده اید";
                            msg.ShowDialog();
                            return false;
                        }
                        M_EventMigrations EV = new M_EventMigrations();
                        frmEventMohajerat Mig = new frmEventMohajerat(new List<M_FamilyMembers>() { Person1, Person2 }, new int[] { 220, 221, 222, 223 }, false);
                        Mig.WindowState = FormWindowState.Maximized;
                        Mig.StartPosition = FormStartPosition.CenterParent;
                        Mig.ShowDialog();
                        if (Mig.M_EM != null)
                        {
                            EV = Mig.M_EM;
                            List<int> M_DelF = Mig.DeleteFamily;
                            //submit4(Person1, Person2, null, null, EV, false, 0, M_DelF);
                            frmMessage msg2 = new frmMessage();
                            msg2.label1.Text = "عملیات با موفقیت انجام شد";
                            msg2.ShowDialog();
                            return true;
                        }
                        else
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "اطلاعات مهاجرت را مشخص نکرده اید , اطاعات ثبت نشد";
                            msg.ShowDialog();
                            return false;
                        }
                    }
                    else
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخصی را انتخاب نکرده اید";
                        msg.ShowDialog();
                        return false;
                    }
                }
            }
            else
            {
                frmMessage msg = new frmMessage();
                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                msg.label1.Text = "لطفا مراحل را تا پایان طی کنید";
                msg.ShowDialog();
            }

            return false;
        }

        public frmEventEzdevaj()
        {
            InitializeComponent();
        }

        private void frmEventEzdevaj_Load(object sender, EventArgs e)
        {
            animator1.Show(pnlStep1);
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            if (txtActionFirstFamilySearch.Text != "")
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
                Family1 = fm2;
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
                FMem = BG.GetFamilyMember(Fm.Single().ID).Where(c => c.MaritalStatus != 34).ToList();
                dgvActionDead.Rows.Clear();
                foreach (M_FamilyMembers fm in FMem)
                {
                    if (fm.Relationship == 64)
                        continue;

                    if (fm.Relationship == 66 && fm.Gender == 12)
                        continue;

                    if (fm.Gender == 12 && (fm.MaritalStatus == 31 || fm.MaritalStatus == 34))
                        continue;

                    if (fm.MaritalStatus == 34)
                        continue;

                    dgvActionDead.Rows.Add(fm.FirstName, fm.LastName, fm.NationalCode, Math.Round(((DateTime.Today - fm.BirthDate).TotalDays / 365)) + " سال", fm.MobileNumber, fm.ID);
                }
            }
            else if (txtActionTalaghNationalCodeSearch.Text != "")
            {
                B_GetDatas bg = new B_GetDatas();
                M_FamilyMembers fmm = bg.GetFamilyMember(txtActionTalaghNationalCodeSearch.Text);
                if (fmm != null)
                {
                    Family1 = bg.GetFamily().Where(c => c.ID == fmm.FamilyID).Single();

                    dgvActionDead.Rows.Clear();
                    if (fmm != null)
                    {
                        if (fmm.Relationship == 64)
                            return;

                        if (fmm.Relationship == 66 && fmm.Gender == 12)
                            return;

                        if (fmm.Gender == 12 && (fmm.MaritalStatus == 31 || fmm.MaritalStatus == 34))
                            return;

                        if (fmm.MaritalStatus == 34)
                            return;

                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        string Date = pc.GetYear(fmm.BirthDate).ToString() + "/" + pc.GetMonth(fmm.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm.BirthDate).ToString();
                        dgvActionDead.Rows.Add(fmm.FirstName, fmm.LastName, fmm.NationalCode, Date, fmm.MobileNumber, fmm.ID);
                    }
                }
                else
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "چنین شخصی پیدا نشد";
                    msg.ShowDialog();
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Steps == 0 && dgvActionDead.SelectedRows.Count > 0)
            {
                dgvActionDead.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                pnlStep1.Enabled = false;
                string s = "زوج";
                B_GetDatas bg = new B_GetDatas();
                int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                M_FamilyMembers FM = bg.GetFamilyMember(id, "Refrense");
                if (FM.Gender == 11)
                    s = "زوجه";
                label7.Text = s + " در مناطقی که شما تحت پوشش دارید ساکن است ؟";
                animator1.Show(pnlStep2);
                Steps++;
            }
            else if (Steps == 1 && rdoVillageTrue.Checked == true)
            {
                pnlStep2.Enabled = false;
                animator1.Show(pnlStep3);
                Steps++;
            }
            else if (Steps == 1 && rdoVillageFalse.Checked == true)
            {
                pnlStep2.Enabled = false;
                animator1.Show(pnlStep3_1);
                Steps++;
                radioButton1.Checked = true;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                buttonX1.Enabled = false;
                FinishSteps = true;
            }
            else if (Steps == 2 && dataGridViewX1.SelectedRows.Count > 0 && rdoVillageTrue.Checked == true)
            {
                dataGridViewX1.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                pnlStep3.Enabled = false;
                animator1.Show(pnlStep4);
                Steps++;
                rdoWhichFamily1.Checked = false;
                rdoWhichFamily2.Checked = false;
                rdoWhichFamily3.Checked = false;
                rdoWhichFamily4.Checked = true;
                buttonX1.Enabled = false;
                FinishSteps = true;
            }
            buttonX3.Enabled = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (Steps == 1)
            {
                dgvActionDead.SelectedRows[0].DefaultCellStyle.BackColor = SystemColors.Window;
                pnlStep1.Enabled = true;
                animator1.Hide(pnlStep2);
                Steps--;
                buttonX3.Enabled = false;
            }
            else if (Steps == 2 && rdoVillageTrue.Checked == true)
            {
                pnlStep2.Enabled = true;
                animator1.Hide(pnlStep3);
                Steps--;
            }
            else if (Steps == 2 && rdoVillageFalse.Checked == true)
            {
                pnlStep2.Enabled = true;
                animator1.Hide(pnlStep3_1);
                Steps--;
            }
            else if (Steps == 3 && rdoVillageTrue.Checked == true)
            {
                dataGridViewX1.SelectedRows[0].DefaultCellStyle.BackColor = SystemColors.Window;
                pnlStep3.Enabled = true;
                animator1.Hide(pnlStep4);
                Steps--;
            }
            buttonX1.Enabled = true;
            FinishSteps = false;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text != "")
            {
                B_GetDatas BG = new B_GetDatas();
                List<M_FamilyMembers> FMem = new List<M_FamilyMembers>();
                List<M_Families> Fm = BG.GetFamily(int.Parse(textBoxX2.Text));
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
                Family2 = fm2;
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
                FMem = BG.GetFamilyMember(Fm.Single().ID).Where(c => c.MaritalStatus != 34).ToList();
                dataGridViewX1.Rows.Clear();

                int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                M_FamilyMembers FM = BG.GetFamilyMember(id, "Refrense");

                foreach (M_FamilyMembers fm in FMem)
                {
                    if (FM.Relationship == 64)
                        continue;

                    if (FM.Gender == 12 && (FM.MaritalStatus == 31 || FM.MaritalStatus == 34))
                        continue;

                    if (fm.ID == int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString()))
                        continue;

                    if (fm.Relationship == 65 && FM.Relationship == 65 && Fm.Single().ID == Family1.ID)
                        continue;

                    if (fm.Relationship == 65 && FM.Relationship == 63 && Fm.Single().ID == Family1.ID)
                        continue;

                    if (FM.Relationship == 65 && fm.Relationship == 63 && Fm.Single().ID == Family1.ID)
                        continue;

                    if (fm.Gender == FM.Gender)
                        continue;

                    dataGridViewX1.Rows.Add(fm.FirstName, fm.LastName, fm.NationalCode, Math.Round(((DateTime.Today - fm.BirthDate).TotalDays / 365)) + " سال", fm.MobileNumber, fm.ID);
                }
            }
            else if (textBoxX1.Text != "")
            {
                B_GetDatas bg = new B_GetDatas();
                M_FamilyMembers fmm = bg.GetFamilyMember(textBoxX1.Text);
                if (fmm != null)
                {
                    dataGridViewX1.Rows.Clear();
                    int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                    M_FamilyMembers FM = bg.GetFamilyMember(id, "Refrense");

                    List<M_Families> Fm = bg.GetFamily().Where(c => c.ID == fmm.FamilyID).ToList();
                    if (FM.Relationship == 64)
                        return;

                    if (FM.Gender == 12 && (FM.MaritalStatus == 31 || FM.MaritalStatus == 34))
                        return;

                    if (fmm.ID == int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString()))
                        return;

                    if (fmm.Relationship == 65 && FM.Relationship == 65 && Fm.Single().ID == Family1.ID)
                        return;

                    if (fmm.Relationship == 65 && FM.Relationship == 63 && Fm.Single().ID == Family1.ID)
                        return;

                    if (FM.Relationship == 65 && fmm.Relationship == 63 && Fm.Single().ID == Family1.ID)
                        return;

                    if (fmm.Gender == FM.Gender)
                        return;

                    Family2 = Fm.Single();

                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string Date = pc.GetYear(fmm.BirthDate).ToString() + "/" + pc.GetMonth(fmm.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm.BirthDate).ToString();
                    dataGridViewX1.Rows.Add(fmm.FirstName, fmm.LastName, fmm.NationalCode, Date, fmm.MobileNumber, fmm.ID);
                }
                else
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "چنین شخصی پیدا نشد";
                    msg.ShowDialog();
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                M_Families fm = new M_Families();
                List<M_FamilyMembers> fmm = new List<M_FamilyMembers>();
                B_GetDatas BG = new B_GetDatas();
                M_Address AD = new M_Address();
                int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                M_FamilyMembers FM = BG.GetFamilyMember(id, "Refrense");
                fmm.Add(new M_FamilyMembers
                {
                    Activity = 0,
                    BirthDate = DateTime.Today.AddYears(-200),
                    Education = 0,
                    FamilyID = 0,
                    FamilyIDNotMap = 0,
                    FirstInsurance = 0,
                    FirstName = "",
                    Gender = 0,
                    IsDeleted = false,
                    Job = 0,
                    LastName = "",
                    MaritalStatus = 31,
                    MobileNumber = "",
                    NationalCode = "",
                    Nationality = 0,
                    Relationship = 0,
                    ResidentStatus = 0,
                    SecondInsurance = 0
                });
                FM.MaritalStatus = 31;
                fmm[0].MaritalStatus = 31;

                if (FM.Gender == 11)
                {
                    FM.Relationship = 63;
                    fmm[0].Relationship = 64;
                    fmm[0].Gender = 12;
                }
                else if (FM.Gender == 12)
                {
                    fmm[0].Relationship = 63;
                    FM.Relationship = 64;
                    fmm[0].Gender = 11;
                }
                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fm, fmm, AD, true, 0, false);
                frm.WindowState = FormWindowState.Maximized;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.IsFirstEditOK == true)
                {
                    fm = frm.ThisFamily;
                    fmm = frm.ThisFamilyMember;
                    AD = frm.ThisAddress;
                    NewFamily = fm;
                    if (fm.FamilyTypeCode == 84)
                        FM.Relationship = 0;
                    Person1 = FM;
                    Person2 = fmm[0];
                    NewAddress = AD;
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton4.Checked = false;
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                List<M_FamilyMembers> fmm = new List<M_FamilyMembers>();
                B_GetDatas BG = new B_GetDatas();
                M_Address AD = BG.GetAdressByFamilyID(Family1.ID);

                int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                M_FamilyMembers FM = BG.GetFamilyMember(id, "Refrense");
                fmm.Add(new M_FamilyMembers
                {
                    Activity = 0,
                    BirthDate = DateTime.Today.AddYears(-200),
                    Education = 0,
                    FamilyID = Family1.ID,
                    FamilyIDNotMap = 0,
                    FirstInsurance = 0,
                    FirstName = "",
                    Gender = 0,
                    IsDeleted = false,
                    Job = 0,
                    LastName = "",
                    MaritalStatus = 31,
                    MobileNumber = "",
                    NationalCode = "",
                    Nationality = 0,
                    Relationship = 66,
                    ResidentStatus = 0,
                    SecondInsurance = 0
                });

                FM.MaritalStatus = 31;
                fmm[0].MaritalStatus = 31;
                fmm[0].Relationship = 66;
                if (FM.Gender == 11)
                {
                    fmm[0].Gender = 12;
                }
                else if (FM.Gender == 12)
                {
                    fmm[0].Gender = 11;
                }

                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(Family1, fmm, AD, true, 1, false);
                frm.WindowState = FormWindowState.Maximized;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.IsFirstEditOK == true)
                {
                    fmm = frm.ThisFamilyMember;
                    Person1 = FM;
                    Person2 = fmm[0];
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton4.Checked = false;
                }
            }
        }

        private void rdoWhichFamily1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWhichFamily1.Checked == true)
            {
                M_Families fm = new M_Families();
                List<M_FamilyMembers> fmm = new List<M_FamilyMembers>();
                B_GetDatas BG = new B_GetDatas();
                M_Address AD = new M_Address();
                int id = int.Parse(dgvActionDead.SelectedRows[0].Cells["MemberID"].Value.ToString());
                int id2 = int.Parse(dataGridViewX1.SelectedRows[0].Cells["MemberID2"].Value.ToString());
                fmm.Add(BG.GetFamilyMember(id, "Refrense"));
                fmm.Add(BG.GetFamilyMember(id2, "Refrense"));

                fmm[0].MaritalStatus = 31;
                fmm[1].MaritalStatus = 31;

                if (fmm[0].Gender == 11)
                {
                    fmm[0].Relationship = 63;
                    fmm[1].Relationship = 64;
                    fmm[1].Gender = 12;
                }
                else if (fmm[0].Gender == 12)
                {
                    fmm[1].Relationship = 63;
                    fmm[0].Relationship = 64;
                    fmm[1].Gender = 11;
                }
                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fm, fmm, AD, true, 0, false);
                frm.WindowState = FormWindowState.Maximized;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.IsFirstEditOK == true)
                {
                    fm = frm.ThisFamily;
                    fmm = frm.ThisFamilyMember;
                    AD = frm.ThisAddress;
                    NewFamily = fm;
                    Person1 = fmm[0];
                    Person2 = fmm[1];
                    NewAddress = AD;
                }
                else
                {
                    rdoWhichFamily1.Checked = false;
                    rdoWhichFamily4.Checked = true;
                }
            }
        }

        /// <summary>
        /// ثبت اطلاعات ازدواج افراد
        /// </summary>
        /// <param name="person1">شخص اول</param>
        /// <param name="person2">شخص دوم</param>
        /// <param name="family">خانواده مورد نظر</param>
        /// <param name="address">ادرس خانوار مورد نظر</param>
        private void submit1(M_FamilyMembers person1, M_FamilyMembers person2, M_Families family, M_Address address)
        {
            B_GetDatas BG = new B_GetDatas();
            B_DeleteDatas BD = new B_DeleteDatas();
            B_InsertDatas BI = new B_InsertDatas();

            person1.MaritalStatus = 31;
            person2.MaritalStatus = 31;

            if (person1.Relationship != 63)
                BD.DeleteFamilyMember(person1);

            BI.InsertFamily(family, new List<M_FamilyMembers> { person1, person2 }, address);
            
            M_Event EV = new M_Event();
            EV.Activity = person1.Activity;
            EV.BirthDate = person1.BirthDate;
            EV.CreateDate = DateTime.Now;
            EV.DeathDate = person1.DeathDate;
            EV.Description = person1.Description;
            EV.Education = person1.Education;
            EV.EventCreateDate = DateTime.Now;
            EV.EventID = 0;
            EV.ExpireDate = person1.ExpireDate;
            EV.FamilyID = person1.FamilyID;
            EV.FamilyMembersUID = person1.FamilyMembersUID;
            EV.FirstInsurance = person1.FirstInsurance;
            EV.FirstName = person1.FirstName;
            EV.Gender = person1.Gender;
            EV.IsActive = true;
            EV.IsDeleted = false;
            EV.IsSend = false;
            EV.Job = person1.Job;
            EV.LastName = person1.LastName;
            EV.MaritalStatus = person1.MaritalStatus;
            EV.MobileNumber = person1.MobileNumber;
            EV.NationalCode = person1.NationalCode;
            EV.Nationality = person1.Nationality;
            EV.OccuredDate = DateTime.Today;
            EV.Organization8DigitID = "12345678";//MostBeChange
            EV.Relationship = person1.Relationship;
            EV.ResidentStatus = person1.ResidentStatus;
            EV.SecondInsurance = person1.SecondInsurance;
            EV.MasterID = 127;
            BI.InsertEvent(EV);

            M_Event EV2 = new M_Event();
            EV2.Activity = person2.Activity;
            EV2.BirthDate = person2.BirthDate;
            EV2.CreateDate = DateTime.Now;
            EV2.DeathDate = person2.DeathDate;
            EV2.Description = person2.Description;
            EV2.Education = person2.Education;
            EV2.EventCreateDate = DateTime.Now;
            EV2.EventID = 0;
            EV2.ExpireDate = person2.ExpireDate;
            EV2.FamilyID = person2.FamilyID;
            EV2.FamilyMembersUID = person2.FamilyMembersUID;
            EV2.FirstInsurance = person2.FirstInsurance;
            EV2.FirstName = person2.FirstName;
            EV2.Gender = person2.Gender;
            EV2.IsActive = true;
            EV2.IsDeleted = false;
            EV2.IsSend = false;
            EV2.Job = person2.Job;
            EV2.LastName = person2.LastName;
            EV2.MaritalStatus = person2.MaritalStatus;
            EV2.MobileNumber = person2.MobileNumber;
            EV2.NationalCode = person2.NationalCode;
            EV2.Nationality = person2.Nationality;
            EV2.OccuredDate = DateTime.Today;
            EV2.Organization8DigitID = "12345678";//MostBeChange
            EV2.Relationship = person2.Relationship;
            EV2.ResidentStatus = person2.ResidentStatus;
            EV2.SecondInsurance = person2.SecondInsurance;
            EV2.MasterID = 127;
            BI.InsertEvent(EV2);
        }



        /// <summary>
        /// ثبت اطلاعات ازدواج افراد
        /// </summary>
        /// <param name="person1">شخص اول</param>
        /// <param name="person2">شخص دوم</param>
        /// <param name="family">خانواده مورد نظر</param>
        /// <param name="address">ادرس خانوار مورد نظر</param>
        private void submit2(M_FamilyMembers person1, M_FamilyMembers person2, M_Families family)
        {
            B_GetDatas BG = new B_GetDatas();
            B_DeleteDatas BD = new B_DeleteDatas();
            B_InsertDatas BI = new B_InsertDatas();

            person1.MaritalStatus = 31;
            person2.MaritalStatus = 31;
            person1.FamilyID = family.ID;
            person2.FamilyID = family.ID;

            if (person1.Relationship != 63)
                BD.DeleteFamilyMember(person1);
            if (person2.Relationship != 63 && person2.ID != 0)
                BD.DeleteFamilyMember(person2);
            else
                person2.CreateDate = DateTime.Now;

            BI.InsertPerson(new List<M_FamilyMembers> { person1, person2 });

            M_Event EV = new M_Event();
            EV.Activity = person1.Activity;
            EV.BirthDate = person1.BirthDate;
            EV.CreateDate = DateTime.Now;
            EV.DeathDate = person1.DeathDate;
            EV.Description = person1.Description;
            EV.Education = person1.Education;
            EV.EventCreateDate = DateTime.Now;
            EV.EventID = 0;
            EV.ExpireDate = person1.ExpireDate;
            EV.FamilyID = person1.FamilyID;
            EV.FamilyMembersUID = person1.FamilyMembersUID;
            EV.FirstInsurance = person1.FirstInsurance;
            EV.FirstName = person1.FirstName;
            EV.Gender = person1.Gender;
            EV.IsActive = true;
            EV.IsDeleted = false;
            EV.IsSend = false;
            EV.Job = person1.Job;
            EV.LastName = person1.LastName;
            EV.MaritalStatus = person1.MaritalStatus;
            EV.MobileNumber = person1.MobileNumber;
            EV.NationalCode = person1.NationalCode;
            EV.Nationality = person1.Nationality;
            EV.OccuredDate = DateTime.Today;
            EV.Organization8DigitID = "12345678";//MostBeChange
            EV.Relationship = person1.Relationship;
            EV.ResidentStatus = person1.ResidentStatus;
            EV.SecondInsurance = person1.SecondInsurance;
            EV.MasterID = 127;
            BI.InsertEvent(EV);

            M_Event EV2 = new M_Event();
            EV2.Activity = person2.Activity;
            EV2.BirthDate = person2.BirthDate;
            EV2.CreateDate = DateTime.Now;
            EV2.DeathDate = person2.DeathDate;
            EV2.Description = person2.Description;
            EV2.Education = person2.Education;
            EV2.EventCreateDate = DateTime.Now;
            EV2.EventID = 0;
            EV2.ExpireDate = person2.ExpireDate;
            EV2.FamilyID = person2.FamilyID;
            EV2.FamilyMembersUID = person2.FamilyMembersUID;
            EV2.FirstInsurance = person2.FirstInsurance;
            EV2.FirstName = person2.FirstName;
            EV2.Gender = person2.Gender;
            EV2.IsActive = true;
            EV2.IsDeleted = false;
            EV2.IsSend = false;
            EV2.Job = person2.Job;
            EV2.LastName = person2.LastName;
            EV2.MaritalStatus = person2.MaritalStatus;
            EV2.MobileNumber = person2.MobileNumber;
            EV2.NationalCode = person2.NationalCode;
            EV2.Nationality = person2.Nationality;
            EV2.OccuredDate = DateTime.Today;
            EV2.Organization8DigitID = "12345678";//MostBeChange
            EV2.Relationship = person2.Relationship;
            EV2.ResidentStatus = person2.ResidentStatus;
            EV2.SecondInsurance = person2.SecondInsurance;
            EV2.MasterID = 127;
            BI.InsertEvent(EV2);
        }


        /// <summary>
        /// ثبت اطلاعات ازدواج افراد
        /// </summary>
        /// <param name="person1">شخص اول</param>
        /// <param name="EM">ایونت مهاجرت مورد نظر</param>
        /// <param name="DelFamily">لیت کدهای خانواری که باید حذف شوند</param>
        private void submit3(M_FamilyMembers person1, M_EventMigrations EM, List<int> DelFamily)
        {
            B_GetDatas BG = new B_GetDatas();
            B_DeleteDatas BD = new B_DeleteDatas();
            B_InsertDatas BI = new B_InsertDatas();

            person1.MaritalStatus = 31;

            if (person1.Relationship != 63 && DelFamily.Count > 0)
                BD.DeleteFamilyMember(person1);

            foreach(int i in DelFamily)
            {
                BD.DeleteFamily(i);
            }

            M_Event EV = new M_Event();
            EV.Activity = person1.Activity;
            EV.BirthDate = person1.BirthDate;
            EV.CreateDate = DateTime.Now;
            EV.DeathDate = person1.DeathDate;
            EV.Description = person1.Description;
            EV.Education = person1.Education;
            EV.EventCreateDate = DateTime.Now;
            EV.EventID = 0;
            EV.ExpireDate = person1.ExpireDate;
            EV.FamilyID = person1.FamilyID;
            EV.FamilyMembersUID = person1.FamilyMembersUID;
            EV.FirstInsurance = person1.FirstInsurance;
            EV.FirstName = person1.FirstName;
            EV.Gender = person1.Gender;
            EV.IsActive = true;
            EV.IsDeleted = false;
            EV.IsSend = false;
            EV.Job = person1.Job;
            EV.LastName = person1.LastName;
            EV.MaritalStatus = person1.MaritalStatus;
            EV.MobileNumber = person1.MobileNumber;
            EV.NationalCode = person1.NationalCode;
            EV.Nationality = person1.Nationality;
            EV.OccuredDate = DateTime.Now;
            EV.Organization8DigitID = "12345678";//MostBeChange
            EV.Relationship = person1.Relationship;
            EV.ResidentStatus = person1.ResidentStatus;
            EV.SecondInsurance = person1.SecondInsurance;
            EV.MasterID = 127;
            BI.InsertEvent(EV);

            EM.CreateDate = DateTime.Now;
            EM.FamilyMemberID = person1.ID;
            EM.IsActive = true;
            EM.IsDeleted = false;
            EM.IsSent = false;
            int id = BI.InsertEventMigrations(EM);
            EV.MasterID = 128;
            EV.EventID = id;
            BI.InsertEvent(EV);
        }

        /// <summary>
        /// ثبت اطلاعات ازدواج افراد
        /// </summary>
        /// <param name="person1">شخص اول</param>
        /// <param name="person2">شخص دوم</param>
        /// <param name="EM">ایونت مهاجرت مورد نظر</param>
        /// <param name="DelFamily">لیت کدهای خانواری که باید حذف شوند</param>
        private void submit4(M_FamilyMembers person1,M_FamilyMembers person2, M_EventMigrations EM, List<int> DelFamily)
        {
            B_GetDatas BG = new B_GetDatas();
            B_DeleteDatas BD = new B_DeleteDatas();
            B_InsertDatas BI = new B_InsertDatas();

            person1.MaritalStatus = 31;
            person2.MaritalStatus = 31;

            if (person1.Relationship != 63 && DelFamily.Count > 0)
                BD.DeleteFamilyMember(person1);


            if (person2.Relationship != 63 && DelFamily.Count > 0)
                BD.DeleteFamilyMember(person2);

            foreach (int i in DelFamily)
            {
                BD.DeleteFamily(i);
            }

            M_Event EV = new M_Event();
            EV.Activity = person1.Activity;
            EV.BirthDate = person1.BirthDate;
            EV.CreateDate = DateTime.Now;
            EV.DeathDate = person1.DeathDate;
            EV.Description = person1.Description;
            EV.Education = person1.Education;
            EV.EventCreateDate = DateTime.Now;
            EV.EventID = 0;
            EV.ExpireDate = person1.ExpireDate;
            EV.FamilyID = person1.FamilyID;
            EV.FamilyMembersUID = person1.FamilyMembersUID;
            EV.FirstInsurance = person1.FirstInsurance;
            EV.FirstName = person1.FirstName;
            EV.Gender = person1.Gender;
            EV.IsActive = true;
            EV.IsDeleted = false;
            EV.IsSend = false;
            EV.Job = person1.Job;
            EV.LastName = person1.LastName;
            EV.MaritalStatus = person1.MaritalStatus;
            EV.MobileNumber = person1.MobileNumber;
            EV.NationalCode = person1.NationalCode;
            EV.Nationality = person1.Nationality;
            EV.OccuredDate = DateTime.Now;
            EV.Organization8DigitID = "12345678";//MostBeChange
            EV.Relationship = person1.Relationship;
            EV.ResidentStatus = person1.ResidentStatus;
            EV.SecondInsurance = person1.SecondInsurance;
            EV.MasterID = 127;
            BI.InsertEvent(EV);


            M_Event EV2 = new M_Event();
            EV2.Activity = person2.Activity;
            EV2.BirthDate = person2.BirthDate;
            EV2.CreateDate = DateTime.Now;
            EV2.DeathDate = person2.DeathDate;
            EV2.Description = person2.Description;
            EV2.Education = person2.Education;
            EV2.EventCreateDate = DateTime.Now;
            EV2.EventID = 0;
            EV2.ExpireDate = person2.ExpireDate;
            EV2.FamilyID = person2.FamilyID;
            EV2.FamilyMembersUID = person2.FamilyMembersUID;
            EV2.FirstInsurance = person2.FirstInsurance;
            EV2.FirstName = person2.FirstName;
            EV2.Gender = person2.Gender;
            EV2.IsActive = true;
            EV2.IsDeleted = false;
            EV2.IsSend = false;
            EV2.Job = person2.Job;
            EV2.LastName = person2.LastName;
            EV2.MaritalStatus = person2.MaritalStatus;
            EV2.MobileNumber = person2.MobileNumber;
            EV2.NationalCode = person2.NationalCode;
            EV2.Nationality = person2.Nationality;
            EV2.OccuredDate = DateTime.Today;
            EV2.Organization8DigitID = "12345678";//MostBeChange
            EV2.Relationship = person2.Relationship;
            EV2.ResidentStatus = person2.ResidentStatus;
            EV2.SecondInsurance = person2.SecondInsurance;
            EV2.MasterID = 127;
            BI.InsertEvent(EV2);

            EM.CreateDate = DateTime.Now;
            EM.FamilyMemberID = person1.ID;
            EM.IsActive = true;
            EM.IsDeleted = false;
            EM.IsSent = false;
            int id = BI.InsertEventMigrations(EM);
            EV.MasterID = 128;
            EV.EventID = id;
            BI.InsertEvent(EV);

            EM.CreateDate = DateTime.Now;
            EM.FamilyMemberID = person2.ID;
            EM.IsActive = true;
            EM.IsDeleted = false;
            EM.IsSent = false;
            id = BI.InsertEventMigrations(EM);
            EV2.MasterID = 128;
            EV2.EventID = id;
            BI.InsertEvent(EV2);
        }
    }
}
