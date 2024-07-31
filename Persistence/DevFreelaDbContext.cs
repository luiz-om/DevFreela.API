using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Persistence
{
    public class DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(e => { e.HasKey(s => s.Id); });
            //===
            builder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(us => us.Id);

                    e.HasOne(u => u.Skill)
                        .WithMany(u => u.UserSkills)
                        .HasForeignKey(s => s.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(x => x.Id);

                    e.HasOne(p => p.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdProject)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Skills)
                        .WithOne(us => us.User)
                        .HasForeignKey(us => us.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Freelancer)
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(p => p.IdFreelancer)
                        .OnDelete(DeleteBehavior.Restrict);
                    
                    e.HasOne(p => p.Client)
                        .WithMany(f => f.OwnedProjects)
                        .HasForeignKey(p => p.IdClient)
                        .OnDelete(DeleteBehavior.Restrict);
                    
                    
                });
                builder.Entity<Project>(entity =>
            {
                entity.Property(e => e.TotalCost)
                    .HasColumnType("decimal(18, 2)");
            });

            base.OnModelCreating(builder);
        }
    }
}