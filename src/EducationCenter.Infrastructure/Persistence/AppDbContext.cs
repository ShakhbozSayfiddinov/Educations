using EducationCenter.Domain.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
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

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(entityType => entityType.GetProperties())
                     .Where(property => property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?)))
        {
            property.SetColumnType("timestamp with time zone");
        }

        // ensure each table name matches its entity name
        modelBuilder.Entity<Attachment>().ToTable(nameof(Attachment));
        modelBuilder.Entity<Course>().ToTable(nameof(Course));
        modelBuilder.Entity<Education>().ToTable(nameof(Education));
        modelBuilder.Entity<Group>().ToTable(nameof(Group));
        modelBuilder.Entity<Role>().ToTable(nameof(Role));
        modelBuilder.Entity<Science>().ToTable(nameof(Science));
        modelBuilder.Entity<Student>().ToTable(nameof(Student));
        modelBuilder.Entity<StudentGroup>().ToTable(nameof(StudentGroup));
        modelBuilder.Entity<Teacher>().ToTable(nameof(Teacher));
        modelBuilder.Entity<TeacherExperience>().ToTable(nameof(TeacherExperience));
        modelBuilder.Entity<TeacherGroup>().ToTable(nameof(TeacherGroup));
        modelBuilder.Entity<TeacherScience>().ToTable(nameof(TeacherScience));
        modelBuilder.Entity<TeacherStudent>().ToTable(nameof(TeacherStudent));
        modelBuilder.Entity<User>().ToTable(nameof(User));

        modelBuilder.Entity<Role>()
        .HasMany(r => r.Users)
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

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Attachments)
            .WithOne(a => a.Teacher)
            .HasForeignKey(a => a.TeacherId)
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
            .HasForeignKey(ts => ts.ScienceId)
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
            .HasIndex(ts => new { ts.TeacherId, ts.ScienceId })
            .IsUnique();

        modelBuilder.Entity<TeacherGroup>()
            .HasIndex(tg => new { tg.TeacherId, tg.GroupId })
            .IsUnique();

        modelBuilder.Entity<StudentGroup>()
            .HasIndex(sg => new { sg.StudentId, sg.GroupId })
            .IsUnique();
    }
}
