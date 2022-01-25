// <auto-generated>

using Generator.Tests.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EFCore6.Multi_context_single_filesCherry
{
    #region Database context interface

    public interface ICherryDbContext : IDisposable
    {
        DbSet<ColumnNameAndType> ColumnNameAndTypes { get; set; } // ColumnNameAndTypes

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        EntityEntry Add(object entity);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);

        EntityEntry Attach(object entity);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        void AttachRange(IEnumerable<object> entities);
        void AttachRange(params object[] entities);

        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);
        object Find(Type entityType, params object[] keyValues);

        EntityEntry Remove(object entity);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        void RemoveRange(params object[] entities);

        EntityEntry Update(object entity);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange(IEnumerable<object> entities);
        void UpdateRange(params object[] entities);

        IQueryable<TResult> FromExpression<TResult> (Expression<Func<IQueryable<TResult>>> expression);
    }

    #endregion

    #region Database context

    public class CherryDbContext : DbContext, ICherryDbContext
    {
        public CherryDbContext()
        {
        }

        public CherryDbContext(DbContextOptions<CherryDbContext> options)
            : base(options)
        {
        }

        public DbSet<ColumnNameAndType> ColumnNameAndTypes { get; set; } // ColumnNameAndTypes

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasSequence<int>("CountBy1", "dbo").StartsAt(1).IncrementsBy(1).IsCyclic(false);
            modelBuilder.HasSequence<long>("CountByBigInt", "dbo").StartsAt(22).IncrementsBy(234).IsCyclic(true).HasMin(1).HasMax(9876543);
            modelBuilder.HasSequence<decimal>("CountByDecimal", "dbo").StartsAt(593).IncrementsBy(82).IsCyclic(false).HasMin(5).HasMax(777777);
            modelBuilder.HasSequence<decimal>("CountByNumeric", "dbo").StartsAt(789).IncrementsBy(987).IsCyclic(false).HasMin(345).HasMax(999999999999999999);
            modelBuilder.HasSequence<short>("CountBySmallInt", "dbo").StartsAt(44).IncrementsBy(456).IsCyclic(true);
            modelBuilder.HasSequence<byte>("CountByTinyInt", "dbo").StartsAt(33).IncrementsBy(3).IsCyclic(false);

            modelBuilder.ApplyConfiguration(new ColumnNameAndTypeConfiguration());
        }

    }

    #endregion

    #region Database context factory

    public class CherryDbContextFactory : IDesignTimeDbContextFactory<CherryDbContext>
    {
        public CherryDbContext CreateDbContext(string[] args)
        {
            return new CherryDbContext();
        }
    }

    #endregion

    #region POCO classes

    // ColumnNameAndTypes
    /// <summary>
    /// This is to document the bring the action table
    /// This is to document the
    /// table with poor column name choices
    /// </summary>
    public class ColumnNameAndType
    {
        [ExampleForTesting("abc")]
        [CustomRequired]
        public int Dollar { get; set; } // $ (Primary key)

        [ExampleForTesting("def")]
        [CustomSecurity(SecurityEnum.Readonly)]
        public int? Pound { get; set; } // £
        public int? StaticField { get; set; } // static
        public int? Day { get; set; } // readonly
    }


    #endregion

    #region POCO Configuration

    // ColumnNameAndTypes
    public class ColumnNameAndTypeConfiguration : IEntityTypeConfiguration<ColumnNameAndType>
    {
        public void Configure(EntityTypeBuilder<ColumnNameAndType> builder)
        {
            builder.ToTable("ColumnNameAndTypes", "dbo");
            builder.HasKey(x => x.Dollar).HasName("PK__ColumnNa__3BD018490C636E25").IsClustered();

            builder.Property(x => x.Dollar).HasColumnName(@"$").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Pound).HasColumnName(@"£").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.StaticField).HasColumnName(@"static").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Day).HasColumnName(@"readonly").HasColumnType("int").IsRequired(false);
        }
    }


    #endregion

}
// </auto-generated>