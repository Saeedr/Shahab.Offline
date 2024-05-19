using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Shahab.Offline.Model;
using Shahab.Offline.Logging;
using Shahab.Offline.BL;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;

namespace Shahab.Offline.WinUI
{
    public partial class frmReadFromXML : Form
    {
        public frmReadFromXML()
        {
            InitializeComponent();
        }

        private void frmReadFromXML_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// تعریف لیست های مورد نیاز
        /// </summary>
        List<M_UnitPlace> UnitList = new List<M_UnitPlace>();
        List<M_Families> FamilyList = new List<M_Families>();
        List<M_FamilyMembers> FamilyMemeberList = new List<M_FamilyMembers>();
        List<M_Address> AddressList = new List<M_Address>();

        /// <summary>
        /// افزودن کنترل های مربوط به خانوار
        /// </summary>
        /// <param name="id">کد خانوار</param>
        /// <param name="Adress">آدرس</param>
        /// <param name="ZipCode">کد پستی</param>
        /// <param name="Telephone">شماره تلفن</param>
        /// <param name="Valid">اطلاعات خانوار معتبر هست یا خیر</param>
        private void AddFamilyItem(int id, string Adress, string ZipCode, string Telephone, bool Valid)
        {
            Label lbl4 = new Label();
            lbl4.BackColor = System.Drawing.Color.Transparent;
            lbl4.Name = "label4";
            lbl4.Size = new System.Drawing.Size(409, 32);
            lbl4.TabIndex = 0;
            lbl4.Text = "آدرس : " + Adress;
            lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lbl5 = new Label();
            lbl5.BackColor = System.Drawing.Color.Transparent;
            lbl5.Name = "label5";
            lbl5.Size = new System.Drawing.Size(139, 32);
            lbl5.TabIndex = 1;
            lbl5.Text = "شماره تلفن : " + Telephone;
            lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lbl6 = new Label();
            lbl6.BackColor = System.Drawing.Color.Transparent;
            lbl6.Name = "label6";
            lbl6.Size = new System.Drawing.Size(206, 32);
            lbl6.TabIndex = 2;
            lbl6.Text = "کد پستی : " + ZipCode;
            lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            DevComponents.DotNetBar.ButtonX btnX = new DevComponents.DotNetBar.ButtonX();
            btnX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            btnX.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            btnX.FocusCuesEnabled = false;
            btnX.Font = new System.Drawing.Font("Tahoma", 8F);
            btnX.Image = global::Shahab.Offline.WinUI.Properties.Resources.pen;
            btnX.ImageFixedSize = new System.Drawing.Size(20, 20);
            btnX.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            btnX.Name = "btn" + id;
            btnX.Size = new System.Drawing.Size(76, 29);
            btnX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            btnX.TabIndex = 22;
            btnX.Text = "ویراش";
            btnX.Tag = id.ToString();
            btnX.Click += btn2_Click;
            btnX.Visible = false;

            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.BackColor = System.Drawing.Color.LightSteelBlue;
            if (Valid == false)
            {
                pnl.BackColor = System.Drawing.Color.LightPink;
                btnX.Visible = true;
            }
            pnl.Name = "pnl" + id;
            pnl.Size = new System.Drawing.Size(854, 35);
            pnl.Controls.Add(lbl4);
            pnl.Controls.Add(lbl5);
            pnl.Controls.Add(lbl6);
            pnl.Controls.Add(btnX);
            flowLayoutPanel1.Controls.Add(pnl);
        }

        /// <summary>
        /// دریافت کد از جدول پابلیک کتگوری با ایدی پدر و نام
        /// </summary>
        /// <param name="ParentID">کد پدر</param>
        /// <param name="Name">نام</param>
        /// <returns>ایدی مربوطه</returns>
        private int GetPublicCategoriIDByName(int ParentID, string Name)
        {
            string[] splitName = Name.Split('-');
            B_ReportPublicCategori BL = new B_ReportPublicCategori();
            M_PublicCategory pc = BL.GetPublicCategoriByNameAndParentCode(ParentID, splitName[1].Trim());
            if (pc != null)
                return pc.ID;
            else
                return 0;
        }

