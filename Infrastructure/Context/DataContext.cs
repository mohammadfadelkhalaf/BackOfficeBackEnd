using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //  public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<BatchEntity> Batches { get; set; }
        public DbSet<UserCourseEntity> UserCourses { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<UserchatEntity> UserChats { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChatEntity>(entity =>
            {
                entity.HasOne(e => e.FromUser)
                      .WithMany(u => u.SentChats)
                      .HasForeignKey(e => e.FromUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ToUser)
                      .WithMany(u => u.ReceivedChats)
                      .HasForeignKey(e => e.ToUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserChats)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserchatEntity>(entity =>
            {
                modelBuilder.Entity<UserchatEntity>(entity =>
                {
                    entity.HasOne(e => e.FromUser)
                          .WithMany(u => u.ToUserChat)
                          .HasForeignKey(e => e.FromUserId)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(e => e.ToUser)
                          .WithMany(u => u.FromUserChats)
                          .HasForeignKey(e => e.ToUserId)
                          .OnDelete(DeleteBehavior.Restrict);
                });
            });
        }
    }
}
