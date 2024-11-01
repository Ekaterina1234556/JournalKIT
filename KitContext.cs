using System;
using System.Collections.Generic;
using JournalKIT.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalKIT;

public partial class KitContext : DbContext
{
    public KitContext()
    {
    }

    public KitContext(DbContextOptions<KitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Bonu> Bonus { get; set; }

    public virtual DbSet<Bonusstudent> Bonusstudents { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Groupstudent> Groupstudents { get; set; }

    public virtual DbSet<Journalofduty> Journalofduties { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teg> Tegs { get; set; }

    public virtual DbSet<Timelesson> Timelessons { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KIT;Username=postgres;Password=TTC#August");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activity_pkey");

            entity.ToTable("activity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creator).HasColumnName("creator");
            entity.Property(e => e.Crreatoristutor).HasColumnName("crreatoristutor");
            entity.Property(e => e.Datecreate).HasColumnName("datecreate");
            entity.Property(e => e.Nameactivity)
                .HasMaxLength(255)
                .HasColumnName("nameactivity");
            entity.Property(e => e.Oneshot).HasColumnName("oneshot");
            entity.Property(e => e.Property).HasColumnName("property");
        });

        modelBuilder.Entity<Bonu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bonus_pkey");

            entity.ToTable("bonus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Namebonus).HasColumnName("namebonus");
            entity.Property(e => e.Property).HasColumnName("property");
        });

        modelBuilder.Entity<Bonusstudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bonusstudent_pkey");

            entity.ToTable("bonusstudent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bonusid).HasColumnName("bonusid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");

            entity.HasOne(d => d.Bonus).WithMany(p => p.Bonusstudents)
                .HasForeignKey(d => d.Bonusid)
                .HasConstraintName("bonusstudent_bonusid_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.Bonusstudents)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("bonusstudent_studentid_fkey");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("club_pkey");

            entity.ToTable("club");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nameclub)
                .HasMaxLength(255)
                .HasColumnName("nameclub");
            entity.Property(e => e.Property).HasColumnName("property");
            entity.Property(e => e.Tutorid).HasColumnName("tutorid");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.Tutorid)
                .HasConstraintName("club_tutorid_fkey");
        });

        modelBuilder.Entity<Groupstudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groupstudent_pkey");

            entity.ToTable("groupstudent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creategroup).HasColumnName("creategroup");
            entity.Property(e => e.Namegroup)
                .HasMaxLength(255)
                .HasColumnName("namegroup");
            entity.Property(e => e.Specialtyid).HasColumnName("specialtyid");
            entity.Property(e => e.Tutorid).HasColumnName("tutorid");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Groupstudents)
                .HasForeignKey(d => d.Specialtyid)
                .HasConstraintName("groupstudent_specialtyid_fkey");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Groupstudents)
                .HasForeignKey(d => d.Tutorid)
                .HasConstraintName("groupstudent_tutorid_fkey");
        });

        modelBuilder.Entity<Journalofduty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("journalofduty_pkey");

            entity.ToTable("journalofduty");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dateduty).HasColumnName("dateduty");
            entity.Property(e => e.Groupstudentid).HasColumnName("groupstudentid");
            entity.Property(e => e.Student1id).HasColumnName("student1id");
            entity.Property(e => e.Student2id).HasColumnName("student2id");

            entity.HasOne(d => d.Groupstudent).WithMany(p => p.Journalofduties)
                .HasForeignKey(d => d.Groupstudentid)
                .HasConstraintName("journalofduty_groupstudentid_fkey");

            entity.HasOne(d => d.Student1).WithMany(p => p.JournalofdutyStudent1s)
                .HasForeignKey(d => d.Student1id)
                .HasConstraintName("journalofduty_student1id_fkey");

            entity.HasOne(d => d.Student2).WithMany(p => p.JournalofdutyStudent2s)
                .HasForeignKey(d => d.Student2id)
                .HasConstraintName("journalofduty_student2id_fkey");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lessons_pkey");

            entity.ToTable("lessons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Namelessons)
                .HasMaxLength(255)
                .HasColumnName("namelessons");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rating_pkey");

            entity.ToTable("rating");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sciencerating).HasColumnName("sciencerating");
            entity.Property(e => e.Societyrating).HasColumnName("societyrating");
            entity.Property(e => e.Sportrating).HasColumnName("sportrating");
            entity.Property(e => e.Studentid).HasColumnName("studentid");

            entity.HasOne(d => d.Student).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("rating_studentid_fkey");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_pkey");

            entity.ToTable("schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datelessons)
                .HasMaxLength(255)
                .HasColumnName("datelessons");
            entity.Property(e => e.Groupstudentid).HasColumnName("groupstudentid");
            entity.Property(e => e.Lessonsid).HasColumnName("lessonsid");
            entity.Property(e => e.Timelessonsid).HasColumnName("timelessonsid");
            entity.Property(e => e.Tutorid).HasColumnName("tutorid");

            entity.HasOne(d => d.Groupstudent).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Groupstudentid)
                .HasConstraintName("schedule_groupstudentid_fkey");

            entity.HasOne(d => d.Lessons).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Lessonsid)
                .HasConstraintName("schedule_lessonsid_fkey");

            entity.HasOne(d => d.Timelessons).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Timelessonsid)
                .HasConstraintName("schedule_timelessonsid_fkey");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Tutorid)
                .HasConstraintName("schedule_tutorid_fkey");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specialty_pkey");

            entity.ToTable("specialty");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Namespecialty)
                .HasMaxLength(255)
                .HasColumnName("namespecialty");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Namestudent)
                .HasMaxLength(255)
                .HasColumnName("namestudent");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("student_groupid_fkey");
        });

        modelBuilder.Entity<Teg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tegs_pkey");

            entity.ToTable("tegs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activityid).HasColumnName("activityid");
            entity.Property(e => e.Nameteg)
                .HasMaxLength(255)
                .HasColumnName("nameteg");

            entity.HasOne(d => d.Activity).WithMany(p => p.Tegs)
                .HasForeignKey(d => d.Activityid)
                .HasConstraintName("tegs_activityid_fkey");
        });

        modelBuilder.Entity<Timelesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("timelessons_pkey");

            entity.ToTable("timelessons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Endlessons).HasColumnName("endlessons");
            entity.Property(e => e.Numberlessons).HasColumnName("numberlessons");
            entity.Property(e => e.Startlessons).HasColumnName("startlessons");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tutor_pkey");

            entity.ToTable("tutor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nametutor)
                .HasMaxLength(255)
                .HasColumnName("nametutor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
