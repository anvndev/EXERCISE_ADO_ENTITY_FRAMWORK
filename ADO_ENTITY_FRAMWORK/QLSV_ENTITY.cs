using ADO_ENTITY_FRAMWORK.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_ENTITY_FRAMWORK
{
    public partial class QLSV_ENTITY : Form
    {
        public DBContext context = new DBContext();
        List<tbLop> lop;
        List<tbSinhVien> SinhVien;

        public QLSV_ENTITY()
        {
            InitializeComponent();
        }

        private void LoadF()
        {

            lop = context.tbLops.ToList();
            SinhVien = context.tbSinhViens.ToList();

        }

        private void BindGrid()
        {
            try
            {
                dgvSinhVien.Rows.Clear();
                int count = 0;
                foreach (tbSinhVien itemI in SinhVien)
                {
                    int index = dgvSinhVien.Rows.Add();
                    dgvSinhVien.Rows[index].Cells[0].Value = itemI.MaSV;
                    dgvSinhVien.Rows[index].Cells[1].Value = itemI.HoTen;
                    count++;
                }
                txtSoLuong.Text = count.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void QLSV_ENTITY_Load(object sender, EventArgs e)
        {
            LoadF();
            BindGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string maLop = cmbMaLop.SelectedItem.ToString();
                SinhVien = context.tbSinhViens.Where(s => s.MaLop.Equals(maLop)).ToList();
                BindGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
