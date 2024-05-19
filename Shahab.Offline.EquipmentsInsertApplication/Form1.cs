using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace Shahab.Offline.EquipmentsInsertApplication
{
    public partial class Form1 : Form
    {

       public class Entyti
        {
            private string ID;

            public string ID1
            {
                get { return ID; }
                set { ID = value; }
            }
            private string Name;

            public string Name1
            {
                get { return Name; }
                set { Name = value; }
            }
        }

        List<Entyti> AllEn;

        public void FillDatas()
        {
            AllEn = new List<Entyti>();
            listBox1.Items.Clear();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = CString;
            SqlCommand cm = new SqlCommand();
            SqlDataReader Rd;
            cm.Connection = cn;


            cm.CommandText = @"select [ID],[Name] from EquipmentsCategories";
            cn.Open();
            List<Entyti> En1 = new List<Entyti>();
            List<Entyti> En2 = new List<Entyti>();
            Rd = cm.ExecuteReader();
            while (Rd.Read())
            {
                Entyti  En = new Entyti();
                En.ID1 = Rd["ID"].ToString();
                En.Name1 = Rd["Name"].ToString();
                En1.Add(En);
                En2.Add(En);
            }
            cn.Close();
            cmbTerminologyCategory.DisplayMember = "Name1";
            cmbTerminologyCategory.ValueMember = "ID1";
            cmbTerminologyCategory.DataSource = En1;
            cmbTerminologyCategory1.DisplayMember = "Name1";
            cmbTerminologyCategory1.ValueMember = "ID1";
            cmbTerminologyCategory1.DataSource = En2;

            cm.CommandText = @"select id , EquipmentName from Equipments";
            cn.Open();
            Rd = cm.ExecuteReader();
            while (Rd.Read())
            {
                Entyti En = new Entyti();
                En.ID1 = Rd["id"].ToString();
                En.Name1 = Rd["EquipmentName"].ToString();
                AllEn.Add(En);
                listBox1.Items.Add(Rd["EquipmentName"].ToString());
            }
            cn.Close();
        }

        public Form1()
        {
            InitializeComponent();
            CString = ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;
        }

        string CString;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = CString;
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = @"insert into Equipments(TerminologyCode,InternalTerminologyCode,EquipmentName,Quantity,IsActive,TerminologyCategory
                                ,Version,CreateDate,StartDate,EquipmentsUID)
                                Values(" + txtTerminologyCode.Text + "," + txtInternalTerminologyCode.Text + ",N'" + txtEquipmentName.Text + "'," + txtQuantity.Text + "," + cmbIsActive.SelectedIndex + ",N'" + cmbTerminologyCategory.SelectedValue + "'," +
                                txtVersion.Text + ",N'" + DateTime.Now + "',N'" + DateTime.Now + "',N'" + Guid.NewGuid() + "')";
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cmbTerminologyCategory.SelectedIndex = 0;
            txtEquipmentName.Text = txtInternalTerminologyCode.Text = txtQuantity.Text = txtTerminologyCode.Text = txtVersion.Text = "";
            cmbIsActive.SelectedIndex = 1;
            MessageBox.Show("مورد با موفقیت اضافه شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FillDatas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIsActive.SelectedIndex = 1;
            FillDatas();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllEn = new List<Entyti>();
            listBox1.Items.Clear();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = CString;
            SqlCommand cm = new SqlCommand();
            SqlDataReader Rd;
            cm.Connection = cn;
            cm.CommandText = @"select id , EquipmentName from Equipments where EquipmentName like N'%" + textBox7.Text + "%'";
            cn.Open();
            Rd = cm.ExecuteReader();
            while (Rd.Read())
            {
                Entyti En = new Entyti();
                En.ID1 = Rd["id"].ToString();
                En.Name1 = Rd["EquipmentName"].ToString();
                AllEn.Add(En);
                listBox1.Items.Add(Rd["EquipmentName"].ToString());
            }
            cn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = CString;
                SqlCommand cm = new SqlCommand();
                SqlDataReader Rd;
                cm.Connection = cn;
                int i = listBox1.SelectedIndex;
                cm.CommandText = @"select * from Equipments where id = " + AllEn[i].ID1;
                cn.Open();
                Rd = cm.ExecuteReader();
                while (Rd.Read())
                {
                    if (Rd["IsActive"].ToString() == "True")
                        cmbIsActive1.SelectedIndex = 1;
                    else
                        cmbIsActive1.SelectedIndex = 0;
                    txtEquipmentName1.Text = Rd["EquipmentName"].ToString();
                    txtTerminologyCode1.Text = Rd["TerminologyCode"].ToString();
                    txtInternalTerminologyCode1.Text = Rd["InternalTerminologyCode"].ToString();
                    txtQuantity1.Text = Rd["Quantity"].ToString();
                    cmbTerminologyCategory1.SelectedValue = Rd["TerminologyCategory"].ToString();
                    txtVersion1.Text = Rd["Version"].ToString();
                }
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = CString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                int i = listBox1.SelectedIndex;
                cm.CommandText = @"delete from Equipments where id = " + AllEn[i].ID1;
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                txtEquipmentName1.Text = txtInternalTerminologyCode1.Text = txtQuantity1.Text = txtTerminologyCode1.Text = txtVersion1.Text = "";
                cmbIsActive1.SelectedIndex = 1;
                FillDatas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = CString;
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                int i = listBox1.SelectedIndex;
                cm.CommandText = @"update Equipments set
                                   TerminologyCode = " + txtTerminologyCode1.Text + @"
                                   ,InternalTerminologyCode = " + txtInternalTerminologyCode1.Text + @"
                                   ,EquipmentName = N'" + txtEquipmentName1.Text + @"'
                                   ,Quantity = " + txtQuantity1.Text + @"
                                   ,IsActive = " + cmbIsActive1.SelectedIndex + @"
                                   ,TerminologyCategory = N'" + cmbTerminologyCategory1.SelectedValue + @"'
                                   ,Version = " + txtVersion1.Text + @"
                                    where id = " + AllEn[i].ID1;
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                FillDatas();
                MessageBox.Show("مورد با موفقیت ویرایش شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
