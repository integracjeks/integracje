namespace EntityHelper
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbLogsContext : DbContext
    {
        public DbLogsContext()
            : base("name=DbLogsContext")
        {
        }

        public virtual DbSet<DbLog> DbLogs { get; set; }


        public DbLog CreateDefaultLog()
        {
            return new DbLog()
            {
                id = DbLogs.Count() + 1,
                data = DateTime.Now,
                ip = "0.0.0.0",
                procedure_name = "default"
            };
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbLog>()
                .Property(e => e.ip)
                .IsFixedLength();

            modelBuilder.Entity<DbLog>()
                .Property(e => e.procedure_name)
                .IsFixedLength();
        }
    }
}