        /// <summary>
        /// افزودن کنترل های مربوط به مناطق تحت پوشش
        /// </summary>
        /// <param name="id">کد</param>
        /// <param name="Name">نام</param>
        /// <param name="PopType">نوع جمعیت</param>
        /// <param name="Population">جمعیت</param>
        private void AddItem(int id, string Name, string PopType, string Population)
        {
            Label lbl4 = new Label();
            lbl4.BackColor = System.Drawing.Color.Transparent;
            lbl4.Name = "label4";
            lbl4.Size = new System.Drawing.Size(409, 32);
            lbl4.TabIndex = 0;
            string[] s = Name.Split('-');
            lbl4.Text = "نام شهر / روستا : " + s[0].Trim() + " ... نوع روستا : " + s[1].Trim();
            lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lbl5 = new Label();
            lbl5.BackColor = System.Drawing.Color.Transparent;
            lbl5.Name = "label5";
            lbl5.Size = new System.Drawing.Size(139, 32);
            lbl5.TabIndex = 1;
            lbl5.Text = "کد والد : " + PopType;
            lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lbl6 = new Label();
            lbl6.BackColor = System.Drawing.Color.Transparent;
            lbl6.Name = "label6";
            lbl6.Size = new System.Drawing.Size(206, 32);
            lbl6.TabIndex = 2;
            lbl6.Text = "جمعیت تحت پوشش : " + Population;
            lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            DevComponents.DotNetBar.ButtonX btnX = new DevComponents.DotNetBar.ButtonX();
            btnX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            btnX.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            btnX.FocusCuesEnabled = false;
            btnX.Font = new System.Drawing.Font("Tahoma", 8F);
            btnX.Image = global::Shahab.Offline.WinUI.Properties.Resources.pen;
            btnX.ImageFixedSize = new System.Drawing.Size(20, 20);
            btnX.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            btnX.Name = "btn" + id;
            btnX.Size = new System.Drawing.Size(76, 29);
            btnX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            btnX.TabIndex = 22;
            btnX.Text = "اصلاح";
            btnX.Tag = id.ToString();
            btnX.Click += btn_Click;
            btnX.Visible = false;

            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.BackColor = System.Drawing.Color.LightSteelBlue;
            if (UnitList[id].PlaceID == 0 || UnitList[id].PlaceName == "" || UnitList[id].UnitCode == 0 || UnitList[id].PlaceTypeID == 0)
            {
                pnl.BackColor = System.Drawing.Color.LightPink;
                btnX.Visible = true;
            }
            pnl.Name = "pnl" + id;
            pnl.Size = new System.Drawing.Size(854, 35);
            pnl.Controls.Add(lbl4);
            pnl.Controls.Add(lbl5);
            pnl.Controls.Add(lbl6);
            pnl.Controls.Add(btnX);
            flowLayoutPanel1.Controls.Add(pnl);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ButtonX btn = sender as ButtonX;
            int id = int.Parse(btn.Tag.ToString());
            M_Families fmA = FamilyList[id];
            List<M_FamilyMembers> fmmA = FamilyMemeberList.Where(c => c.FamilyIDNotMap == FamilyList.IndexOf(FamilyList[id])).ToList<M_FamilyMembers>();
            M_Address addA=AddressList[id];
            frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fmA, fmmA, addA);
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.IsFirstEditOK == true)
            {
                FamilyList[id] = frm.ThisFamily;
                AddressList[id] = frm.ThisAddress;
                int i = 0;
                foreach (M_FamilyMembers fm in frm.ThisFamilyMember)
                {
                    FamilyMemeberList[i] = fm;
                    i++;
                }
                foreach (Control ctn in flowLayoutPanel1.Controls)
                {
                    if (ctn is FlowLayoutPanel)
                    {
                        FlowLayoutPanel pnl = ctn as FlowLayoutPanel;
                        if (pnl.Name.Replace("pnl", "") == id.ToString())
                        {
                            ctn.BackColor = Color.LightGreen;
                            btn.Visible = false;
                        }
                    }
                }
            }
            frm.Dispose();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ButtonX btn = sender as ButtonX;
            if (UnitList[int.Parse(btn.Tag.ToString())].PlaceID == 0 || UnitList[int.Parse(btn.Tag.ToString())].PlaceName == "" || UnitList[int.Parse(btn.Tag.ToString())].UnitCode == 0 || UnitList[int.Parse(btn.Tag.ToString())].PlaceTypeID == 0)
            {
                string msg = "";
                if (UnitList[int.Parse(btn.Tag.ToString())].PlaceID == 0)
                    msg = "- این منطقه کد والد ندارد" + Environment.NewLine;
                if (UnitList[int.Parse(btn.Tag.ToString())].PlaceName == "")
                    msg += "- این منطقه نام ندارد" + Environment.NewLine;
                if (UnitList[int.Parse(btn.Tag.ToString())].UnitCode == 0)
                    msg += "- این منطقه کد ندارد" + Environment.NewLine;
                if (UnitList[int.Parse(btn.Tag.ToString())].PlaceTypeID == 0)
                    msg += "- نوع این روستا مشخص نیست";
                lblErrorMessages.Text = msg;
                animator1.Show(pnlError);
                return;
            }
            //SomeCode

