using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Багаж> Багажs { get; set; }

    public virtual DbSet<Билет> Билетs { get; set; }

    public virtual DbSet<Бортпроводник> Бортпроводникs { get; set; }

    public virtual DbSet<Грузчик> Грузчикs { get; set; }

    public virtual DbSet<Диспечер> Диспечерs { get; set; }

    public virtual DbSet<ИнженерМеханик> ИнженерМеханикs { get; set; }

    public virtual DbSet<Командир> Командирs { get; set; }

    public virtual DbSet<Охрана> Охранаs { get; set; }

    public virtual DbSet<Паспорт> Паспортs { get; set; }

    public virtual DbSet<Пассажир> Пассажирs { get; set; }

    public virtual DbSet<Пилот> Пилотs { get; set; }

    public virtual DbSet<Пограничник> Пограничникs { get; set; }

    public virtual DbSet<РаботникАэропорта> РаботникАэропортаs { get; set; }

    public virtual DbSet<Рассписание> Рассписаниеs { get; set; }

    public virtual DbSet<РучнаяКладь> РучнаяКладьs { get; set; }

    public virtual DbSet<Самолёт> Самолётs { get; set; }

    public virtual DbSet<ТалонБагажа> ТалонБагажаs { get; set; }

    public virtual DbSet<Таможенник> Таможенникs { get; set; }

    public virtual DbSet<Экипаж> Экипажs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DP6O776;Database=Система_аэропорта;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Багаж>(entity =>
        {
            entity.HasKey(e => new { e.КодТалонаБагажа, e.КодГрузчика, e.КодТаможенника }).HasName("Unique_Identifier11");

            entity.ToTable("Багаж");

            entity.Property(e => e.КодТалонаБагажа).HasColumnName("Код_талона_багажа");
            entity.Property(e => e.КодГрузчика).HasColumnName("Код_грузчика");
            entity.Property(e => e.КодТаможенника).HasColumnName("Код_таможенника");
            entity.Property(e => e.ВесБагажаКг).HasColumnName("Вес_багажа(кг)");
            entity.Property(e => e.ДлинаСм).HasColumnName("Длина(см)");
            entity.Property(e => e.ШиринаСм).HasColumnName("Ширина(см)");

            entity.HasOne(d => d.КодГрузчикаNavigation).WithMany(p => p.Багажs)
                .HasForeignKey(d => d.КодГрузчика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R16");

            entity.HasOne(d => d.КодТалонаБагажаNavigation).WithMany(p => p.Багажs)
                .HasForeignKey(d => d.КодТалонаБагажа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R10");

            entity.HasOne(d => d.КодТаможенникаNavigation).WithMany(p => p.Багажs)
                .HasForeignKey(d => d.КодТаможенника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R19");
        });

        modelBuilder.Entity<Билет>(entity =>
        {
            entity.HasKey(e => e.КодБилета).HasName("Unique_Identifier3");

            entity.ToTable("Билет");

            entity.HasIndex(e => e.КодПассажира, "IX_R13");

            entity.HasIndex(e => e.КодОхранника, "IX_R21");

            entity.HasIndex(e => e.КодПограничника, "IX_R23");

            entity.Property(e => e.КодБилета)
                .ValueGeneratedNever()
                .HasColumnName("Код_билета");
            entity.Property(e => e.ВремяВылета).HasColumnName("Время_вылета");
            entity.Property(e => e.ВремяОкончанияПосадки).HasColumnName("Время_окончания_посадки");
            entity.Property(e => e.ВремяПрилёта).HasColumnName("Время_прилёта");
            entity.Property(e => e.ВрмеяВПути).HasColumnName("Врмея_в_пути");
            entity.Property(e => e.ДатаВылета).HasColumnName("Дата_вылета");
            entity.Property(e => e.ДатаПрилёта).HasColumnName("Дата_прилёта");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодОхранника).HasColumnName("Код_охранника");
            entity.Property(e => e.КодПассажира).HasColumnName("Код_пассажира");
            entity.Property(e => e.КодПограничника).HasColumnName("Код_пограничника");
            entity.Property(e => e.КолВоБагажа).HasColumnName("Кол-во_багажа");
            entity.Property(e => e.МестоОтправления)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Место_отправления");
            entity.Property(e => e.МестоПрилёта)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Место_прилёта");
            entity.Property(e => e.НазваниеАвиокомпании)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Название_авиокомпании");
            entity.Property(e => e.НомерМеста).HasColumnName("Номер_места");
            entity.Property(e => e.НомерРейса).HasColumnName("Номер_рейса");
            entity.Property(e => e.НомерРяда).HasColumnName("Номер_ряда");
            entity.Property(e => e.Тариф)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодОхранникаNavigation).WithMany(p => p.Билетs)
                .HasForeignKey(d => d.КодОхранника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R21");

            entity.HasOne(d => d.КодПассажираNavigation).WithMany(p => p.Билетs)
                .HasForeignKey(d => d.КодПассажира)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R13");

            entity.HasOne(d => d.КодПограничникаNavigation).WithMany(p => p.Билетs)
                .HasForeignKey(d => d.КодПограничника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R23");
        });

        modelBuilder.Entity<Бортпроводник>(entity =>
        {
            entity.HasKey(e => new { e.КодБортпроводника, e.КодКомандира, e.КодПилота, e.Attribute1 }).HasName("Unique_Identifier8");

            entity.ToTable("Бортпроводник");

            entity.HasIndex(e => e.КодПассажира, "IX_R15");

            entity.Property(e => e.КодБортпроводника).HasColumnName("Код_бортпроводника");
            entity.Property(e => e.КодКомандира).HasColumnName("Код_командира");
            entity.Property(e => e.КодПилота).HasColumnName("Код_пилота");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодПассажира).HasColumnName("Код_пассажира");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодПассажираNavigation).WithMany(p => p.Бортпроводникs)
                .HasForeignKey(d => d.КодПассажира)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R15");

            entity.HasOne(d => d.Экипаж).WithMany(p => p.Бортпроводникs)
                .HasForeignKey(d => new { d.КодКомандира, d.КодПилота, d.Attribute1 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R3");
        });

        modelBuilder.Entity<Грузчик>(entity =>
        {
            entity.HasKey(e => e.КодГрузчика).HasName("Unique_Identifier17");

            entity.ToTable("Грузчик");

            entity.HasIndex(e => e.КодРаботника, "IX_R6");

            entity.Property(e => e.КодГрузчика)
                .ValueGeneratedNever()
                .HasColumnName("Код_грузчика");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.ОтчествоОтчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.Грузчикs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R6");
        });

        modelBuilder.Entity<Диспечер>(entity =>
        {
            entity.HasKey(e => e.КодДиспечера).HasName("Unique_Identifier13");

            entity.ToTable("Диспечер");

            entity.HasIndex(e => e.КодРаботника, "IX_R4");

            entity.Property(e => e.КодДиспечера)
                .ValueGeneratedNever()
                .HasColumnName("Код_диспечера");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.Диспечерs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R4");
        });

        modelBuilder.Entity<ИнженерМеханик>(entity =>
        {
            entity.HasKey(e => e.КодИнженерМеханика).HasName("Unique_Identifier18");

            entity.ToTable("Инженер-механик");

            entity.HasIndex(e => e.КодРаботника, "IX_R7");

            entity.Property(e => e.КодИнженерМеханика)
                .ValueGeneratedNever()
                .HasColumnName("Код_инженер-механика");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.ИнженерМеханикs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R7");
        });

        modelBuilder.Entity<Командир>(entity =>
        {
            entity.HasKey(e => e.КодКомандира).HasName("Unique_Identifier6");

            entity.ToTable("Командир");

            entity.HasIndex(e => e.КодДиспечера, "IX_Информирует");

            entity.Property(e => e.КодКомандира)
                .ValueGeneratedNever()
                .HasColumnName("Код_командира");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодДиспечера).HasColumnName("Код_диспечера");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодДиспечераNavigation).WithMany(p => p.Командирs)
                .HasForeignKey(d => d.КодДиспечера)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Информирует");
        });

        modelBuilder.Entity<Охрана>(entity =>
        {
            entity.HasKey(e => e.КодОхранника).HasName("Unique_Identifier14");

            entity.ToTable("Охрана");

            entity.HasIndex(e => e.КодРаботника, "IX_R9");

            entity.Property(e => e.КодОхранника)
                .ValueGeneratedNever()
                .HasColumnName("Код_охранника");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.Охранаs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R9");
        });

        modelBuilder.Entity<Паспорт>(entity =>
        {
            entity.HasKey(e => e.СерияНомер).HasName("Unique_Identifier9");

            entity.ToTable("Паспорт");

            entity.HasIndex(e => e.КодПассажира, "IX_R14");

            entity.HasIndex(e => e.КодОхранника, "IX_R20");

            entity.HasIndex(e => e.КодПограничника, "IX_R22");

            entity.Property(e => e.СерияНомер)
                .ValueGeneratedNever()
                .HasColumnName("Серия_номер");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КемВыдан)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Кем_выдан");
            entity.Property(e => e.КодОхранника).HasColumnName("Код_охранника");
            entity.Property(e => e.КодПассажира).HasColumnName("Код_пассажира");
            entity.Property(e => e.КодПограничника).HasColumnName("Код_пограничника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодОхранникаNavigation).WithMany(p => p.Паспортs)
                .HasForeignKey(d => d.КодОхранника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R20");

            entity.HasOne(d => d.КодПассажираNavigation).WithMany(p => p.Паспортs)
                .HasForeignKey(d => d.КодПассажира)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R14");

            entity.HasOne(d => d.КодПограничникаNavigation).WithMany(p => p.Паспортs)
                .HasForeignKey(d => d.КодПограничника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R22");
        });

        modelBuilder.Entity<Пассажир>(entity =>
        {
            entity.HasKey(e => e.КодПассажира).HasName("Unique_Identifier2");

            entity.ToTable("Пассажир");

            entity.HasIndex(e => new { e.КодСамолёта, e.КодКомандира, e.КодПилота, e.Attribute1 }, "IX_Перевозит");

            entity.Property(e => e.КодПассажира)
                .ValueGeneratedNever()
                .HasColumnName("Код_пассажира");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата_рождения");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Категория)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодКомандира).HasColumnName("Код_командира");
            entity.Property(e => e.КодПилота).HasColumnName("Код_пилота");
            entity.Property(e => e.КодСамолёта).HasColumnName("Код_самолёта");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Пол)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Самолёт).WithMany(p => p.Пассажирs)
                .HasForeignKey(d => new { d.КодСамолёта, d.КодКомандира, d.КодПилота, d.Attribute1 })
                .HasConstraintName("Перевозит");
        });

        modelBuilder.Entity<Пилот>(entity =>
        {
            entity.HasKey(e => e.КодПилота).HasName("Unique_Identifier7");

            entity.ToTable("Пилот");

            entity.Property(e => e.КодПилота)
                .ValueGeneratedNever()
                .HasColumnName("Код_пилота");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Пограничник>(entity =>
        {
            entity.HasKey(e => e.КодПограничника).HasName("Unique_Identifier16");

            entity.ToTable("Пограничник");

            entity.HasIndex(e => e.КодРаботника, "IX_R8");

            entity.Property(e => e.КодПограничника)
                .ValueGeneratedNever()
                .HasColumnName("Код_пограничника");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.Пограничникs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R8");
        });

        modelBuilder.Entity<РаботникАэропорта>(entity =>
        {
            entity.HasKey(e => e.КодРаботника).HasName("Unique_Identifier4");

            entity.ToTable("Работник_аэропорта");

            entity.Property(e => e.КодРаботника)
                .ValueGeneratedNever()
                .HasColumnName("Код_работника");
            entity.Property(e => e.КолВоОтработаныхЧасов).HasColumnName("Кол-во_отработаных_часов");
            entity.Property(e => e.ПочасоваяОплата).HasColumnName("Почасовая_оплата");
        });

        modelBuilder.Entity<Рассписание>(entity =>
        {
            entity.HasKey(e => new { e.КодСамолёта, e.КодКомандира, e.КодПилота, e.Attribute1 }).HasName("Unique_Identifier1");

            entity.ToTable("Рассписание");

            entity.Property(e => e.КодСамолёта).HasColumnName("Код_самолёта");
            entity.Property(e => e.КодКомандира).HasColumnName("Код_командира");
            entity.Property(e => e.КодПилота).HasColumnName("Код_пилота");

            entity.HasOne(d => d.Самолёт).WithOne(p => p.Рассписание)
                .HasForeignKey<Рассписание>(d => new { d.КодСамолёта, d.КодКомандира, d.КодПилота, d.Attribute1 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R25");
        });

        modelBuilder.Entity<РучнаяКладь>(entity =>
        {
            entity.HasKey(e => new { e.КодТалонаБагажа, e.КодТаможенника }).HasName("Unique_Identifier12");

            entity.ToTable("Ручная_кладь");

            entity.Property(e => e.КодТалонаБагажа).HasColumnName("Код_талона_багажа");
            entity.Property(e => e.КодТаможенника).HasColumnName("Код_таможенника");
            entity.Property(e => e.ВесБагажа).HasColumnName("Вес_багажа");
            entity.Property(e => e.ВысотаСм).HasColumnName("Высота(см)");
            entity.Property(e => e.ДлинаСм).HasColumnName("Длина(см)");
            entity.Property(e => e.ШиринаСм).HasColumnName("Ширина(см)");

            entity.HasOne(d => d.КодТалонаБагажаNavigation).WithMany(p => p.РучнаяКладьs)
                .HasForeignKey(d => d.КодТалонаБагажа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R11");

            entity.HasOne(d => d.КодТаможенникаNavigation).WithMany(p => p.РучнаяКладьs)
                .HasForeignKey(d => d.КодТаможенника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R18");
        });

        modelBuilder.Entity<Самолёт>(entity =>
        {
            entity.HasKey(e => new { e.КодСамолёта, e.КодКомандира, e.КодПилота, e.Attribute1 }).HasName("Unique_Identifier10");

            entity.ToTable("Самолёт");

            entity.HasIndex(e => e.КодИнженерМеханика, "IX_R17");

            entity.Property(e => e.КодСамолёта).HasColumnName("Код_самолёта");
            entity.Property(e => e.КодКомандира).HasColumnName("Код_командира");
            entity.Property(e => e.КодПилота).HasColumnName("Код_пилота");
            entity.Property(e => e.ГрузоподъёмностьТ).HasColumnName("Грузоподъёмность(т)");
            entity.Property(e => e.КодИнженерМеханика).HasColumnName("Код_инженер-механика");
            entity.Property(e => e.КолВоМест).HasColumnName("Кол-во_мест");
            entity.Property(e => e.МодельСамолёта)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Модель_самолёта");
            entity.Property(e => e.НазваниеАвикомпании)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Название_авикомпании");
            entity.Property(e => e.ПродолжительностьПолёта).HasColumnName("Продолжительность_полёта");

            entity.HasOne(d => d.КодИнженерМеханикаNavigation).WithMany(p => p.Самолётs)
                .HasForeignKey(d => d.КодИнженерМеханика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R17");

            entity.HasOne(d => d.Экипаж).WithMany(p => p.Самолётs)
                .HasForeignKey(d => new { d.КодКомандира, d.КодПилота, d.Attribute1 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R12");
        });

        modelBuilder.Entity<ТалонБагажа>(entity =>
        {
            entity.HasKey(e => e.КодТалонаБагажа).HasName("Unique_Identifier19");

            entity.ToTable("Талон_багажа");

            entity.HasIndex(e => e.КодПассажира, "IX_R24");

            entity.Property(e => e.КодТалонаБагажа)
                .ValueGeneratedNever()
                .HasColumnName("Код_талона_багажа");
            entity.Property(e => e.ВесБагажаКг).HasColumnName("Вес_багажа(кг)");
            entity.Property(e => e.КодПассажира).HasColumnName("Код_пассажира");
            entity.Property(e => e.МестоПрилёта)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Место_прилёта");
            entity.Property(e => e.НомерМеста).HasColumnName("Номер_места");
            entity.Property(e => e.НомерРейса).HasColumnName("Номер_рейса");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодПассажираNavigation).WithMany(p => p.ТалонБагажаs)
                .HasForeignKey(d => d.КодПассажира)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R24");
        });

        modelBuilder.Entity<Таможенник>(entity =>
        {
            entity.HasKey(e => e.КодТаможенника).HasName("Unique_Identifier15");

            entity.ToTable("Таможенник");

            entity.HasIndex(e => e.КодРаботника, "IX_R5");

            entity.Property(e => e.КодТаможенника)
                .ValueGeneratedNever()
                .HasColumnName("Код_таможенника");
            entity.Property(e => e.Имя)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.КодРаботника).HasColumnName("Код_работника");
            entity.Property(e => e.Отчество)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.СтажРаботыЧ).HasColumnName("Стаж_работы(ч)");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.КодРаботникаNavigation).WithMany(p => p.Таможенникs)
                .HasForeignKey(d => d.КодРаботника)
                .HasConstraintName("R5");
        });

        modelBuilder.Entity<Экипаж>(entity =>
        {
            entity.HasKey(e => new { e.КодКомандира, e.КодПилота, e.КодЭкипажа }).HasName("Unique_Identifier5");

            entity.ToTable("Экипаж");

            entity.Property(e => e.КодКомандира).HasColumnName("Код_командира");
            entity.Property(e => e.КодПилота).HasColumnName("Код_пилота");
            entity.Property(e => e.КодЭкипажа).HasColumnName("Код_экипажа");
            entity.Property(e => e.КолВоНалётанныхЧасов).HasColumnName("Кол-во_налётанных_часов");
            entity.Property(e => e.ПочасоваяОплата).HasColumnName("Почасовая_оплата");

            entity.HasOne(d => d.КодКомандираNavigation).WithMany(p => p.Экипажs)
                .HasForeignKey(d => d.КодКомандира)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R1");

            entity.HasOne(d => d.КодПилотаNavigation).WithMany(p => p.Экипажs)
                .HasForeignKey(d => d.КодПилота)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
