using EntityFrameworkCore.EncryptColumn.Example.Entity;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.EncryptColumn.Example.Context
{
    public class ExampleDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public ExampleDbContext()
        {
            Initialize.EncryptionKey = "example_encrypt_key";
            this._provider = new GenerateEncryptionProvider();
        }

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres;Pooling=true;Search Path=encryptexample");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
            modelBuilder.HasDefaultSchema("encryptexample");
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.ID).HasName("PK_User_Id");

                entity.Property(p => p.ID).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
