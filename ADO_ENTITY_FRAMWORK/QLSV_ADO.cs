using ADO_ENTITY_FRAMWORK.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_ENTITY_FRAMWORK
{
    public partial class QLSV_ADO : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBContext dbcon = new DBContext();
        SqlDataReader dr;

        public QLSV_ADO()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            loadSinhVien();
        }

        public void loadSinhVien()
        {
            int i = 0;
            dgvSinhVien.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbSinhVien ORDER BY MaSV", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvSinhVien.Rows.Add(i, dr["MaSV"].ToString(), dr["HoTen"].ToString());
            }

            txtSoLuong.Text = i.ToString();
            dr.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            dgvSinhVien.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbSinhVien AS s INNER JOIN tbLop AS l ON s.MaLop = l.MaLop WHERE s.MaLop = @maLop ORDER BY s.MaSV ", cn);

            cm.Parameters.AddWithValue("@maLop", cmbMaLop.SelectedItem);


            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvSinhVien.Rows.Add(i, dr["MaSV"].ToString(), dr["HoTen"].ToString());
            }

            txtSoLuong.Text = i.ToString();
            dr.Close();
            cn.Close();
        }
    }
}
