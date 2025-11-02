using EducationCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationCenter.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Science> Sciences => Set<Science>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentGroup> StudentGroups => Set<StudentGroup>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<TeacherExperience> TeacherExperiences => Set<TeacherExperience>();
    public DbSet<TeacherGroup> TeacherGroups => Set<TeacherGroup>();
    public DbSet<TeacherScience> TeacherSciences => Set<TeacherScience>();
    public DbSet<TeacherStudent> TeacherStudents => Set<TeacherStudent>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>()
        .HasMany(r => r.User)
        .WithOne(u => u.Role)
        .HasForeignKey(u => u.RoleId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.TeacherSciences)
            .WithOne(ts => ts.Teacher)
            .HasForeignKey(ts => ts.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.TeacherGroups)
            .WithOne(tg => tg.Teacher)
            .HasForeignKey(tg => tg.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.TeacherStudents)
            .WithOne(ts => ts.Teacher)
            .HasForeignKey(ts => ts.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TeacherStudent>()
            .HasOne(ts => ts.Student)
            .WithMany(s => s.TeacherStudents)
            .HasForeignKey(ts => ts.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.StudentGroups)
            .WithOne(sg => sg.Student)
            .HasForeignKey(sg => sg.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.StudentGroups)
            .WithOne(sg => sg.Group)
            .HasForeignKey(sg => sg.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.TeacherGroups)
            .WithOne(tg => tg.Group)
            .HasForeignKey(tg => tg.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Group>()
            .HasOne(g => g.Course)
            .WithMany()
            .HasForeignKey(g => g.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TeacherScience>()
            .HasOne(ts => ts.Science)
            .WithMany(s => s.TeacherSciences)
            .HasForeignKey(ts => ts.ScienceID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TeacherExperience>()
            .HasOne(te => te.Teacher)
            .WithMany()
            .HasForeignKey(te => te.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Education>()
            .HasOne(e => e.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TeacherStudent>()
            .HasIndex(ts => new { ts.TeacherId, ts.StudentId })
            .IsUnique();

        modelBuilder.Entity<TeacherScience>()
            .HasIndex(ts => new { ts.TeacherId, ts.ScienceID })
            .IsUnique();

        modelBuilder.Entity<TeacherGroup>()
            .HasIndex(tg => new { tg.TeacherId, tg.GroupId })
            .IsUnique();

        modelBuilder.Entity<StudentGroup>()
            .HasIndex(sg => new { sg.StudentId, sg.GroupId })
            .IsUnique();
    }
}
