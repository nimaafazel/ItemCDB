namespace ItemCDBMigrations.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ICContext : DbContext
    {
        public ICContext()
            : base("name=ICContextConnection")
        {
        }

        public virtual DbSet<tblBargainUnit> tblBargainUnits { get; set; }
        public virtual DbSet<tblBud> tblBuds { get; set; }
        public virtual DbSet<tblBudItemNum> tblBudItemNums { get; set; }
        public virtual DbSet<tblDivision> tblDivisions { get; set; }
        public virtual DbSet<tblEMPLOYEELIST> tblEMPLOYEELISTs { get; set; }
        public virtual DbSet<tblEmploymentType> tblEmploymentTypes { get; set; }
        public virtual DbSet<tblEmplStatu> tblEmplStatus { get; set; }
        public virtual DbSet<tblEthnicity> tblEthnicities { get; set; }
        public virtual DbSet<tblFilled> tblFilleds { get; set; }
        public virtual DbSet<tblFunction> tblFunctions { get; set; }
        public virtual DbSet<tblGender> tblGenders { get; set; }
        public virtual DbSet<tblOrd> tblOrds { get; set; }
        public virtual DbSet<tblOrgCode> tblOrgCodes { get; set; }
        public virtual DbSet<tblPayLocation> tblPayLocations { get; set; }
        public virtual DbSet<tblPayPeriod> tblPayPeriods { get; set; }
        public virtual DbSet<tblPERating> tblPERatings { get; set; }
        public virtual DbSet<tblPEStatu> tblPEStatus { get; set; }
        public virtual DbSet<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }
        public virtual DbSet<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
        public virtual DbSet<tblSection> tblSections { get; set; }
        public virtual DbSet<tblStep> tblSteps { get; set; }
        public virtual DbSet<tblSubItem> tblSubItems { get; set; }
        public virtual DbSet<tblUnit> tblUnits { get; set; }
        public virtual DbSet<tblVacant> tblVacants { get; set; }
        public virtual DbSet<tblEmplPEStatu> tblEmplPEStatus { get; set; }
        public virtual DbSet<tblEmplPEType> tblEmplPETypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBargainUnit>()
                .HasMany(e => e.tblBudItemNums)
                .WithOptional(e => e.tblBargainUnit)
                .HasForeignKey(e => e.BudBargainUnit);

            modelBuilder.Entity<tblBud>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblBud)
                .HasForeignKey(e => e.BudBud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblBudItemNum>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblBudItemNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblDivision>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblDivision)
                .HasForeignKey(e => e.BudDivCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEMPLOYEELIST>()
                .Property(e => e.SeniorityDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblEMPLOYEELIST>()
                .Property(e => e.BirthDate)
                .HasPrecision(0);

            //modelBuilder.Entity<tblEMPLOYEELIST>()
            //    .Property(e => e.SSMA_TimeStamp)
            //    .IsFixedLength();

            modelBuilder.Entity<tblEmploymentType>()
                .HasMany(e => e.tblPOSITIONACTUALs)
                .WithRequired(e => e.tblEmploymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEmplStatu>()
                .HasMany(e => e.tblEMPLOYEELISTs)
                .WithRequired(e => e.tblEmplStatu)
                .HasForeignKey(e => e.EmplStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEthnicity>()
                .HasMany(e => e.tblEMPLOYEELISTs)
                .WithOptional(e => e.tblEthnicity)
                .HasForeignKey(e => e.Ethnicity);

            modelBuilder.Entity<tblFilled>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblFilled)
                .HasForeignKey(e => e.BudFilled)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblFunction>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblFunction)
                .HasForeignKey(e => e.BudFunction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblGender>()
                .HasMany(e => e.tblEMPLOYEELISTs)
                .WithOptional(e => e.tblGender)
                .HasForeignKey(e => e.Gender);

            modelBuilder.Entity<tblOrd>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblOrd)
                .HasForeignKey(e => e.BudOrd)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPayLocation>()
                .HasMany(e => e.tblEMPLOYEELISTs)
                .WithOptional(e => e.tblPayLocation)
                .HasForeignKey(e => e.PayLoc);

            modelBuilder.Entity<tblPayPeriod>()
                .HasMany(e => e.tblPOSITIONACTUALs)
                .WithOptional(e => e.tblPayPeriod)
                .HasForeignKey(e => e.PayPeriod);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.DueDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.RatingFromDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.RatingToDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.ApprovedByDivChiefDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.ApprovedBySecHeadDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.ApprovedByEmployeeDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.HRCompletedDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.PECreationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.PELastChangedDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPEStatu>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<tblPOSITIONACTUAL>()
                .Property(e => e.EffectiveDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPOSITIONACTUAL>()
                .Property(e => e.DeptHireDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblPOSITIONACTUAL>()
                .Property(e => e.PayRate)
                .HasPrecision(19, 4);

            //modelBuilder.Entity<tblPOSITIONACTUAL>()
            //    .Property(e => e.SSMA_TimeStamp)
            //    .IsFixedLength();

            //modelBuilder.Entity<tblPOSITIONBUDGETED>()
            //    .Property(e => e.SSMA_TimeStamp)
            //    .IsFixedLength();

            modelBuilder.Entity<tblPOSITIONBUDGETED>()
                .HasMany(e => e.tblPOSITIONACTUALs)
                .WithRequired(e => e.tblPOSITIONBUDGETED)
                .HasForeignKey(e => e.ActPosNum);

            modelBuilder.Entity<tblSection>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblSection)
                .HasForeignKey(e => e.BudSecCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSubItem>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblSubItem)
                .HasForeignKey(e => e.BudSubItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUnit>()
                .HasMany(e => e.tblPOSITIONBUDGETEDs)
                .WithRequired(e => e.tblUnit)
                .HasForeignKey(e => e.BudUnitCode)
                .WillCascadeOnDelete(false);
        }
    }
}
