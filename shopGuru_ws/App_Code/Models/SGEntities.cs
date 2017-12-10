namespace shopGuru_ws.Models
{
    using System.Data.Entity;

    public partial class SGEntities : DbContext
    {
        public SGEntities()
            : base("name=SGEntities")
        {
        }

        public virtual DbSet<User_info> User_info { get; set; }
        public virtual DbSet<User_statistics> User_statistics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_info>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User_info>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User_info>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.User_info1)
                .HasForeignKey(e => e.user_info);

            modelBuilder.Entity<User_statistics>()
                .HasMany(e => e.User_info)
                .WithRequired(e => e.User_statistics1)
                .HasForeignKey(e => e.user_statistics);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.Item1)
                .HasForeignKey(e => e.item);

            modelBuilder.Entity<Price>()
                .Property(e => e.shop)
                .IsUnicode(false);

            modelBuilder.Entity<Price>()
                .Property(e => e.price1)
                .HasPrecision(6, 2);
        }
    }
}