            B_InsertDatas BI = new B_InsertDatas();

            UnitList[int.Parse(btn.Tag.ToString())].IsAdded = true;
            foreach (Control ctn in flowLayoutPanel1.Controls)
            {
                if (ctn is FlowLayoutPanel)
                {
                    FlowLayoutPanel pnl = ctn as FlowLayoutPanel;
                    if (pnl.Name.Replace("pnl", "") == btn.Name.Replace("btn", ""))
                    {
                        pnl.BackColor = Color.LightGreen;
                    }
                }
            }
            btn.Text = "اضافه شد";
            btn.Image = null;
            btn.Enabled = false;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (rdoUnit.Checked == true)
            {
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "برای این کار لازم است تمام واحدهای جاری حذف شوند" + Environment.NewLine + "این کار انجام شود ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    OpenFileDialog fl = new OpenFileDialog();
                    fl.Filter = "فایل data.xml|data.xml";
                    fl.Multiselect = false;
                    int i = 0;
                    if (fl.ShowDialog() == DialogResult.OK)
                    {
                        animator1.Show(panel1);
                        UnitList.Clear();
                        flowLayoutPanel1.Controls.Clear();
                        XmlDataDocument xmldoc = new XmlDataDocument();
                        txtConfingXMLAdress.Text = fl.FileName;
                        xmldoc.Load(fl.FileName);
                        XmlNodeList xmlnode = xmldoc.GetElementsByTagName("tblPlaces");
                        circularProgress1.Visible = true;
                        circularProgress1.Maximum = xmlnode.Count;
                        circularProgress1.Value = 1;
                        label1.Text = "در حال خواندن اطلاعات";
                        foreach (XmlNode xn in xmlnode)
                        {
                            Application.DoEvents();
                            string PlaceName = "";
                            int popType = 0;
                            string Population = "";
                            if (xn["PlaceName"] != null)
                                PlaceName = xn["PlaceName"].InnerText;
                            if (xn["popType"] != null)
                                try { popType = int.Parse(xn["popType"].InnerText); }
                                catch { }
                            if (xn["Population"] != null)
                                Population = xn["Population"].InnerText;
                            string[] s = PlaceName.Split('-');

                            string pName;
                            try { pName = s[0].Trim(); }
                            catch { pName = ""; }

                            string tName;
                            try { tName = s[1].Trim(); }
                            catch { tName = ""; }

                            int pCode;
                            try { pCode = int.Parse(s[2].Trim()); }
                            catch { pCode = 0; }

                            int TypeCode = 0;
                            try
                            {
                                B_ReportPublicCategori bg = new B_ReportPublicCategori();
                                M_PublicCategory pc = bg.GetPublicCategoriByNameAndParentCode(96, tName);
                                TypeCode = pc.ID;
                            }
                            catch { TypeCode = 0; }

                            UnitList.Add(new M_UnitPlace
                            {
                                CreateDate = DateTime.Now,
                                PlaceName = pName,
                                PlaceID = pCode,
                                UnitCode = popType,
                                PlaceTypeID = TypeCode
                            });
                            AddItem(i, PlaceName, popType.ToString(), Population);
                            circularProgress1.Value++;
                            Application.DoEvents();
                            i++;
                        }
                        label1.Text = "تعداد واحد های یافت شده : " + UnitList.Count;
                        circularProgress1.Visible = false;
                        buttonX5.Text = "افزودن همه مناطق";
                        buttonX5.Visible = true;
                        animator1.Hide(panel1);
                    }
                }
            }

            if (rdoFamily.Checked == true)
            {
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "برای ایمپورت کردن خانواده نیاز به پاک شدن اطلاعات خانوار در بانک اطلاعاتی است" + Environment.NewLine + "این کار انجام شود ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    OpenFileDialog fl = new OpenFileDialog();
                    fl.Filter = "فایل data.xml|data.xml";
                    fl.Multiselect = false;
                    int i = 0;
                    if (fl.ShowDialog() == DialogResult.OK)
                    {
                        //animator1.Show(panel1);
                        panel1.Visible = true;
                        Application.DoEvents();
                        UnitList.Clear();
                        flowLayoutPanel1.Controls.Clear();
                        XmlDataDocument xmldoc = new XmlDataDocument();
                        txtConfingXMLAdress.Text = fl.FileName;
                        xmldoc.Load(fl.FileName);
                        XmlNodeList xmlnode = xmldoc.GetElementsByTagName("family");
                        circularProgress1.Visible = true;
                        circularProgress2.Visible = true;
                        circularProgress1.Maximum = xmlnode.Count;
                        circularProgress1.Value = 1;
                        label1.Text = "در حال خواندن اطلاعات";
                        foreach (XmlNode xn in xmlnode)
                        {
                            bool Valid = true;
                            Application.DoEvents();
                            if (xn["member"] != null)
                            {
                                M_Families fm = new M_Families();
                                M_Address ad = new M_Address();
                                if (xn["familyType"] != null)
                                    fm.FamilyTypeCode = GetPublicCategoriIDByName(82, xn["familyType"].InnerText);
                                else
                                {
                                    fm.FamilyTypeCode = 0;
                                    Valid = false;
                                }
                                if (xn["caringPhone"] != null)
                                    fm.HeaderMobileNumber = xn["caringPhone"].InnerText.Replace("-", "");
                                if (xn["ownerSt"] != null)
                                    fm.OwnrshipCode = GetPublicCategoriIDByName(77, xn["ownerSt"].InnerText);
                                else
                                {
                                    fm.OwnrshipCode = 0;
                                    Valid = false;
                                }
                                if (xn["vilName"] != null)
                                {
                                    string[] s = xn["vilName"].InnerText.Split('-');
                                    if (s[2].Trim() != string.Empty)
                                    {
                                        fm.PlaceID = int.Parse(s[2]);
                                        ad.PlaceID = int.Parse(s[2]);
                                    }
                                    else
                                    {
                                        Valid = false;
                                        fm.PlaceID = 0;
                                        ad.PlaceID = 0;
                                    }
                                }
                                if (xn["addr"] != null)
                                    ad.AddressString1 = xn["addr"].InnerText;
                                if (xn["zip"] != null && xn["zip"].InnerText.Replace("-", "").Length==10)
                                    ad.ZipCode = xn["zip"].InnerText.Replace("-", "");
                                else
                                {
                                    ad.ZipCode = "";
                                }
                                if (xn["phone"] != null)
                                    ad.TelephoneNumber = xn["phone"].InnerText.Replace("-", "");
                                if (xn["buildNo"] != null)
                                    try
                                    {
                                        ad.BuildingNumber = int.Parse(xn["buildNo"].InnerText.Trim());
                                    }
                                    catch { }
                                else
                                    Valid = false;
                                    ad.FamilyIDNotMap = FamilyList.IndexOf(fm);
                                AddressList.Add(ad);
                                XmlDocument XmlD = new XmlDocument();
                                string xml = "<?xml version=\"1.0\" standalone=\"yes\"?><region>" + xn.InnerXml.ToString() + "</region>";
                                XmlD.LoadXml(xml);
                                XmlNodeList xmlnodes = XmlD.GetElementsByTagName("member");
                                circularProgress2.Value = 0;
                                circularProgress2.Maximum = xmlnodes.Count;
                                foreach (XmlNode xn2 in xmlnodes)
                                {
                                    M_FamilyMembers fmm = new M_FamilyMembers();
                                    if (xn2["name"] != null)
                                        fmm.FirstName = xn2["name"].InnerText;
                                    else
                                    {
                                        fmm.FirstName = "";
                                        Valid = false;
                                    }
                                    if (xn2["lastName"] != null)
                                        fmm.LastName = xn2["lastName"].InnerText;
                                    else
                                    {
                                        fmm.LastName = "";
                                        Valid = false;
                                    }
                                    if (xn2["relTo"] != null)
                                        fmm.Relationship = GetPublicCategoriIDByName(62, xn2["relTo"].InnerText);
                                    else
                                    {
                                        fmm.Relationship = 0;
                                        Valid = false;
                                    }
                                    if (xn2["natCode"] != null)
                                        fmm.NationalCode = xn2["natCode"].InnerText;
                                    else
                                    {
                                        fmm.NationalCode = "";
                                        Valid = false;
                                    }
                                    if (xn2["nat"] != null)
                                        fmm.Nationality = GetPublicCategoriIDByName(7, xn2["nat"].InnerText);
                                    else
                                    {
                                        fmm.Nationality = 0;
                                        Valid = false;
                                    }
                                    if (xn2["birthDate"] != null)
                                    {
                                        string[] date1 = xn2["birthDate"].InnerText.Split('/');
                                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                                        DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                                        fmm.BirthDate = dt1;
                                    }
                                    else
                                    {
                                        Valid = false;
                                        string[] date1 = "1000/10/10".Split('/');
                                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                                        DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                                        fmm.BirthDate = dt1;
                                    }
                                    if (xn2["gender"] != null)
                                        fmm.Gender = GetPublicCategoriIDByName(10, xn2["gender"].InnerText);
                                    else
                                        fmm.Gender = 0;
                                    if (xn2["marSt"] != null)
                                        fmm.MaritalStatus = GetPublicCategoriIDByName(29, xn2["marSt"].InnerText);
                                    else
                                        fmm.MaritalStatus = 0;
                                    if (xn2["edu"] != null)
                                        fmm.Education = GetPublicCategoriIDByName(51, xn2["edu"].InnerText);
                                    else
                                        fmm.Education = 0;
                                    if (xn2["job"] != null)
                                        fmm.Job = GetPublicCategoriIDByName(13, xn2["job"].InnerText);
                                    else
                                        fmm.Job = 0;
                                    if (xn2["lastAct"] != null)
                                        fmm.Activity = GetPublicCategoriIDByName(73, xn2["lastAct"].InnerText);
                                    else
                                        fmm.Activity = 0;
                                    if (xn2["insType1"] != null)
                                        fmm.FirstInsurance = GetPublicCategoriIDByName(35, xn2["insType1"].InnerText);
                                    else
                                    {
                                        fmm.FirstInsurance = 0;
                                        Valid = false;
                                    }
                                    if (xn2["insType2"] != null)
                                        fmm.SecondInsurance = GetPublicCategoriIDByName(43, xn2["insType2"].InnerText);
                                    else
                                    {
                                        fmm.SecondInsurance = 0;
                                        Valid = false;
                                    }
                                    if (xn2["resStat"] != null)
                                        fmm.ResidentStatus = GetPublicCategoriIDByName(109, xn2["resStat"].InnerText);
                                    else
                                    {
                                        fmm.ResidentStatus = 0;
                                        Valid = false;
                                    }
                                    fmm.MobileNumber = "09";
                                    fmm.FamilyIDNotMap = FamilyList.Count;
                                    FamilyMemeberList.Add(fmm);
                                    circularProgress2.Value++;
                                    circularProgress2.Text = ((circularProgress2.Value * 100) / xmlnodes.Count).ToString() + " %";
                                    label4.Text = "خانوارهای یافت شده : " + FamilyList.Count + " .::. تعداد افراد یافت شده : " + FamilyMemeberList.Count;
                                    Application.DoEvents();
                                }
                                fm.IsValid = Valid;
                                FamilyList.Add(fm);
                            }
                            circularProgress1.Value++;
                            Application.DoEvents();
                            i++;
                            circularProgress1.Text = ((circularProgress1.Value * 100) / xmlnode.Count).ToString() + " %";
                        }
                        List<M_Families> FM = FamilyList.OrderBy(c=>c.IsValid).ToList<M_Families>();
                        foreach (M_Families fm in FM)
                        {
                            int i1 = FamilyList.IndexOf(fm);
                            M_Address ad = AddressList[FamilyList.IndexOf(fm)];
                            AddFamilyItem(FamilyList.IndexOf(fm), ad.AddressString1, ad.ZipCode, ad.TelephoneNumber, fm.IsValid);
                            Application.DoEvents();
                        }
                        label1.Text = "تعداد خانوارهای یافت شده : " + FamilyList.Count + " .::. تعداد افراد یافت شده : " + FamilyMemeberList.Count;
                        circularProgress1.Visible = false;
                        circularProgress2.Visible = false;
                        buttonX5.Text = "افزودن همه خانوارها";
                        buttonX5.Visible = true;
                        //animator1.Hide(panel1);
                        panel1.Visible = false;
                        Application.DoEvents();
                    }
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            animator1.Hide(pnlError);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (rdoUnit.Checked == true && flowLayoutPanel1.Controls.Count > 0 && UnitList.Count > 0)
            {
                foreach (M_UnitPlace plc in UnitList)
                {
                    if (plc.PlaceID != 0 && plc.PlaceName != "" && plc.UnitCode != 0 && plc.PlaceTypeID != 0)
                    {
                        if (plc.IsAdded == false)
                        {
                            //SomeCode
                            plc.IsAdded = true;
                        }
                        foreach (Control ctn in flowLayoutPanel1.Controls)
                        {
                            if (ctn is FlowLayoutPanel)
                            {
                                FlowLayoutPanel pnl = ctn as FlowLayoutPanel;
                                if (pnl.Name.Replace("pnl", "") == UnitList.IndexOf(plc).ToString())
                                {
                                    flowLayoutPanel1.Controls.Remove(ctn);
                                }
                            }
                        }
                    }
                }
                label1.Text = "واحد ها با موقیت اضافه شد .::. تعداد واحد های اضافه شده : " + (UnitList.Count - flowLayoutPanel1.Controls.Count) + " .::. واحدهای غیر قابل استفاده : " + flowLayoutPanel1.Controls.Count;
                buttonX5.Visible = false;
            }
            if (rdoFamily.Checked == true && flowLayoutPanel1.Controls.Count > 0 && FamilyList.Count > 0)
            {
                foreach (M_Families fml in FamilyList)
                {
                    B_InsertDatas BL = new B_InsertDatas();
                    BL.InsertFamily(fml, FamilyMemeberList.Where(c => c.FamilyIDNotMap == FamilyList.IndexOf(fml)).ToList<M_FamilyMembers>(), AddressList[FamilyList.IndexOf(fml)]);
                    foreach (Control ctn in flowLayoutPanel1.Controls)
                    {
                        if (ctn is FlowLayoutPanel)
                        {
                            FlowLayoutPanel pnl = ctn as FlowLayoutPanel;
                            if (pnl.Name.Replace("pnl", "") == FamilyList.IndexOf(fml).ToString())
                            {
                                flowLayoutPanel1.Controls.Remove(ctn);
                            }
                        }
                    }
                }
            }
        }
    }
}
