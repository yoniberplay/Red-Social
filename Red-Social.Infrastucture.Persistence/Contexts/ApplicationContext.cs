using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Domain.Common;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Post> Post { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendship { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Post>()
                .ToTable("Post");

            modelBuilder.Entity<Comments>()
                .ToTable("Comments");

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Friendship>()
                .ToTable("Friendship");

            #endregion

            #region "primary keys"
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Comments>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Friendship>()
               .HasKey(f => f.Id);
            #endregion

            #region "Relationships"

            modelBuilder.Entity<User>()
            .HasMany<Post>(user => user.Post)
            .WithOne(P => P.User)            
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
            .HasMany<Friendship>(user => user.Friendship)
            .WithOne(P => P.User)
            .HasForeignKey(p => p.IdUser)
            .HasForeignKey(p => p.IdFriend)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany<Comments>(a => a.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.NoAction);




            #endregion

            #region "Property configurations"

            #region Post

            modelBuilder.Entity<Post>().
                Property(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<Post>().
               Property(p => p.Text)
               .IsRequired();

            modelBuilder.Entity<Post>().
               Property(p => p.Text)
               .IsRequired();

            #endregion

            #region Comments
            modelBuilder.Entity<Comments>().
              Property(c => c.Text)
              .IsRequired();

            modelBuilder.Entity<Comments>().
             Property(c => c.UserId)
             .IsRequired();

            modelBuilder.Entity<Comments>().
            Property(c => c.PostId)
            .IsRequired();
            #endregion

            #region users

            modelBuilder.Entity<User>().
                Property(user => user.Name)
                .IsRequired();

            modelBuilder.Entity<User>().
                Property(user => user.LastName)
                .IsRequired();

            modelBuilder.Entity<User>().
               Property(user => user.Username)
               .IsRequired();

            modelBuilder.Entity<User>()
    .HasIndex(user => user.Username)
      .IsUnique();

            modelBuilder.Entity<User>().
              Property(user => user.Password)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Email)
              .IsRequired();

            modelBuilder.Entity<User>().
               Property(user => user.Phone)
               .IsRequired();



            #endregion

            #region Friendship

            modelBuilder.Entity<Friendship>().
              Property(f => f.IdUser)
              .IsRequired();

            modelBuilder.Entity<Friendship>().
            Property(f => f.IdFriend)
            .IsRequired();
            #endregion

            #endregion

        }

    }
}
