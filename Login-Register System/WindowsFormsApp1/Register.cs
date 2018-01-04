using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            txtDOB.Visible = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            Bind_ddlCountry();
        }
        public void Bind_ddlCountry()
        {
            string SqlConnectionString = "server=DESKTOP-QPN61SP ;database=DB_New; Trusted_Connection=true;";
            SqlConnection con = new SqlConnection(SqlConnectionString);
            string Query = "select * from country";
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Country--" };
            dt.Rows.InsertAt(dr, 0);


            cmbCountry.ValueMember = "id";
            cmbCountry.DisplayMember = "countryname";
            cmbCountry.DataSource = dt;
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCountry.ToString()!=null)
            {
                int countryid = Convert.ToInt32(cmbCountry.SelectedValue);
                refreshstate(countryid);
            }
        }
        public void refreshstate(int countryid)
        {
            string SqlConnectionString = "server=DESKTOP-QPN61SP ;database=DB_New; Trusted_Connection=true;";
            SqlConnection con = new SqlConnection(SqlConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from state where countryid = @countryid", con);
            cmd.Parameters.AddWithValue("countryid", countryid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            cmbState.ValueMember = "id";
            cmbState.DisplayMember = "statename";
            cmbState.DataSource = dt;
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string Gender;
            if (rdbMale.Checked == true) Gender = rdbMale.Text;
            else Gender = rdbFemale.Text;
            
            string ConString = "server=DESKTOP-QPN61SP ;database=DB_New; Trusted_Connection=true;";
            SqlConnection con = new SqlConnection(ConString);
            if (txtName.Text == "" || txtPass.Text == "" || txtDOB.Text == "" || txtEmail.Text == ""
                || cmbCountry.Text == "" || cmbState.Text == "")
            {
                MessageBox.Show("Please insert all the values");
                return;
            }
            else
            {
                string query = "insert into [user](username,password,gender,DOB,Email,country,state) " +
                    "values(@name,@pass,@gender,@dob,@email,@country,@state)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@pass", Hash(txtPass.Text));
                cmd.Parameters.AddWithValue("@gender", Gender);
                cmd.Parameters.AddWithValue("@dob", txtDOB.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@country", cmbCountry.Text);
                cmd.Parameters.AddWithValue("@state", cmbState.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recodrs saved successfully");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERROR: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDOB.Text = dateTimePicker1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
