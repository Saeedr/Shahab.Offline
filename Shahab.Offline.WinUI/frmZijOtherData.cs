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
    public partial class frmZijOtherData : Form
    {
        public frmZijOtherData()
        {
            InitializeComponent();
        }

        M_Families FM;
        bool Is = false;

        private void buttonX14_Click(object sender, EventArgs e)
        {
            B_GetDatas BG = new B_GetDatas();
            List<M_FamilyMembers> FMem = new List<M_FamilyMembers>();
            M_Families Fm = new M_Families();
            try
            {
                Fm = FM = BG.GetFamily(int.Parse(txtActionFirstFamilySearch.Text))[0];
            }
            catch { MessageBox.Show("خانواری یافت نشد"); return; }
            label1.Text = Fm.FamilyCode.ToString();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            SqlDataReader Rd;
            cm.CommandText = @"select * from temp_OtherData where FamilyID = '" + Fm.ID + "'";
            cn.Open();
            Rd = cm.ExecuteReader();
            while (Rd.Read())
            {
                Is = true;
                if (Rd[1].ToString() == "True")
                {
                    rdo2.Checked = true;
                    rdo1.Checked = false;
                }
                else
                {
                    rdo2.Checked = false;
                    rdo1.Checked = true;
                }
                comboBoxEx10.SelectedIndex = comboBoxEx10.FindString(Rd[2].ToString());
            }
            if (!Rd.HasRows)
                Is = false;
            cn.Close();
        }

        public void Submit()
        {
            string s = "";
            if (rdo1.Checked == true)
                s = "False";
            else
                s = "True";
            if (Is == false)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"insert into temp_OtherData(Namak,Tanzim,FamilyID) values('" + s + "','" + comboBoxEx10.Text + "','" + FM.ID + "')";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"update temp_OtherData set Namak = '" + s + "',Tanzim = '" + comboBoxEx10.Text + "' where FamilyID='" + FM.ID + "'";
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
