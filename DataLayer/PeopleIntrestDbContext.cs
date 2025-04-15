using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessLayer
{
    public partial class PeopleIntrestDbContext : DbContext
    {
        public PeopleIntrestDbContext()
        {
        }

        public PeopleIntrestDbContext(DbContextOptions<PeopleIntrestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userfriend> Userfriends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3308;database=DatabaseFirstRS2;user=root;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("friends");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("interests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("districtId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DistrictId).HasColumnName("districtId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("firstName");

                entity.Property(e => e.FriendsId).HasColumnName("friendsId");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Userfriend>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendsId })
                    .HasName("PRIMARY");

                entity.ToTable("userfriends");

                entity.HasIndex(e => e.FriendsId, "FK_UserFriends_Friends");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.FriendsId).HasColumnName("friendsId");

                entity.HasOne(d => d.Friends)
                    .WithMany(p => p.Userfriends)
                    .HasForeignKey(d => d.FriendsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFriends_Friends");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userfriends)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFriends_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
