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
using System.Configuration;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
        SqlCommand cmd;
        string gender = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDOB_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if  ( checkBox1.Checked==true)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Employee(Ename,Gender,Religion,DOB) VALUES (@name,@gender,@religion,@dob)", con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@religion", txtreligion.Text);
                    cmd.Parameters.AddWithValue("@dob", monthCalendar1.SelectionRange.Start.ToShortDateString());
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdemployeeinfo.DataSource = dt.DefaultView;
                   

                    con.Close();

                    rbtnMale.Checked = false;
                    rbtnFemale.Checked = false;
                    rbtnOthers.Checked = false;
                    
                }
            }
            else
            {
                lblerror.Text= "Please Check Above checkbox";
            }
            
         
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void rbtnOthers_CheckedChanged(object sender, EventArgs e)
        {
            gender = "others";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd = new SqlCommand("Update Employee set Ename=@name,Gender=@gender,Religion=@religion,DOB=@dob where EmployeeID=@id  ", con);
                    cmd.Parameters.AddWithValue("@id", txtid.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@religion", txtreligion.Text);
                    cmd.Parameters.AddWithValue("@dob", monthCalendar1.SelectionRange.Start.ToShortDateString());
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdemployeeinfo.DataSource = dt.DefaultView;


                    con.Close();
                    rbtnMale.Checked = false;
                    rbtnFemale.Checked = false;
                    rbtnOthers.Checked = false;

                }
            }
            else
            {
                lblerror.Text = "Please Check Above checkbox";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd = new SqlCommand("Delete from Employee where EmployeeID=@id  ", con);
                    cmd.Parameters.AddWithValue("@id", txtid.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@religion", txtreligion.Text);
                    cmd.Parameters.AddWithValue("@dob", monthCalendar1.SelectionRange.Start.ToShortDateString());
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdemployeeinfo.DataSource = dt.DefaultView;


                    con.Close();
                    rbtnMale.Checked = false;
                    rbtnFemale.Checked = false;
                    rbtnOthers.Checked = false;

                }
            }
            else
            {
                MessageBox.Show("If You are sure Please Check the check box");
            }
        }
    }
}
