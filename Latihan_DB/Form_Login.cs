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

namespace Latihan_DB
{
    public partial class Form_Login : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=MUHAFANX\SQLEXPRESS;Initial Catalog=MhnnX;Integrated Security=True");
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            if(txtNama.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Mohon masukkan nama atau password anda terlebih dahulu !");
            }
            else
            {
                SqlDataAdapter dtap = new SqlDataAdapter("select Nama,Password,Jabatan from Pegawai where Nama = '" + txtNama.Text + "' AND Password = '" + txtPassword.Text + "'", koneksi);
                DataTable dt = new DataTable();
                dtap.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if (dr["Jabatan"].ToString() == "Admin")
                        {
                            this.Hide();
                            Form_Admin fa = new Form_Admin();
                            fa.Show();
                        }
                        else if (dr["Jabatan"].ToString() == "Pegawai")
                        {
                            this.Hide();
                            Form_Pegawai fg = new Form_Pegawai();
                            fg.Show();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Nama atau Password anda salah, mohon kontak admin!");
                }
                koneksi.Close();
            }
        }
    }
}
