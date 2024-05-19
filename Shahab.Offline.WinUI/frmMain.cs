using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Shahab.Offline.Model;
using Shahab.Offline.BL;
using System.Runtime.InteropServices;
using Shahab.Offline.Logging;

namespace Shahab.Offline.WinUI
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// اخطار در رابطه با وارد شدن و ذخیره نشدن اطلاعات هنگام تعویض فرم
        /// </summary>
        /// <returns></returns>
        private bool ChangeAsk()
        {
            if (pnlMain.Controls.Find("dgvParvandeAddPerson", true).Length != 0)
            {
                Control ctn = pnlMain.Controls.Find("dgvParvandeAddPerson", true).Single();
                DataGridViewX dgv = ctn as DataGridViewX;
                if (dgv.Rows.Count > 0 && dgv.Enabled == true)
                {
                    frmDeleteConfirm frm = new frmDeleteConfirm();
                    frm.label1.Text = "اطلاعات خانوار ثبت نهایی نشده , مایل به ثبت اطلاعات هستید ؟" + Environment.NewLine + "(با انتخاب گزینه خیر اطلاعات از بین خواهد رفت)";
                    frm.ShowDialog();
                    if (frm.Status == true)
                    {
                        buttonX11_Click(null, null);
                    }
                }
            }
            return true;
        }

        private void ChangeForm(Form frm)
        {
            if (ChangeAsk())
            {
                pnlMain.Controls.Clear();
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.Dock = DockStyle.Fill;
                frm.BackColor = pnlMain.BackColor;
                pnlMain.Controls.Add(frm);
                frm.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            panelEx2.Top = this.Height - 41;
        }

        private void btnStatusShowHide_Click(object sender, EventArgs e)
        {
            if (panelEx2.Top == this.Height - 143)
            {
                panelEx2.Top = this.Height - 41;
                btnStatusShowHide.Image = global::Shahab.Offline.WinUI.Properties.Resources.arrow_up;
            }
            else
            {
                panelEx2.Top = this.Height - 143;
                btnStatusShowHide.Image = global::Shahab.Offline.WinUI.Properties.Resources.arrow_down;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            analogClockControl1.Value = DateTime.Now;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmPersonFamilyAdd frm = new frmPersonFamilyAdd();
            ChangeForm(frm);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            ChangeForm(frm);
            //MessageBox.Show(pnlMain.Controls.Find("dgvParvandeAddPerson", true).Length.ToString());
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            System.Threading.Thread.Sleep(500);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            frmPhotoGallery frm = new frmPhotoGallery();
            frm.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            frmWeather frm = new frmWeather();
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            frmSearchFamily frm = new frmSearchFamily();
            ChangeForm(frm);
            pnlMain.Controls.Find("buttonX13", true).Single().Click += SearchFamilySelectClick;
        }

        private void SearchFamilySelectClick(object sender, EventArgs e)
        {
            DataGridView dgv = pnlMain.Controls.Find("dgvParvandeSearch", true).Single() as DataGridView;
            if (dgv.SelectedRows.Count > 0)
            {
                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(int.Parse(dgv.SelectedRows[0].Cells["FamilyID"].Value.ToString()));
                B_GetDatas bg = new B_GetDatas();
                M_Families fm = bg.GetFamily().Where(c => c.ID == frm.FamilyCode).Single<M_Families>();
                frm.ThisFamily = fm;
                frm.btnParvandeAddDelFamily.Enabled = true;
                //frm.Show();
                ChangeForm(frm);
            }
            else
            {
                frmMessage frm2 = new frmMessage();
                frm2.label1.Text = "شخصی انتخاب نشده";
                frm2.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                frm2.ShowDialog();
            }
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlMain.Controls.Find("frmPersonFamilyAdd", false).Length > 0)
                {
                    Control ctn2 = pnlMain.Controls.Find("frmPersonFamilyAdd", false).Single();
                    frmPersonFamilyAdd AddFrm = ctn2 as frmPersonFamilyAdd;
                    if (AddFrm.FinalSubmitValidate() == true)
                    {
                        if (AddFrm.FamilyCode.ToString() == "0")
                        {
                            Control ctn = pnlMain.Controls.Find("dgvParvandeAddPerson", true).Single();
                            DataGridViewX dgv = ctn as DataGridViewX;
                            if (dgv.Rows.Count > 0)
                            {
                                if (((ComboBox)pnlMain.Controls.Find("cmbParvandeAddFamilyType", true).Single()).SelectedValue.ToString() != "84")
                                {
                                    bool st = false;
                                    bool Sp = false;
                                    foreach (DataGridViewRow rw in dgv.Rows)
                                    {
                                        if (String.IsNullOrEmpty(dgv.Rows[rw.Index].Cells[5].Value.ToString()) == true)
                                        {
                                            st = true;
                                        }
                                        if (dgv.Rows[rw.Index].Cells[16].Value.ToString() == "63")
                                        {
                                            Sp = true;
                                        }
                                    }
                                    if (st == true)
                                    {
                                        frmMessage msg = new frmMessage();
                                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                        msg.label1.Text = "در بین اعضای خانوار شما کسانی هستند که نسبت آنها با سرپرست مشخص نشده , لطفا آنها را تصحیح کنید و مجددا اقدام نمایید";
                                        msg.ShowDialog();
                                        return;
                                    }
                                    if (Sp == false)
                                    {
                                        frmMessage msg = new frmMessage();
                                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                        msg.label1.Text = "این خانوار فاقد سرپرست میباشد";
                                        msg.ShowDialog();
                                        return;
                                    }
                                }
                                B_InsertDatas ac = new B_InsertDatas();
                                int CityOrVillageCode = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddCityOrVillage", true).Single()).SelectedValue.ToString());
                                int ShomareSakhteman = int.Parse(((TextBox)pnlMain.Controls.Find("txtParvandeAddShomareSakhteman", true).Single()).Text);
                                int FamilyNumber = int.Parse(((TextBox)pnlMain.Controls.Find("txtParvandeAddFamilyNumber", true).Single()).Text);
                                int FamilyType = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddFamilyType", true).Single()).SelectedValue.ToString());
                                int Malekiat = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddMalekiat", true).Single()).SelectedValue.ToString());
                                string PostalCode = ((TextBox)pnlMain.Controls.Find("txtParvandeAddPostalCode", true).Single()).Text;
                                string Tell1 = ((MaskedTextBoxAdv)pnlMain.Controls.Find("txtParvandeAddTell1", true).Single()).Text.Replace("-", "");
                                string Tell2 = ((MaskedTextBoxAdv)pnlMain.Controls.Find("txtParvandeAddTell2", true).Single()).Text.Replace("-", "");
                                string Adrees1 = ((TextBox)pnlMain.Controls.Find("txtParvandeAddAdress", true).Single()).Text;
                                string Adrees2 = "";
                                try
                                {
                                    Adrees2 = ((TextBox)pnlMain.Controls.Find("txtAddDel32", true).Single()).Text;
                                }
                                catch { }
                                string Adrees3 = "";
                                try
                                {
                                    Adrees3 = ((TextBox)pnlMain.Controls.Find("txtAddDel64", true).Single()).Text;
                                }
                                catch { }
                                DateTime CreateDate = DateTime.Now;
                                long UnitCode = 10;
                                ac.InsertFamilyAndPerson(CityOrVillageCode, ShomareSakhteman, FamilyNumber, FamilyType, Malekiat, PostalCode, Tell1, Tell2, Adrees1, Adrees2, Adrees3, CreateDate, UnitCode, dgv);
                                frmMessage frm = new frmMessage();
                                frm.label1.Text = "خانوار با موفقیت ثبت شد";
                                frm.ShowDialog();
                                ////////////////////////////////////////////////////////////// EmpForm -------------------------//
                                frmPersonFamilyAdd frm2 = new frmPersonFamilyAdd();
                                pnlMain.Controls.Clear();
                                frm2.TopLevel = false;
                                frm2.AutoScroll = true;
                                frm2.Dock = DockStyle.Fill;
                                frm2.BackColor = pnlMain.BackColor;
                                pnlMain.Controls.Add(frm2);
                                frm2.Show();
                                ////////////////////////////////////////////////////////////// EmpForm -------------------------//
                            }
                            else
                            {
                                frmMessage frm = new frmMessage();
                                frm.label1.Text = "لطفا برای خانوار عضوی ثبت نمایید";
                                frm.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                frm.ShowDialog();
                            }
                        }///////////////////////////////////////////////////////// ویرایش خانوار ////////////////////////////////////////
                        else if (AddFrm.FamilyCode.ToString() != "0")
                        {
                            Control ctn = pnlMain.Controls.Find("dgvParvandeAddPerson", true).Single();
                            DataGridViewX dgv = ctn as DataGridViewX;
                            if (dgv.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow rw in dgv.Rows)
                                {
                                    if (rw.DefaultCellStyle.BackColor == Color.LightPink)
                                    {
                                        frmMessage frmm = new frmMessage();
                                        frmm.label1.Text = "اطلاعات خانوار شما صحیح نمیباشد , لطفا اطلاعات را تصحیح و مجددا سعی نمایید";
                                        frmm.ShowDialog();
                                        return;
                                    }
                                }
                                if (((ComboBox)pnlMain.Controls.Find("cmbParvandeAddFamilyType", true).Single()).SelectedValue.ToString() != "84")
                                {
                                    bool st = false;
                                    bool Sp = false;
                                    foreach (DataGridViewRow rw in dgv.Rows)
                                    {
                                        if (String.IsNullOrEmpty(dgv.Rows[rw.Index].Cells[5].Value.ToString()) == true)
                                        {
                                            st = true;
                                        }
                                        if (dgv.Rows[rw.Index].Cells[16].Value.ToString() == "63")
                                        {
                                            Sp = true;
                                        }
                                    }
                                    if (st == true)
                                    {
                                        frmMessage msg = new frmMessage();
                                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                        msg.label1.Text = "در بین اعضای خانوار شما کسانی هستند که نسبت آنها با سرپرست مشخص نشده , لطفا آنها را تصحیح کنید و مجددا اقدام نمایید";
                                        msg.ShowDialog();
                                        return;
                                    }
                                    if (Sp == false)
                                    {
                                        frmMessage msg = new frmMessage();
                                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                        msg.label1.Text = "این خانوار فاقد سرپرست میباشد";
                                        msg.ShowDialog();
                                        return;
                                    }
                                }
                                B_UpdateDatas ac = new B_UpdateDatas();
                                B_GetDatas bd = new B_GetDatas();
                                int CityOrVillageCode = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddCityOrVillage", true).Single()).SelectedValue.ToString());
                                int ShomareSakhteman = int.Parse(((TextBox)pnlMain.Controls.Find("txtParvandeAddShomareSakhteman", true).Single()).Text);
                                int FamilyNumber = int.Parse(((TextBox)pnlMain.Controls.Find("txtParvandeAddFamilyNumber", true).Single()).Text);
                                int FamilyType = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddFamilyType", true).Single()).SelectedValue.ToString());
                                int Malekiat = int.Parse(((ComboBox)pnlMain.Controls.Find("cmbParvandeAddMalekiat", true).Single()).SelectedValue.ToString());
                                string PostalCode = ((TextBox)pnlMain.Controls.Find("txtParvandeAddPostalCode", true).Single()).Text;
                                string Tell1 = ((MaskedTextBoxAdv)pnlMain.Controls.Find("txtParvandeAddTell1", true).Single()).Text.Replace("-", "");
                                string Tell2 = ((MaskedTextBoxAdv)pnlMain.Controls.Find("txtParvandeAddTell2", true).Single()).Text.Replace("-", "");
                                string Adrees1 = ((TextBox)pnlMain.Controls.Find("txtParvandeAddAdress", true).Single()).Text;
                                string Adrees2 = "";
                                try
                                {
                                    Adrees2 = ((TextBox)pnlMain.Controls.Find("txtAddDel32", true).Single()).Text;
                                }
                                catch { }
                                string Adrees3 = "";
                                try
                                {
                                    Adrees3 = ((TextBox)pnlMain.Controls.Find("txtAddDel64", true).Single()).Text;
                                }
                                catch { }
                                DateTime CreateDate = DateTime.Now;
                                long UnitCode = 10;
                                List<M_FamilyMembers> mmb = bd.GetFamilyMember(AddFrm.FamilyCode);
                                ac.UpdateFamilyAndPerson(AddFrm.FamilyCode, CityOrVillageCode, ShomareSakhteman, FamilyNumber, FamilyType, Malekiat, PostalCode, Tell1, Tell2, Adrees1, Adrees2, Adrees3, CreateDate, UnitCode, dgv, mmb);
                                frmMessage frm = new frmMessage();
                                frm.label1.Text = "خانوار با موفقیت به روز رسانی شد";
                                frm.ShowDialog();
                            }
                            else
                            {
                                frmMessage frm = new frmMessage();
                                frm.label1.Text = "لطفا برای خانوار عضوی ثبت نمایید";
                                frm.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                                frm.ShowDialog();
                            }
                        }
                    }
                }
                if (pnlMain.Controls.Find("frmPersonel", false).Length > 0)
                {
                    frmPersonel frm = pnlMain.Controls.Find("frmPersonel", false).Single() as frmPersonel;
                    if (frm.Submit() == true)
                        ChangeForm(new frmPersonel());
                }
                if (pnlMain.Controls.Find("frmTajhizat", false).Length > 0)
                {
                    frmTajhizat frm = pnlMain.Controls.Find("frmTajhizat", false).Single() as frmTajhizat;
                    if (frm.Submit() == true)
                        ChangeForm(new frmTajhizat());
                }
                if (pnlMain.Controls.Find("frmPersonelDelete", false).Length > 0)
                {
                    frmPersonelDelete frm = pnlMain.Controls.Find("frmPersonelDelete", false).Single() as frmPersonelDelete;
                    if (frm.Submit() == true)
                        ChangeForm(new frmPersonelDelete());
                }
                if (pnlMain.Controls.Find("frmPersonelEdit", false).Length > 0)
                {
                    frmPersonelEdit frm = pnlMain.Controls.Find("frmPersonelEdit", false).Single() as frmPersonelEdit;
                    if (frm.Submit() == true)
                        ChangeForm(new frmPersonelEdit());
                }
                if (pnlMain.Controls.Find("frmEventTalagh", false).Length > 0)
                {
                    frmEventTalagh frm = pnlMain.Controls.Find("frmEventTalagh", false).Single() as frmEventTalagh;
                    if (frm.Submit() == true)
                        ChangeForm(new frmEventTalagh());
                }
                if (pnlMain.Controls.Find("frmEventEzdevaj", false).Length > 0)
                {
                    frmEventEzdevaj frm = pnlMain.Controls.Find("frmEventEzdevaj", false).Single() as frmEventEzdevaj;
                    if (frm.Submit() == true)
                        ChangeForm(new frmEventEzdevaj());
                }
                if (pnlMain.Controls.Find("frmEventMohajerat", false).Length > 0)
                {
                    frmEventMohajerat frm = pnlMain.Controls.Find("frmEventMohajerat", false).Single() as frmEventMohajerat;
                    if (frm.Submit() == true)
                        ChangeForm(new frmEventMohajerat());
                }
            }
            catch (Exception Ex)
            {
                L_ErrorLogs.Errors(Ex.Message);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            frmReadFromXML frm = new frmReadFromXML();
            ChangeForm(frm);
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            frmEventTalagh frm = new frmEventTalagh();
            ChangeForm(frm);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmEventMotherDeath frm = new frmEventMotherDeath();
            ChangeForm(frm);
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            frmEventTavalod frm = new frmEventTavalod();
            ChangeForm(frm);
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            frmEventMohajerat frm = new frmEventMohajerat();
            ChangeForm(frm);
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            frmEventEzdevaj frm = new frmEventEzdevaj();
            ChangeForm(frm);
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            frmTajhizat frm = new frmTajhizat();
            ChangeForm(frm);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            frmZijPoster frm = new frmZijPoster();
            ChangeForm(frm);
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            frmReportAll frm = new frmReportAll();
            ChangeForm(frm);
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            frmZijOtherData frm = new frmZijOtherData();
            ChangeForm(frm);
        }

        private void buttonX38_Click(object sender, EventArgs e)
        {
            frmPersonel frm = new frmPersonel();
            ChangeForm(frm);
        }

        private void buttonX37_Click(object sender, EventArgs e)
        {
            frmPersonelDelete frm = new frmPersonelDelete();
            ChangeForm(frm);
        }

        private void buttonX33_Click(object sender, EventArgs e)
        {

        }

        private void buttonX36_Click(object sender, EventArgs e)
        {
            frmPersonelEdit frm = new frmPersonelEdit();
            ChangeForm(frm);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex != -1)
            //{
            //    if (comboBox1.SelectedIndex == 0)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            //    if (comboBox1.SelectedIndex == 1)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            //    if (comboBox1.SelectedIndex == 2)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
            //    if (comboBox1.SelectedIndex == 3)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            //    if (comboBox1.SelectedIndex == 4)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            //    if (comboBox1.SelectedIndex == 5)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            //    if (comboBox1.SelectedIndex == 6)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            //    if (comboBox1.SelectedIndex == 7)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue;
            //    if (comboBox1.SelectedIndex == 8)
            //        styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue;
            //}
        }

        private void ribbonTabItem11_Click(object sender, EventArgs e)
        {

        }
    }
}
