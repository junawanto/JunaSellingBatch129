using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Selling.Model
{
    public class DataContext:DbContext
    {
        public DataContext() :base("name=SellingContext")
        {
            Database.SetInitializer<DataContext>(null);
        }
        public DbSet<tblOfficer> TblOfficer { get; set; }
        public DbSet<tblItem> TblItem { get; set; }
        public DbSet<MstUser> MstUser { get; set; }
        public DbSet<tblSelling> TblSelling { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
