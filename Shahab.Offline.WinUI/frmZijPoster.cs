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

namespace Shahab.Offline.WinUI
{
    public partial class frmZijPoster : Form
    {
        public frmZijPoster()
        {
            InitializeComponent();
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void frmZijPoster_Load(object sender, EventArgs e)
        {
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmZijPoster_Load_1(object sender, EventArgs e)
        {
            int Count1 = 0, Count2 = 0;
            int Count3 = 0, Count4 = 0;
            for (int i = 0; i <= 19; i++)
            {
                string s = "";
                if (i == 0)
                    s = "BirthDate > '" + DateTime.Today.AddMonths(-1) + "'";
                else if (i == 1)
                    s = "BirthDate between '" + DateTime.Today.Year + "' and '" + DateTime.Today.AddMonths(-2) + "'";
                else if (i == 2)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-4).Year + "' and '" + DateTime.Today.Year + "'";
                else if (i == 3)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-9).Year + "' and '" + DateTime.Today.AddYears(-4).Year + "'";
                else if (i == 4)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-14).Year + "' and '" + DateTime.Today.AddYears(-9).Year + "'";
                else if (i == 5)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-19).Year + "' and '" + DateTime.Today.AddYears(-14).Year + "'";
                else if (i == 6)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-24).Year + "' and '" + DateTime.Today.AddYears(-19).Year + "'";
                else if (i == 7)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-29).Year + "' and '" + DateTime.Today.AddYears(-24).Year + "'";
                else if (i == 8)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-34).Year + "' and '" + DateTime.Today.AddYears(-29).Year + "'";
                else if (i == 9)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-39).Year + "' and '" + DateTime.Today.AddYears(-34).Year + "'";
                else if (i == 10)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-44).Year + "' and '" + DateTime.Today.AddYears(-39).Year + "'";
                else if (i == 11)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-49).Year + "' and '" + DateTime.Today.AddYears(-44).Year + "'";
                else if (i == 12)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-54).Year + "' and '" + DateTime.Today.AddYears(-49).Year + "'";
                else if (i == 13)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-59).Year + "' and '" + DateTime.Today.AddYears(-54).Year + "'";
                else if (i == 14)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-64).Year + "' and '" + DateTime.Today.AddYears(-59).Year + "'";
                else if (i == 15)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-69).Year + "' and '" + DateTime.Today.AddYears(-64).Year + "'";
                else if (i == 16)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-74).Year + "' and '" + DateTime.Today.AddYears(-69).Year + "'";
                else if (i == 17)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-79).Year + "' and '" + DateTime.Today.AddYears(-74).Year + "'";
                else if (i == 18)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-84).Year + "' and '" + DateTime.Today.AddYears(-79).Year + "'";
                else if (i == 19)
                    s = "BirthDate < '" + DateTime.Today.AddYears(-85).Year + "'";

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select COUNT([ID]),Gender from [dbo].[FamilyMembers] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                        )
                                    ) group by Gender order by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                int i1 = 1;
                while (Rd.Read())
                {
                    i1++;
                    if (Rd[1].ToString() == "11")
                    {
                        Count1 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl1_" + (int.Parse(Rd[1].ToString()) - 10) + "_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "12")
                    {
                        Count2 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl1_" + (int.Parse(Rd[1].ToString()) - 10) + "_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();
                cm.CommandText = @"select COUNT([ID]),Gender from [dbo].[FamilyMembers] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                        )
                                    ) group by Gender order by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                i1 = 1;
                while (Rd.Read())
                {
                    i1++;
                    if (Rd[1].ToString() == "11")
                    {
                        Count3 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl1_3_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "12")
                    {
                        Count4 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl1_4_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();

                this.Controls.Find("lbl1_5_" + (i + 1), true).Single().Text =
                    (int.Parse(this.Controls.Find("lbl1_1_" + (i + 1), true).Single().Text) + int.Parse(this.Controls.Find("lbl1_3_" + (i + 1), true).Single().Text)).ToString();

                this.Controls.Find("lbl1_6_" + (i + 1), true).Single().Text =
                    (int.Parse(this.Controls.Find("lbl1_2_" + (i + 1), true).Single().Text) + int.Parse(this.Controls.Find("lbl1_4_" + (i + 1), true).Single().Text)).ToString();
            }
            lbl1_1_21.Text = Count1.ToString();
            lbl1_2_21.Text = Count2.ToString();
            lbl1_3_21.Text = Count3.ToString();
            lbl1_4_21.Text = Count4.ToString();
            lbl1_5_21.Text = (int.Parse(lbl1_1_21.Text) + int.Parse(lbl1_3_21.Text)).ToString();
            lbl1_6_21.Text = (int.Parse(lbl1_2_21.Text) + int.Parse(lbl1_4_21.Text)).ToString();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int Count1_1 = 0, Count2_1 = 0;
            int Count3_1 = 0, Count4_1 = 0;
            for (int i = 0; i <= 19; i++)
            {
                string s = "";
                if (i == 0)
                    s = "BirthDate > '" + DateTime.Today.AddMonths(-1) + "'";
                else if (i == 1)
                    s = "BirthDate between '" + DateTime.Today.Year + "' and '" + DateTime.Today.AddMonths(-2) + "'";
                else if (i == 2)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-4).Year + "' and '" + DateTime.Today.Year + "'";
                else if (i == 3)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-9).Year + "' and '" + DateTime.Today.AddYears(-4).Year + "'";
                else if (i == 4)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-14).Year + "' and '" + DateTime.Today.AddYears(-9).Year + "'";
                else if (i == 5)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-19).Year + "' and '" + DateTime.Today.AddYears(-14).Year + "'";
                else if (i == 6)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-24).Year + "' and '" + DateTime.Today.AddYears(-19).Year + "'";
                else if (i == 7)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-29).Year + "' and '" + DateTime.Today.AddYears(-24).Year + "'";
                else if (i == 8)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-34).Year + "' and '" + DateTime.Today.AddYears(-29).Year + "'";
                else if (i == 9)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-39).Year + "' and '" + DateTime.Today.AddYears(-34).Year + "'";
                else if (i == 10)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-44).Year + "' and '" + DateTime.Today.AddYears(-39).Year + "'";
                else if (i == 11)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-49).Year + "' and '" + DateTime.Today.AddYears(-44).Year + "'";
                else if (i == 12)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-54).Year + "' and '" + DateTime.Today.AddYears(-49).Year + "'";
                else if (i == 13)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-59).Year + "' and '" + DateTime.Today.AddYears(-54).Year + "'";
                else if (i == 14)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-64).Year + "' and '" + DateTime.Today.AddYears(-59).Year + "'";
                else if (i == 15)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-69).Year + "' and '" + DateTime.Today.AddYears(-64).Year + "'";
                else if (i == 16)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-74).Year + "' and '" + DateTime.Today.AddYears(-69).Year + "'";
                else if (i == 17)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-79).Year + "' and '" + DateTime.Today.AddYears(-74).Year + "'";
                else if (i == 18)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-84).Year + "' and '" + DateTime.Today.AddYears(-79).Year + "'";
                else if (i == 19)
                    s = "BirthDate < '" + DateTime.Today.AddYears(-85).Year + "'";

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select COUNT([ID]),Gender from [dbo].[temp_Events] where EventTypeID = 129 and " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                        )
                                    ) group by Gender order by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                int i1 = 1;
                while (Rd.Read())
                {
                    i1++;
                    if (Rd[1].ToString() == "11")
                    {
                        Count1_1 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl2_" + (int.Parse(Rd[1].ToString()) - 10) + "_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "12")
                    {
                        Count2_1 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl2_" + (int.Parse(Rd[1].ToString()) - 10) + "_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();
                cm.CommandText = @"select COUNT([ID]),Gender from [dbo].[temp_Events] where EventTypeID = 129 and " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                        )
                                    ) group by Gender order by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                i1 = 1;
                while (Rd.Read())
                {
                    i1++;
                    if (Rd[1].ToString() == "11")
                    {
                        Count3_1 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl2_3_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "12")
                    {
                        Count4_1 += int.Parse(Rd[0].ToString());
                        this.Controls.Find("lbl2_4_" + (i + 1), true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();

                this.Controls.Find("lbl2_5_" + (i + 1), true).Single().Text =
                    (int.Parse(this.Controls.Find("lbl2_1_" + (i + 1), true).Single().Text) + int.Parse(this.Controls.Find("lbl2_3_" + (i + 1), true).Single().Text)).ToString();
                this.Controls.Find("lbl2_6_" + (i + 1), true).Single().Text =
                    (int.Parse(this.Controls.Find("lbl2_2_" + (i + 1), true).Single().Text) + int.Parse(this.Controls.Find("lbl2_4_" + (i + 1), true).Single().Text)).ToString();
            }
            lbl2_1_21.Text = Count1_1.ToString();
            lbl2_2_21.Text = Count2_1.ToString();
            lbl2_3_21.Text = Count3_1.ToString();
            lbl2_4_21.Text = Count4_1.ToString();
            lbl2_5_21.Text = (int.Parse(lbl2_1_21.Text) + int.Parse(lbl2_3_21.Text)).ToString();
            lbl2_6_21.Text = (int.Parse(lbl2_2_21.Text) + int.Parse(lbl2_4_21.Text)).ToString();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] Dead = { "خونریزی", "عفونت بعد از زایمان", "پره اکلامپسی", "بیماری های قلبی", "سایر علل" };
            for (int j = 0; j <= 4; j++)
            {
                for (int i = 4; i <= 12; i++)
                {
                    string s = "";
                    if (i == 4)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-14).Year + "' and '" + DateTime.Today.AddYears(-9).Year + "'";
                    else if (i == 5)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-19).Year + "' and '" + DateTime.Today.AddYears(-14).Year + "'";
                    else if (i == 6)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-24).Year + "' and '" + DateTime.Today.AddYears(-19).Year + "'";
                    else if (i == 7)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-29).Year + "' and '" + DateTime.Today.AddYears(-24).Year + "'";
                    else if (i == 8)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-34).Year + "' and '" + DateTime.Today.AddYears(-29).Year + "'";
                    else if (i == 9)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-39).Year + "' and '" + DateTime.Today.AddYears(-34).Year + "'";
                    else if (i == 10)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-44).Year + "' and '" + DateTime.Today.AddYears(-39).Year + "'";
                    else if (i == 11)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-49).Year + "' and '" + DateTime.Today.AddYears(-44).Year + "'";
                    else if (i == 12)
                        s = "BirthDate < '" + DateTime.Today.AddYears(-49).Year + "'";

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = cn;
                    cm.CommandText = @"select COUNT([ID]) from [dbo].[temp_Events] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                        )
                                    ) 
									and Gender = 12 and [EventTypeID] = 129 and [EventID] in
									(
										select [ID] from [dbo].[temp_Dead] where [ElateMarg] like N'" + Dead[j] + "')";
                    cn.Open();
                    this.Controls.Find("lbl3_" + (j + 1) + "_" + (i - 3), true).Single().Text = cm.ExecuteScalar().ToString();
                    cn.Close();
                    cm.CommandText = @"select COUNT([ID]) from [dbo].[temp_Events] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                        )
                                    ) 
									and Gender = 12 and [EventTypeID] = 129 and [EventID] in
									(
										select [ID] from [dbo].[temp_Dead] where [ElateMarg] like N'" + Dead[j] + "')";
                    cn.Open();
                    this.Controls.Find("lbl3_" + (j + 6) + "_" + (i - 3), true).Single().Text = cm.ExecuteScalar().ToString();
                    cn.Close();
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] CDead = { "عفونت های تنفسی", "اسهال و استفراق", "حوادث, مسمومیتها, سوختگی ها", "عوارض کمبود وزن هنگام تولد", "نارس_ نوزاد", "بیماری های قابل پیشگیری با واکسن", "مرگ نوزاد از صدمات زایمان", "ناهنجاری های مادر زادی", "سایر علل" };
            for (int j = 0; j <= 8; j++)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string s = "";
                    if (i == 1)
                        s = "BirthDate > '" + DateTime.Today.AddMonths(-1) + "'";
                    else if (i == 2)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-1).Year + "' and '" + DateTime.Today.AddMonths(-1) + "'";
                    else if (i == 3)
                        s = "BirthDate between '" + DateTime.Today.AddYears(-5).Year + "' and '" + DateTime.Today.AddYears(-1).Year + "'";

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = cn;
                    cm.CommandText = @"select COUNT([ID]) from [dbo].[temp_Events] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                        )
                                    ) 
									and [EventTypeID] = 129 and [EventID] in
									(
										select [ID] from [dbo].[temp_Dead] where [ElateMarg] like N'" + CDead[j] + "')";
                    cn.Open();
                    this.Controls.Find("lbl4_" + (i) + "_" + (j + 1), true).Single().Text = cm.ExecuteScalar().ToString();
                    cn.Close();
                    cm.CommandText = @"select COUNT([ID]) from [dbo].[temp_Events] where " + s + @" and [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                        )
                                    ) 
									and [EventTypeID] = 129 and [EventID] in
									(
										select [ID] from [dbo].[temp_Dead] where [ElateMarg] like N'" + CDead[j] + "')";
                    cn.Open();
                    this.Controls.Find("lbl4_" + (i + 3) + "_" + (j + 1), true).Single().Text = cm.ExecuteScalar().ToString();
                    cn.Close();
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"select COUNT([ID]) from [dbo].[temp_Events] where [FamilyID] in
                                    (
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID =  " + j + @"
                                        )
                                    ) and [EventTypeID] = 128";
                cn.Open();
                this.Controls.Find("lbl5_" + (j - 96) + "_1", true).Single().Text = cm.ExecuteScalar().ToString();
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            for (int i = 1; i <= 3; i++)
            {
                string s = "";
                if (i == 3)
                    s = "BirthDate > '" + DateTime.Today.AddYears(-1) + "'";
                else if (i == 2)
                    s = "BirthDate between '" + DateTime.Today.AddYears(-5).Year + "' and '" + DateTime.Today.AddYears(-1) + "'";
                else if (i == 1)
                    s = "BirthDate < '" + DateTime.Today.AddYears(-5).Year + "'";
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select DeadDate from [dbo].[temp_Dead] where ID in
								        (
									        select [EventID] from [dbo].[temp_Events] as F where EventTypeID = 129 and " + s + @" and [FamilyID] in
                                            (
                                                select[ID] from[dbo].[Families] where PlaceID in
                                                (
                                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                                )
                                            )
								        ) and DeadDate > '" + DateTime.Today.Year + "'";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    DateTime dt = DateTime.Parse(Rd[0].ToString());
                    System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
                    if (PC.GetMonth(dt) == 1)
                        this.Controls.Find("lbl6_" + i + "_2", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_2", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 2)
                        this.Controls.Find("lbl6_" + i + "_4", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_4", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 3)
                        this.Controls.Find("lbl6_" + i + "_6", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_6", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 4)
                        this.Controls.Find("lbl6_" + i + "_8", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_8", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 5)
                        this.Controls.Find("lbl6_" + i + "_10", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_10", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 6)
                        this.Controls.Find("lbl6_" + i + "_12", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_12", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 7)
                        this.Controls.Find("lbl6_" + i + "_14", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_14", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 8)
                        this.Controls.Find("lbl6_" + i + "_16", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_16", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 9)
                        this.Controls.Find("lbl6_" + i + "_18", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_18", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 10)
                        this.Controls.Find("lbl6_" + i + "_20", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_20", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 11)
                        this.Controls.Find("lbl6_" + i + "_22", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_22", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 12)
                        this.Controls.Find("lbl6_" + i + "_24", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_24", true).Single().Text) + 1).ToString();
                }
                cn.Close();
                cm.CommandText = @"select DeadDate from [dbo].[temp_Dead] where ID in
								        (
									        select [EventID] from [dbo].[temp_Events] as F where EventTypeID = 129 and " + s + @" and [FamilyID] in
                                            (
                                                select[ID] from[dbo].[Families] where PlaceID in
                                                (
                                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                                )
                                            )
								        ) and DeadDate > '" + DateTime.Today.Year + "'";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    DateTime dt = DateTime.Parse(Rd[0].ToString());
                    System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
                    if (PC.GetMonth(dt) == 1)
                        this.Controls.Find("lbl6_" + i + "_1", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_1", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 2)
                        this.Controls.Find("lbl6_" + i + "_3", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_3", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 3)
                        this.Controls.Find("lbl6_" + i + "_5", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_5", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 4)
                        this.Controls.Find("lbl6_" + i + "_7", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_7", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 5)
                        this.Controls.Find("lbl6_" + i + "_9", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_9", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 6)
                        this.Controls.Find("lbl6_" + i + "_11", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_11", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 7)
                        this.Controls.Find("lbl6_" + i + "_13", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_13", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 8)
                        this.Controls.Find("lbl6_" + i + "_15", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_15", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 9)
                        this.Controls.Find("lbl6_" + i + "_17", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_17", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 10)
                        this.Controls.Find("lbl6_" + i + "_19", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_19", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 11)
                        this.Controls.Find("lbl6_" + i + "_21", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_21", true).Single().Text) + 1).ToString();
                    if (PC.GetMonth(dt) == 12)
                        this.Controls.Find("lbl6_" + i + "_23", true).Single().Text = (int.Parse(this.Controls.Find("lbl6_" + i + "_23", true).Single().Text) + 1).ToString();
                }
                cn.Close();
            }
            SqlConnection cn2 = new SqlConnection();
            cn2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
            SqlCommand cm2 = new SqlCommand();
            cm2.Connection = cn2;
            SqlDataReader Rd2;
            cm2.CommandText = @"select BirthDate from [dbo].[temp_Events] as F where EventTypeID = 126 and  [FamilyID] in
                                            (
                                                select[ID] from[dbo].[Families] where PlaceID in
                                                (
                                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                                )
                                            ) and [EventDate] > '" + DateTime.Today.Year + "'";
            cn2.Open();
            Rd2 = cm2.ExecuteReader();
            while (Rd2.Read())
            {
                DateTime dt = DateTime.Parse(Rd2[0].ToString());
                System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
                if (PC.GetMonth(dt) == 1)
                    this.Controls.Find("lbl6_4_" + 2, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 2, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 2)
                    this.Controls.Find("lbl6_4_" + 4, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 4, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 3)
                    this.Controls.Find("lbl6_4_" + 6, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 6, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 4)
                    this.Controls.Find("lbl6_4_" + 8, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 8, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 5)
                    this.Controls.Find("lbl6_4_" + 10, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 10, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 6)
                    this.Controls.Find("lbl6_4_" + 12, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 12, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 7)
                    this.Controls.Find("lbl6_4_" + 14, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 14, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 8)
                    this.Controls.Find("lbl6_4_" + 15, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 16, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 9)
                    this.Controls.Find("lbl6_4_" + 16, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 18, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 10)
                    this.Controls.Find("lbl6_4_" + 20, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 20, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 11)
                    this.Controls.Find("lbl6_4_" + 22, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 22, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 12)
                    this.Controls.Find("lbl6_4_" + 24, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 24, true).Single().Text) + 1).ToString();
            }
            cn2.Close(); cm2.CommandText = @"select BirthDate from [dbo].[temp_Events] as F where EventTypeID = 126 and  [FamilyID] in
                                            (
                                                select[ID] from[dbo].[Families] where PlaceID in
                                                (
                                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                                )
                                            ) and [EventDate] > '" + DateTime.Today.Year + "'";
            cn2.Open();
            Rd2 = cm2.ExecuteReader();
            while (Rd2.Read())
            {
                DateTime dt = DateTime.Parse(Rd2[0].ToString());
                System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
                if (PC.GetMonth(dt) == 1)
                    this.Controls.Find("lbl6_4_" + 1, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 1, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 2)
                    this.Controls.Find("lbl6_4_" + 3, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 3, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 3)
                    this.Controls.Find("lbl6_4_" + 5, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 5, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 4)
                    this.Controls.Find("lbl6_4_" + 7, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 7, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 5)
                    this.Controls.Find("lbl6_4_" + 9, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 9, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 6)
                    this.Controls.Find("lbl6_4_" + 11, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 11, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 7)
                    this.Controls.Find("lbl6_4_" + 13, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 13, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 8)
                    this.Controls.Find("lbl6_4_" + 15, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 15, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 9)
                    this.Controls.Find("lbl6_4_" + 17, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 17, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 10)
                    this.Controls.Find("lbl6_4_" + 19, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 19, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 11)
                    this.Controls.Find("lbl6_4_" + 21, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 21, true).Single().Text) + 1).ToString();
                if (PC.GetMonth(dt) == 12)
                    this.Controls.Find("lbl6_4_" + 23, true).Single().Text = (int.Parse(this.Controls.Find("lbl6_4_" + 23, true).Single().Text) + 1).ToString();
            }
            cn2.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT COUNT([ID]) from [dbo].[temp_OtherData] where [FamilyID] in
									(
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
                                        )
                                    ) and [Namak] = 1";
                cn.Open();
                this.Controls.Find("lbl7_" + (j - 96) + "_1", true).Single().Text = cm.ExecuteScalar().ToString();
                cn.Close();
                cm.CommandText = @"select COUNT([ID])  from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
                                        )";
                cn.Open();
                this.Controls.Find("lbl7_" + (j - 96) + "_2", true).Single().Text = cm.ExecuteScalar().ToString();
                cn.Close();
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] PDead = { "قرص", "کاندوم", "ای-یو-دی", "بستن لوله به روش جراحی", "امپول سه ماهه", "امپوله یک ماهه", "سایر", "طبیعی" };
            for (int j = 0; j <= 7; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT COUNT([ID]) from [dbo].[temp_OtherData] where [FamilyID] in
									(
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 97
                                        )
                                    ) and [Tanzim] like N'" + PDead[j] + "'";
                cn.Open();
                this.Controls.Find("lbl8_1_" + (j + 1), true).Single().Text = cm.ExecuteScalar().ToString();
                cn.Close();
                cm.CommandText = @"SELECT COUNT([ID]) from [dbo].[temp_OtherData] where [FamilyID] in
									(
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = 98
                                        )
                                    ) and [Tanzim] like N'" + PDead[j] + "'";
                cn.Open();
                this.Controls.Find("lbl8_2_" + (j + 1), true).Single().Text = cm.ExecuteScalar().ToString();
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select COUNT([ID]) , [Gender] from [dbo].[temp_Events] where [EventID] in
                                    (
	                                    select [ID] from [dbo].[temp_Dead] where [NoeMarg] = 2
                                    )
                                    and [FamilyID] in
									(
                                        select[ID] from[dbo].[Families] where PlaceID in
                                        (
                                            select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
                                        )
                                    )group by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    if (Rd["Gender"].ToString() == "11")
                        this.Controls.Find("lbl9_" + (j - 96) + "_1", true).Single().Text = Rd[0].ToString();
                    if (Rd["Gender"].ToString() == "12")
                        this.Controls.Find("lbl9_" + (j - 96) + "_2", true).Single().Text = Rd[0].ToString();
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select count([ID]) , [Gender] from [dbo].[temp_Events] where [EventID] in
                                    (
	                                    select [ID] from [dbo].[temp_Tavalod]
                                    ) and [BirthDate] > '" + DateTime.Now.Year + @"' and
                                    [FamilyID] in
                                    (
	                                    select[ID] from[dbo].[Families] where PlaceID in
                                        (
		                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
                                        )
                                    )group by Gender";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    if (Rd["Gender"].ToString() == "11")
                        this.Controls.Find("lbl9_" + (j - 94) + "_1", true).Single().Text = Rd[0].ToString();
                    if (Rd["Gender"].ToString() == "12")
                        this.Controls.Find("lbl9_" + (j - 94) + "_2", true).Single().Text = Rd[0].ToString();
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 1; i <= 3; i++)
            {
                string s = "";
                if (i == 1)
                    s = "cast([Vazn] as bigint) < 2500";
                else if (i == 2)
                    s = "cast([Vazn] as bigint) >= 2500";
                else if (i == 3)
                    s = "[Vazn] is null or [Vazn] = ''";
                for (int j = 97; j <= 98; j++)
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = cn;
                    SqlDataReader Rd;
                    cm.CommandText = @"select count([ID]) , [Gender] from [dbo].[temp_Events] where [EventID] in
                                        (
	                                        select [ID] from [dbo].[temp_Tavalod] where " + s + @"
                                        ) and [BirthDate] > '" + DateTime.Now.Year + @"' and
                                        [FamilyID] in
                                        (
	                                        select[ID] from[dbo].[Families] where PlaceID in
                                            (
		                                        select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID =  " + j + @"
                                            )
                                        )group by Gender";
                    cn.Open();
                    Rd = cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        if (Rd["Gender"].ToString() == "11")
                            this.Controls.Find("lbl9_" + (j - 92) + "_" + i, true).Single().Text = Rd[0].ToString();
                        if (Rd["Gender"].ToString() == "12")
                            this.Controls.Find("lbl9_" + (j - 92) + "_" + i + 3, true).Single().Text = Rd[0].ToString();
                    }
                    cn.Close();
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //for (int i = 1; i <= 8; i++)
            //{
            //    string s = "";
            //    if (i == 1)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-14).Year + "' and '" + DateTime.Today.AddYears(-9).Year + "'";
            //    else if (i == 2)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-19).Year + "' and '" + DateTime.Today.AddYears(-14).Year + "'";
            //    else if (i == 3)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-24).Year + "' and '" + DateTime.Today.AddYears(-19).Year + "'";
            //    else if (i == 4)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-29).Year + "' and '" + DateTime.Today.AddYears(-24).Year + "'";
            //    else if (i == 5)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-34).Year + "' and '" + DateTime.Today.AddYears(-29).Year + "'";
            //    else if (i == 6)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-39).Year + "' and '" + DateTime.Today.AddYears(-34).Year + "'";
            //    else if (i == 7)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-44).Year + "' and '" + DateTime.Today.AddYears(-39).Year + "'";
            //    else if (i == 8)
            //        s = "(cast(FA.[BirthDate] as datetime) - cast(EV.[BirthDate] as datetime)) between '" + DateTime.Today.AddYears(-49).Year + "' and '" + DateTime.Today.AddYears(-44).Year + "'";

            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select EV.BirthDate , FA.BirthDate from [dbo].[FamilyMembers] as FA inner join 
	                                [temp_Tavalod] as TV on FA.ID = TV.MotherID inner join
	                                [temp_Events] as EV on EV.BirthDate > '" + DateTime.Now.Year + @"' where EV.FamilyID in 
	                                (
		                                select[ID] from[dbo].[Families] where PlaceID in
		                                (
			                                select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
		                                )
	                                )";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    DateTime dt1 = DateTime.Parse(Rd[0].ToString());
                    DateTime dt2 = DateTime.Parse(Rd[1].ToString());
                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 10 && Math.Round((dt1 - dt2).TotalDays / 365) <= 14)
                        this.Controls.Find("lbl9_" + (j - 90) + "_1", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_1", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 15 && Math.Round((dt1 - dt2).TotalDays / 365) <= 19)
                        this.Controls.Find("lbl9_" + (j - 90) + "_2", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_2", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 20 && Math.Round((dt1 - dt2).TotalDays / 365) <= 24)
                        this.Controls.Find("lbl9_" + (j - 90) + "_3", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_3", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 25 && Math.Round((dt1 - dt2).TotalDays / 365) <= 29)
                        this.Controls.Find("lbl9_" + (j - 90) + "_4", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_4", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 30 && Math.Round((dt1 - dt2).TotalDays / 365) <= 34)
                        this.Controls.Find("lbl9_" + (j - 90) + "_5", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_5", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 35 && Math.Round((dt1 - dt2).TotalDays / 365) <= 39)
                        this.Controls.Find("lbl9_" + (j - 90) + "_6", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_6", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 40 && Math.Round((dt1 - dt2).TotalDays / 365) <= 44)
                        this.Controls.Find("lbl9_" + (j - 90) + "_7", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_7", true).Single().Text) + 1).ToString();

                    if (Math.Round((dt1 - dt2).TotalDays / 365) >= 45 && Math.Round((dt1 - dt2).TotalDays / 365) <= 49)
                        this.Controls.Find("lbl9_" + (j - 90) + "_8", true).Single().Text = (int.Parse(this.Controls.Find("lbl9_" + (j - 90) + "_8", true).Single().Text) + 1).ToString();
                }
                cn.Close();
            }
            //}
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"SELECT COUNT([ID]),[MahalZayeman] FROM [temp_Tavalod] where [ID] in
                                    (
	                                    select EventID from [dbo].[temp_Events] where BirthDate > '" + DateTime.Now.Year + @"' and FamilyID in
	                                    (
                                            select[ID] from[dbo].[Families] where PlaceID in
                                            (
			                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
		                                    )
	                                    )
                                    ) group by [MahalZayeman]";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    if (Rd[1].ToString() == "132")
                    {
                        this.Controls.Find("lbl9_" + (j - 88) + "_1", true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "133")
                    {
                        this.Controls.Find("lbl9_" + (j - 88) + "_2", true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "134")
                    {
                        this.Controls.Find("lbl9_" + (j - 88) + "_3", true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd[1].ToString() == "135")
                    {
                        this.Controls.Find("lbl9_" + (j - 88) + "_4", true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"SELECT COUNT([ID]),[NoZayeman] FROM [temp_Tavalod] where [ID] in
                                    (
	                                    select EventID from [dbo].[temp_Events] where BirthDate > '" + DateTime.Now.Year + @"' and FamilyID in
	                                    (
                                            select[ID] from[dbo].[Families] where PlaceID in
                                            (
			                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
		                                    )
	                                    )
                                    ) group by [NoZayeman]";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    if (Rd["NoZayeman"].ToString().Trim() == "139" || Rd["NoZayeman"].ToString().Trim() == "140")
                    {
                        this.Controls.Find("lbl9_" + (j - 86) + "_1", true).Single().Text = Rd[0].ToString();
                    }
                    else if (Rd["NoZayeman"].ToString().Trim() == "141")
                    {
                        this.Controls.Find("lbl9_" + (j - 86) + "_2", true).Single().Text = Rd[0].ToString();
                    }
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select count(ID) , [BirthDate] from [dbo].[FamilyMembers] where ID in
                                    (
	                                    select [MotherID] from [dbo].[temp_Tavalod] where [ID] in
	                                    (
		                                    select [EventID] from  [dbo].[temp_Events] where [BirthDate] > '" + DateTime.Now.Year + @"'
	                                    )
                                    ) and FamilyID in 
                                    (
	                                    select[ID] from[dbo].[Families] where PlaceID in
	                                    (
		                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
	                                    )
                                    ) group by [BirthDate]";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    DateTime dt = DateTime.Parse(Rd[1].ToString());
                    if (Math.Round((DateTime.Now - dt).TotalDays / 365) >= 10 && Math.Round((DateTime.Now - dt).TotalDays / 365) <= 49)
                    {
                        if (Rd[0].ToString().Trim() == "1")
                        {
                            this.Controls.Find("lbl9_14_" + (j - 96), true).Single().Text = (int.Parse(this.Controls.Find("lbl9_14_" + (j - 96), true).Single().Text) + 1).ToString();
                        }
                    }
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int j = 97; j <= 98; j++)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                SqlDataReader Rd;
                cm.CommandText = @"select [BirthDate] from [dbo].[FamilyMembers] where MaritalStatus = 31 and ID not in
                                    (
	                                    select [MotherID] from [dbo].[temp_Tavalod] where [ID] in
	                                    (
		                                    select [EventID] from  [dbo].[temp_Events] where [BirthDate] > '" + DateTime.Now.Year + @"'
	                                    )
                                    ) and FamilyID in 
                                    (
	                                    select[ID] from[dbo].[Families] where PlaceID in
	                                    (
		                                    select[PlaceID] from[dbo].[UnitPlaces] where PlaceTypeID = " + j + @"
	                                    )
                                    )";
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    DateTime dt = DateTime.Parse(Rd[0].ToString());
                    if (Math.Round((DateTime.Now - dt).TotalDays / 365) >= 10 && Math.Round((DateTime.Now - dt).TotalDays / 365) <= 49)
                    {
                        this.Controls.Find("lbl9_13_" + (j - 96), true).Single().Text = (int.Parse(this.Controls.Find("lbl9_13_" + (j - 96), true).Single().Text) + 1).ToString();
                    }
                }
                cn.Close();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmAllZij frm = new frmAllZij();
            frm.ShowDialog();
        }
    }
}
