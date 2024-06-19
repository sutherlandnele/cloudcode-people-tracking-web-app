namespace CRPApp.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CRPApp.Data;
    using CRPApp.Data.DBModels;


    public partial class CRPDbContext : DbContext
    {
        public CRPDbContext()
            : base("name=CRPDbContext")
        {
        }

        #region EF Dbset defintions
        public DbSet<CRPOnsiteStatus> CRPOnsiteStatuses { get; set; }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
