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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string Username = "";
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string SqlConnectionString = "server=DESKTOP-QPN61SP ;database=DB_New; Trusted_Connection=true;";
            SqlConnection Con = new SqlConnection(SqlConnectionString);
            string Query = "select * from [user] where username = @username and [password] = @password";
            SqlCommand cmd = new SqlCommand(Query,Con);
            cmd.Parameters.AddWithValue("@username", txtName.Text);
            Register rg = new Register();
            cmd.Parameters.AddWithValue("@password", rg.Hash(txtPass.Text));
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Con.Close();
            if(dt.Rows.Count > 0)
            {
                Username = dt.Rows[0]["username"].ToString();
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect UserName Or Password");
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register frm = new Register();
            frm.Show();
            //this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
