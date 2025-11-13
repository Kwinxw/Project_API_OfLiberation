using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class SqlContext : DbContext
{
    public SqlContext()
    {
    }

    public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Группы> Группыs { get; set; }

    public virtual DbSet<Задания> Заданияs { get; set; }

    public virtual DbSet<Нагрузка> Нагрузкаs { get; set; }

    public virtual DbSet<Освобождения> Освобожденияs { get; set; }

    public virtual DbSet<Отделения> Отделенияs { get; set; }

    public virtual DbSet<Оценки> Оценкиs { get; set; }

    public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

    public virtual DbSet<ПричиныОсвобождения> ПричиныОсвобожденияs { get; set; }

    public virtual DbSet<Специальности> Специальностиs { get; set; }

    public virtual DbSet<Студенты> Студентыs { get; set; }

    public virtual DbSet<ТипыЗаданий> ТипыЗаданийs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Группы>(entity =>
        {
            entity.HasKey(e => e.IdГруппы).HasName("PK__Группы__7EC7037D9B754A1C");

            entity.ToTable("Группы");

            entity.HasIndex(e => e.Название, "UQ__Группы__38DA8035B4795D03").IsUnique();

            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.IdСпециальности).HasColumnName("ID_специальности");
            entity.Property(e => e.ГодПоступления).HasColumnName("Год_поступления");
            entity.Property(e => e.Название).HasMaxLength(20);

            entity.HasOne(d => d.IdСпециальностиNavigation).WithMany(p => p.Группыs)
                .HasForeignKey(d => d.IdСпециальности)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Группы__ID_специ__412EB0B6");
        });

        modelBuilder.Entity<Задания>(entity =>
        {
            entity.HasKey(e => e.IdЗадания).HasName("PK__Задания__D3DD242A3E9D8E9C");

            entity.ToTable("Задания");

            entity.Property(e => e.IdЗадания).HasColumnName("ID_задания");
            entity.Property(e => e.IdОсвобождения).HasColumnName("ID_освобождения");
            entity.Property(e => e.IdТипаЗадания).HasColumnName("ID_типа_задания");
            entity.Property(e => e.ДатаНазначения).HasColumnName("Дата_назначения");
            entity.Property(e => e.Описание).HasMaxLength(500);
            entity.Property(e => e.СрокСдачи).HasColumnName("Срок_сдачи");
            entity.Property(e => e.Тема).HasMaxLength(200);

            entity.HasOne(d => d.IdОсвобожденияNavigation).WithMany(p => p.Заданияs)
                .HasForeignKey(d => d.IdОсвобождения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Задания__ID_осво__571DF1D5");

            entity.HasOne(d => d.IdТипаЗаданияNavigation).WithMany(p => p.Заданияs)
                .HasForeignKey(d => d.IdТипаЗадания)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Задания__ID_типа__5812160E");
        });

        modelBuilder.Entity<Нагрузка>(entity =>
        {
            entity.HasKey(e => e.IdНагрузки).HasName("PK__Нагрузка__5784711A82DFB935");

            entity.ToTable("Нагрузка");

            entity.HasIndex(e => new { e.IdПреподавателя, e.IdГруппы, e.Семестр, e.УчебныйГод }, "UQ__Нагрузка__036905DA55B07A86").IsUnique();

            entity.Property(e => e.IdНагрузки).HasColumnName("ID_нагрузки");
            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.IdПреподавателя).HasColumnName("ID_преподавателя");
            entity.Property(e => e.УчебныйГод).HasColumnName("Учебный_год");

            entity.HasOne(d => d.IdГруппыNavigation).WithMany(p => p.Нагрузкаs)
                .HasForeignKey(d => d.IdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Нагрузка__ID_гру__6754599E");

            entity.HasOne(d => d.IdПреподавателяNavigation).WithMany(p => p.Нагрузкаs)
                .HasForeignKey(d => d.IdПреподавателя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Нагрузка__ID_пре__66603565");
        });

        modelBuilder.Entity<Освобождения>(entity =>
        {
            entity.HasKey(e => e.IdОсвобождения).HasName("PK__Освобожд__6A05CE556E5CD89C");

            entity.ToTable("Освобождения");

            entity.Property(e => e.IdОсвобождения).HasColumnName("ID_освобождения");
            entity.Property(e => e.IdПричины).HasColumnName("ID_причины");
            entity.Property(e => e.IdСтудента).HasColumnName("ID_студента");
            entity.Property(e => e.ДатаНачала).HasColumnName("Дата_начала");
            entity.Property(e => e.ДатаОкончания).HasColumnName("Дата_окончания");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.КемВыдано)
                .HasMaxLength(100)
                .HasColumnName("Кем_выдано");
            entity.Property(e => e.НомерСправки)
                .HasMaxLength(50)
                .HasColumnName("Номер_справки");
            entity.Property(e => e.Примечание).HasMaxLength(500);

            entity.HasOne(d => d.IdПричиныNavigation).WithMany(p => p.Освобожденияs)
                .HasForeignKey(d => d.IdПричины)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Освобожде__ID_пр__4E88ABD4");

            entity.HasOne(d => d.IdСтудентаNavigation).WithMany(p => p.Освобожденияs)
                .HasForeignKey(d => d.IdСтудента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Освобожде__ID_ст__4D94879B");
        });

        modelBuilder.Entity<Отделения>(entity =>
        {
            entity.HasKey(e => e.IdОтделения).HasName("PK__Отделени__A935EBC47FF3FA16");

            entity.ToTable("Отделения");

            entity.HasIndex(e => e.Название, "UQ__Отделени__38DA8035BF01208B").IsUnique();

            entity.Property(e => e.IdОтделения).HasColumnName("ID_отделения");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.Заведующий).HasMaxLength(100);
            entity.Property(e => e.Название).HasMaxLength(100);
        });

        modelBuilder.Entity<Оценки>(entity =>
        {
            entity.HasKey(e => e.IdОценки).HasName("PK__Оценки__7491505F506D2039");

            entity.ToTable("Оценки");

            entity.HasIndex(e => e.IdЗадания, "UQ__Оценки__D3DD242B0C03EA45").IsUnique();

            entity.Property(e => e.IdОценки).HasColumnName("ID_оценки");
            entity.Property(e => e.IdЗадания).HasColumnName("ID_задания");
            entity.Property(e => e.ДатаОценки)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Дата_оценки");
            entity.Property(e => e.ДатаСдачи).HasColumnName("Дата_сдачи");
            entity.Property(e => e.Комментарий).HasMaxLength(500);
            entity.Property(e => e.Преподаватель).HasMaxLength(100);

            entity.HasOne(d => d.IdЗаданияNavigation).WithOne(p => p.Оценки)
                .HasForeignKey<Оценки>(d => d.IdЗадания)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Оценки__ID_задан__5EBF139D");
        });

        modelBuilder.Entity<Преподаватели>(entity =>
        {
            entity.HasKey(e => e.IdПреподавателя).HasName("PK__Преподав__5C1E636A9010CB9A");

            entity.ToTable("Преподаватели");

            entity.Property(e => e.IdПреподавателя).HasColumnName("ID_преподавателя");
            entity.Property(e => e.Должность).HasMaxLength(100);
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.Отчество).HasMaxLength(50);
            entity.Property(e => e.Ставка)
                .HasDefaultValueSql("((1.0))")
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Фамилия).HasMaxLength(50);
        });

        modelBuilder.Entity<ПричиныОсвобождения>(entity =>
        {
            entity.HasKey(e => e.IdПричины).HasName("PK__ПричиныО__518A6CA02682A811");

            entity.ToTable("Причины_Освобождения");

            entity.HasIndex(e => e.КодПричины, "UQ__ПричиныО__0DE9769C97695664").IsUnique();

            entity.Property(e => e.IdПричины).HasColumnName("ID_причины");
            entity.Property(e => e.КодПричины)
                .HasMaxLength(10)
                .HasColumnName("Код_причины");
            entity.Property(e => e.МаксДней).HasColumnName("Макс_дней");
            entity.Property(e => e.Название).HasMaxLength(100);
            entity.Property(e => e.ТребуетСправку)
                .HasDefaultValue(false)
                .HasColumnName("Требует_справку");
        });

        modelBuilder.Entity<Специальности>(entity =>
        {
            entity.HasKey(e => e.IdСпециальности).HasName("PK__Специаль__AB8BFED36633350D");

            entity.ToTable("Специальности");

            entity.HasIndex(e => e.КодСпециальности, "UQ__Специаль__042110197325F23D").IsUnique();

            entity.Property(e => e.IdСпециальности).HasColumnName("ID_специальности");
            entity.Property(e => e.IdОтделения).HasColumnName("ID_отделения");
            entity.Property(e => e.КодСпециальности)
                .HasMaxLength(10)
                .HasColumnName("Код_специальности");
            entity.Property(e => e.Название).HasMaxLength(150);

            entity.HasOne(d => d.IdОтделенияNavigation).WithMany(p => p.Специальностиs)
                .HasForeignKey(d => d.IdОтделения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Специальн__ID_от__3C69FB99");
        });

        modelBuilder.Entity<Студенты>(entity =>
        {
            entity.HasKey(e => e.IdСтудента).HasName("PK__Студенты__520B7B76874D27D1");

            entity.ToTable("Студенты");

            entity.HasIndex(e => e.НомерЗачетки, "UQ__Студенты__93450139A08F91DC").IsUnique();

            entity.Property(e => e.IdСтудента).HasColumnName("ID_студента");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.ДатаРегистрации)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Дата_регистрации");
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.НомерЗачетки)
                .HasMaxLength(20)
                .HasColumnName("Номер_зачетки");
            entity.Property(e => e.Отчество).HasMaxLength(50);
            entity.Property(e => e.Телефон).HasMaxLength(15);
            entity.Property(e => e.Фамилия).HasMaxLength(50);

            entity.HasOne(d => d.IdГруппыNavigation).WithMany(p => p.Студентыs)
                .HasForeignKey(d => d.IdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Студенты__ID_гру__45F365D3");
        });

        modelBuilder.Entity<ТипыЗаданий>(entity =>
        {
            entity.HasKey(e => e.IdТипаЗадания).HasName("PK__ТипыЗада__AA5324F39E0A8232");

            entity.ToTable("Типы_Заданий");

            entity.HasIndex(e => e.КодЗадания, "UQ__ТипыЗада__C9CDA979A6907137").IsUnique();

            entity.Property(e => e.IdТипаЗадания).HasColumnName("ID_типа_задания");
            entity.Property(e => e.КодЗадания)
                .HasMaxLength(10)
                .HasColumnName("Код_задания");
            entity.Property(e => e.МаксБалл)
                .HasDefaultValue(5)
                .HasColumnName("Макс_балл");
            entity.Property(e => e.Название).HasMaxLength(100);
            entity.Property(e => e.Описание).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
