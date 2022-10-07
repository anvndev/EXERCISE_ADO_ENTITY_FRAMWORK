using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ADO_ENTITY_FRAMWORK.Data
{
    public partial class DBContext : DbContext
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();

        private string con;
        public string myConnection()
        {
            con = @"data source=Albert;initial catalog=QLSV;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            return con;
        }

        public DataTable getTable(string qury)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand(qury, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<tbLop> tbLops { get; set; }
        public virtual DbSet<tbSinhVien> tbSinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbLop>()
                .Property(e => e.MaLop)
                .IsFixedLength();

            modelBuilder.Entity<tbSinhVien>()
                .Property(e => e.MaSV)
                .IsFixedLength();

            modelBuilder.Entity<tbSinhVien>()
                .Property(e => e.MaLop)
                .IsFixedLength();
        }
    }
}
